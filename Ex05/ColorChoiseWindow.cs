using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    internal class ColorChoiceWindow:Form
    {

        private Button OptionBtnRed;
        private Button OptionBtnGreen;
        private Button OptionBtnBlue;
        private Button OptionBtnYellow;
        private Button OptionBtnPurple;
        private Button OptionBtnGray;
        private Button OptionBtnBrown;
        private Button OptionBtnOrange;

        private void InitializeComponent()
        {

            this.OptionBtnRed = new System.Windows.Forms.Button();
            this.OptionBtnGreen = new System.Windows.Forms.Button();
            this.OptionBtnBlue = new System.Windows.Forms.Button();
            this.OptionBtnYellow = new System.Windows.Forms.Button();
            this.OptionBtnPurple = new System.Windows.Forms.Button();
            this.OptionBtnGray = new System.Windows.Forms.Button();
            this.OptionBtnBrown = new System.Windows.Forms.Button();
            this.OptionBtnOrange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OptionBtnRed
            // 
            this.OptionBtnRed.BackColor = System.Drawing.Color.Red;
            this.OptionBtnRed.Location = new System.Drawing.Point(115, 19);
            this.OptionBtnRed.Name = "OptionBtnRed";
            this.OptionBtnRed.Size = new System.Drawing.Size(30, 30);
            this.OptionBtnRed.TabIndex = 0;
            this.OptionBtnRed.UseVisualStyleBackColor = false;
            // 
            // OptionBtnGreen
            // 
            this.OptionBtnGreen.BackColor = System.Drawing.Color.Green;
            this.OptionBtnGreen.Location = new System.Drawing.Point(62, 19);
            this.OptionBtnGreen.Name = "OptionBtnGreen";
            this.OptionBtnGreen.Size = new System.Drawing.Size(30, 30);
            this.OptionBtnGreen.TabIndex = 1;
            this.OptionBtnGreen.UseVisualStyleBackColor = false;
            // 
            // OptionBtnBlue
            // 
            this.OptionBtnBlue.BackColor = System.Drawing.Color.Blue;
            this.OptionBtnBlue.Location = new System.Drawing.Point(62, 70);
            this.OptionBtnBlue.Name = "OptionBtnBlue";
            this.OptionBtnBlue.Size = new System.Drawing.Size(30, 30);
            this.OptionBtnBlue.TabIndex = 2;
            this.OptionBtnBlue.UseVisualStyleBackColor = false;
            // 
            // OptionBtnYellow
            // 
            this.OptionBtnYellow.BackColor = System.Drawing.Color.Yellow;
            this.OptionBtnYellow.Location = new System.Drawing.Point(12, 70);
            this.OptionBtnYellow.Name = "OptionBtnYellow";
            this.OptionBtnYellow.Size = new System.Drawing.Size(30, 30);
            this.OptionBtnYellow.TabIndex = 3;
            this.OptionBtnYellow.UseVisualStyleBackColor = false;
            // 
            // OptionBtnPurple
            // 
            this.OptionBtnPurple.BackColor = System.Drawing.Color.Purple;
            this.OptionBtnPurple.Location = new System.Drawing.Point(168, 19);
            this.OptionBtnPurple.Name = "OptionBtnPurple";
            this.OptionBtnPurple.Size = new System.Drawing.Size(30, 30);
            this.OptionBtnPurple.TabIndex = 4;
            this.OptionBtnPurple.UseVisualStyleBackColor = false;
            // 
            // OptionBtnGray
            // 
            this.OptionBtnGray.BackColor = System.Drawing.Color.Gray;
            this.OptionBtnGray.Location = new System.Drawing.Point(115, 70);
            this.OptionBtnGray.Name = "OptionBtnGray";
            this.OptionBtnGray.Size = new System.Drawing.Size(30, 30);
            this.OptionBtnGray.TabIndex = 5;
            this.OptionBtnGray.UseVisualStyleBackColor = false;
            // 
            // OptionBtnBrown
            // 
            this.OptionBtnBrown.BackColor = System.Drawing.Color.Brown;
            this.OptionBtnBrown.Location = new System.Drawing.Point(12, 19);
            this.OptionBtnBrown.Name = "OptionBtnBrown";
            this.OptionBtnBrown.Size = new System.Drawing.Size(30, 30);
            this.OptionBtnBrown.TabIndex = 7;
            this.OptionBtnBrown.UseVisualStyleBackColor = false;
            // 
            // OptionBtnOrange
            // 
            this.OptionBtnOrange.BackColor = System.Drawing.Color.Orange;
            this.OptionBtnOrange.Location = new System.Drawing.Point(168, 70);
            this.OptionBtnOrange.Name = "OptionBtnOrange";
            this.OptionBtnOrange.Size = new System.Drawing.Size(30, 30);
            this.OptionBtnOrange.TabIndex = 6;
            this.OptionBtnOrange.UseVisualStyleBackColor = false;
            // 
            // ColorChoiceWindow
            // 
            this.ClientSize = new System.Drawing.Size(225, 129);
            this.Controls.Add(this.OptionBtnRed);
            this.Controls.Add(this.OptionBtnGreen);
            this.Controls.Add(this.OptionBtnBlue);
            this.Controls.Add(this.OptionBtnYellow);
            this.Controls.Add(this.OptionBtnPurple);
            this.Controls.Add(this.OptionBtnGray);
            this.Controls.Add(this.OptionBtnOrange);
            this.Controls.Add(this.OptionBtnBrown);
            this.Name = "ColorChoiceWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }
    
        public ColorChoiceWindow()
        {
            InitializeComponent();
        }

       
    }
}
