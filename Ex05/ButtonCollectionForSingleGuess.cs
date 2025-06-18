using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

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

        public ButtonCollectionForSingleGuess(int i_Height, int i_left)
        {
            int buttonWidth = 40;
            int buttonHeight = 40;
            int buttonSpacing = 10;

            int resultButtonSize = 15;
            int resultVerticalSpacing = 0; // Was 1, reduced to 0 for compactness

            // Set size for choice buttons
            m_ChoiceButton1.Width = buttonWidth;
            m_ChoiceButton2.Width = buttonWidth;
            m_ChoiceButton3.Width = buttonWidth;
            m_ChoiceButton4.Width = buttonWidth;

            m_ChoiceButton1.Height = buttonHeight;
            m_ChoiceButton2.Height = buttonHeight;
            m_ChoiceButton3.Height = buttonHeight;
            m_ChoiceButton4.Height = buttonHeight;

            // Disable buttons by default
            m_ChoiceButton1.Enabled = false;
            m_ChoiceButton2.Enabled = false;
            m_ChoiceButton3.Enabled = false;
            m_ChoiceButton4.Enabled = false;
            m_SubmitButton.Enabled = false;
            m_ResultButton1.Enabled = false;
            m_ResultButton2.Enabled = false;
            m_ResultButton3.Enabled = false;
            m_ResultButton4.Enabled = false;

            // Set position for choice buttons
            m_ChoiceButton1.Left = i_left;
            m_ChoiceButton2.Left = i_left + 1 * (buttonWidth + buttonSpacing);
            m_ChoiceButton3.Left = i_left + 2 * (buttonWidth + buttonSpacing);
            m_ChoiceButton4.Left = i_left + 3 * (buttonWidth + buttonSpacing);

            m_ChoiceButton1.Top = i_Height;
            m_ChoiceButton2.Top = i_Height;
            m_ChoiceButton3.Top = i_Height;
            m_ChoiceButton4.Top = i_Height;

            // Submit button setup
            m_SubmitButton.Width = 50;
            m_SubmitButton.Height = buttonHeight;
            m_SubmitButton.Left = m_ChoiceButton4.Left + buttonWidth + buttonSpacing;
            m_SubmitButton.Top = i_Height;
            m_SubmitButton.Text = "-->";

            // Result buttons setup (smaller & tighter layout)
            m_ResultButton1.Width = resultButtonSize;
            m_ResultButton2.Width = resultButtonSize;
            m_ResultButton3.Width = resultButtonSize;
            m_ResultButton4.Width = resultButtonSize;

            m_ResultButton1.Height = resultButtonSize;
            m_ResultButton2.Height = resultButtonSize;
            m_ResultButton3.Height = resultButtonSize;
            m_ResultButton4.Height = resultButtonSize;

            m_ResultButton1.Left = m_SubmitButton.Left + m_SubmitButton.Width + buttonSpacing;
            m_ResultButton1.Top = i_Height;

            m_ResultButton2.Left = m_ResultButton1.Left + m_ResultButton1.Width + 1;
            m_ResultButton2.Top = i_Height;

            m_ResultButton3.Left = m_ResultButton1.Left;
            m_ResultButton3.Top = i_Height + resultButtonSize + resultVerticalSpacing;

            m_ResultButton4.Left = m_ResultButton2.Left;
            m_ResultButton4.Top = i_Height + resultButtonSize + resultVerticalSpacing;


            // Add all buttons to their collections
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
    }
}
