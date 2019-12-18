namespace Lab_26_MVC1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Spartan
    {
        public int SpartanID { get; set; }

        [StringLength(6)]
        public string TitleOfCourtesy { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string University { get; set; }

        [StringLength(50)]
        public string Course { get; set; }

        [StringLength(5)]
        public string MarkAchieved { get; set; }
    }
}
