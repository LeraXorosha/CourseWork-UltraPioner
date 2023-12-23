using System.ComponentModel.DataAnnotations;

namespace UltraPioner.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Введен неверный логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введен неверный пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


	}
}
