using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbol5.Entities
{
    [Table("Equipos")]
    public class Equipo
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public int CampeonatoId { get; set; }
        public virtual ICollection<Jugador> Jugadores { get; set; }
    }
}
