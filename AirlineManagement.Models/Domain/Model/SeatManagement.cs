using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineManagement.Models.Domain.Model
{
    public class SeatManagement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TotalSeat { get; set; }
        public int? RouteId { get; set; }
        public int? AvalibaleSeat { get; set; }
        public int? BookSeat { get; set; }
        public int? Price { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DateModify { get; set; }
        public int? ModifiedBy { get; set; }

     
    }
}