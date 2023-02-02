using System;
namespace BEŞİKTAŞ_KÜTÜPHANE
{
	public class BookSection
	{
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int BookId { get; set; }

        public Section Section { get; set; }
        public Book Book { get; set; }
    }
}

