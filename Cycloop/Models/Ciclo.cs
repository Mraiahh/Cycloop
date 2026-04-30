using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycloop.Models
{
    class Ciclo
    {
       // [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public int Duracao { get; set; }
        public string Intensidade { get; set; } 
        public string Sintomas { get; set; }
    }
}
