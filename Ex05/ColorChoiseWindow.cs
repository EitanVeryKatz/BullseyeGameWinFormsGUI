using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    internal class ColorChoiseWindow:Form
    {

        private Button OptionBtnRed = new Button();
        private Button OptionBtnGreen = new Button();
        private Button OptionBtnBlue = new Button();
        private Button OptionBtnYellow = new Button();
        private Button OptionBtnPurple = new Button();
        private Button OptionBtnGray = new Button();
        private Button OptionBtnBrown = new Button();
        private Button OptionBtnOrange = new Button();

        public ColorChoiseWindow()
        {
            Controls.Add(OptionBtnRed);
            Controls.Add(OptionBtnGreen);
            Controls.Add(OptionBtnBlue);
            Controls.Add(OptionBtnYellow);
            Controls.Add(OptionBtnPurple);
            Controls.Add(OptionBtnGray);
            Controls.Add(OptionBtnOrange);
            Controls.Add(OptionBtnBrown);



            StartPosition = FormStartPosition.CenterParent;
            OptionBtnBlue.BackColor = Color.Blue;
            OptionBtnGreen.BackColor = Color.Green;
            OptionBtnRed.BackColor = Color.Red;
            OptionBtnYellow.BackColor = Color.Yellow;
            OptionBtnPurple.BackColor = Color.Purple;
            OptionBtnGray.BackColor = Color.Gray;
            OptionBtnBrown.BackColor = Color.Brown;
            OptionBtnOrange.BackColor = Color.Orange;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ColorChoiseWindow
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(984, 435);
            this.Name = "ColorChoiseWindow";
            this.ResumeLayout(false);

        }
    }
}
