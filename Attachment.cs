using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRover
{
	public abstract class Attachment
	{
		string _name;
		protected static Random rnd = new Random();
		public Attachment()
		{
			List<string> _firstName = new List<string> { "Rusty", "Average", "Super", "Ultra", "Mega" };
			List<string> _middleName = new List<string> { "Alpha", "Megatron", "Neuro", "Sega", "Nintendo" };
			List<string> _lastName = new List<string> { "MKI", "MKII", "MKIII", "64", "2000" };
			_name = (_firstName[rnd.Next(5)] + _middleName[rnd.Next(5)] + _lastName[rnd.Next(5)]);
		}

		public String Name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
			}
		}
	}
}
