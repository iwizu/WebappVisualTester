using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Models
{
    public class Project
    {
        public Project()
        {
            Id =Guid.NewGuid();
            Tests = new List<Test>();
        }
        public Guid Id { get; set; }
        public List<Test> Tests { get; set; }
        public string _type => GetType().Name;
    }
}
