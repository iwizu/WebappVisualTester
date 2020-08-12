using System;

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
