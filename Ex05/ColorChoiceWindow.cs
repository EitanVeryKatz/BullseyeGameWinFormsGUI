using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    internal class ColorChoiceWindow : Form
    {
        private readonly Button r_ChosenButton;
        private readonly List<Button> r_ColorButtons = new List<Button>();

        public ColorChoiceWindow(Button i_ChosenButton)
        {
            r_ChosenButton = i_ChosenButton;
            initializeForm();
            createColorButtons();
            addColorButtonsToForm();
        }

        private void initializeForm()
        {
            this.ClientSize = new Size(225, 129);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = nameof(ColorChoiceWindow);
        }

        private void createColorButtons()
        {
            addColorButton(Color.Brown, 12, 19);
            addColorButton(Color.Green, 62, 19);
            addColorButton(Color.Red, 115, 19);
            addColorButton(Color.Purple, 168, 19);
            addColorButton(Color.Yellow, 12, 70);
            addColorButton(Color.Blue, 62, 70);
            addColorButton(Color.Gray, 115, 70);
            addColorButton(Color.Orange, 168, 70);
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
