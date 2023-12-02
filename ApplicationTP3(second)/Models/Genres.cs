namespace ApplicationTP3_second_.Models
{
	public class Genres
	{
		public String  Id { get; set; }
		public String? GenreName { get; set; }
		//propriete de naviagtion
		public ICollection<Movies> Movies { get; set;}
	}
}
