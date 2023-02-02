using System;
namespace BEŞİKTAŞ_KÜTÜPHANE
{
	public class LibraryFloor
	{
		public int Id { get; set; }
		public float Area { get; set; }
		public string FloorType { get; set; }
		public double Capacity { get; set; }
		public string Nickname { get; set; }
		

		public List <Section> Sections { get; set; }

    }
}

