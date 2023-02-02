using System;
namespace BEŞİKTAŞ_KÜTÜPHANE
{
	public class Section
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public int LibraryFloorId { get; set; }
        public int WorkerId { get; set; }

        public Worker Worker { get; set; }
        public LibraryFloor LibraryFloor { get; set; }
        public List<BookSection> BookSections { get; set; }

    }
}

