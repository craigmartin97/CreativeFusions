using System.ComponentModel.DataAnnotations;

namespace CreativeFusions.Auth.Models
{
    public class RegisterViewModel
    {
        #region Properties

        /// <summary>
        /// Email address of the user
        /// </summary>
        [Required, EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Users desired password
        /// </summary>
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// User must supply a name with at least two characters
        /// </summary>
        [Required, MinLength(2)]
        public string FullName { get; set; }

        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string ReturnUrl { get; set; }
        #endregion

        #region Constructors

        public RegisterViewModel()
        {

        }

        public RegisterViewModel(string returnUrl)
        {
            ReturnUrl = returnUrl;
        }
        #endregion    
    }
}