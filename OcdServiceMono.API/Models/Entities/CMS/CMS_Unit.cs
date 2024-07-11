using OcdServiceMono.Lib.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcdServiceMono.API.Models.Entities.CMS
{
    [Table("CMS_Unit")]
    public class CMS_Unit : AuditEntity
    {
        [Required]
        [MaxLength(55)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string CertificationCode { get; set; }

        public bool Active { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime ExpDate { get; set; }

        [MaxLength(100)]
        public string CerField { get; set; }

        [MaxLength(100)]
        public string Standard { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string District { get; set; }

        [MaxLength(100)]
        public string Commune { get; set; }

        [MaxLength(100)]
        public string SpecificAddress { get; set; }
    }
}
