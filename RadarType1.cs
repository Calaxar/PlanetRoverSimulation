using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRover
{
	public class RadarType1 : Radar
	{
		public RadarType1() : base()
		{
		}

		public override String Operate(Rover r)
		{
			if (this.Battery.Power< 4)
			{
				return (this.Battery.Name + " has insufficient power to use " + this.Name);
			}
			List<Specimen> scanned = ScanList(r, r.ToCollect);
			this.Battery.Power -= 4;
			if (scanned.Count != 0)
			{
				string result = ("Scan Complete:\nSpecimens at following coordinates\n");
				foreach (Specimen s in scanned)
				{
					result += ("\t{" + s.PositionX + "," + s.PositionY + "}\n");
				}
				return result;
			}
			else return ("Scan Complete: Nothing found");
		}
	} 
}
