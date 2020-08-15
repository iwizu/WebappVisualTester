using System;

namespace WebappVisualTester.Models
{
    public class FillTextboxCommand : Command
    {
        public string FindBy { get; set; }
        public string FindByValue { get; set; }
        public int Wait { get; set; }
        public bool ScrollToElement { get; set; }

        public string Text { get; set; }

        public override ICommand GetClone()
        {
            return new FillTextboxCommand
            {
                Id = Guid.NewGuid(),
                OrderIndex = this.OrderIndex,
                Title = this.Title,
                BelongsToCommandIndex = this.BelongsToCommandIndex,          
                Text = this.Text,
                FindBy = this.FindBy,
                FindByValue = this.FindByValue,
                Wait = this.Wait,
                ScrollToElement = this.ScrollToElement
            };
        }
    }
}
