using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

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
            m_CurrentGuessNumber++;
            ButtonCollectionForSingleGuess nextGuess = r_ButtonSetsForGuesses[m_CurrentGuessNumber];
            foreach (Button button in nextGuess.r_ChoiceButtons)
            {
                button.Enabled = true;
            }
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
            int secretButtonWidth = 50;
            int secretButtonHeight = 50;
            int buttonSpacing = 10;
            int leftMargin = 10;
            int topMargin = 20;

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

            int guessRowStartY = topMargin + secretButtonHeight + buttonSpacing;

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
    }
}
