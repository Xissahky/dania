using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    class Utils
    {
        public static int GetUserChoice(int min, int max)
        {
            int choice;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
                    return choice;
                else
                    Console.WriteLine("Nieprawidłowe dane. Proszę wprowadzić liczbę od {0} do {1}.", min, max);
            }
        }
    }
}
