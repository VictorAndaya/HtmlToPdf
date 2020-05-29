using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlToPdf
{
    class CreatePdf
    {
        public CreatePdf(string url, string namePdf)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "wkhtmltopdf/wkhtmltopdf.exe";

                ProcessStartInfo oProcessStartInfo = new ProcessStartInfo();
                oProcessStartInfo.UseShellExecute = false;
                oProcessStartInfo.FileName = path;
                oProcessStartInfo.Arguments = url + " " + namePdf+".pdf";

                using (Process oProcess = Process.Start(oProcessStartInfo))
                {
                    oProcess.WaitForExit();
                }
                MessageBox.Show("Su PDF a sido Creado","Archivo Creado",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
