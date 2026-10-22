using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApi.Data.Models
{
    public class Screen
    {
        public Guid Id { get; set; }
        public Cinema Cinema { get; set; }
        public string Name { get; set; }
        public string TypeDescription { get; set; }
        public ICollection<Seat> Seats { get; set; }

    }
}
