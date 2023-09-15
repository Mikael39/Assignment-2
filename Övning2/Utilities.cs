using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning2
{
    internal class Utilities
    {
        //metod i utilities klassen som används för att säkerställa att input inte är nullvärde eller whitespace. en bool initieras och en string initieras.
        //do while loopen repeteras så länge inte success sätts till true i else statementet. I consol efterfrågas en string baserat på prompten som skickats med 
        //från anropande metod. if stringen är null eller whitespace meddelas användaren att input inte är valid, därefter efterfrågas en korrekt input baserad
        //    på skickad prompt string. och  loopen repeteras. är input valid så sätts success till true och inputen returneras.
        public static string AskForString(string prompt)
        {

            bool success = false;
            string answer;

            do
            {
                Console.WriteLine($"Enter {prompt}: ");
                answer = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine($"You must enter a valid {prompt}");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
                         
        }

        //metod som validerar en string till uint, en string (prompt) har skickats till metoden. stringen skickas till AskForString för att säkerställa
        //Attribute det inte är ett whitespace eller nullvärde, därefter kollas via if loopen at det verkligen är ett intvärde, därefter returneras det. om det inte
        //är ett intvärde repeteras loopen och användaren bes om ett korrekt värde
        public static uint AskForUInt(string prompt)
        {
            do
            {
                string input = AskForString(prompt);

                if (uint.TryParse(input, out uint result))
                {
                    return result;
                }
                Console.WriteLine($"You must enter a valid {prompt}");
            } while (true);
        }
        
        //beräkning av kostnad beroende på värdet på variabeln age som skickats från anropande metod. 
        public static uint CalculateTicketPrice(uint age)
        {
            if (age < 20 && age > 4)
            {
                return 80;
            }
            else if (age > 64 && age < 100)
            {
                return 90;
            }
            else if (age >= 20 && age <= 64)
            {
                return 120;
            }
            else
            {
                return 0;
            }
        // åldersgrupp assignas beroende på värdet på variabeln age som skickats från anropande metod. 
        }
        public static string DetermineAgeGroup(uint age)
        {
            if (age < 20 && age > 4)
            {
                return "Ungdomspris";
            }
            else if (age > 64 && age < 100)
            {
                return "Pensionärspris";
            }
            else if (age >= 20 && age <= 64)
            {
                return "Standardpris";
            }
            else if (age > 100)
            {
                return "100+ pris";
            }
            else
            {
                return "barnpris";
            }

        }


    }
}
