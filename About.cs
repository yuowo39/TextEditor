using System;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class About : Form
    {
        public About(string copyright)
        {
            InitializeComponent();
            lbCopyright.Text = copyright;
        }

        private void lbCopyright_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void About_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbVersion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbProduct_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}