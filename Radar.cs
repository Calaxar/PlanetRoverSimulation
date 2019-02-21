using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRover
{
	public abstract class Radar : Device
	{
		public Radar() : base()
		{
			this.Name += " Radar";
		}

		public override abstract string Operate(Rover r);

		protected List<Specimen> ScanList(Rover r, List<Specimen> objects)
		{
			List<Specimen> result = new List<Specimen> { };
			int k;
			int minusk;
			int l;
			foreach (Specimen s in objects)
			{
				k = r.PositionY;
				minusk = r.PositionY;
				l = 0;
				for (int i = (r.PositionX-5); i != (r.PositionX+5); i++)
				{
					for (int j = minusk; j != (k + 1); j++)
					{
						if ((s.PositionX == i) && (s.PositionY == j))
							result.Add(s);
					}
					l++;
					if (l > 5)
					{
						k--;
						minusk++;
					}
					else
					{
						k++;
						minusk--;
					}
				}
			}
			return result;
		}
	} 
}
