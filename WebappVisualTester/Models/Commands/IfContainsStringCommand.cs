using System;

namespace WebappVisualTester.Models
{
    public class IfContainsStringCommand : Command
    {

        public string IfContainsString { get; set; }
        public override ICommand GetClone()
        {
            return new IfContainsStringCommand
            {
                Id = Guid.NewGuid(),
                OrderIndex = this.OrderIndex,
                Title = this.Title,
                BelongsToCommandIndex = this.BelongsToCommandIndex,
                IfContainsString = this.IfContainsString
            };
        }
    }
}
