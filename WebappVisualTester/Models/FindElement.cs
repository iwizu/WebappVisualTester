using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Models
{
    public class FindElement
    {
        public string FindBy { get; set; }
        public string FindByValue { get; set; }
        public int Wait { get; set; }
        public bool ScrollToElement { get; set; }
    }
}
