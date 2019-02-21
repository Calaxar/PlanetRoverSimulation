using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Devices { Motor, Drill, Radar, SolarPanel };

namespace PlanetRover
{
	public class Rover : PlanetObject
	{
		private List<Specimen> _inv;
		private List<Specimen> _toCollect;
		private List<Attachment> _attachments;
		public Rover() : base()
		{
			List<string> _model = new List<string> { "Sojourner", "Spirit", "Opportunity" };
			List<string> _stage = new List<string> { "Alpha", "Beta", "Delta" };
			_name = (_model[rnd.Next(3)] + " " + _stage[rnd.Next(3)]);
			_inv = new List<Specimen> { };
			_toCollect = new List<Specimen> { };
			_attachments = new List<Attachment> { };
		}

		public void Attach(Attachment a)
		{
			_attachments.Add(a);
		}

		public void DefaultEquip()
		{
			Attach(new Battery());
			Attach(new Battery());
			Attach(new SolarPanel());
			Attach(new RadarType1());
			Attach(new RadarType2());
			Attach(new RadarType3());
			Attach(new Motor(Direction.forward));
			Attach(new Motor(Direction.backward));
			Attach(new Motor(Direction.left));
			Attach(new Motor(Direction.right));
			Attach(new Drill());
			List<Battery> batList = new List<Battery> { };
			foreach (Attachment a in _attachments)
			{
				if (a is Battery) batList.Add((Battery) a);
			}
			foreach (Attachment a in _attachments)
			{
				if (a is Device) batList[rnd.Next(2)].AttachDevice((Device) a);
			}
		}

		public List<Device> DevicesByType(Devices d)
		{
			List<Device> result = new List<Device> { };
			switch (d)
			{
				case Devices.Motor:
				foreach (Attachment a in _attachments)
				{
					if (a is Motor) result.Add((Motor) a);
				}
				break;
				case Devices.Drill:
				foreach (Attachment a in _attachments)
				{
					if (a is Drill) result.Add((Drill) a);
				}
				break;
				case Devices.Radar:
				foreach (Attachment a in _attachments)
				{
					if (a is Radar) result.Add((Radar) a);
				}
				break;
				case Devices.SolarPanel:
				foreach (Attachment a in _attachments)
				{
					if (a is SolarPanel) result.Add((SolarPanel) a);
				}
				break;
			}
			return result;
		}

		public Specimen FindSpecimen(string name)
		{
			foreach (Specimen s in _inv)
			{
				if (s.Name == name) return s;
			}
			return null;
		}

		public List<Specimen> Inv
		{
			get
			{
				return _inv;
			}

			set
			{
				_inv = value;
			}
		}

		public List<Specimen> ToCollect
		{
			get
			{
				return _toCollect;
			}

			set
			{
				_toCollect = value;
			}
		}

		public List<Attachment> Attachments
		{
			get
			{
				return _attachments;
			}
		}
	}
}
