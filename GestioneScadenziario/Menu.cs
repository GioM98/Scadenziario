using GestioneScadenziario.Models;
using LinqToExcel;
using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace GestioneScadenziario
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            aData.Value = DateTime.Now;
            daData.Value = DateTime.Now;
        }

        private void btnEsportaScadenziario_Click(object sender, EventArgs e)
        {
            string filePath = "";
            string fileNames = "";
            List<Scadenziario> scadenziarioList = null;
            List<Fornitore> fornitori = null;
            try
            {

                Period monthDifference = Period.Between(LocalDateTime.FromDateTime(DateTime.Parse(daData.Text)), LocalDateTime.FromDateTime(DateTime.Parse(aData.Text)));
                var months = monthDifference.Months;

                filePath = ConfigurationManager.AppSettings["fileFolderPath"];
                fileNames = ConfigurationManager.AppSettings["filesName"];

                if (filePath != "")
                {
                    string[] files = System.IO.Directory.GetFiles(filePath, "Forn_SAP.xlsx");
                    if (files.Count() > 0)
                    {
                        var excel = new ExcelQueryFactory(files[0]);
                        fornitori = (from c in excel.Worksheet<Fornitore>("Foglio1")
                                               //where c.ragSociale == "IN"
                                               select c).ToList();
                        var a = fornitori.Count();
                    }
                    files = System.IO.Directory.GetFiles(filePath, "Scad_SAP.xlsx");
                    if (files.Count() > 0)
                    {
                        var excel = new ExcelQueryFactory(files[0]);
                        scadenziarioList = (from c in excel.Worksheet<Scadenziario>("Foglio1")
                                                    //where c.ragSociale == "IN"
                                                select c).ToList();
                        var a = scadenziarioList.Count();
                    }
                }
                String outputPath = "C:\\Users\\Utente\\Desktop\\Scadenziario\\Test.xlsx";

                Excel.Application ex = new Excel.Application();
                Excel.Workbook workbook = ex.Workbooks.Add(Type.Missing);
                Excel.Worksheet sheet = (Excel.Worksheet)workbook.ActiveSheet;

                ((Excel.Range)sheet.Cells[1, 1]).Value = "F=Fattura O=Ordine C=Carico";
                ((Excel.Range)sheet.Cells[1, 2]).Value = "Data Registr.";
                ((Excel.Range)sheet.Cells[1, 3]).Value = "Nr. Fattura Nr. Ordine";
                ((Excel.Range)sheet.Cells[1, 4]).Value = "Data Fatt. Data Cons. Data Carico";
                ((Excel.Range)sheet.Cells[1, 5]).Value = "Codice";
                ((Excel.Range)sheet.Cells[1, 6]).Value = "Nome";
                ((Excel.Range)sheet.Cells[1, 7]).Value = "Tipo Fornitura";
                ((Excel.Range)sheet.Cells[1, 8]).Value = "Paese";
                ((Excel.Range)sheet.Cells[1, 9]).Value = "Fattura bloccata";
                ((Excel.Range)sheet.Cells[1, 10]).Value = "Data Scadenza";
                ((Excel.Range)sheet.Cells[1, 11]).Value = "Divisa";
                ((Excel.Range)sheet.Cells[1, 12]).Value = "Importo";
                ((Excel.Range)sheet.Cells[1, 13]).Value = "Modalità di  Pagamento";

                DateTime aDataDoc = DateTime.Parse("31/12/2019");
                DateTime daDataDoc = DateTime.Parse("01/12/2019");

                var scadenziarioTemp = scadenziarioList.Where(x => x.dataDocumento >= daDataDoc && x.dataDocumento <= aDataDoc).GroupBy(x => x.ragSociale).ToList();
                var scadenziarioTipiForn = fornitori.Select(x => x).GroupBy(x => x.tipoForn).ToList();
                int r = 2;
                foreach (var a in scadenziarioTemp)
                {
                    var current = scadenziarioList.Where(x => (x.dataDocumento >= daDataDoc && x.dataDocumento <= aDataDoc) && x.ragSociale == a.Key).ToList();
                    float totale = 0.0f;

                    foreach (var q in current)
                    {
                        int c = 1;
                        ((Excel.Range)sheet.Cells[r, c]).Value = "F";
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = q.dataReg;
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = q.numDocumento;
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = q.dataDocumento;
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = q.codFornitore;
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = q.ragSociale;
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = "";
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = "ITALIA";
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = "";
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = "";
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = q.divisa;
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = q.importo;
                        c++;
                        ((Excel.Range)sheet.Cells[r, c]).Value = "";
                        c++;
                        totale += float.Parse(q.importo);

                        switch (q.modalitaPagamento)
                        {
                            case "P":
                                ((Excel.Range)sheet.Rows[r]).Interior.Color = System.Drawing.Color.LightGreen;
                                break;
                            case "S":
                                ((Excel.Range)sheet.Rows[r]).Interior.Color = System.Drawing.Color.Orange;
                                break;
                            case "C":
                                ((Excel.Range)sheet.Rows[r]).Interior.Color = System.Drawing.Color.DeepSkyBlue;
                                break;
                            case "B":
                                ((Excel.Range)sheet.Rows[r]).Interior.Color = System.Drawing.Color.Red;
                                break;
                            case "D":
                                ((Excel.Range)sheet.Rows[r]).Interior.Color = System.Drawing.Color.Violet;
                                break;
                            default:
                                Console.WriteLine("Default case");
                                break;
                        }

                        r++;
                    }
                    ((Excel.Range)sheet.Cells[r, 7]).Value = $"Totale {a.Key}";
                    ((Excel.Range)sheet.Cells[r, 7]).Font.Bold = true;
                    ((Excel.Range)sheet.Cells[r, 12]).Value = totale;
                    ((Excel.Range)sheet.Cells[r, 12]).Font.Bold = true;
                    r++;
                }

                var b = scadenziarioTemp.Count();
                workbook.SaveAs(outputPath);
                workbook.Close();
                ex.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore : {ex.Message.ToString()}");
            }
        }
    }
}
