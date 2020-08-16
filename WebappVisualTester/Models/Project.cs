using System;
using System.Collections.Generic;

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
        public string Title { get; set; }
        public bool EnableCookies { get; set; }
        public string CookiesFolder { get; set; }
        public List<Test> Tests { get; set; }
        public string _type => GetType().Name;
    }
}
