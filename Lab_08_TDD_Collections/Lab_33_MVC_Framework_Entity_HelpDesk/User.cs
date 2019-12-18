namespace Lab_33_MVC_Framework_Entity_HelpDesk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
