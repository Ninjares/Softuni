﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Excercise.Data.Models
{
    public class PatientMedicament
    {
        public int PatientId { get; set; }
        public int MedicamentId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Medicament Medicament { get; set; }
    }
}