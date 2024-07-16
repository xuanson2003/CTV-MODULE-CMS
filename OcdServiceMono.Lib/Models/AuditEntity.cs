using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OcdServiceMono.Lib.Core;
using OcdServiceMono.Lib.Enums;
using OcdServiceMono.Lib.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcdServiceMono.Lib.Models
{
    abstract public class AuditEntity
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(55)]
        [Comment("Tài khoản khởi tạo")]
        [JsonIgnore]
        public string CreatedBy { get; set; }

        [Comment("Ngày khởi tạo")]
        [JsonIgnore]
        public DateTimeOffset? CreatedDateTime { get; set; }

        [StringLength(55)]
        [Comment("Tài khoản cập nhập lần cuối")]
        [JsonIgnore]
        public string UpdatedBy { get; set; }

        [Comment("Ngày cập nhập lần cuối")]
        [JsonIgnore]
        public DateTimeOffset? UpdatedDateTime { get; set; }

        [Comment("Ngày xóa lần cuối")]
        [JsonIgnore]
        public DateTimeOffset? DeleteAt { get; set; }
    }
}
