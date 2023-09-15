using System;
using System.Text.RegularExpressions;

namespace Övning2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
           
          // do loop som körs så länge input inte är noll, om de valbara värdena inte används skickas ett default meddelande till användaren. 
          // under class Menuhelpers anges värderna. Under varje case anropas en metod.
            do
            {
                ShowMainMeny();
                string selectedAction = Console.ReadLine()!;
                switch (selectedAction)
                {
                    case MenuHelpers.AgeGroup:
                        BookOneTicket();
                       break;
                    case MenuHelpers.Group:
                        BookMultipleTickets();
                        break;

                    case MenuHelpers.PrintTenTimes:
                        EchoTen();

                        break;

                    case MenuHelpers.ThirdWord:
                        ThirdWord();
                        
                        break;
                    
                    case MenuHelpers.Quit:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Input out of bounds, please select specified inputs: \n\n -Press Enter to Continue-");
                        Console.ReadLine();
                        break;
                }


            } while (true);

        }
        //Consolen rensas
        //Metod som anropas vid knapptryck 4, tar in input i form av text, undersöker så att det inte är nullvärde eller whitespace och sparar i en string.
        //trimmar sedan bort multipla mellanslag och ersätter med ett mellanslag. Därefter sparas varje ord i en array. i for loopen sätts startvärdet för i
        //till 3:e enheten i array, så länge i är mindre än längden på output arrayen,skrivs innehållet på plats i ut, därefter hoppar i 3 steg fram.
        //användaren får ett slutmedelande och en prompt för att komma tillbaka till Meny
        private static void ThirdWord()
        {
            Console.Clear();
            var input = Utilities.AskForString("Sentence: ");
            input = Regex.Replace(input, @"\s+", " ");
            string[] output = input.Split(' ');

            
            for (int i = 2; i < output.Length; i += 3)
            {
                Console.WriteLine(output[i]);
            }
            Console.WriteLine("\n\n -Press Enter to Continue-");
            Console.ReadLine();
        }

        //Consolen rensas
        //Metod som anropas vid knapptryck 3, tar in input i form av text, undersöker så att det inte är nullvärde eller whitespace och sparar i en string.
        //i sätts till noll och för varje iteration ökas i med 1, under iterationen skrivs användarens input + ett mellanslag på samma linje
        //användaren får ett slutmedelande och en prompt för att komma tillbaka till Meny
        private static void EchoTen()
        {
            Console.Clear();
            string input = Utilities.AskForString("Echo: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(input + " ");
            }
            Console.WriteLine("\n\n -Press Enter to Continue-");
            Console.ReadLine();

        }

        //Consolen rensas
        //N sätts till antal personer i sällskapet, summa initieras till 0, i initieras. Under for loopen sätts i till 1, och loopen itererar så länge i är mindre
        // eller likamed N, i ökas med 1. Under loopen ber vi användaren om ålder på varje person. Summa sätts till summa + resultatet av metoden CalculateTicketPrice
        //när vi skickar variabeln age. Efter att loopen gått igenom, skrivs sedan summa ut tillsammans med i som är antalet gånger loopen har körts.
        //användaren får ett slutmedelande och en prompt för att komma tillbaka till Meny
        private static void BookMultipleTickets()
        {
            Console.Clear();
            uint N = Utilities.AskForUInt("Number of people");
            uint sum = 0;
            int i;
            for (i = 1;  i <= N; i++)
            {
                uint age = Utilities.AskForUInt($"Age for person {i}");
                sum += Utilities.CalculateTicketPrice(age);               
            }
            Console.WriteLine($"Total cost is {sum} for {i} people\n\n -Press Enter to Continue");
            Console.ReadLine();
        }

        //Consolen rensas
        //variabeln age sätts genom anrop till metoden AskForUInt där samtidigt age verifieras att det inte är et nullvärde, variabeln age används sedan i två metoder för att 
        //beräknas kostnad och att tilldela grupptillhöriget. Därefter medelas användaren kostnad, grupptillhörighet och ålder
        //användaren får ett slutmedelande och en prompt för att komma tillbaka till Meny
        private static void BookOneTicket()
        {
            Console.Clear();
            uint age = Utilities.AskForUInt("Age");

            uint cost = Utilities.CalculateTicketPrice(age);
            
            string ageGroup = Utilities.DetermineAgeGroup(age);

            Console.WriteLine($"You have booked a ticket for {cost}kr which is {ageGroup}, since you are {age} years old\n\n -Press Enter to Continue-");
            Console.ReadLine();
        }

        //Consolen rensas, och en meny skrivs ut till användaren
        private static void ShowMainMeny()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the main menu, select options from Below\n");
            Console.WriteLine("1: Book a Single Ticket: ");
            Console.WriteLine("2: Book Group ticket: ");
            Console.WriteLine("3: Echo your words 10 times: ");
            Console.WriteLine("4: Write three words, the third will be repeated to you: ");
            Console.WriteLine("0 Exit");
        }
    }
}