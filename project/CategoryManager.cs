/* Metoder för kategorier */

using categories;
using System.Text.Json;
using questions;
namespace categoryManager
{
    public class CategoryManager {
        private string filename = @"quiz.json";

        //Lista med alla frågor inom kategorin
        public List<Category> allCategories = new List<Category>();

        //Kontrollerar json-fil
        public CategoryManager()
        {
            if (File.Exists(filename) == true)
            {
                string fileContent = File.ReadAllText(filename);
                allCategories = JsonSerializer.Deserialize<List<Category>>(fileContent)!;
            }
        }

        /* CRUD till JSON-fil */
        //Lägger till ny fråga
        public List<Category> GetQuestions()
        {
            return allCategories;
        }

        public Question AddQuestion(int catIndex, string question, string answer)
        {
            Question newQuestion = new Question();
            newQuestion.Query = question; 
            newQuestion.Answer = answer;

            allCategories[catIndex].CategorizedQuestions.Add(newQuestion);
            serialize();

            return newQuestion;
        }

        //Tar bort fråga
        public int DeleteQuestion(int catIndex, int questIndex)
        {
            allCategories[catIndex].CategorizedQuestions.RemoveAt(questIndex);
            serialize();

            return questIndex;
        }

        //Uppdaterar fråga
        public Question UpdateQuestion(int catIndex, int questIndex, string question, string answer)
        {
            Question updatedQuestion = new Question();
            updatedQuestion.Query = question;
            updatedQuestion.Answer = answer;
            allCategories[catIndex].CategorizedQuestions[questIndex] = updatedQuestion;

            serialize();

            return updatedQuestion;
        }

        //Serialiserar listan och lagrar i json-fil
        private void serialize()
        {
            string jsonString = JsonSerializer.Serialize(allCategories);
            File.WriteAllText(filename, jsonString);
        }

    }
}