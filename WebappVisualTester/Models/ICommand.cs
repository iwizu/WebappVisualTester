using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Models
{
    public interface ICommand
    {
        public Guid Id { get; set; }
        public int OrderIndex { get; set; }
        public string Title { get; set; }

    }
}
