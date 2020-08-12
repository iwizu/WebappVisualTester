using System;

namespace WebappVisualTester.Models
{
    public class ClickButtonCommand : Command
    {
        public string ButtonType { get; set; }
        public string ButtonId { get; set; }
        public string ButtonClass { get; set; }
        public override ICommand GetClone()
        {
            return new ClickButtonCommand
            {
                Id = Guid.NewGuid(),
                OrderIndex = this.OrderIndex,
                Title = this.Title,
                BelongsToCommandIndex = this.BelongsToCommandIndex,
                 ButtonClass=this.ButtonClass,
                 ButtonId=this.ButtonId,
                  ButtonType=this.ButtonType
            };
        }
    }
}
