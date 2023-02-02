using System;
namespace BEŞİKTAŞ_KÜTÜPHANE
{
	public class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public int PageNumber { get; set; }
		public DateTime PublishTime { get; set; }
		

		public List <Episode> Episodes { get; set; }
		public List <BookSection> BookSections { get; set; }
    }
}

