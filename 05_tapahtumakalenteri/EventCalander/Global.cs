using EventCalander;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EventCalander
{
	public class Event
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string Location { get; set; }
		public int CategoryId { get; set; }
		public int CreatedBy { get; set; }
	}

	public class Category
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}

	public class User
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string Role { get; set; }
	}
}

