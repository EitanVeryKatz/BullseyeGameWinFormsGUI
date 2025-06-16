using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    internal class GameSetupWindow:Form
    {
        public Button m_StartBtn = new Button();
        private Button m_CounterBtn = new Button();
        private int m_NumberOfGuesses = 4;
        public int NumberOfGuesses
        {
            get
            {
                return m_NumberOfGuesses;
            }
            private set
            {
                if (value>10)
                {
                    m_NumberOfGuesses = value%10+3;
                }
                else
                {
                    m_NumberOfGuesses=value;
                }
            }
        }

        


        public GameSetupWindow()
        {
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(m_StartBtn);
            Controls.Add(m_CounterBtn);
            m_CounterBtn.Width = 300;
            m_CounterBtn.MouseClick += M_CounterBtn_MouseClick;
            m_StartBtn.Top = Top + 20;
            m_StartBtn.Text = "start";
            m_StartBtn.MouseClick += M_StartBtn_MouseClick;

            m_CounterBtn.Text = $"numbe of guesses: {NumberOfGuesses}";
        }

        private void M_StartBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void M_CounterBtn_MouseClick(object sender, MouseEventArgs e)
        {
            NumberOfGuesses++;
            ((Button)sender).Text = $"numbe of guesses: {NumberOfGuesses}";
            
        }
    }
}
