using System.ComponentModel.DataAnnotations;

namespace CreativeFusions.Auth.Models
{
    public class LoginViewModel
    {
        #region Properties

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
        #endregion

        #region Constructors

        public LoginViewModel()
        {

        }

        public LoginViewModel(string returnUrl)
        {
            ReturnUrl = returnUrl;
        }
        #endregion
    }
}