using CreativeFusions.Auth.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CreativeFusions.Auth.Data
{
    public sealed class AppUser : IdentityUser
    {
        #region Properties

        /// <summary>
        /// The users full name
        /// </summary>
        [Required, MinLength(2)]
        public string FullName { get; set; }
        #endregion

        #region Constructors

        public AppUser(string userName, string fullName, string phoneNumber)
            : base(userName)
        {
            Email = userName;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public AppUser(RegisterViewModel registerViewModel)
            : base(registerViewModel.Email)
        {
            Email = registerViewModel.Email;
            FullName = registerViewModel.FullName;
            PhoneNumber = registerViewModel.PhoneNumber;
        }
        #endregion
    }
}