using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schools
{
    public partial class School
    {
        public Guid Primarykey { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public Guid? Director { get; set; }

        public virtual Director DirectorNavigation { get; set; }
    }
}
