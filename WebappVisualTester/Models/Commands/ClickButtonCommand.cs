using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Models
{
    public class ClickButtonCommand : Command
    {
        public string ButtonType { get; set; }
        public string ButtonId { get; set; }
        public string ButtonClass { get; set; }

    }
}
