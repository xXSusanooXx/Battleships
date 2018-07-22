using Battleships.Abstracts;
using System;

namespace Battleships.Models
{
	public class FieldCell
	{
		private int _x;
		private int _y;

		public int X
		{
			get { return _x; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Length cannot be negative");
				}
				_x = value;
			}
		}

		public int Y
		{
			get { return _y; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be negative");
				}
				_y = value;
			}
		}

		public FieldUnit FieldUnit { get; set; }

		public FieldCell(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
