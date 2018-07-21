using Battleships.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Models
{
	public class FieldCell
	{
		public int X { get; set; }
		public int Y { get; set; }
		public FieldUnit FieldUnit { get; set; }
		public bool IsDead { get; set; }


		public FieldCell(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
