using Battleships.Abstracts;
using System;

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
				if (value < 0)
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
				if (value < 0)
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
			int aCode = 'A';

			for (var i = 0; i < FieldHeight + 1; i++)
			{
				for (var j = 0; j < FieldLength + 1; j++)
				{
					if (i == 0 && j == 0)
					{
						Console.Write("   ");
						continue;
					}
					else if (i != 0 && j == 0)
					{
						Console.Write(i + " ");

						if (i < 10)
						{
							Console.Write(" ");
						}

						continue;
					}
					else if (i == 0 && j != 0 )
					{
						Console.Write(((char)aCode++) + " ");
						continue;
					}

					if (fieldcells[i - 1, j - 1].FieldUnit == null)
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
