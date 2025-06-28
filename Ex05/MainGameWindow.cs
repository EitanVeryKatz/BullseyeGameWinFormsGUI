using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Ex05
{
    internal class MainGameWindow : Form
    {
        private readonly GameLogicManager r_LogicManager = new GameLogicManager();
        private readonly GameSetupWindow r_GameSetupWindow = new GameSetupWindow();
        private int r_NumberOfGuesses = 0;
        private readonly Dictionary<int, ButtonCollectionForSingleGuess> r_ButtonSetsForGuesses = new Dictionary<int, ButtonCollectionForSingleGuess>();
        private int m_CurrentGuessNumber = -1;
        private readonly Dictionary<Color, GameLogicManager.eSequenceItem> r_ColorsToSequanceItems = new Dictionary<Color, GameLogicManager.eSequenceItem>();
        private readonly Dictionary<GameLogicManager.eSequenceItem, Color> r_SetuanceItemsToColors = new Dictionary<GameLogicManager.eSequenceItem, Color>();
        
        private void startNextGuess()
        {
            m_CurrentGuessNumber++;
            enableChoiceButtonsForCurrentGuess();
        }

        public MainGameWindow()
        {
            Text = "Bul-Pgiah!";
            BackColor = Color.Beige;
            StartPosition = FormStartPosition.CenterScreen;
            r_GameSetupWindow.m_StartBtn.MouseClick += m_StartBtn_MouseClick;
            r_GameSetupWindow.ShowDialog();
            if (r_NumberOfGuesses == 0)
            {
                throw new Exception();
            }

            initializeComponents();
            setColorsForGame();
            r_LogicManager.GenerateSequence();
            startNextGuess();
        }

        private void setColorsForGame()
        {
            r_SetuanceItemsToColors[GameLogicManager.eSequenceItem.A] = Color.Gold;
            r_SetuanceItemsToColors[GameLogicManager.eSequenceItem.B] = Color.Red;
            r_SetuanceItemsToColors[GameLogicManager.eSequenceItem.C] = Color.Blue;
            r_SetuanceItemsToColors[GameLogicManager.eSequenceItem.D] = Color.Green;
            r_SetuanceItemsToColors[GameLogicManager.eSequenceItem.E] = Color.Magenta;
            r_SetuanceItemsToColors[GameLogicManager.eSequenceItem.F] = Color.DeepSkyBlue;
            r_SetuanceItemsToColors[GameLogicManager.eSequenceItem.G] = Color.DarkGray;
            r_SetuanceItemsToColors[GameLogicManager.eSequenceItem.H] = Color.Tomato;
            foreach(KeyValuePair<GameLogicManager.eSequenceItem,Color> translationPair in r_SetuanceItemsToColors)
            {
                r_ColorsToSequanceItems[translationPair.Value] = translationPair.Key;
            }
        }

        private void m_StartBtn_MouseClick(object sender, MouseEventArgs e)
        {
            r_NumberOfGuesses = r_GameSetupWindow.NumberOfGuesses;
        }

        private void initializeComponents()
        {
            int secretButtonWidth = 40;
            int secretButtonHeight = 40;
            int buttonSpacing = 10;
            int leftMargin = 10;
            int topMargin = 15;
            int guessRowStartY = topMargin + secretButtonHeight + buttonSpacing + 5;

            AutoSize = true;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Icon = new Icon(Path.Combine(Application.StartupPath, "bullseye.ico"));
            for (int i = 0; i < r_LogicManager.m_Secretsequence.Length; i++)
            {
                Button SecretButton = new Button();

                SecretButton.Width = secretButtonWidth;
                SecretButton.Height = secretButtonHeight;
                SecretButton.BackColor = Color.Black;
                SecretButton.Left = leftMargin + i * (secretButtonWidth + buttonSpacing);
                SecretButton.Top = topMargin;
                SecretButton.Enabled = false;
                Controls.Add(SecretButton);
            }

            for (int i = 0; i < r_NumberOfGuesses; i++)
            {
                int rowTop = guessRowStartY + i * (secretButtonHeight + buttonSpacing);

                r_ButtonSetsForGuesses[i] = new ButtonCollectionForSingleGuess(rowTop, leftMargin);
                foreach (Button button in r_ButtonSetsForGuesses[i].r_AllButtons)
                {
                    Controls.Add(button);
                }

                foreach (Button choiceButton in r_ButtonSetsForGuesses[i].r_ChoiceButtons)
                {
                    choiceButton.Click += choiceButton_Click;
                }

                r_ButtonSetsForGuesses[i].SubmitButton.Click += SubmitButton_Click;
            }

            int totalHeight = guessRowStartY + r_NumberOfGuesses * (secretButtonHeight + buttonSpacing) + topMargin;
            int totalWidth = leftMargin + 4 * (secretButtonWidth + buttonSpacing) + leftMargin;

            ClientSize = new Size(totalWidth, totalHeight);
        }

        private void choiceButton_Click(object sender, EventArgs e)
        {
            ColorChoiceWindow colorChoiceWindow = new ColorChoiceWindow(sender as Button,r_SetuanceItemsToColors.Values.ToArray());

            colorChoiceWindow.ShowDialog();
            enableSubmitButtonIfGuessFilledAndValid();
        }

        private void enableSubmitButtonIfGuessFilledAndValid()
        {
            ButtonCollectionForSingleGuess currentGuess = r_ButtonSetsForGuesses[m_CurrentGuessNumber];
            bool allButtonsFilled = true;

            foreach (Button button in currentGuess.r_ChoiceButtons)
            {
                if (button.BackColor == Color.Beige)
                {
                    allButtonsFilled = false;
                    break;
                }
            }

            if (allButtonsFilled && isGuessValid(currentGuess))
            {
                currentGuess.SubmitButton.Enabled = true;
            }
            else
            {
                currentGuess.SubmitButton.Enabled = false;
            }
        }

        private bool isGuessValid(ButtonCollectionForSingleGuess i_Guess)
        {
            GameLogicManager.eSequenceItem[] guessItems = new GameLogicManager.eSequenceItem[GameLogicManager.k_AmountOfItemsInSequence];

            for (int i = 0; i < GameLogicManager.k_AmountOfItemsInSequence; i++)
            {
                guessItems[i] = r_ColorsToSequanceItems[i_Guess.r_ChoiceButtons[i].BackColor];
                
            }

            return r_LogicManager.SequenceHasNoDuplicates(guessItems);
        }
        
        private void disableChoiceButtonsForCurrentGuess()
        {
            ButtonCollectionForSingleGuess currentGuess = r_ButtonSetsForGuesses[m_CurrentGuessNumber];

            foreach (Button button in currentGuess.r_ChoiceButtons)
            {
                button.Enabled = false;
            }
        }
        
        private void enableChoiceButtonsForCurrentGuess()
        {
            ButtonCollectionForSingleGuess currentGuess = r_ButtonSetsForGuesses[m_CurrentGuessNumber];

            foreach (Button button in currentGuess.r_ChoiceButtons)
            {
                button.Enabled = true;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            ButtonCollectionForSingleGuess currentGuess = r_ButtonSetsForGuesses[m_CurrentGuessNumber];
            GameLogicManager.eSequenceItem[] guessItems = new GameLogicManager.eSequenceItem[GameLogicManager.k_AmountOfItemsInSequence];

            for (int i = 0; i < GameLogicManager.k_AmountOfItemsInSequence; i++)
            {
                guessItems[i] = r_ColorsToSequanceItems[currentGuess.r_ChoiceButtons[i].BackColor];
            }

            r_LogicManager.CheckGuess(guessItems);
            if (m_CurrentGuessNumber >= 0)
            {
                disableChoiceButtonsForCurrentGuess();
                r_ButtonSetsForGuesses[m_CurrentGuessNumber].SubmitButton.Enabled = false;
            }

            updateResultButtons(currentGuess);
            if (m_CurrentGuessNumber + 1 >= r_NumberOfGuesses || r_LogicManager.CheckWin())
            {
                setSecretButtonsToCorrectSequence();
            }
            else
            {
                startNextGuess();
            }
        }

        private void updateResultButtons(ButtonCollectionForSingleGuess i_Guess)
        {
            GameLogicManager.Guess guess = r_LogicManager.r_GuessList.Last();

            for (int i = 0; i < guess.Hits; i++)
            {
                i_Guess.ResultButtons[i].BackColor = Color.Black;
            }

            for (int i = guess.Hits; i < GameLogicManager.k_AmountOfItemsInSequence; i++)
            {
                if (i - guess.Hits < guess.Misses)
                {
                    i_Guess.ResultButtons[i].BackColor = Color.Yellow;
                }
                else
                {
                    i_Guess.ResultButtons[i].BackColor = Color.Empty;
                }
            }
        }
        
        private void setSecretButtonsToCorrectSequence()
        {
            for (int i = 0; i < GameLogicManager.k_AmountOfItemsInSequence; i++)
            {
                Button secretButton = Controls[i] as Button; // Assuming the first 4 buttons are the secret buttons

                secretButton.BackColor = r_SetuanceItemsToColors[r_LogicManager.m_Secretsequence[i]];
            }
        }
    }
}
