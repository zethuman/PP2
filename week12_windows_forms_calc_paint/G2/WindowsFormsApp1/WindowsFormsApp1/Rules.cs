using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Rules
    {
        public static bool IsDigit(String text)
        {
            String[] digits = new String[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return digits.Contains(text);
        }

        public static bool IsNonZeroDigit(String text)
        {
            String[] digits = new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return digits.Contains(text);
        }

        public static bool IsOperation(String text)
        {
            String[] digits = new String[] { "+", "-", "*", "/", "%" };
            return digits.Contains(text);
        }

        public static bool IsEqual(String text)
        {
            return text == "=";
        }
    }
}
