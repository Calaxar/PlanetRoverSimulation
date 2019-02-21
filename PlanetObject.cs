using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRover
{
	public abstract class PlanetObject
	{
		protected static Random rnd = new Random();
		protected String _name;
		private int _positionX;
		private int _positionY;

		public PlanetObject()
		{
			_positionX = rnd.Next(21);
			_positionY = rnd.Next(21);
		}

		public String Name
		{
			get
			{
				return _name;
			}
		}

		public int PositionX
		{
			get
			{
				return _positionX;
			}
			set
			{
				_positionX = value;
			}
		}

		public int PositionY
		{
			get
			{
				return _positionY;
			}
			set
			{
				_positionY = value;
			}
		}
	}
}
