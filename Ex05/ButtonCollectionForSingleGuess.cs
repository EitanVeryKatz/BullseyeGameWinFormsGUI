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
            Buttons.Add(m_ChoiceButton1);
            Buttons.Add(m_ChoiceButton2);
            Buttons.Add(m_ChoiceButton3);
            Buttons.Add(m_ChoiceButton4);
            Buttons.Add(m_SubmitButton);
            Buttons.Add(m_ResultButton1);
            Buttons.Add(m_ResultButton2);
            Buttons.Add(m_ResultButton3);
            Buttons.Add(m_ResultButton4);

            m_ChoiceButton1.Left = i_left + 12;
            m_ChoiceButton2.Left = m_ChoiceButton1.Right + 1;
            m_ChoiceButton3.Left = m_ChoiceButton2.Right + 1;
            m_ChoiceButton4.Left = m_ChoiceButton3.Right + 1;
            m_SubmitButton.Left = m_ChoiceButton4.Right + 1;
            m_ResultButton1.Left = m_SubmitButton.Right + 1;
            m_ResultButton3.Left = m_ResultButton1.Right + 1;
            m_ResultButton2.Left = m_SubmitButton.Right + 1; 
            m_ResultButton4.Left = m_ResultButton1.Right + 1;

            m_ChoiceButton1.Top = i_Height + 1;
            m_ChoiceButton2.Top = i_Height + 1;
            m_ChoiceButton3.Top = i_Height + 1;
            m_ChoiceButton4.Top = i_Height + 1;
            m_SubmitButton.Top = i_Height + 1;
            m_ResultButton1.Top = i_Height + 1;
            m_ResultButton3.Top = i_Height + 1;
            m_ResultButton2.Top = m_ResultButton1.Bottom + 1;
            m_ResultButton4.Top = m_ResultButton1.Bottom + 1;

            m_ChoiceButton1.Width = 20;
            m_ChoiceButton2.Width = 20;
            m_ChoiceButton3.Width = 20;
            m_ChoiceButton4.Width = 20;
            m_SubmitButton.Width = 50;  
            m_ResultButton1.Width = 20;
            m_ResultButton2.Width = 20;
            m_ResultButton3.Width = 20;
            m_ResultButton4.Width = 20;

            m_ResultButton1.Text = "1";
            m_ResultButton2.Text = "2";
            m_ResultButton3.Text = "3";
            m_ResultButton4.Text = "4";
            m_SubmitButton.Text = "-->";
        }

    }
}
