using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schools
{
    public partial class Director
    {
        public Director()
        {
            School = new HashSet<School>();
        }

        public Guid Primarykey { get; set; }
        public string Fio { get; set; }

        public virtual ICollection<School> School { get; set; }
    }
}
