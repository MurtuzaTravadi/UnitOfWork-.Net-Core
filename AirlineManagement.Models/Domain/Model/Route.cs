using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineManagement.Models.Domain.Model
{
    public class Route
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateModified { get; set; }
        public int ModifiedBy { get; set; }


        public Airline Airlines { get; set; }
        public Airport Airports { get; set; }
    }
}