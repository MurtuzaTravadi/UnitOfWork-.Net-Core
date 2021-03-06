﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineManagement.Models.Domain.Model
{
    public class Airline
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateModified { get; set; }
        public int ModifiedBy { get; set; }

        public ICollection<Route> Enrollments { get; set; }
    }
}