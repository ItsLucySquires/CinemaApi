using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApi.Data.Models
{
    public class Seat
    {
        public Guid Id { get; set; }
        public Screen Screen { get; set; }
        public string Row { get; set; }
        public int Number { get; set; }
    }
}
