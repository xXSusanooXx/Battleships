using Battleships.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Models
{
	public class Battlefield
	{
		private FieldCell[,] fieldcells;

		private int _fieldLength;
		private int _fieldHeight;

		public int FieldLength
		{
			get { return _fieldLength; }
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("Length cannot be negative");
				}
				_fieldLength = value;
			}
		}

		public int FieldHeight
		{
			get { return _fieldHeight; }
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException("Height cannot be negative");
				}
				_fieldHeight = value;
			}
		}


		public Battlefield(int fieldLength, int fieldHeight)
		{
			this.FieldLength = fieldLength;
			this.FieldHeight = fieldHeight;
		}

		public void Build(FieldBuildStrategy fieldBuildStrategy)
		{
			this.fieldcells = fieldBuildStrategy.Build();
		}

		public void Show()
		{
			for (var i = 0; i < FieldHeight; i++)
			{
				for (var j = 0; j < FieldLength; j++)
				{
					if (fieldcells[i, j].FieldUnit == null)
					{
						Console.Write(0 + " ");
					}
					else
					{
						Console.Write(1 + " ");
					}
				}
				Console.WriteLine();
			}
		}
	}
}
