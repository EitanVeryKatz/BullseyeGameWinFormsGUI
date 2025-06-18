using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ex05
{
    internal class GameLogicManager
    {
        public const int k_AmountOfItemsInSequence = 4;
        public const int k_MaximumAnountOfGuesses = 10;
        public const int k_MinumumAmountOfGuesses = 4;
        public const int k_AmountOfOptionsForSequanceItems = 8;

        public enum SequenceItem
        {
            A = 0,
            B = 1,
            C = 2,
            D = 3,
            E = 4,
            F = 5,
            G = 6,
            H = 7,
            N = 8 // N is for empty button
        }

        public List<Guess> m_guessList = new List<Guess>();
            private Random m_sequenceItemRandomizer = new Random();
        public SequenceItem[] m_secretsequence = new SequenceItem[k_AmountOfItemsInSequence];
        public int MaxGuesses { get; set; }
        public int CurrentGuessCount { get; private set; }


        public class Guess
        {
            public SequenceItem[] m_guess;
            public int Hits { get; set; }
            public int Misses { get; set; }

            public Guess(SequenceItem[] i_guess)
            {
                m_guess = i_guess;
            }
        }

        public bool CheckWin()
        {
            bool isWin = (m_guessList.Last().Hits == k_AmountOfItemsInSequence);
            return isWin;
        }

        public void SetSecretSequence(SequenceItem[] i_sequenceItems)
        {
            m_secretsequence = i_sequenceItems;
        }

        public void SetUpNewGame()
        {
            CurrentGuessCount = 0;
            m_guessList.Clear();
        }

        public bool SequenceHasNoDuplicates(SequenceItem[] i_input)
        {
            bool isNotDuplicate = true;
            HashSet<SequenceItem> seen = new HashSet<SequenceItem>();
            foreach (SequenceItem item in i_input)
            {
                if (item == SequenceItem.N)
                {
                    continue; // Ignore empty slots
                }
                if (seen.Contains(item))
                {
                    isNotDuplicate = false; // Duplicate found
                }
                else
                {
                    seen.Add(item);
                }
            }
            return isNotDuplicate;
        }

        public void CheckGuess(SequenceItem[] i_guess)
        {
            int hits = 0;
            int misses = 0;
            Guess guess = new Guess(i_guess);

            CurrentGuessCount++;
            for (int inputIndex = 0; inputIndex < i_guess.Length; inputIndex++)
            {
                for (int SequenceIndex = 0; SequenceIndex < i_guess.Length; SequenceIndex++)
                {
                    if (i_guess[inputIndex] == m_secretsequence[SequenceIndex])
                    {
                        if (inputIndex == SequenceIndex)
                        {
                            hits++;
                        }
                        else
                        {
                            misses++;
                        }
                    }
                }
            }

            guess.Misses = misses;
            guess.Hits = hits;
            m_guessList.Add(guess);
        }

        public void GenerateSequence()
        {
            SequenceItem[] sequence;
            do
            {
                sequence = createRandomSequence();
            }
            while (!SequenceHasNoDuplicates(sequence));
            m_secretsequence = sequence;
        }

        private SequenceItem[] createRandomSequence()
        {
            SequenceItem[] sequence = new SequenceItem[k_AmountOfItemsInSequence];
            for (int i = 0; i < sequence.Length; i++)
            {
                // Only use A-H (0-7)
                sequence[i] = (SequenceItem)m_sequenceItemRandomizer.Next(0, 8);
            }
            return sequence;
        }
    }
}
