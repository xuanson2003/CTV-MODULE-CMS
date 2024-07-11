using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OcdServiceMono.Lib.Models;
using System;

namespace OcdServiceMono.API.Models.Entities.SM
{
    [Table("SM_Department")]
    public class SM_Department : AuditEntity
    {
        //[Key]
        //public int DepartmentId { get; set; }

        [Required]
        [MaxLength(255)]
        public string DepartmentName { get; set; }

       


    }
}
