using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Models
{
    public class FillTextboxCommand : Command
    {
        public string ElementId { get; set; }
        public string Class { get; set; }
        public string Text { get; set; }

        public override ICommand GetClone()
        {
            return new FillTextboxCommand
            {
                Id = Guid.NewGuid(),
                OrderIndex = this.OrderIndex,
                Title = this.Title,
                BelongsToCommandIndex = this.BelongsToCommandIndex,
                Class = this.Class,
                Text = this.Text
            };
        }
    }
}
