using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WebappVisualTester.Models;

namespace WebappVisualTester
{
    public partial class FillTextboxCommandUC : UserControl
    {
        IProjectManager projectManager;
        FillTextboxCommand command;
        Test test;
        EditTest parentForm;
        EditCommand mainCommandForm;

        public FillTextboxCommandUC(ICommand command, Test test, EditTest parentForm,EditCommand mainCommandForm,IProjectManager projectManager)
        {
            InitializeComponent();
            this.command = command as FillTextboxCommand;
            this.test = test;
            this.parentForm = parentForm;
            this.mainCommandForm = mainCommandForm;
            this.projectManager = projectManager;
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            if(parentForm!=null)
            {
                parentForm.RefreshCommands();
                mainCommandForm.Close();
            }

        }
        private void RefreshCommands()
        {
           var cmds= test.Commands.Where(i => i._type.Contains(nameof(IfContainsStringCommand))).OrderBy(i => i.OrderIndex)
                .Select(i=>new { Id=i.Id,Title= i.OrderIndex+":"+i.Title }).ToList();
            comboBox1.DataSource = cmds;
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedIndex = -1;
        }
        private void Save()
        {
            var selFindByUC = selectElementuc1.GetData();

            if (parentForm != null)
            {
                if (command == null || command.OrderIndex == 0)
                {
                    command = new FillTextboxCommand();
                    
                    command.OrderIndex = 1;
                    if (test.Commands.Any())
                    {
                        command.OrderIndex = test.Commands.Max(i => i.OrderIndex) + 1;
                    }
                    test.Commands.Add(command);
                }

                command.Title = mainCommandForm.GetTitle();
                command.Text = txtText.Text;
                command.FindBy = selFindByUC.FindBy;
                command.FindByValue = selFindByUC.FindBy;
                command.Wait = selFindByUC.Wait;
                command.ScrollToElement = selFindByUC.ScrollToElement;
                Guid? belongToIndex = comboBox1.SelectedValue as Guid?;
                if (belongToIndex.HasValue)
                    command.BelongsToCommandIndex = belongToIndex;
                else
                    command.BelongsToCommandIndex = null;
            }
            projectManager.SaveProject();
        }
       
        private void NavigateToUrlCommandUC_Load(object sender, EventArgs e)
        {
            RefreshCommands();
            if (command!=null && command.OrderIndex>0)
            {
                FindElement f = new FindElement()
                {
                    FindBy = command.FindBy,
                    FindByValue = command.FindByValue,
                    Wait = command.Wait,
                    ScrollToElement = command.ScrollToElement
                };
                selectElementuc1.SetData(f);

                txtText.Text = command.Text;
                if (command.BelongsToCommandIndex.HasValue)
                    comboBox1.SelectedValue = command.BelongsToCommandIndex;
                else
                    comboBox1.SelectedIndex = -1;
            }
            
        }
    }
}
