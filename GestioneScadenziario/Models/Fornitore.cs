using LinqToExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneScadenziario.Models
{
    public class Fornitore
    {
        [ExcelColumn("CodFornitore")] //maps the "Name" property to the "Company Title" column
        public string codFornitore { get; set; }

        [ExcelColumn("Nome Fornitore")] //maps the "State" property to the "Providence" column
        public string ragSociale { get; set; }

        [ExcelColumn("Tipo Fornitore")] //maps the "Name" property to the "Company Title" column
        public string tipoForn { get; set; }
    }
}
