using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OcdServiceMono.Lib.Models;
using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace OcdServiceMono.API.Models.Entities.SM
{
    [Table("SM_Menu")]
    public class SM_Menu : AuditEntity
    {
        //[Key]
     //   public int id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Url { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public int Order { get; set; }

        [MaxLength(100)]
        public string Icon { get; set; }

        public int Type { get; set; }

        public bool Active { get; set; }

        // Navigation property for child menus
        [JsonIgnore]
        public virtual ICollection<SM_Menu> ChildMenus { get; set; } = new List<SM_Menu>();
        
    }
}
