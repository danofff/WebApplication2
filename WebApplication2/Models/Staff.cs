using System.Web.Mvc;

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
     
        [HiddenInput(DisplayValue = false)]
        public int StaffId { get; set; }

        [Required]
        public string FullName { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        
        public string Description { get; set; }

       
        public string ImageUrl { get; set; }

       
    }
}
