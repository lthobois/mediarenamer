using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MediaRenamer.Common
{
    public partial class InputDialog : Form
    {
        public String value = "";

        public InputDialog()
        {
            InputDialogConstruct("Enter your data", "Question:", "");
        }
        public InputDialog(String q)
        {
            InputDialogConstruct(q, "Question:", "");
        }
        public InputDialog(String q, String title)
        {
            InputDialogConstruct(q, title, "");
        }
        public InputDialog(String q, String title, String def)
        {
            InputDialogConstruct(q, title, def);
        }

        private void InputDialogConstruct(String q, String title, String def)
        {
            InitializeComponent();
            this.Text = title;
            this.question.Text = q;
            this.answerBox.Text = def;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.value = answerBox.Text;
        }
    }
}
