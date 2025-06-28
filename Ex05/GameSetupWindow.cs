using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    internal class GameSetupWindow : Form
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
                if (value > 10)
                {
                    m_NumberOfGuesses = value % 10 + 3;
                }
                else
                {
                    m_NumberOfGuesses = value;
                }
            }
        }

        public GameSetupWindow()
        {
            InitializeComponent();
            ResumeLayout(false);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            m_CounterBtn.MouseClick += M_CounterBtn_MouseClick;
            m_StartBtn.MouseClick += M_StartBtn_MouseClick;
            m_CounterBtn.Text = $"number of guesses: {NumberOfGuesses}";
            m_CounterBtn.Font= new Font("Arial", 10, FontStyle.Bold);
            m_StartBtn.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        private void InitializeComponent()
        {
            m_StartBtn = new System.Windows.Forms.Button();
            m_CounterBtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // m_StartBtn
            // 
            m_StartBtn.Location = new System.Drawing.Point(124, 134);
            m_StartBtn.Name = "m_StartBtn";
            m_StartBtn.Size = new System.Drawing.Size(108, 37);
            m_StartBtn.TabIndex = 0;
            m_StartBtn.Text = "start";
            // 
            // m_CounterBtn
            // 
            m_CounterBtn.Location = new System.Drawing.Point(28, 51);
            m_CounterBtn.Name = "m_CounterBtn";
            m_CounterBtn.Size = new System.Drawing.Size(300, 23);
            m_CounterBtn.TabIndex = 1;
            // 
            // GameSetupWindow
            // 
            ClientSize = new System.Drawing.Size(359, 210);
            Controls.Add(m_StartBtn);
            Controls.Add(m_CounterBtn);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GameSetupWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Choose Number of Guesses for the Game!";
            ResumeLayout(false);

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
