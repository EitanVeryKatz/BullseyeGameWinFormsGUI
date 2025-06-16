using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ex05
{
    internal class MainGameWindow : Form
    {
        private readonly GameLogicManager r_LogicManager = new GameLogicManager();
        private readonly GameSetupWindow r_gameSetupWindow = new GameSetupWindow();
        private int r_NumberOfGuesses;
        private readonly Dictionary<int ,ButtonCollectionForSingleGuess> r_ButtonSetsForGuesses = new Dictionary<int ,ButtonCollectionForSingleGuess>();
        private int m_CurrentGuessNumber = 1;


        public MainGameWindow()
        {
            Text = "Bul-Pgiah!";
            StartPosition = FormStartPosition.CenterScreen;
            r_gameSetupWindow.m_StartBtn.MouseClick += M_StartBtn_MouseClick;
            r_gameSetupWindow.ShowDialog();
            setUpGameWindow();
        }

        private void M_StartBtn_MouseClick(object sender, MouseEventArgs e)
        {
            r_NumberOfGuesses = r_gameSetupWindow.NumberOfGuesses;
        }

        private void setUpGameWindow()
        {
           for(int i = 0; i < r_NumberOfGuesses; i++)
            {
                r_ButtonSetsForGuesses[i] = new ButtonCollectionForSingleGuess(Top+i*40, Left);
                foreach(Button button in r_ButtonSetsForGuesses[i].Buttons)
                {
                    Controls.Add(button);
                }
            }

        }
    }
}
