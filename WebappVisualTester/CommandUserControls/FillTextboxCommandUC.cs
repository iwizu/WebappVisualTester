﻿using System;
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
    public partial class FillTextboxCommandUC : UserControl
    {
        IProjectManager projectManager;
        public FillTextboxCommand command;
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
           var cmds= test.commands.Where(i => i._type.Contains(nameof(IfContainsStringCommand))).OrderBy(i => i.OrderIndex).Select(i=>new { Index=i.OrderIndex,Title= i.OrderIndex+":"+i.Title }).ToList();
            comboBox1.DataSource = cmds;
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "Index";
            comboBox1.SelectedIndex = -1;
        }
        private void Save()
        {
            if (parentForm != null)
            {
                if (command == null || command.OrderIndex == 0)
                {
                    command = new FillTextboxCommand();
                    command.Title = mainCommandForm.GetTitle();
                    command.Id = txtId.Text;
                    command.Class = txtClass.Text;
                    command.Text = txtText.Text;
                    int? belongToIndex = comboBox1.SelectedValue as int?;
                    if (belongToIndex.HasValue)
                        command.BelongsToCommandIndex = belongToIndex;
                    else
                        command.BelongsToCommandIndex = null;
                    command.OrderIndex = 1;
                    if (test.commands.Any())
                    {
                        command.OrderIndex = test.commands.Max(i => i.OrderIndex) + 1;
                    }
                    test.commands.Add(command);
                }
                else
                {
                    command.Title = mainCommandForm.GetTitle();
                    command.Id = txtId.Text;
                    command.Class = txtClass.Text;
                    command.Text = txtText.Text;                    
                    int? belongToIndex = comboBox1.SelectedValue as int?;
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
                txtId.Text= command.Id;
                txtClass.Text = command.Class;
                txtText.Text = command.Text;
                if (command.BelongsToCommandIndex.HasValue)
                    comboBox1.SelectedValue = command.BelongsToCommandIndex;
                else
                    comboBox1.SelectedIndex = -1;
            }
            
        }
    }
}
