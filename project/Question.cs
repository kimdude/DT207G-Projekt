/* Klass för frågor */

namespace questions
{
    public class Question
    {
        public string? Query
        {
            get; set;
        }
        public string? Answer
        {
            get; set;
        }
        public Boolean? Correct
        {
            get; set;
        }
    }
}