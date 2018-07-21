using Battleships.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Models.FuildBuildStrategies
{
	public class SubmarineArmada : FieldBuildStrategy
	{
		public SubmarineArmada(int fieldLength, int fieldHeight)
		{
			this.FieldLength = fieldLength;
			this.FieldHeight = fieldHeight;
		}

		public override FieldCell[,] Build()
		{
			FieldCell[,] field = new FieldCell[FieldHeight, FieldLength];

			for (var i = 0; i < FieldHeight; i++)
			{
				for (var j = 0; j < FieldLength; j++)
				{
					field[i, j] = new FieldCell(j, i);
					if (i % 2 == 0 && j % 2 == 0)
					{
						field[i, j].FieldUnit = new Submarine(field[i, j]);
					}
				}
			}

			return field;
		}
	}
}
