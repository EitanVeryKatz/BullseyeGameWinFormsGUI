using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    public partial class MainWindow : Form
    {
        ColorChoiceWindow colorChoiceWindow = new ColorChoiceWindow();
        Button ChosenButtonColorCoiceButton;
        private readonly GameSetupWindow r_gameSetupWindow = new GameSetupWindow();
        private int r_NumberOfGuesses;
        public MainWindow()
        {
            r_gameSetupWindow.m_StartBtn.MouseClick += M_StartBtn_MouseClick;
            r_gameSetupWindow.ShowDialog();
            InitializeComponent();
            foreach(Button btn in Controls)
            {
                btn.MouseClick += OptionBtn_MouseClick;
            }
        }

        private void OptionBtn_MouseClick(object sender, MouseEventArgs e)
        {
            ChosenButtonColorCoiceButton = sender as Button;
            colorChoiceWindow.ShowDialog();
        }

        private void M_StartBtn_MouseClick(object sender, MouseEventArgs e)
        {
            r_NumberOfGuesses = r_gameSetupWindow.NumberOfGuesses;
        }
    }
}
