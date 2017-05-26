using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineManagement.Models.Domain.Model
{
    public class Transection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? AirlineId { get; set; }
        public int? AirportId { get; set; }
        public int? UserId { get; set; }
        public bool? Payment { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public int? ModifiedBy { get; set; }

       
    }
}