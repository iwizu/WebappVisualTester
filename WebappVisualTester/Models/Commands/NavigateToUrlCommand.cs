using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Models
{
    public class NavigateToUrlCommand : Command
    {

        public string Url { get; set; }
        public override ICommand GetClone()
        {
            return new NavigateToUrlCommand
            {
                Id = Guid.NewGuid(),
                OrderIndex = this.OrderIndex,
                Title = this.Title,
                BelongsToCommandIndex = this.BelongsToCommandIndex,
                Url = this.Url
            };
        }
    }
}
