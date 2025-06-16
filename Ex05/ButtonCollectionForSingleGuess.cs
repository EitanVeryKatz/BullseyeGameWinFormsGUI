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
        private Button m_ChoiseButton1 = new Button();
        private Button m_ChoiseButton2 = new Button();
        private Button m_ChoiseButton3 = new Button();
        private Button m_ChoiseButton4 = new Button();

        private Button m_SubmitButton = new Button();

        private Button m_ResaultButton1 = new Button();
        private Button m_ResaultButton2 = new Button();
        private Button m_ResaultButton3 = new Button();
        private Button m_ResaultButton4 = new Button();

        public ButtonCollectionForSingleGuess(int i_Height, int i_left)
        {
            Buttons.Add(m_ChoiseButton1);
            Buttons.Add(m_ChoiseButton2);
            Buttons.Add(m_ChoiseButton3);
            Buttons.Add(m_ChoiseButton4);
            Buttons.Add(m_SubmitButton);
            Buttons.Add(m_ResaultButton1);
            Buttons.Add(m_ResaultButton2);
            Buttons.Add(m_ResaultButton3);
            Buttons.Add(m_ResaultButton4);

            m_ChoiseButton1.Left = i_left + 12;
            m_ChoiseButton2.Left = m_ChoiseButton1.Right + 1;
            m_ChoiseButton3.Left = m_ChoiseButton2.Right + 1;
            m_ChoiseButton4.Left = m_ChoiseButton3.Right + 1;
            m_SubmitButton.Left = m_ChoiseButton4.Right + 1;
            m_ResaultButton1.Left = m_SubmitButton.Right + 1;
            m_ResaultButton3.Left = m_ResaultButton1.Right + 1;
            m_ResaultButton2.Left = m_SubmitButton.Right + 1; 
            m_ResaultButton4.Left = m_ResaultButton1.Right + 1;

            m_ChoiseButton1.Top = i_Height + 1;
            m_ChoiseButton2.Top = i_Height + 1;
            m_ChoiseButton3.Top = i_Height + 1;
            m_ChoiseButton4.Top = i_Height + 1;
            m_SubmitButton.Top = i_Height + 1;
            m_ResaultButton1.Top = i_Height + 1;
            m_ResaultButton3.Top = i_Height + 1;
            m_ResaultButton2.Top = m_ResaultButton1.Bottom + 1;
            m_ResaultButton4.Top = m_ResaultButton1.Bottom + 1;

            m_ChoiseButton1.Width = 20;
            m_ChoiseButton2.Width = 20;
            m_ChoiseButton3.Width = 20;
            m_ChoiseButton4.Width = 20;
            m_SubmitButton.Width = 50;  
            m_ResaultButton1.Width = 20;
            m_ResaultButton2.Width = 20;
            m_ResaultButton3.Width = 20;
            m_ResaultButton4.Width = 20;

            m_ResaultButton1.Text = "1";
            m_ResaultButton2.Text = "2";
            m_ResaultButton3.Text = "3";
            m_ResaultButton4.Text = "4";
            m_SubmitButton.Text = "-->";
        }

    }
}
