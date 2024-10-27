using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class App : Form
    {
        private string filepath;
        private const string APP_NAME = "Text Editor";
        private bool textChanged = false;
        private bool readFromFile = false;
        private string textToPrint;

        public App()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new App());
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textChanged)
            {
                DialogResult result = MessageBox.Show(
                    "Your file is not saved. Would you like to still open a file?",
                    "Open File", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Document | *.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        filepath = ofd.FileName;
                        Text = APP_NAME + " - " + filepath;
                        readFromFile = true;
                        textChanged = false;
                        Task<string> text = sr.ReadToEndAsync();
                        textBox.Text = text.Result;
                    }
                }
            }
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text Document | *.txt";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        filepath = sfd.FileName;
                        Text = APP_NAME + " - " + filepath;
                        textChanged = false;
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            await sw.WriteAsync(textBox.Text);
                        }
                    }
                }
            }
            else
            {
                Text = APP_NAME + " - " + filepath;
                textChanged = false;
                using (StreamWriter sw = new StreamWriter(filepath))
                {
                    await sw.WriteAsync(textBox.Text);
                }
            }
        }

        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Document | *.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(filepath))
                    {
                        filepath = sfd.FileName;
                        Text = APP_NAME + " - " + filepath;
                    }

                    if (filepath == sfd.FileName)
                    {
                        Text = APP_NAME + " - " + filepath;
                        textChanged = false;
                    }

                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        await sw.WriteAsync(textBox.Text);
                    }
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog pd = new PrintDialog())
            {
                pd.Document = new PrintDocument();
                textToPrint = textBox.Text;
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    pd.Document.PrintPage += new PrintPageEventHandler(onPrintPage);
                    pd.Document.Print();
                }
            }
        }

        private void onPrintPage(object source, PrintPageEventArgs args)
        {
            Font printFont = new Font("Times New Roman", 12);

            int charactersOnPage = 0;
            int linesPerPage = 0;

            args.Graphics.MeasureString(textToPrint, printFont, args.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            args.Graphics.DrawString(textToPrint, printFont, Brushes.Black, args.MarginBounds,
                StringFormat.GenericTypographic);
            textToPrint = textToPrint.Substring(charactersOnPage);

            args.HasMorePages = (textToPrint.Length > 0);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox.CanUndo)
            {
                textBox.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox.CanRedo)
            {
                textBox.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox.SelectedText != "")
            {
                Clipboard.SetText(textBox.SelectedText);
                textBox.SelectedText = "";
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox.SelectedText != "")
            {
                Clipboard.SetText(textBox.SelectedText);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                if (textBox.SelectedText != "")
                {
                    textBox.SelectedText = Clipboard.GetText();
                }
                else
                {
                    textBox.Text = textBox.Text.Insert(textBox.SelectionStart, Clipboard.GetText());
                }
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About("\u00a9 2024 Yu\n\nThanks\nPedro Ferreira");
            about.ShowDialog();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (readFromFile)
            {
                readFromFile = false;
                return;
            }
            
            if (!textChanged)
            {
                textChanged = true;
                Text = Text + " [Not Saved]";
            }
        }

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!textChanged)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                "Your file is not saved. Would you like to still exit?",
                "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                return;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}