using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace SonarSNKRS.Forms
{
    public partial class ErrorForm : TemplateForm
    {
        

        public ErrorForm(string error, string desc)
        {
            InitializeComponent();
            metroTextBox1.Text = error;
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
