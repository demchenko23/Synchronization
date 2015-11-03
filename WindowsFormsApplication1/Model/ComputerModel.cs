namespace Synchronization.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Computer")]
    public partial class ComputerModel
    {
        public ComputerModel()
        {
            Phones = new HashSet<PhoneModel>();
        }

        [Key]
        public int IdComp { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public virtual ICollection<PhoneModel> Phones { get; set; }
    }
}
