using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRover
{
	public class Drill : Device
	{
		private int _wear;
		public Drill() : base()
		{
			this.Name += " Drill";
			_wear = 0;
		}

		public override string Operate(Rover r)
		{
			if (this.Battery.Power< 6)
			{
				return (this.Battery.Name + " has insufficient power to use " + this.Name);
			}
			if (_wear > 100)
			{
				Random rnd = new Random();
				if (rnd.Next(1, 5) == 1)
				{
					return Dig(r);
				}
				else return ("Drill Failure: Extraction Unsuccessful");
			}
			else return Dig(r);
		}

		private string Dig(Rover r)
		{
			foreach (Specimen s in r.ToCollect)
			{
				if ((r.PositionX == s.PositionX) && (r.PositionY == s.PositionY))
				{
					r.Inv.Add(s);
					r.ToCollect.Remove(s);
					this.Battery.Power -= 6;
					_wear += 5;
					return ("You excavated " + s.Name);
				}
			}
			_wear += 10;
			this.Battery.Power -= 6;
			return ("Nothing excavated, " + Name + " damaged");
		}

		public int Wear
		{
			get
			{
				return _wear;
			}
		}
	} 
}
