using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SonarSNKRS.Forms
{
    public partial class SetTimeFrm : TemplateForm
    {
        public MainForm form;
        public SetTimeFrm(MainForm frm)
        {
            InitializeComponent();
            form = frm;
        }

        private void SetTimeFrm_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            form.StartTime = dateTimePicker1.Value;
            this.Close();
        }
    }
}
