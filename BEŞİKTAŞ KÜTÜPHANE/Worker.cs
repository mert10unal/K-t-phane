using System;
namespace BEŞİKTAŞ_KÜTÜPHANE
{
	public class Worker
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double PhoneNumber { get; set; }
        public double Salary { get; set; }
     

        public List<Section> Sections { get; set; }
    }
}

