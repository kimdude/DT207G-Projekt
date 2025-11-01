/* Metoder för kategorier */

using categories;
using System.Text.Json;
using questions;
namespace categoryManager
{
    public class CategoryManager {
        private string filename = @"quiz.json";

        //Lista för samtliga kategorier och frågor
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
        //Hämtar alla kategorier
        public List<Category> GetQuestions()
        {
            return allCategories;
        }

        //Tar emot kategorins index, fråga och svar för att lägga till ny fråga
        public Question AddQuestion(int catIndex, string question, string answer)
        {   
            //Skapar nytt fråge-objekt
            Question newQuestion = new Question();
            newQuestion.Query = question;
            newQuestion.Answer = answer;

            //Lägger till objektet i kategorin
            allCategories[catIndex].CategorizedQuestions.Add(newQuestion);
            serialize(); //Serialiserar uppdaterade listan

            return newQuestion;
        }

        //Tar emot kategorins och frågans index för att ta bort frågan
        public int DeleteQuestion(int catIndex, int questIndex)
        {
            allCategories[catIndex].CategorizedQuestions.RemoveAt(questIndex);
            serialize();

            return questIndex;
        }

        //Tar emot kategorins och frågans index, fråga och svar för att uppdatera frågan
        public Question UpdateQuestion(int catIndex, int questIndex, string question, string answer)
        {
            Question updatedQuestion = new Question();
            updatedQuestion.Query = question;
            updatedQuestion.Answer = answer;
            allCategories[catIndex].CategorizedQuestions[questIndex] = updatedQuestion; //Byter ut gamla frågan till nya objektet

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