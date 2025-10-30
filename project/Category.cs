/* Klass för kategorier */

using System.Text.Json;
using questions;
namespace categories {
    //Klass för kategorier
    public class Category
    {
        private string filename = @"quiz.json";

        //Lista med alla frågor och kategorier
        public List<Question> allQuestions = new List<Question>();

        //List med alla frågor inom kategorin
        public List<Question> Quiz { get; set; } = new();

        //Kontrollerar json-fil
        public Category()
        {
            if (File.Exists(filename) == true)
            {
                string fileContent = File.ReadAllText(filename);
                allQuestions = JsonSerializer.Deserialize<List<Question>>(fileContent)!;
            }
        }

        //CRUD till json-fil
    }

}