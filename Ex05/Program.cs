using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    public class Program
    {
        public static void Main()
        {
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.ShowDialog();
            try
            {
                MainGameWindow mainGameWindow = new MainGameWindow();
                mainGameWindow.ShowDialog();
            } catch (Exception)
            {
            }
        }
    }
}
