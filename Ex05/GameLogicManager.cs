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
        public readonly List<Guess> r_GuessList = new List<Guess>();
        private readonly Random r_SequenceItemRandomizer = new Random();
        public eSequenceItem[] m_Secretsequence = new eSequenceItem[k_AmountOfItemsInSequence];
        public int MaxGuesses { get; set; }
        public int CurrentGuessCount { get; private set; }
        public enum eSequenceItem
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

        public class Guess
        {
            public eSequenceItem[] m_guess;
            public int Hits { get; set; }
            public int Misses { get; set; }

            public Guess(eSequenceItem[] i_Guess)
            {
                m_guess = i_Guess;
            }
        }

        public bool CheckWin()
        {
            return r_GuessList.Last().Hits == k_AmountOfItemsInSequence;
        }

        public void SetSecretSequence(eSequenceItem[] i_SequenceItems)
        {
            m_Secretsequence = i_SequenceItems;
        }

        public void SetUpNewGame()
        {
            CurrentGuessCount = 0;
            r_GuessList.Clear();
        }

        public bool SequenceHasNoDuplicates(eSequenceItem[] i_input)
        {
            bool hasNoDuplicates = true;
            HashSet<eSequenceItem> seen = new HashSet<eSequenceItem>();

            foreach (eSequenceItem item in i_input)
            {
                if (item == eSequenceItem.N)
                {
                    continue;
                }
                else if (seen.Contains(item))
                {
                    hasNoDuplicates = false;
                    break;
                }
                else
                {
                    seen.Add(item);
                }
            }

            return hasNoDuplicates;
        }

        public void CheckGuess(eSequenceItem[] i_Guess)
        {
            int hits = 0;
            int misses = 0;
            Guess guess = new Guess(i_Guess);

            CurrentGuessCount++;
            for (int inputIndex = 0; inputIndex < i_Guess.Length; inputIndex++)
            {
                for (int SequenceIndex = 0; SequenceIndex < i_Guess.Length; SequenceIndex++)
                {
                    if (i_Guess[inputIndex] == m_Secretsequence[SequenceIndex])
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
            r_GuessList.Add(guess);
        }

        public void GenerateSequence()
        {
            eSequenceItem[] sequence;

            do
            {
                sequence = createRandomSequence();
            }
            while (!SequenceHasNoDuplicates(sequence));
            m_Secretsequence = sequence;
        }

        private eSequenceItem[] createRandomSequence()
        {
            eSequenceItem[] sequence = new eSequenceItem[k_AmountOfItemsInSequence];

            for (int i = 0; i < sequence.Length; i++)
            {
                // Only use A-H (0-7)
                sequence[i] = (eSequenceItem)r_SequenceItemRandomizer.Next(0, 8);
            }

            return sequence;
        }
    }
}
