﻿using System.ComponentModel.DataAnnotations;

namespace SCT.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }
        public string? Role { get; set; }
        public Guid? UserId { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
