using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscotecaAlcatraz.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        [StringLength(50)]
        public string Genero { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [Range(1, 100000,
            ErrorMessage = "El aforo debe ser mayor que cero")]
        public int Aforo { get; set; }

        [Required]
        [StringLength(30)]
        public string Estado { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }

        public Evento()
        {
            Nombre = "";
            Genero = "";
            Estado = "Programado";
            Reservas = new HashSet<Reserva>();
        }
    }
}