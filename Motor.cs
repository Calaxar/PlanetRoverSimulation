using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRover
{
	public enum Direction { forward, backward, left, right };
	public class Motor : Device
	{
		private int _dx;
		private int _dy;

		public Motor(Direction d) : base()
		{
			switch (d)
			{
				case Direction.backward:
				_dy = -1;
				this.Name += " B-";
				break;
				case Direction.forward:
				_dy = 1;
				this.Name += " F-";
				break;
				case Direction.left:
				_dx = -1;
				this.Name += " L-";
				break;
				case Direction.right:
				_dx = 1;
				this.Name += " R-";
				break;
			}
			this.Name += " Motor";
		}

		public override String Operate(Rover r)
		{
			if (this.Battery.Power< 1)
			{
				return (this.Battery.Name + " has insufficient power to use " + this.Name);
			}
			r.PositionX += _dx;
			r.PositionY += _dy;
			if ((r.PositionX > 20) || (r.PositionX < 1) || (r.PositionY > 20) || (r.PositionY < 1))
			{
				r.PositionX -= _dx;
				r.PositionY -= _dy;
				return ("Can't move any further in that direction");
			}
			this.Battery.Power -= 1;
			return (r.Name + " moved to {" + r.PositionX + "," + r.PositionY + "}");
		}
	} 
}
