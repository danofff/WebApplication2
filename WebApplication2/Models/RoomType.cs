using System.Web.Mvc;

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoomType")]
    public partial class RoomType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        [HiddenInput(DisplayValue = false)]
        public int RoomTypeId { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Тип комнаты")]
        public string Name { get; set; }

        [StringLength(1000)]
        [Display(Name = "Описание комнаты")]
        [Required(ErrorMessage = "Описание комнаты обязательно!!!")]
        public string RoomTypeDescription { get; set; }

        [Required]
        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public int? Price { get; set; }

        [StringLength(1000)]
        [DataType(DataType.Url)]
        public string Imagepath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
