﻿using System.ComponentModel.DataAnnotations;
namespace UltraPioner.Models.ViewModels
{
	public class AdminTableModel
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public string Discription { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }

		public string Login { get; set; }
		public string RoleName { get; set; }
	}
}
