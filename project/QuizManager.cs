/* Metoder för quiz funktionalitet */

using System.Text.RegularExpressions;
using categories;
using categoryManager;
using questions;

namespace quizManager
{
    public class QuizManager
    {
        //Skapar instanser
        CategoryManager manager = new CategoryManager();
        Random random = new Random();

        public List<Category> allQuestions = new List<Category>(); //Lista med samtliga kategorier
        public List<Question> randomQuestions = new List<Question>(); //Lista med fem slumpmässiga frågor

        //Tar emot index för vald kategori och skapar quiz
        public List<Question> CreateQuiz(int catIndex)
        {
            randomQuestions.Clear(); //Tömmer lista på gamla frågor
            allQuestions = manager.GetQuestions(); //Hämtar samtliga frågor och kategorier

            List<Question> catQuestions = allQuestions[catIndex].CategorizedQuestions; //Hämtar samtliga frågor inom vald kategori

            List<int> intsArray = new List<int>(); //Skapar ny lista för fem slumpmässiga siffror som blir index för frågor

            for (int i = 0; intsArray.Count < 5; i++)
            {
                int newInt = random.Next(0, catQuestions.Count);  //Skapar slumpmässig siffra mellan 0 och längden på listan med frågor inom kategorin.

                //Kontrollerar att inga dublett siffror genereras
                if (!intsArray.Contains(newInt))
                {
                    intsArray.Add(newInt);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                //Använder slumpmässigt genererade siffror som index på frågor
                int questionIndex = intsArray[i];
                Question addQuestion = catQuestions[questionIndex];

                //Lägger till utvalda frågor i aktuell lista för quizzet
                randomQuestions.Add(addQuestion);
            }

            return randomQuestions;
        }

        //Tar emot index på fråga och använderns svar och returnerar true för korrekt, respektive false för fel svar
        public bool CorrectingQuiz(int questIndex, string userAnswer)
        {

            string userInput = userAnswer.Replace(",", " ").Replace("-", " ").Replace(".", " ").Replace(":", " ").Replace(";", " ").ToUpper(); //Ersätter tecken med mellanslag i svaret
            List<string> userList = Regex.Split(userInput, @"\s+").ToList(); //Splittrar vid varje mellanslag och lägger in varje ord i en lista

            string correctAnswer = randomQuestions[questIndex].Answer!.Replace(",", " ").Replace("-", " ").Replace(".", " ").Replace(":", " ").Replace(";", " ").ToUpper(); 
            List<string> correctList = Regex.Split(correctAnswer, @"\s+").ToList();

            //Kontrollerar att alla ord från användarens svar finns med i listan för korrekt svar
            for (int i = 0; i < userList.Count; i++)
            {
                if (!correctList.Contains(userList[i]))
                {
                    return false;
                }
            }

            return true;
        }

    }
}