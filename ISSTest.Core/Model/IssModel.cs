using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSTest.Core.Model
{
    public class IssModel
    {
        public IssPosition iss_position { get; set; }
        public string message { get; set; }
        public int timestamp { get; set; }
        public string note { get; set; }
    }
}
