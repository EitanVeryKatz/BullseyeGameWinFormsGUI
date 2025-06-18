using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace Ex05
{
    internal class MainGameWindow : Form
    {
        private readonly GameLogicManager r_LogicManager = new GameLogicManager();
        private readonly GameSetupWindow r_gameSetupWindow = new GameSetupWindow();
        private int r_NumberOfGuesses = 0;
        private readonly Dictionary<int, ButtonCollectionForSingleGuess> r_ButtonSetsForGuesses = new Dictionary<int, ButtonCollectionForSingleGuess>();
        private int m_CurrentGuessNumber = -1;

        private void startNextGuess()
        {
            if (m_CurrentGuessNumber >= 0)
            {
                disableChoiceButtonsForCurrentGuess(); // disable the choice buttons of the previous guess
            }
            m_CurrentGuessNumber++;
            enableChoiceButtonsForCurrentGuess();// enable the choice buttons for the next guess
        }

        public MainGameWindow()
        {
            Text = "Bul-Pgiah!";
            StartPosition = FormStartPosition.CenterScreen;
            r_gameSetupWindow.m_StartBtn.MouseClick += M_StartBtn_MouseClick;
            r_gameSetupWindow.ShowDialog();
            if (r_NumberOfGuesses == 0)
            {
                throw new Exception();
            }
            InitializeComponent();
            r_LogicManager.GenerateSequence();
            startNextGuess();
        }

        private void M_StartBtn_MouseClick(object sender, MouseEventArgs e)
        {
            r_NumberOfGuesses = r_gameSetupWindow.NumberOfGuesses;
        }

        private void InitializeComponent()
        {
            int secretButtonWidth = 40;
            int secretButtonHeight = 40;
            int buttonSpacing = 10;
            int leftMargin = 10;
            int topMargin = 15;

            this.AutoSize = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            for (int i = 0; i < 4; i++)
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
            

            int guessRowStartY = topMargin + secretButtonHeight + buttonSpacing + 5;

            for (int i = 0; i < r_NumberOfGuesses; i++)
            {
                int rowTop = guessRowStartY + i * (secretButtonHeight + buttonSpacing);
                r_ButtonSetsForGuesses[i] = new ButtonCollectionForSingleGuess(rowTop, leftMargin);
                foreach (Button button in r_ButtonSetsForGuesses[i].r_Buttons)
                {
                    Controls.Add(button);
                }
                foreach (Button choiceButton in r_ButtonSetsForGuesses[i].r_ChoiceButtons)
                {
                    choiceButton.Click += ChoiceButton_Click;
                }
                r_ButtonSetsForGuesses[i].SubmitButton.Click += SubmitButton_Click;
            }

            int totalHeight = guessRowStartY + r_NumberOfGuesses * (secretButtonHeight + buttonSpacing) + topMargin;
            int totalWidth = leftMargin + 4 * (secretButtonWidth + buttonSpacing) + leftMargin;
            this.ClientSize = new Size(totalWidth, totalHeight);
        }

        private void ChoiceButton_Click(object sender, EventArgs e)
        {
            ColorChoiceWindow colorChoiceWindow = new ColorChoiceWindow(sender as Button);
            colorChoiceWindow.ShowDialog();
            enableSubmitButtonIfLastChoiceButton(sender as Button);
        }

        // if the current choice button is the last one in the row, it will enable the submit button
        private void enableSubmitButtonIfLastChoiceButton(Button i_ChoiceButton)
        {
            if (!isGuessValid(r_ButtonSetsForGuesses[m_CurrentGuessNumber]))
            {
                MessageBox.Show("Invalid guess! Please choose a sequence with no duplicates.", "Invalid Guess", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ButtonCollectionForSingleGuess currentGuess = r_ButtonSetsForGuesses[m_CurrentGuessNumber];
                if (currentGuess.r_ChoiceButtons.IndexOf(i_ChoiceButton) == currentGuess.r_ChoiceButtons.Count - 1)
                {
                    currentGuess.SubmitButton.Enabled = true;
                }
            }
        }

        // Convert button color to SequenceItem
        private GameLogicManager.SequenceItem getSequenceItemFromButtonColor(Button i_Button)
        {
            Color buttonColor = i_Button.BackColor;
            return r_LogicManager.GetSequenceItemFromColor(buttonColor);
        }

        // Convert SequenceItem to color
        private Color getColorFromSequenceItem(GameLogicManager.SequenceItem item)
        {
            return r_LogicManager.GetColorFromSequenceItem(item);
        }

        // Check if the guess is valid
        private bool isGuessValid(ButtonCollectionForSingleGuess i_Guess)
        {
            GameLogicManager.SequenceItem[] guessItems = new GameLogicManager.SequenceItem[GameLogicManager.k_AmountOfItemsInSequence];
            for (int i = 0; i < GameLogicManager.k_AmountOfItemsInSequence; i++)
            {
                guessItems[i] = getSequenceItemFromButtonColor(i_Guess.r_ChoiceButtons[i]);
            }
            return r_LogicManager.SequenceHasNoDuplicates(guessItems);
        }
        //disable the choice buttons of the current guess
        private void disableChoiceButtonsForCurrentGuess()
        {
            ButtonCollectionForSingleGuess currentGuess = r_ButtonSetsForGuesses[m_CurrentGuessNumber];
            foreach (Button button in currentGuess.r_ChoiceButtons)
            {
                button.Enabled = false;
            }
        }
        //enable the choice buttons for the current guess
        private void enableChoiceButtonsForCurrentGuess()
        {
            ButtonCollectionForSingleGuess currentGuess = r_ButtonSetsForGuesses[m_CurrentGuessNumber];
            foreach (Button button in currentGuess.r_ChoiceButtons)
            {
                button.Enabled = true;
            }
        }
        //when the submit button is clicked, it will check the guess and update the result buttons
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            ButtonCollectionForSingleGuess currentGuess = r_ButtonSetsForGuesses[m_CurrentGuessNumber];
            GameLogicManager.SequenceItem[] guessItems = new GameLogicManager.SequenceItem[GameLogicManager.k_AmountOfItemsInSequence];
            for (int i = 0; i < GameLogicManager.k_AmountOfItemsInSequence; i++)
            {
                guessItems[i] = getSequenceItemFromButtonColor(currentGuess.r_ChoiceButtons[i]);// convert button color to SequenceItem
            }
            r_LogicManager.CheckGuess(guessItems);


            //if (r_LogicManager.CheckLoss())
            //{
            //    MessageBox.Show("You lost! Try again.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Close();
            //}
            //else if (r_LogicManager.CheckWin())
            //{
            //    MessageBox.Show("Congratulations! You guessed the sequence!", "You Win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Close();
            //}
            //else
            //{
            //    updateResultButtons(currentGuess); // Update the result buttons with hits and misses
            //    startNextGuess();
            //}

            updateResultButtons(currentGuess); // Update the result buttons with hits and misses
            startNextGuess();
        }
        // Update the result buttons with hits and misses
        private void updateResultButtons(ButtonCollectionForSingleGuess i_Guess)
        {
            GameLogicManager.Guess guess = r_LogicManager.m_guessList.Last(); // Get the last guess
            for (int i = 0; i < guess.Hits; i++)
            {
                i_Guess.r_ResultButtons[i].BackColor = Color.Black; // Black for hits
            }
            for (int i = guess.Hits; i < GameLogicManager.k_AmountOfItemsInSequence; i++)
            {
                if (i - guess.Hits < guess.Misses)
                {
                    i_Guess.r_ResultButtons[i].BackColor = Color.Yellow; // Yellow for misses
                }
                else
                {
                    i_Guess.r_ResultButtons[i].BackColor = Color.Empty; // Empty for no hits or misses
                }
            }
        }
    }
}
