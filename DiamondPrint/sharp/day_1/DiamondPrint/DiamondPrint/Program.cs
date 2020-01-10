using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString;
            do
            {
                Console.Write("Enter a char A to Z : ");
                testString = Console.ReadLine();
                Console.WriteLine("You entered '{0}'", testString);
                if (testString.Length > 1)
                {
                    break;
                }
                char[] insertChar = testString.ToCharArray();
                if ('A' <= insertChar[0] && insertChar[0] <= 'Z')
                {
                    break;
                }
                string diamondString = (new Solution()).GetDiamondString(insertChar[0]);
                //string input = args[1];
                System.Console.WriteLine(diamondString);
            } while (true);

            Console.WriteLine("Exit program");

        }
    }
}
