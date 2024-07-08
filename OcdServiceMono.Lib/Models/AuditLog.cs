﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OcdServiceMono.Lib.Models
{
    public class AuditLog
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string TableName { get; set; }
        public string Type { get; set; }
        public string ObjectId { get; set; }
        public string OldObject { get; set; }
        public string NewObject { get; set; }
        public DateTime DateTime { get; set; }
    }
}
