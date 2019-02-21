using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRover
{
	public class Battery : Attachment
	{
		private int _power;

		public Battery() : base()
		{
			this.Name += " Battery";
			_power = 100;
		}

		public void AttachDevice(Device d)
		{
			d.Battery = this;
		}

		public int Power
		{
			get { return _power;}
			set { _power = value;}
		}
	} 
}
