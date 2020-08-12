using System;

namespace WebappVisualTester.Models
{
    public class TakeScreenshotCommand : Command
    {
        public override ICommand GetClone()
        {
            return new TakeScreenshotCommand
            {
                Id = Guid.NewGuid(),
                OrderIndex = this.OrderIndex,
                Title = this.Title,
                BelongsToCommandIndex = this.BelongsToCommandIndex
            };
        }
    }
}
