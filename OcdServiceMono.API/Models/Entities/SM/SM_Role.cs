using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OcdServiceMono.Lib.Models;
using System;

namespace OcdServiceMono.API.Models.Entities.SM
{
    [Table("SM_Role")]
    public class SM_Role : AuditEntity
    {
        //[Key]
        //public int RoleId { get; set; }

        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; }

        public string Descible { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public bool Active { get; set; }




    }
}
