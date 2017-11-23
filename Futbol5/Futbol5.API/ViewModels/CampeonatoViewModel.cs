using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol5.API.ViewModels
{
    public class CampeonatoViewModel
    {
        public int CampeonatoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public IEnumerable<EquipoViewModel> Equipos { get; set; }
    }
}
