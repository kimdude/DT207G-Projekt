/* Lösning för projektuppgift - Quiz */

//SKAPA VIOLET FIL !!!!!!!!!

using categories;
using categoryManager;
using questions;
using quizManager;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryManager categoryManager = new CategoryManager();
            QuizManager quizManager = new QuizManager();

            List<Category> allCategories = categoryManager.GetQuestions();

            //Loop för meny
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("====================================");
                Console.WriteLine("              QUIZ ME               ");
                Console.WriteLine("====================================\n\n");
                Console.ResetColor();

                //Startmeny
                Console.WriteLine("1. Start quiz");
                Console.WriteLine("2. Edit quiz");
                Console.WriteLine("3. Exit quiz");

                char menuChoice = Console.ReadKey().KeyChar;

                switch (menuChoice)
                {
                    case '1':

                        //Val för att spela quizzet
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\nChoose category: \n");
                        Console.ResetColor();

                        //Listar kategorier
                        for (int i = 0; i < allCategories.Count; i++)
                        {
                            Console.WriteLine(i + ". " + allCategories[i].Name);
                        }

                        char quizCatChar = Console.ReadKey().KeyChar;
                        int quizCategory = quizCatChar - '0'; //Omvandlar char till int

                        //Skapar quiz med 5 slumpmässiga frågor
                        List<Question> quiz = quizManager.CreateQuiz(quizCategory);
                        int points = 0;

                        for (int i = 0; i < quiz.Count; i++)
                        {
                            //Läser ut frågor
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"\n\n{quiz[i].Query}");
                            Console.ResetColor();
                            string? userAnswer = Console.ReadLine();

                            //Rättar svar
                            bool correct = quizManager.CorrectingQuiz(i, userAnswer!);                          //Lägg till kontroll

                            //Räknar poäng
                            if (correct == true)
                            {
                                points++;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nCorrect!");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\nWrong. Correct answer:\n{quiz[i].Answer}");
                                Console.ResetColor();
                                Console.WriteLine("\nPress any button to continue.");
                                Console.ReadKey();
                            }

                        }

                        //Läser ut resultat
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"\nYou got {points}/{quiz.Count} points!");
                        Console.ResetColor();
                        Console.WriteLine("Press any button to continue.");
                        Console.ReadKey();

                        break;

                    case '2':

                        //Val för att redigera quizzet
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\nChoose category: \n");
                        Console.ResetColor();

                        //Listar alla kategorier
                        for (int i = 0; i < allCategories.Count; i++)
                        {
                            Console.WriteLine(i + ". " + allCategories[i].Name);
                        }

                        char catIndexChar = Console.ReadKey().KeyChar;
                        int catIndex = catIndexChar - '0';


                        //Kontroll för korrekt menyval
                        if (catIndex != 1 | catIndex != 2 | catIndex != 3)
                        {
                            Console.WriteLine("\n\nInvalid input. Choose option 1, 2 or 3. Press any button to continue.");
                            Console.ReadKey();
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\nAll questions in this category: ");
                        Console.ResetColor();

                        //Listar frågor och svar
                        for (int i = 0; i < allCategories[catIndex].CategorizedQuestions.Count; i++)
                        {
                            Console.WriteLine($"{i}. {allCategories[catIndex].CategorizedQuestions[i].Query} {allCategories[catIndex].CategorizedQuestions[i].Answer}.");
                        }

                        Console.WriteLine("\nPress any button to continue.");
                        Console.ReadKey();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\nChoose measure: \n");
                        Console.ResetColor();

                        //Menyval för redigering
                        Console.WriteLine("1. Add question");
                        Console.WriteLine("2. Delete question");
                        Console.WriteLine("3. Edit question");

                        char edit = Console.ReadKey().KeyChar;

                        if (edit == '1')
                        {

                            //Funktionalitet för att lägga till ny fråga
                            Console.WriteLine("\n\nState question: ");
                            string? newQuestion = Console.ReadLine();

                            Console.WriteLine("\nState answer: ");
                            string? newAnswer = Console.ReadLine();

                            //Lägger till ny fråga
                            categoryManager.AddQuestion(catIndex, newQuestion!, newAnswer!);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nQuestion added! Press any button to continue."); //Lägg till kontroll
                            Console.ResetColor();
                            Console.ReadKey();

                        }
                        else if (edit == '2')
                        {

                            //Funktionalitet för att ta bort fråga
                            Console.WriteLine("\n\nState index of question: ");
                            char questIndexChar = Console.ReadKey().KeyChar;
                            int questIndex = questIndexChar - '0';

                            //Tar bort fråga
                            categoryManager.DeleteQuestion(catIndex, questIndex);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nQuestion deleted! Press any button to continue.");                 //Lägg till kontroll 
                            Console.ResetColor();
                            Console.ReadKey();

                        }
                        else if (edit == '3')
                        {

                            //Funktionalitet för att ändra fråga
                            Console.WriteLine("\n\nState index of question: ");                                     //Lägg till kontroll 
                            char questIndexChar = Console.ReadKey().KeyChar;
                            int questIndex = questIndexChar - '0';

                            Console.WriteLine("\n\nState question: ");                                              //Lägg till kontroll 
                            string? editQuestion = Console.ReadLine();

                            Console.WriteLine("\nState answer: ");                                                  //Lägg till kontroll 
                            string? editAnswer = Console.ReadLine();

                            //Uppdaterar fråga
                            categoryManager.UpdateQuestion(catIndex, questIndex, editQuestion!, editAnswer!);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\nQuestion updated! Press any button to continue.");               //Lägg till kontroll 
                            Console.ResetColor();
                            Console.ReadKey();

                        }

                        break;

                    case '3':

                        //Lämnar quizzet
                        Environment.Exit(0);
                        break;

                    default:

                        //Kontroll för korrekt menyval
                        Console.WriteLine("\n\nInvalid input. Choose option 1, 2 or 3. Press any button to continue.");
                        Console.ReadKey();
                        break;

                }
            }
        }
    }
}