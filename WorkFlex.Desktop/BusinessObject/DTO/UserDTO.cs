﻿namespace WorkFlex.Desktop.BusinessObject.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; }
        public bool IsLock { get; set; }
        public bool IsActive { get; set; }
    }
}
