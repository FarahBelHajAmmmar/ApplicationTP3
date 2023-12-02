using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ApplicationTP3_second_.Models
{
	public class Movies
	{
		public int Id { get; set; }
		public String? Name { get; set; }
		public String ?ImageURL { get; set; }
		public DateTime DateAdded { get; set; }
		[NotMapped]
		[Required(ErrorMessage = "Please choose Front Image")]
		public IFormFile ?FrontImage { get; set; }
		//cle 
		public String ?genres_Id { get; set; }


		//proprite de naviagation
		public ICollection<Customers> ?Customers { get; set; }
		public Genres Genres { get; set; }

	}
}
