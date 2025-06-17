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
            foreach(Button button in nextGuess.ChoiceButtons)
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
                foreach (Button button in r_ButtonSetsForGuesses[i].Buttons)
                {
                    Controls.Add(button);
                }
                foreach(Button choiceButton in r_ButtonSetsForGuesses[i].ChoiceButtons)
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
        }
    }
}
