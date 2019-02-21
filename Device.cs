using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRover
{
	public abstract class Device : Attachment
	{
		Battery _battery;

		public abstract string Operate(Rover r);

		public Battery Battery
		{
			get
			{
				return _battery;
			}

			set
			{
				_battery = value;
			}
		}
	} 
}
