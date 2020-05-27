using System;
using System.Collections.Generic;
using System.Text;

namespace SagaPattern
{
    public class MySagaData
    {
        public string boo { get; set; }
        public String SpanishGreet { get; set; }
        public String EnglishGreet { get; set; }
        public String FrenchGreet { get; set; }
        public String GermanGreet { get; set; }
        public String RussianGreet { get; set; }
        public IList<int> Property2 { get; set; }
        public IDictionary<String, String> DirectoryContent { get; set; }
    }
}
