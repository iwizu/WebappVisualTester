using System;

namespace WebappVisualTester.Models
{
    public class SelectFromDropdownCommand : Command
    {
        public string FindBy { get; set; }
        public string FindByValue { get; set; }
        public int Wait { get; set; }
        public bool ScrollToElement { get; set; }

        public string SelectByTextValue { get; set; }
        public string SelectedValue { get; set; }
        public override ICommand GetClone()
        {
            return new SelectFromDropdownCommand
            {
                Id = Guid.NewGuid(),
                OrderIndex = this.OrderIndex,
                Title = this.Title,
                BelongsToCommandIndex = this.BelongsToCommandIndex,
                SelectByTextValue=this.SelectByTextValue,
                SelectedValue = this.SelectedValue,
                FindBy = this.FindBy,
                FindByValue = this.FindByValue,
                Wait = this.Wait,
                ScrollToElement = this.ScrollToElement
            };
        }
    }
}
