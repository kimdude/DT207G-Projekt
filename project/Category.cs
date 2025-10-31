/* Klass för kategorier */

using questions;
namespace categories {

    public class Category
    {
        public string? Name
        {
            get; set;
        }
        
        public List<Question> CategorizedQuestions { get; set; } = new List<Question>();
    }
}