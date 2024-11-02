using System;
using System.Windows.Forms;
namespace PCSimSaveEditor
{
    public partial class InputDialog : Form
    {
        public string InputText { get; private set; }

        public InputDialog(string prompt)
        {
            InitializeComponent();
            clabel.Text = prompt;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            InputText = ctextbox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}