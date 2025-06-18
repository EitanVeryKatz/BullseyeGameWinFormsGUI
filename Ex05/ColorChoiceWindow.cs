using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ex05
{
    internal class ColorChoiceWindow : Form
    {
        private readonly Button r_ChosenButton;
        private readonly List<Button> r_ColorButtons = new List<Button>();

        public ColorChoiceWindow(Button i_ChosenButton,Color[] i_colors)
        {
            r_ChosenButton = i_ChosenButton;
            initializeForm();
            createColorButtons(i_colors);
            addColorButtonsToForm();
        }

        private void initializeForm()
        {
            this.ClientSize = new Size(225, 129);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = nameof(ColorChoiceWindow);
            this.ResumeLayout(false);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.Text = "Pick A Color:";
        }

        private void createColorButtons(Color[] i_colors)
        {
            addColorButton(i_colors[0], 12, 19);
            addColorButton(i_colors[1], 62, 19);
            addColorButton(i_colors[2], 115, 19);
            addColorButton(i_colors[3], 168, 19);
            addColorButton(i_colors[4], 12, 70);
            addColorButton(i_colors[5], 62, 70);
            addColorButton(i_colors[6], 115, 70);
            addColorButton(i_colors[7], 168, 70);
        }

        private void addColorButton(Color color, int x, int y)
        {
            Button button = new Button
            {
                BackColor = color,
                Size = new Size(30, 30),
                Location = new Point(x, y),
                UseVisualStyleBackColor = false
            };
            button.Click += ColorButton_Click;
            r_ColorButtons.Add(button);
        }

        private void addColorButtonsToForm()
        {
            foreach (Button button in r_ColorButtons)
            {
                this.Controls.Add(button);
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            Button chosenColor = sender as Button;
            r_ChosenButton.BackColor = chosenColor.BackColor;
            Close();
        }
        
    }
}
