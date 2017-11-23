using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Futbol5.Entities
{
    [Table("Jugadores")]
    public class Jugador
    {
        public int JugadorId { get; set; }
        public string Nombre { get; set; }
        public bool Capitan { get; set; }
        public int EquipoId { get; set; }
    }
}
