using System;
using System.Collections.Generic;
using System.Text;

namespace SagaPattern
{
    public class MySagaData
    {
        public String Property1 { get; set; }
        public IList<int> Property2 { get; set; }
        public IDictionary<String, String> DirectoryContent { get; set; }
    }
}
