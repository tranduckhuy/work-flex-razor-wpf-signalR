﻿namespace WorkFlex.Web.ViewModels
{
    public class RegisterVM
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password {  get; set; } = null!;
        
        public string RePassword { get; set; } = null!;
    }
}
