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
        public Button m_StartBtn;
        private Button m_CounterBtn;
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
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            m_CounterBtn.MouseClick += M_CounterBtn_MouseClick;
            m_StartBtn.MouseClick += M_StartBtn_MouseClick;
            m_CounterBtn.Text = $"number of guesses: {NumberOfGuesses}";
        }

        private void InitializeComponent()
        {
            this.m_StartBtn = new System.Windows.Forms.Button();
            this.m_CounterBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_StartBtn
            // 
            this.m_StartBtn.Location = new System.Drawing.Point(124, 134);
            this.m_StartBtn.Name = "m_StartBtn";
            this.m_StartBtn.Size = new System.Drawing.Size(108, 37);
            this.m_StartBtn.TabIndex = 0;
            this.m_StartBtn.Text = "start";
            // 
            // m_CounterBtn
            // 
            this.m_CounterBtn.Location = new System.Drawing.Point(28, 51);
            this.m_CounterBtn.Name = "m_CounterBtn";
            this.m_CounterBtn.Size = new System.Drawing.Size(300, 23);
            this.m_CounterBtn.TabIndex = 1;
            // 
            // GameSetupWindow
            // 
            this.ClientSize = new System.Drawing.Size(359, 210);
            this.Controls.Add(this.m_StartBtn);
            this.Controls.Add(this.m_CounterBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSetupWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Choose Number of Guesses for the Game!";
            this.ResumeLayout(false);

        }

        private void M_StartBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void M_CounterBtn_MouseClick(object sender, MouseEventArgs e)
        {
            NumberOfGuesses++;
            ((Button)sender).Text = $"number of guesses: {NumberOfGuesses}";
            
        }
    }
}
