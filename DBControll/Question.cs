using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBControll
{
    public class Question
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }

        public Question(string content)
        {
            Content = content;
            Answers = new List<Answer>();
        }
    }
}
