/* Lösning för projektuppgift */

//SKAPA VIOLET FIL !!!!!!!!!

namespace quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("      QUIZ ME      ");
                Console.WriteLine("-------------------\n\n");

                Console.WriteLine("1. Start quiz");
                Console.WriteLine("2. Edit quiz");
                Console.WriteLine("3. Exit quiz");

                char menuChoice = Console.ReadKey().KeyChar;

                switch (menuChoice)
                {
                    case '1':
                        Console.WriteLine("Choose category: \n");
                        Console.WriteLine("1. History");
                        Console.WriteLine("2. Geography");
                        Console.WriteLine("3. Pop culture");
                        Console.WriteLine("4. Food and drink");

                        char quizCategory = Console.ReadKey().KeyChar;

                        //Skapa egen fil för quiz metoder

                        break;

                    case '2':
                        Console.WriteLine("Choose category: \n");
                        Console.WriteLine("1. History");
                        Console.WriteLine("2. Geography");
                        Console.WriteLine("3. Pop culture");
                        Console.WriteLine("4. Food and drink");

                        char editCategory = Console.ReadKey().KeyChar;

                        //Läs ut alla frågor och svar med index

                        Console.WriteLine("\nChoose measure: \n");
                        Console.WriteLine("1. Add question");
                        Console.WriteLine("2. Delete question");
                        Console.WriteLine("3. Edit question");

                        char edit = Console.ReadKey().KeyChar;

                        if (edit == '1')
                        {
                            Console.WriteLine("\n State question: ");
                            string? newQuestion = Console.ReadLine();

                            Console.WriteLine("\n State answer: ");
                            string? newAnswer = Console.ReadLine();

                            Console.WriteLine("Question added! Press any button to continue."); //Lägg till kontroll
                            Console.ReadKey();

                        }
                        else if (edit == '2')
                        {
                            Console.WriteLine("\n State index of question: ");
                            Console.ReadKey();

                            Console.WriteLine("Question deleted! Press any button to continue."); //Lägg till kontroll 
                            Console.ReadKey();

                        }
                        else if (edit == '3')
                        {
                            Console.WriteLine("\n State question: ");
                            string? editQuestion = Console.ReadLine();

                            Console.WriteLine("\n State answer: ");
                            string? editAnswer = Console.ReadLine();

                            Console.WriteLine("Question updated! Press any button to continue."); //Lägg till kontroll 
                            Console.ReadKey();

                        }
                        else
                        {
                            //Lägg till kontroll
                        }

                        break;

                    case '3':
                        Environment.Exit(0);
                        break;

                }
            }
        }
    }
}