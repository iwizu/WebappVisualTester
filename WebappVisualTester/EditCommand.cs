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
            else if (cmbCommandType.Text == "Fill Input")
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
            else if (cmbCommandType.Text == "Click element")
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
            else if (cmbCommandType.Text == "Select option")
            {
                if (command == null || command.OrderIndex == 0)
                {
                    command = new SelectFromDropdownCommand();
                }
                var cmd = DependencyInjector.Resolve<SelectFromDropdownCommandUC>(new { command = command, test = test, parentForm = parentForm, mainCommandForm = this, projectManager = projectManager });
                if (cmd != null)
                {
                    panel1.Controls.Add(cmd);
                    cmd.Dock = DockStyle.Fill;
                }
            }
            else if (cmbCommandType.Text == "Scroll to element")
            {
                if (command == null || command.OrderIndex == 0)
                {
                    command = new ScrollToElementCommand();
                }
                var cmd = DependencyInjector.Resolve<ScrollToElementCommandUC>(new { command = command, test = test, parentForm = parentForm, mainCommandForm = this, projectManager = projectManager });
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
                    cmbCommandType.Text = "Fill Input";
                    cmbCommandType_SelectedIndexChanged(null, null);
                }
                else if (command.GetType().Equals(typeof(ClickButtonCommand)))
                {
                    cmbCommandType.Text = "Click element";
                    cmbCommandType_SelectedIndexChanged(null, null);
                }
                else if (command.GetType().Equals(typeof(SelectFromDropdownCommand)))
                {
                    cmbCommandType.Text = "Select option";
                    cmbCommandType_SelectedIndexChanged(null, null);
                }
                else if (command.GetType().Equals(typeof(ScrollToElementCommand)))
                {
                    cmbCommandType.Text = "Scroll to element";
                    cmbCommandType_SelectedIndexChanged(null, null);
                }
            }
        }
    }
}
