using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol5.Entities
{
    [Table("Campeonatos")]
    public class Campeonato
    {
        public int CampeonatoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}
