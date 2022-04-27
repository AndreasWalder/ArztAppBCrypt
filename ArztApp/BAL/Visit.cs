using System;
using System.Collections.Generic;

namespace ArztApp.BAL
{
    public partial class Visit
    {
        public Visit()
        {
            VisitMedications = new HashSet<VisitMedication>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string DiagnosticReport { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;
        public virtual ICollection<VisitMedication> VisitMedications { get; set; }
    }
}
