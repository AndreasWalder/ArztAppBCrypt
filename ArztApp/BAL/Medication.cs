using System;
using System.Collections.Generic;

namespace ArztApp.BAL
{
    public partial class Medication
    {
        public Medication()
        {
            VisitMedications = new HashSet<VisitMedication>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<VisitMedication> VisitMedications { get; set; }
    }
}
