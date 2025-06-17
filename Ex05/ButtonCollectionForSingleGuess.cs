using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    internal class ButtonCollectionForSingleGuess
    {
        public List<Button> Buttons = new List<Button>();
        private Button m_ChoiceButton1 = new Button();
        private Button m_ChoiceButton2 = new Button();
        private Button m_ChoiceButton3 = new Button();
        private Button m_ChoiceButton4 = new Button();

        private Button m_SubmitButton = new Button();

        private Button m_ResultButton1 = new Button();
        private Button m_ResultButton2 = new Button();
        private Button m_ResultButton3 = new Button();
        private Button m_ResultButton4 = new Button();

        public ButtonCollectionForSingleGuess(int i_Height, int i_left)
        {
            int buttonWidth = 50;
            int buttonHeight = 50;
            int buttonSpacing = 10;

            m_ChoiceButton1.Width = buttonWidth;
            m_ChoiceButton2.Width = buttonWidth;
            m_ChoiceButton3.Width = buttonWidth;
            m_ChoiceButton4.Width = buttonWidth;

            m_ChoiceButton1.Height = buttonHeight;
            m_ChoiceButton2.Height = buttonHeight;
            m_ChoiceButton3.Height = buttonHeight;
            m_ChoiceButton4.Height = buttonHeight;

            m_ChoiceButton1.Left = i_left;
            m_ChoiceButton2.Left = i_left + 1 * (buttonWidth + buttonSpacing);
            m_ChoiceButton3.Left = i_left + 2 * (buttonWidth + buttonSpacing);
            m_ChoiceButton4.Left = i_left + 3 * (buttonWidth + buttonSpacing);

            m_ChoiceButton1.Top = i_Height;
            m_ChoiceButton2.Top = i_Height;
            m_ChoiceButton3.Top = i_Height;
            m_ChoiceButton4.Top = i_Height;

            Buttons.Add(m_ChoiceButton1);
            Buttons.Add(m_ChoiceButton2);
            Buttons.Add(m_ChoiceButton3);
            Buttons.Add(m_ChoiceButton4);

            Buttons.Add(m_SubmitButton);
            Buttons.Add(m_ResultButton1);
            Buttons.Add(m_ResultButton2);
            Buttons.Add(m_ResultButton3);
            Buttons.Add(m_ResultButton4);

            m_SubmitButton.Width = 50;
            m_SubmitButton.Height = buttonHeight;
            m_SubmitButton.Left = m_ChoiceButton4.Left + buttonWidth + buttonSpacing;
            m_SubmitButton.Top = i_Height;

            m_ResultButton1.Width = 20;
            m_ResultButton2.Width = 20;
            m_ResultButton3.Width = 20;
            m_ResultButton4.Width = 20;

            m_ResultButton1.Height = 20;
            m_ResultButton2.Height = 20;
            m_ResultButton3.Height = 20;
            m_ResultButton4.Height = 20;

            m_ResultButton1.Left = m_SubmitButton.Left + m_SubmitButton.Width + buttonSpacing;
            m_ResultButton1.Top = i_Height;

            m_ResultButton2.Left = m_ResultButton1.Left + m_ResultButton1.Width + 1;
            m_ResultButton2.Top = i_Height;

            m_ResultButton3.Left = m_ResultButton1.Left;
            m_ResultButton3.Top = i_Height + m_ResultButton1.Height + 1;

            m_ResultButton4.Left = m_ResultButton2.Left;
            m_ResultButton4.Top = i_Height + m_ResultButton2.Height + 1;

            m_ResultButton1.Text = "1";
            m_ResultButton2.Text = "2";
            m_ResultButton3.Text = "3";
            m_ResultButton4.Text = "4";
            m_SubmitButton.Text = "-->";
        }

    }
}
