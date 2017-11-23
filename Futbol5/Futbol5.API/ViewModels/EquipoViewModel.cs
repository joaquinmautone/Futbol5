using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol5.API.ViewModels
{
    public class EquipoViewModel
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public int CampeonatoId { get; set; }
        public IEnumerable<JugadorViewModel> Jugadores { get; set; }
    }
}
