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
        private Dictionary<Color,char> r_ColorsToChars = new Dictionary<Color,char>();

        private void startNextGuess()
        {
            m_CurrentGuessNumber++;
            ButtonCollectionForSingleGuess nextGuess = r_ButtonSetsForGuesses[m_CurrentGuessNumber];
            foreach(Button button in nextGuess.r_ChoiceButtons)
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
                foreach(Button choiceButton in r_ButtonSetsForGuesses[i].r_ChoiceButtons)
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
            if (isValidCurrentGuess())
            {
                r_ButtonSetsForGuesses[m_CurrentGuessNumber].SubmitButton.Enabled = true;
            }
        }

        private bool isValidCurrentGuess()//////////////////////add logic
        {
            bool res = false;
            char[] encodedGuess = new char[4];
            int ButtonIndex = 0;
            foreach (Button guessButton in r_ButtonSetsForGuesses[m_CurrentGuessNumber].r_ChoiceButtons)
            {
                encodedGuess[ButtonIndex] = r_ColorsToChars[guessButton.BackColor];////initialize dictionary and handle default color
            }
            if(r_LogicManager.SequenceHasNoDuplicates(encodedGuess))
            {
                res = true;
            }

            return res;
        }
    }
}
