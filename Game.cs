using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRover
{
	public class Game
	{
		private Rover _r1;
		private Rover _r2;
		public Game()
		{
			_r1 = new Rover();
			_r2 = new Rover();
			_r1.ToCollect.Add(new Specimen());
			_r1.ToCollect.Add(new Specimen());
			_r1.ToCollect.Add(new Specimen());
			_r1.ToCollect.Add(new Specimen());
			_r1.ToCollect.Add(new Specimen());
			_r1.ToCollect.Add(new Specimen());
			_r1.ToCollect.Add(new Specimen());
			_r1.ToCollect.Add(new Specimen());
			_r1.ToCollect.Add(new Specimen());
			_r1.ToCollect.Add(new Specimen());
			_r2.ToCollect = _r1.ToCollect;
			_r1.DefaultEquip();
			_r2.DefaultEquip();
		}

		public void Run()
		{
			Console.WriteLine("You are controlling " + _r1.Name);
			Console.WriteLine("It's coordinates are " + "{" + _r1.PositionX + "," + _r1.PositionY + "}");
			Console.WriteLine("What would you like to do?\n\t1: Motor\n\t2: Radar\n\t3: SolarPanel\n\t4: Drill\n\t5: Check Rover\n\t6: Move Device\n\t7: Switch Rovers");
			switch (Console.ReadKey().Key)
			{
				case ConsoleKey.D1:
				Operate(_r1, Devices.Motor);
				break;
				case ConsoleKey.D2:
				Operate(_r1, Devices.Radar);
				break;
				case ConsoleKey.D3:
				Operate(_r1, Devices.SolarPanel);
				break;
				case ConsoleKey.D4:
				Operate(_r1, Devices.Drill);
				RoverSync();
				break;
				case ConsoleKey.D5:
				Console.WriteLine(CheckInfo(_r1));
				break;
				case ConsoleKey.D6:
				MoveDevice(_r1);
				break;
				case ConsoleKey.D7:
				SwitchRovers();
				Console.WriteLine("Switched to " + _r1.Name);
				break;
				default:
				Console.WriteLine("Please press one of the number keys to continue");
				break;
			}
			_r2.ToCollect = _r1.ToCollect;
		}

		private string DisplayOptions(Rover r, Devices d)
		{
			string result = "";
			for (int i = 0; i != r.DevicesByType(d).Count; i++)
			{
				result += ("\t" + (i + 1) + ": " + r.DevicesByType(d)[i].Name + "\n");
			}
			return result;
		}

		private void Operate(Rover r, Devices d)
		{
			if (r.DevicesByType(d).Count == 0)
			{
				Console.WriteLine(r.Name + "does not have a " + d.ToString().ToLower());
				return;
			}
			Console.WriteLine("Which " + d.ToString().ToLower() + " would you like to use?");
			Console.Write(DisplayOptions(r, d));
			switch (Console.ReadKey().Key)
			{
				case ConsoleKey.D1:
				if (r.DevicesByType(d).Count < 1) Console.WriteLine("Option 1 not given");
				else Console.WriteLine(r.DevicesByType(d)[0].Operate(r));
				break;
				case ConsoleKey.D2:
				if (r.DevicesByType(d).Count < 2) Console.WriteLine("Option 2 not given");
				else Console.WriteLine(r.DevicesByType(d)[1].Operate(r));
				break;
				case ConsoleKey.D3:
				if (r.DevicesByType(d).Count < 3) Console.WriteLine("Option 3 not given");
				else Console.WriteLine(r.DevicesByType(d)[2].Operate(r));
				break;
				case ConsoleKey.D4:
				if (r.DevicesByType(d).Count < 4) Console.WriteLine("Option 4 not given");
				else Console.WriteLine(r.DevicesByType(d)[3].Operate(r));
				break;
				case ConsoleKey.D5:
				if (r.DevicesByType(d).Count < 5) Console.WriteLine("Option 5 not given");
				else Console.WriteLine(r.DevicesByType(d)[4].Operate(r));
				break;
				case ConsoleKey.D6:
				if (r.DevicesByType(d).Count < 6) Console.WriteLine("Option 6 not given");
				else Console.WriteLine(r.DevicesByType(d)[5].Operate(r));
				break;
				case ConsoleKey.D7:
				if (r.DevicesByType(d).Count < 7) Console.WriteLine("Option 7 not given");
				else Console.WriteLine(r.DevicesByType(d)[6].Operate(r));
				break;
				case ConsoleKey.D8:
				if (r.DevicesByType(d).Count < 8) Console.WriteLine("Option 8 not given");
				else Console.WriteLine(r.DevicesByType(d)[7].Operate(r));
				break;
				case ConsoleKey.D9:
				if (r.DevicesByType(d).Count < 9) Console.WriteLine("Option 9 not given");
				else Console.WriteLine(r.DevicesByType(d)[8].Operate(r));
				break;
				default:
				Console.WriteLine("Please press one of the correct number keys to continue");
				return;
			}
		}

		private string CheckInfo(Rover r)
		{
			string result = "";
			result += (r.Name + "\n");
			result += ("Inventory\n");
			foreach (Specimen s in r.Inv) result += ("\t-" + s.Name + "\n");
			result += ("Batteries\n");
			foreach (Attachment b in r.Attachments) if (b is Battery) result += ("\t-" + b.Name + " [" + ((Battery)b).Power + " Zaps]" + "\n");
			result += ("Devices\n");
			foreach (Attachment d in r.Attachments)
			{
				if (d is Device)
				{
					result += ("\t-" + d.Name);
					if (d is Drill) result += (" (" + ((Drill)d).Wear + "%)");
					result += (" [" + ((Device)d).Battery.Name + "]" + "\n");
				}
			}
			return result;
		}

		private void MoveDevice(Rover r)
		{
			List<Device> dList = new List<Device> { };
			List<Battery> bList = new List<Battery> { };
			Device toMove = null;
			Battery moveTo = null;
			foreach (Attachment a in r.Attachments)
			{
				if (a is Device) dList.Add((Device)a);
			}
			foreach (Attachment a in r.Attachments)
			{
				if (a is Battery) bList.Add((Battery)a);
			}
			Console.WriteLine("Which Device would you like to move?");
			for (int i = 0; i != dList.Count; i++)
			{
				Console.WriteLine("\t" + (i + 1) + ": " + dList[i].Name + "\n");
			}
			switch (Console.ReadKey().Key)
			{
				case ConsoleKey.D1:
				if (dList.Count < 1) Console.WriteLine("Option 1 not given");
				else toMove = dList[0];
				break;
				case ConsoleKey.D2:
				if (dList.Count < 2) Console.WriteLine("Option 2 not given");
				else toMove = dList[1];
				break;
				case ConsoleKey.D3:
				if (dList.Count < 3) Console.WriteLine("Option 3 not given");
				else toMove = dList[2];
				break;
				case ConsoleKey.D4:
				if (dList.Count < 4) Console.WriteLine("Option 4 not given");
				else toMove = dList[3];
				break;
				case ConsoleKey.D5:
				if (dList.Count < 5) Console.WriteLine("Option 5 not given");
				else toMove = dList[4];
				break;
				case ConsoleKey.D6:
				if (dList.Count < 6) Console.WriteLine("Option 6 not given");
				else toMove = dList[5];
				break;
				case ConsoleKey.D7:
				if (dList.Count < 7) Console.WriteLine("Option 7 not given");
				else toMove = dList[6];
				break;
				case ConsoleKey.D8:
				if (dList.Count < 8) Console.WriteLine("Option 8 not given");
				else toMove = dList[7];
				break;
				case ConsoleKey.D9:
				if (dList.Count < 9) Console.WriteLine("Option 9 not given");
				else toMove = dList[8];
				break;
				default:
				Console.WriteLine("Please press one of the correct number keys to continue");
				return;
			}
			Console.WriteLine("Which Battery would you like to move it to?");
			for (int i = 0; i != bList.Count; i++)
			{
				Console.WriteLine("\t" + (i + 1) + ": " + bList[i].Name + "\n");
			}
			switch (Console.ReadKey().Key)
			{
				case ConsoleKey.D1:
				if (bList.Count < 1) Console.WriteLine("Option 1 not given");
				else moveTo = bList[0];
				break;
				case ConsoleKey.D2:
				if (bList.Count < 2) Console.WriteLine("Option 2 not given");
				else moveTo = bList[1];
				break;
				case ConsoleKey.D3:
				if (bList.Count < 3) Console.WriteLine("Option 3 not given");
				else moveTo = bList[2];
				break;
				case ConsoleKey.D4:
				if (bList.Count < 4) Console.WriteLine("Option 4 not given");
				else moveTo = bList[3];
				break;
				case ConsoleKey.D5:
				if (bList.Count < 5) Console.WriteLine("Option 5 not given");
				else moveTo = bList[4];
				break;
				case ConsoleKey.D6:
				if (bList.Count < 6) Console.WriteLine("Option 6 not given");
				else moveTo = bList[5];
				break;
				case ConsoleKey.D7:
				if (bList.Count < 7) Console.WriteLine("Option 7 not given");
				else moveTo = bList[6];
				break;
				case ConsoleKey.D8:
				if (bList.Count < 8) Console.WriteLine("Option 8 not given");
				else moveTo = bList[7];
				break;
				case ConsoleKey.D9:
				if (dList.Count < 9) Console.WriteLine("Option 9 not given");
				else moveTo = bList[8];
				break;
				default:
				Console.WriteLine("Please press one of the correct number keys to continue");
				return;
			}
			if (moveTo != null && toMove != null)
			{
				moveTo.AttachDevice(toMove);
				Console.WriteLine(toMove.Name + " attached to " + moveTo.Name);
			}
		}

		private void SwitchRovers()
		{
			Rover rSwitch = _r1;
			_r1 = _r2;
			_r2 = rSwitch;
		}

		private void RoverSync()
		{
			_r2.ToCollect = _r1.ToCollect;
		}

		public Rover R1
		{
			get { return _r1; }
		}
	}
}
