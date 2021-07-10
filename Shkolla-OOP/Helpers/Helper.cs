using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shkolla_OOP
{
    class Helper
    {
        public static bool showMessage(bool response, string message)
        {
            if (response == true)
            {
                MessageBox.Show(message);
                return true;
            }
            else
                MessageBox.Show("Ka ndodhur nje gabim, ju lutem provoni perseri.");

            return false;
        }

        public static void showMessage(bool response, string successMessage, string errorMessage)
        {
            if (response == true)
                MessageBox.Show(successMessage);
            else
                MessageBox.Show(errorMessage);
        }
    }
}
