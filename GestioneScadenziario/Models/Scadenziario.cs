using LinqToExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneScadenziario.Models
{
    public class Scadenziario
    {
        [ExcelColumn("Fornitore")]
        public string codFornitore { get; set; }

        [ExcelColumn("Cognome 1")]
        public string ragSociale { get; set; }

        [ExcelColumn("Tipo di documento")]
        public string tipoDocumento { get; set; }

        [ExcelColumn("Numero documento")]
        public string numDocumento { get; set; }

        [ExcelColumn("Riferimento")]
        public string riferimento { get; set; }

        [ExcelColumn("Blocco pagamento")]
        public string bloccoPagamento { get; set; }

        [ExcelColumn("Mdpag")]
        public string modalitaPagamento { get; set; }

        [ExcelColumn("Testo")]
        public string testo { get; set; }

        [ExcelColumn("Data di reg.")]
        public string dataReg { get; set; }

        [ExcelColumn("Data documento")]
        public DateTime dataDocumento { get; set; }

        [ExcelColumn("Scadenza al netto")]
        public string scadenzaNetta { get; set; }

        [ExcelColumn("Importo divisa estera")]
        public string importoEstero { get; set; }

        [ExcelColumn("Divisa")]
        public string divisa { get; set; }

        [ExcelColumn("Importo in dare/avere")]
        public string importo { get; set; }
    }
}
