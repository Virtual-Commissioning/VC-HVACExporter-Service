using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVACExporter.Helpers
{
    public partial class PromptTokenForm : Form
    {
        public string userId;
        public string projectId;
        public string url;
        public PromptTokenForm()
        {
            InitializeComponent();
        }

        private void PromptToken_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            userId = userIdTextBox.Text;
            projectId = projectIdTextBox.Text;
            url = urlTextBox.Text;

            okButton.DialogResult = DialogResult.OK;

            Close();
            return;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancelButton.DialogResult = DialogResult.Cancel;

            Close();
            return;
        }
    }
}
