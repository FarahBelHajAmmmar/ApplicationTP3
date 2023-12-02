namespace ApplicationTP3_second_.Models
{
	public class Membershiptypes
	{
		public int Id { get; set;}
		public float Signupfee { get; set; }
		public float DurationInMonth { get; set; }
		public float DiscountRate { get; set;}
		
		//propriete de navigation
		public ICollection<Customers> ?Customers { get; set; }


	}
}
