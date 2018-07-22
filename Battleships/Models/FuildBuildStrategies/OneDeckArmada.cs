using Battleships.Abstracts;
using Battleships.Enums;

namespace Battleships.Models.FuildBuildStrategies
{
	public class OneDeckArmada : FieldBuildStrategy
	{
		public OneDeckArmada(int fieldLength, int fieldHeight) : base(fieldLength, fieldHeight) { }

		//adding submarines to 0,2,4,6... rows
		public override FieldCell[,] Build()
		{
			FieldCell[,] field = new FieldCell[FieldHeight, FieldLength];

			for (var i = 0; i < FieldHeight; i++)
			{
				for (var j = 0; j < FieldLength; j++)
				{
					field[i, j] = new FieldCell(j, i);
					if (i % 2 == 0)
					{
						field[i, j].FieldUnit = new Ship(DeckType.OneDeck, new FieldCell[] { field[i, j] });
					}
				}
			}

			return field;
		}
	}
}
