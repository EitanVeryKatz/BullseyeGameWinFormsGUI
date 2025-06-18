using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ex05
{
    internal class ButtonCollectionForSingleGuess
    {
        public readonly List<Button> r_Buttons = new List<Button>();
        public readonly List<Button> r_ChoiceButtons = new List<Button>();
        public List<Button> r_ResultButtons { get; } = new List<Button>();

        private Button m_ChoiceButton1 = new Button();
        private Button m_ChoiceButton2 = new Button();
        private Button m_ChoiceButton3 = new Button();
        private Button m_ChoiceButton4 = new Button();

        private Button m_SubmitButton = new Button();

        private Button m_ResultButton1 = new Button();
        private Button m_ResultButton2 = new Button();
        private Button m_ResultButton3 = new Button();
        private Button m_ResultButton4 = new Button();

        public Button SubmitButton
        {
            get { return m_SubmitButton; }
        }

        public ButtonCollectionForSingleGuess(int i_Height, int i_Left)
        {
            int buttonWidth = 40;
            int buttonHeight = 40;
            int buttonSpacing = 10;
            int resultButtonSize = 15;
            int resultVerticalSpacing = 0;

            choiceButtonsSetup(buttonWidth, buttonHeight, i_Left, i_Height, buttonSpacing);
            disableAllButtons();

            submitButtonSetup(buttonWidth, buttonHeight, i_Height, buttonSpacing);



            resultButtonsSetup(resultButtonSize, buttonSpacing, i_Height, resultVerticalSpacing);

            AddButtonsToCollections();

            MakeAllButtonsGlossy();

        }
        private void disableAllButtons()
        {
            m_ChoiceButton1.Enabled = false;
            m_ChoiceButton2.Enabled = false;
            m_ChoiceButton3.Enabled = false;
            m_ChoiceButton4.Enabled = false;
            m_SubmitButton.Enabled = false;
            m_ResultButton1.Enabled = false;
            m_ResultButton2.Enabled = false;
            m_ResultButton3.Enabled = false;
            m_ResultButton4.Enabled = false;
        }
        private void choiceButtonsSetup(int i_ButtonWidth, int i_ButtonHeight, int i_Left, int i_Height, int i_ButtonSpacing)
        {
            m_ChoiceButton1.Width = i_ButtonWidth;
            m_ChoiceButton2.Width = i_ButtonWidth;
            m_ChoiceButton3.Width = i_ButtonWidth;
            m_ChoiceButton4.Width = i_ButtonWidth;

            m_ChoiceButton1.Height = i_ButtonHeight;
            m_ChoiceButton2.Height = i_ButtonHeight;
            m_ChoiceButton3.Height = i_ButtonHeight;
            m_ChoiceButton4.Height = i_ButtonHeight;

            // Set position for choice buttons
            m_ChoiceButton1.Left = i_Left;
            m_ChoiceButton2.Left = i_Left + 1 * (i_ButtonWidth + i_ButtonSpacing);
            m_ChoiceButton3.Left = i_Left + 2 * (i_ButtonWidth + i_ButtonSpacing);
            m_ChoiceButton4.Left = i_Left + 3 * (i_ButtonWidth + i_ButtonSpacing);

            m_ChoiceButton1.Top = i_Height;
            m_ChoiceButton2.Top = i_Height;
            m_ChoiceButton3.Top = i_Height;
            m_ChoiceButton4.Top = i_Height;
        }
        private void resultButtonsSetup(int i_ResultButtonSize, int i_ButtonSpacing, int i_Height, int i_ResultVerticalSpacing)
        {
            m_ResultButton1.Width = i_ResultButtonSize;
            m_ResultButton2.Width = i_ResultButtonSize;
            m_ResultButton3.Width = i_ResultButtonSize;
            m_ResultButton4.Width = i_ResultButtonSize;
            m_ResultButton1.Height = i_ResultButtonSize;
            m_ResultButton2.Height = i_ResultButtonSize;
            m_ResultButton3.Height = i_ResultButtonSize;
            m_ResultButton4.Height = i_ResultButtonSize;
            m_ResultButton1.Left = m_SubmitButton.Left + m_SubmitButton.Width + i_ButtonSpacing;
            m_ResultButton1.Top = i_Height;
            m_ResultButton2.Left = m_ResultButton1.Left + m_ResultButton1.Width + 1;
            m_ResultButton2.Top = i_Height;
            m_ResultButton3.Left = m_ResultButton1.Left;
            m_ResultButton3.Top = i_Height + i_ResultButtonSize + i_ResultVerticalSpacing;
            m_ResultButton4.Left = m_ResultButton2.Left;
            m_ResultButton4.Top = i_Height + i_ResultButtonSize + i_ResultVerticalSpacing;
        }
        private void submitButtonSetup(int i_ButtonWidth, int i_ButtonHeight, int i_Height, int i_ButtonSpacing)
        {
            // Submit button setup
            m_SubmitButton.Width = 50;
            m_SubmitButton.Height = i_ButtonHeight;
            m_SubmitButton.Left = m_ChoiceButton4.Left + i_ButtonWidth + i_ButtonSpacing;
            m_SubmitButton.Top = i_Height;
            m_SubmitButton.Text = "-->";
        }
        private void AddButtonsToCollections()
        {
            r_Buttons.Add(m_ChoiceButton1);
            r_Buttons.Add(m_ChoiceButton2);
            r_Buttons.Add(m_ChoiceButton3);
            r_Buttons.Add(m_ChoiceButton4);
            r_Buttons.Add(m_SubmitButton);
            r_Buttons.Add(m_ResultButton1);
            r_Buttons.Add(m_ResultButton2);
            r_Buttons.Add(m_ResultButton3);
            r_Buttons.Add(m_ResultButton4);

            r_ChoiceButtons.Add(m_ChoiceButton1);
            r_ChoiceButtons.Add(m_ChoiceButton2);
            r_ChoiceButtons.Add(m_ChoiceButton3);
            r_ChoiceButtons.Add(m_ChoiceButton4);

            r_ResultButtons.Add(m_ResultButton1);
            r_ResultButtons.Add(m_ResultButton2);
            r_ResultButtons.Add(m_ResultButton3);
            r_ResultButtons.Add(m_ResultButton4);
        }
        private void MakeButtonGlossy(Button i_Button)
        {
            i_Button.FlatStyle = FlatStyle.Flat;
            i_Button.FlatAppearance.BorderSize = 0;
            i_Button.BackColor = Color.Beige;
            i_Button.ForeColor = Color.White;
            i_Button.Paint += (sender, e) =>
            {
                Button btn = sender as Button;
                Graphics g = e.Graphics;
                // Gloss effect (top half white with alpha)
                Rectangle glossRect = new Rectangle(0, 0, btn.Width, btn.Height / 2);
                using (LinearGradientBrush glossBrush = new LinearGradientBrush(glossRect,
                    Color.FromArgb(180, Color.White), Color.FromArgb(0, Color.White), LinearGradientMode.Vertical))
                {
                    g.FillRectangle(glossBrush, glossRect);
                }

                // Optional border
                using (Pen borderPen = new Pen(Color.DarkGray))
                {
                    g.DrawRectangle(borderPen, 0, 0, btn.Width - 1, btn.Height - 1);
                }

            };
        }
        private void MakeAllButtonsGlossy()
        {
            for (int i = 0; i < r_ChoiceButtons.Count; i++)
            {
                MakeButtonGlossy(r_ChoiceButtons[i]);
            }

            for (int i = 0; i < r_ResultButtons.Count; i++)
            {
                MakeButtonGlossy(r_ResultButtons[i]);
            }
        }
    }
}
