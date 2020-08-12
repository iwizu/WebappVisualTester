using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Models
{
    public class FillTextboxCommand : Command
    {
        public string Id { get; set; }
        public string Class { get; set; }
        public string Text { get; set; }


    }
}
