/* Metoder för quiz funktionalitet */

using categories;
using categoryManager;
using questions;

namespace quizManager
{
    public class QuizManager
    {
        CategoryManager manager = new CategoryManager();
        Random random = new Random();

        public List<Category> allQuestions = new List<Category>();
        public List<Question> randomQuestions = new List<Question>();

        public List<Question> CreateQuiz(int catIndex)
        {
            randomQuestions.Clear();
            allQuestions = manager.GetQuestions();
            
            List<Question> catQuestions = allQuestions[catIndex].CategorizedQuestions;

            //Randomisera 5st frågor och lägg i list randomQuestions
            List<int> intsArray = new List<int>();

            for (int i = 0; intsArray.Count < 5; i++)
            {
                int newInt = random.Next(0, catQuestions.Count);

                if (!intsArray.Contains(newInt))
                {
                    intsArray.Add(newInt);
                }
            }
            
            //Använd intsArray som index för frågor
            for(int i = 0; i < 5; i++)
            {
                int questionIndex = intsArray[i];
                Question addQuestion = catQuestions[questionIndex];

                randomQuestions.Add(addQuestion);
            }

            return randomQuestions;
        }

        public bool CorrectingQuiz(int questIndex, string userAnswer)
        {

            if(userAnswer.ToUpper() == randomQuestions[questIndex].Answer!.ToUpper()) //Ändra till randomQuestions[questIndex].Answer!
            {
                return true;

            } else
            {
                return false;
            }
        }

    }
}