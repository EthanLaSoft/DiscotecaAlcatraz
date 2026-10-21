using System.Collections.Generic;

namespace DiscotecaAlcatraz.Models
{
    public class InicioViewModel
    {
        public List<Evento> Eventos { get; set; }

        public List<Reserva> Reservas { get; set; }

        public InicioViewModel()
        {
            Eventos = new List<Evento>();
            Reservas = new List<Reserva>();
        }
    }
}