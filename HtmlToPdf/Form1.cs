using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HtmlToPdf
{
    public partial class Form1 : Form
    {
        string path = @"C:\Users\daniel\source\repos\HtmlToPdf\HtmlToPdf\bin\Debug\";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreatePdf oCreatePdf = new CreatePdf(txtUrl.Text,txtName.Text);
            txtUrl.Text = txtName.Text = string.Empty;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileSystemWatcher1.Path = path;
            GetFiles();
        }
        private void GetFiles()
        {
            string[] lst = Directory.GetFiles(path);
            textBox1.Text = "";
            foreach (var sFile  in lst)
            {
                if(Path.GetExtension(sFile) == ".pdf")
                    textBox1.Text += sFile + Environment.NewLine;
            }
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            GetFiles();
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            GetFiles();
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            GetFiles();
        }

        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            GetFiles();
        }
    }
}
