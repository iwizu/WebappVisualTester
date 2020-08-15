using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium.DevTools.Network;
using WebappVisualTester.Models;

namespace WebappVisualTester.CommandUserControls
{
    public partial class SelectElementUC : UserControl
    {
        public SelectElementUC()
        {
            InitializeComponent();
        }
        public FindElement GetData()
        {
            return new FindElement()
            {
                FindBy = cmbFindBy.Text,
                FindByValue = txtType.Text,
                 Wait=Convert.ToInt32(txtWait.Text),
                 ScrollToElement=chkScrollToElement.Checked
        };
        }

        public void SetData(FindElement data)
        {
            cmbFindBy.Text = data.FindBy;
            txtType.Text = data.FindByValue;
            txtWait.Text = data.Wait.ToString();
            chkScrollToElement.Checked = data.ScrollToElement;
        }

        private void cmbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelType.Text= cmbFindBy.Text;
        }
    }
}
