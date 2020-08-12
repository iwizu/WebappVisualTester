using System;
using System.Windows.Forms;
using WebappVisualTester.Models;

namespace WebappVisualTester
{
    public partial class EditCommand : Form
    {
        IProjectManager projectManager;
        EditTest parentForm;
        ICommand command;
        Test test;

        public EditCommand(ICommand command, Test test, EditTest parentForm,IProjectManager projectManager)
        {
            InitializeComponent();
            this.test = test;
            this.command = command;
            this.parentForm = parentForm;
            this.projectManager = projectManager;
        }
        public void CloseForm()
        {
            this.Close();
        }

        private void cmbCommandType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            if (cmbCommandType.Text== "Take Screenshot")
            {
                if (command == null || command.OrderIndex == 0)
                {
                    command = new TakeScreenshotCommand();
                }
                var cmd = DependencyInjector.Resolve<TakeScreenshotCommandUC>(new { command = command, test = test, parentForm = parentForm, mainCommandForm = this, projectManager = projectManager });
                if (cmd != null)
                {
                    panel1.Controls.Add(cmd);
                    cmd.Dock = DockStyle.Fill;
                }
            }
            else if (cmbCommandType.Text == "Navigate to URL")
            {
                if(command==null||command.OrderIndex==0)
                {
                    command = new NavigateToUrlCommand();
                }
                var cmd = DependencyInjector.Resolve<NavigateToUrlCommandUC>(new { command=command,test = test, parentForm = parentForm, mainCommandForm=this, projectManager = projectManager });
                if (cmd != null)
                {
                    panel1.Controls.Add(cmd);
                    cmd.Dock = DockStyle.Fill;
                }
            }
            else if (cmbCommandType.Text == "Fill Input (type text)")
            {
                if (command == null || command.OrderIndex == 0)
                {
                    command = new FillTextboxCommand();
                }
                var cmd = DependencyInjector.Resolve<FillTextboxCommandUC>(new { command = command, test = test, parentForm = parentForm, mainCommandForm = this, projectManager = projectManager });
                if (cmd != null)
                {
                    panel1.Controls.Add(cmd);
                    cmd.Dock = DockStyle.Fill;
                }
            }
            else if (cmbCommandType.Text == "Click button")
            {
                if (command == null || command.OrderIndex == 0)
                {
                    command = new ClickButtonCommand();
                }
                var cmd = DependencyInjector.Resolve<ClickButtonCommandUC>(new { command = command, test = test, parentForm = parentForm, mainCommandForm = this, projectManager = projectManager });
                if (cmd != null)
                {
                    panel1.Controls.Add(cmd);
                    cmd.Dock = DockStyle.Fill;
                }
            }
            else if (cmbCommandType.Text == "If contains string")
            {
                if (command == null || command.OrderIndex == 0)
                {
                    command = new IfContainsStringCommand();
                }
                var cmd = DependencyInjector.Resolve<IfContainsStringCommandUC>(new { command = command, test = test, parentForm = parentForm, mainCommandForm = this, projectManager = projectManager });
                if (cmd != null)
                {
                    panel1.Controls.Add(cmd);
                    cmd.Dock = DockStyle.Fill;
                }
            }
        }
        public string GetTitle()
        {
            return txtTitle.Text;
        }
        private void EditCommand_Load(object sender, EventArgs e)
        {
            if(command!=null&&command.OrderIndex>0)
            {
                txtTitle.Text = command.Title;
                if (command.GetType().Equals(typeof(NavigateToUrlCommand)))
                {
                    cmbCommandType.Text = "Navigate to URL";
                    cmbCommandType_SelectedIndexChanged(null, null);
                }
                else if (command.GetType().Equals(typeof(TakeScreenshotCommand)))
                {
                    cmbCommandType.Text = "Take Screenshot";
                    cmbCommandType_SelectedIndexChanged(null, null);
                }
                else if (command.GetType().Equals(typeof(IfContainsStringCommand)))
                {
                    cmbCommandType.Text = "If contains string";
                    cmbCommandType_SelectedIndexChanged(null, null);
                }
                else if (command.GetType().Equals(typeof(FillTextboxCommand)))
                {
                    cmbCommandType.Text = "Fill Input (type text)";
                    cmbCommandType_SelectedIndexChanged(null, null);
                }
                else if (command.GetType().Equals(typeof(ClickButtonCommand)))
                {
                    cmbCommandType.Text = "Click button";
                    cmbCommandType_SelectedIndexChanged(null, null);
                }
            }
        }
    }
}
