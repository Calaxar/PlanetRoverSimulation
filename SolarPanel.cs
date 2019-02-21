using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRover
{
	public class SolarPanel : Device
	{
		public SolarPanel() : base()
		{
			this.Name += " SolarPanel";
		}

		public override String Operate(Rover r)
		{
			this.Battery.Power += 1;
			return (this.Battery.Name + "'s Power units increased by 1");
		}
	}
}
