using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebappVisualTester.Models;

namespace WebappVisualTester
{
    public partial class ClickButtonCommandUC : UserControl
    {
        IProjectManager projectManager;
        public ClickButtonCommand command;
        Test test;
        EditTest parentForm;
        EditCommand mainCommandForm;

        public ClickButtonCommandUC(ICommand command, Test test, EditTest parentForm,EditCommand mainCommandForm,IProjectManager projectManager)
        {
            InitializeComponent();
            this.command = command as ClickButtonCommand;
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
            if (parentForm != null)
            {
                if (command == null || command.OrderIndex == 0)
                {
                    command = new ClickButtonCommand();
                    command.Title = mainCommandForm.GetTitle();
                    command.ButtonType = cmbType.Text;
                    command.ButtonId = txtId.Text;
                    command.ButtonClass = txtClass.Text;
                    Guid? belongToIndex = comboBox1.SelectedValue as Guid?;
                    if (belongToIndex.HasValue)
                        command.BelongsToCommandIndex = belongToIndex;
                    else
                        command.BelongsToCommandIndex = null;
                    command.OrderIndex = 1;
                    if (test.Commands.Any())
                    {
                        command.OrderIndex = test.Commands.Max(i => i.OrderIndex) + 1;
                    }
                    test.Commands.Add(command);
                }
                else
                {
                    command.Title = mainCommandForm.GetTitle();
                    command.ButtonType = cmbType.Text;
                    command.ButtonClass = txtClass.Text;
                    command.ButtonId = txtId.Text;
                    Guid? belongToIndex = comboBox1.SelectedValue as Guid?;
                    if (belongToIndex.HasValue)
                        command.BelongsToCommandIndex = belongToIndex;
                    else
                        command.BelongsToCommandIndex = null;
                }
            }
            projectManager.SaveProject();
        }
       
        private void NavigateToUrlCommandUC_Load(object sender, EventArgs e)
        {
            RefreshCommands();
            if (command!=null && command.OrderIndex>0)
            {
                txtId.Text= command.ButtonId;
                txtClass.Text = command.ButtonClass;
                cmbType.Text = command.ButtonType;
                if (command.BelongsToCommandIndex.HasValue)
                    comboBox1.SelectedValue = command.BelongsToCommandIndex;
                else
                    comboBox1.SelectedIndex = -1;
            }
            
        }
    }
}
