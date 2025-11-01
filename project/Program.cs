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

            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("====================================");
                Console.WriteLine("              QUIZ ME               ");
                Console.WriteLine("====================================\n\n");
                Console.ResetColor();

                Console.WriteLine("1. Start quiz");
                Console.WriteLine("2. Edit quiz");
                Console.WriteLine("3. Exit quiz");

                char menuChoice = Console.ReadKey().KeyChar;

                switch (menuChoice)
                {
                    case '1':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\nChoose category: \n");
                        Console.ResetColor();

                        for(int i = 0; i < allCategories.Count; i++)
                        {
                            Console.WriteLine( i + ". " + allCategories[i].Name);
                        }

                        char quizCatChar = Console.ReadKey().KeyChar;
                        int quizCategory = quizCatChar - '0';

                        List<Question> quiz = quizManager.CreateQuiz(quizCategory);
                        int points = 0;

                        for(int i = 0; i < quiz.Count; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"\n\n{quiz[i].Query}");
                            Console.ResetColor();
                            string? userAnswer = Console.ReadLine();

                            bool correct = quizManager.CorrectingQuiz(i, userAnswer!); //Lägg till kontroll

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

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"\nYou got {points}/{quiz.Count} points!");
                        Console.ResetColor();
                        Console.WriteLine("Press any button to continue.");
                        Console.ReadKey();

                        break;

                    case '2':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\nChoose category: \n");
                        Console.ResetColor();

                        for(int i = 0; i < allCategories.Count; i++)
                        {
                            Console.WriteLine( i + ". " + allCategories[i].Name);
                        }

                        char catIndexChar = Console.ReadKey().KeyChar;
                        int catIndex = catIndexChar - '0';

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\nAll questions in this category: ");
                        Console.ResetColor();

                        for (int i = 0; i < allCategories[catIndex].CategorizedQuestions.Count; i++)
                        {
                            Console.WriteLine($"{i}. {allCategories[catIndex].CategorizedQuestions[i].Query} {allCategories[catIndex].CategorizedQuestions[i].Answer}.");
                        }

                        Console.WriteLine("\nPress any button to continue.");
                        Console.ReadKey();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\nChoose measure: \n");
                        Console.ResetColor();

                        Console.WriteLine("1. Add question");
                        Console.WriteLine("2. Delete question");
                        Console.WriteLine("3. Edit question");

                        char edit = Console.ReadKey().KeyChar;

                        if (edit == '1')
                        {
                            Console.WriteLine("\n\nState question: ");
                            string? newQuestion = Console.ReadLine();

                            Console.WriteLine("\nState answer: ");
                            string? newAnswer = Console.ReadLine();

                            categoryManager.AddQuestion(catIndex, newQuestion!, newAnswer!);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nQuestion added! Press any button to continue."); //Lägg till kontroll
                            Console.ResetColor();
                            Console.ReadKey();

                        }
                        else if (edit == '2')
                        {
                            Console.WriteLine("\n\nState index of question: ");
                            char questIndexChar = Console.ReadKey().KeyChar;
                            int questIndex = questIndexChar - '0';

                            categoryManager.DeleteQuestion(catIndex, questIndex);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nQuestion deleted! Press any button to continue."); //Lägg till kontroll 
                            Console.ResetColor();
                            Console.ReadKey();

                        }
                        else if (edit == '3')
                        {

                            Console.WriteLine("\n\nState index of question: "); //Lägg till kontroll 
                            char questIndexChar = Console.ReadKey().KeyChar;
                            int questIndex = questIndexChar - '0';

                            Console.WriteLine("\n\nState question: "); //Lägg till kontroll 
                            string? editQuestion = Console.ReadLine();

                            Console.WriteLine("\nState answer: "); //Lägg till kontroll 
                            string? editAnswer = Console.ReadLine();

                            categoryManager.UpdateQuestion(catIndex, questIndex, editQuestion!, editAnswer!);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\nQuestion updated! Press any button to continue."); //Lägg till kontroll 
                            Console.ResetColor();
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