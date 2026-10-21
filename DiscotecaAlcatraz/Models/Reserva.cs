using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscotecaAlcatraz.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [StringLength(100)]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Selecciona un plan")]
        [StringLength(50)]
        public string TipoPlan { get; set; }

        [Range(1, 100,
            ErrorMessage = "La cantidad debe ser de 1 a 100")]
        public int NumeroPersonas { get; set; }

        public decimal ValorTotal { get; set; }

        public int EventoId { get; set; }

        public virtual Evento Evento { get; set; }

        public Reserva()
        {
            NombreCliente = "";
            TipoPlan = "";
        }
    }
}