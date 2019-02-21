using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRover
{
	public class Specimen : PlanetObject
	{
		private int _size;

		public Specimen() : base()
		{
			_size = rnd.Next(1, 10);
			List<string> _scientist = new List<string> { "Steve", "Gregor", "Xena", "Oak", "Juniper" };
			List<string> _ore = new List<string> { "Iron", "Gold", "Diamond", "Uranium", "Cheese" };
			_name = (_scientist[rnd.Next(1, 5)] + ": " + _ore[rnd.Next(1, 5)]);
		}

		public int Size
		{
			get { return _size;}
		}
	}
}
