using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Cycloop.Models
{
    public class Ciclo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public int DuracaoDias { get; set; }
        public string IntensidadeFluxo { get; set; } 
        public string NivelColica { get; set; }

        public string CorSangue { get; set; }

        public string Sintomas { get; set; }
    }
}
