using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    internal class GameLogicManager
    {
        // $G$ CSS-999 (-3) Bad data members names (should be in k_PascalCase and m_PascalCase).
        public const int k_amountOfItemsInSequence = 4;
        public const int k_maximumAnountOfGuesses = 10;
        public const int k_minumumAmountOfGuesses = 4;
        public const int k_amountOfOptionsForSequanceItems = 8;

        public List<Guess> m_guessList = new List<Guess>();
        // $G$ CSS-999 (-3) The data members should have access modifiers.
        private Random m_sequenceItemRandomizer = new Random();
        private char[] m_secretsequence = new char[k_amountOfItemsInSequence];
        public int MaxGuesses { get; set; }
        public int CurrentGuessCount { get; private set; }

        public class Guess
        {
            public char[] m_guess;
            public int Hits { get; set; }
            public int Misses { get; set; }

            public Guess(char[] i_guess)
            {
                m_guess = i_guess;
            }

        }

        public bool CheckWin()
        {
            bool isWin = (m_guessList.Last().Hits == k_amountOfItemsInSequence);

            return isWin;
        }

        public void SetSecretSequence(char[] i_sequenceItems)
        {
            m_secretsequence = i_sequenceItems;
        }

        public void SetUpNewGame()
        {
            CurrentGuessCount = 0;
            m_guessList.Clear();
        }

        public bool SequenceHasNoDuplicates(char[] i_input)
        {
            bool hasNoDuplicates = true;
            Dictionary<char, bool> existingCharsInSequence = new Dictionary<char, bool>();

            for (int i = 0; i < k_amountOfItemsInSequence; i++)
            {
                char currentLetterToCheck = char.ToUpper(i_input[i]);

                if (existingCharsInSequence.ContainsKey(currentLetterToCheck))
                {
                    hasNoDuplicates = false;
                    break;
                }
                else
                {
                    existingCharsInSequence[currentLetterToCheck] = true;
                }

            }

            return hasNoDuplicates;
        }

        public void CheckGuess(char[] i_guess)
        {
            int hits = 0;
            int misses = 0;
            Guess guess = new Guess(i_guess);

            CurrentGuessCount++;
            for (int inputIndex = 0; inputIndex < i_guess.Length; inputIndex++)
            {
                for (int SequenceIndex = 0; SequenceIndex < i_guess.Length; SequenceIndex++)
                {
                    if (i_guess[inputIndex].Equals(m_secretsequence[SequenceIndex]) == true)
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

        public bool CheckLoss()
        {
            bool didPlayerLose = MaxGuesses - 1 < CurrentGuessCount;

            return didPlayerLose;
        }

        public void GenerateSequence()
        {
            char[] sequence;

            do
            {
                sequence = createRandomSequence();
            }
            while (SequenceHasNoDuplicates(sequence) == false);

            m_secretsequence = sequence;
        }

        private char[] createRandomSequence()
        {
            // $G$ DSN-999 (-3) Sequence of elements should be represented as sequence of enum values and not as a string or char.
            char[] sequence = new char[k_amountOfItemsInSequence];

            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = (char)m_sequenceItemRandomizer.Next('A', 'I');
            }

            return sequence;
        }

    }
}
