using Battleships.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Models
{
	public class Submarine : FieldUnit //single-decker
	{
		public Submarine( FieldCell fieldCells)
		{
			this.Cells = new[] { fieldCells };
		}
	}
}
