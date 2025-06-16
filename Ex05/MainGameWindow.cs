using System;
using System.Windows.Forms;

namespace Ex05
{
    internal class MainGameWindow : Form
    {
        private readonly GameLogicManager r_LogicManager = new GameLogicManager();
        private readonly GameSetupWindow r_gameSetupWindow = new GameSetupWindow();

        public MainGameWindow()
        {
            r_gameSetupWindow.ShowDialog();
            setUpGameWindow();
        }
        
        private void setUpGameWindow()
        {
           
        }
    }
}
