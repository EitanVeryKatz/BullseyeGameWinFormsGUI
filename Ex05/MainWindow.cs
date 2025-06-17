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
        ColorChoiseWindow colorChoiseWindow = new ColorChoiseWindow();
        Button ChosenButtonColorCoiceButton;
        public MainWindow()
        {
            InitializeComponent();
            foreach(Button btn in Controls)
            {
                btn.MouseClick += OptionBtn_MouseClick;
            }
        }

        private void OptionBtn_MouseClick(object sender, MouseEventArgs e)
        {
            ChosenButtonColorCoiceButton = sender as Button;
            colorChoiseWindow.ShowDialog();
        }

        
    }
}
