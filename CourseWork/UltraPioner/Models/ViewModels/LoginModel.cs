﻿using System.ComponentModel.DataAnnotations;

namespace UltraPioner.Models.ViewModels
{
    public class LoginModel
    {
		[Required(ErrorMessage = "Incorrect login given")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Incorrect password given")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

	}
}
