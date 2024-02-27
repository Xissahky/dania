using cinema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        KinoTeatr kinoTeatr = new KinoTeatr();
        while (true)
        {
            Console.WriteLine("Wybierz działanie:");
            Console.WriteLine("1. Zaloguj się");
            Console.WriteLine("2. Zarejestruj nowe konto");
            Console.WriteLine("3. Zobacz listę sesji");
            Console.WriteLine("4. Wyjdź");

            int choice = Utils.GetUserChoice(1, 4);

            switch (choice)
            {
                case 1:
                    kinoTeatr.Login();
                    break;
                case 2:
                    kinoTeatr.Register();
                    break;
                case 3:
                    kinoTeatr.DisplaySchedule();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                
            }
        }
    }

    
}







