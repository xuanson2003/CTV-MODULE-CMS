using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OcdServiceMono.Lib.Models;
using System;

namespace OcdServiceMono.API.Models.Entities.SM
{
    [Table("SM_Accounts")]
    public class SM_Accounts : AuditEntity
    {
        //[Key]
        //public int AccId { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(255)]
        public string PassWord { get; set; }

        [MaxLength(255)]
        public string FullName { get; set; }

        [MaxLength(255)]
        public string Avatar { get; set; }

        [MaxLength(30)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(30)]
        public string CitizenCard { get; set; }

        public bool Active { get; set; }

        public DateTime CreateAt { get; set; }

        [MaxLength(50)]
        public string CreateBy { get; set; }


        // khóa ngoai
        //public int DepartmentId { get; set; }
        [Column("DepartmentId ")]
        public Guid DepartmentId { get; set; }
        [ForeignKey("Id")]
        public SM_Department SM_Department { get; set; }

        //public int RoleId { get; set; }
        [Column("RoleId ")]
        public Guid RoleId { get; set; }
        [ForeignKey("Id")]
        public SM_Role SM_Role { get; set; }

    }
}
