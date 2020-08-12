using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Models
{
    public class Test
    {
        public Test()
        {
            Id = Guid.NewGuid();
            commands = new List<Command>();
        }

        public Guid Id { get; set; }

        public int OrderIndex { get; set; }

        public string Title { get; set; }

        public List<Command> commands { get; set; }
        public string _type => GetType().Name;
    }
}
