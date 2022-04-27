using System;
using System.Collections.Generic;

namespace ArztApp.BAL
{
    public partial class VisitMedication
    {
        public int Id { get; set; }
        public int VisitId { get; set; }
        public int MedicationId { get; set; }

        public virtual Medication Medication { get; set; } = null!;
        public virtual Visit Visit { get; set; } = null!;
    }
}
