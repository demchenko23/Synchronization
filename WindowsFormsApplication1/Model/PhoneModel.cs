namespace Synchronization.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phone")]
    public partial class PhoneModel
    {
        public PhoneModel()
        {
            Computers = new HashSet<ComputerModel>();
        }

        [Key]
        public int IdPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public virtual ICollection<ComputerModel> Computers { get; set; }
    }
}
