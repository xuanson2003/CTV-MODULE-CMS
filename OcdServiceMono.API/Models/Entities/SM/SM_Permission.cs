using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OcdServiceMono.Lib.Models;
using System;

namespace OcdServiceMono.API.Models.Entities.SM
{
    [Table("SM_Permission")]
    public class SM_Permission : AuditEntity
    {
        //[Key]
        //public int PerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Descible { get; set; }
     
        public DateTime CreatedAt { get; set; }
     
        public DateTime UpdateAt { get; set; }

       


    }
}
