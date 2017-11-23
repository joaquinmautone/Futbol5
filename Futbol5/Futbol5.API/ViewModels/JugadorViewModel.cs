using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol5.API.ViewModels
{
    public class JugadorViewModel
    {
        public int JugadorId { get; set; }
        public string Nombre { get; set; }        
        public bool Capitan { get; set; }
        public int EquipoId { get; set; }
    }
}
