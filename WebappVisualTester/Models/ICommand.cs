using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Models
{
    public interface ICommand
    {
        Guid Id { get; set; }
        int OrderIndex { get; set; }
        string Title { get; set; }
        Guid? BelongsToCommandIndex { get; set; }
        string _type { get; }
        ICommand GetClone();
    }
}
