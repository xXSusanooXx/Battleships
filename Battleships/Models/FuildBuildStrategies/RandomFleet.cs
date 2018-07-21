using Battleships.Abstracts;
using Battleships.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Models.FuildBuildStrategies
{
	public class RandomFleet : FieldBuildStrategy
	{
		public RandomFleet(int fieldLength, int fieldHeight) : base(fieldLength, fieldHeight) { }

		public override FieldCell[,] Build()
		{
			FieldCell[,] field = new FieldCell[FieldHeight + 2, FieldLength + 2];

			for (var i = 0; i < FieldHeight; i++)
			{
				for (var j = 0; j < FieldLength; j++)
				{
					field[i, j] = new FieldCell(j, i);
				}
			}

			PlaceShips(field, DeckType.FourDeck, 1);
			PlaceShips(field, DeckType.ThreeDeck, 1);
			PlaceShips(field, DeckType.TwoDeck, 1);
			PlaceShips(field, DeckType.OneDeck, 1);

			return field;
		}

		private void PlaceShips(FieldCell[,] field, DeckType shipDeckType, int nOfShips)
		{
			Random r = new Random();
			for (var i = 0; i < nOfShips; i++)
			{
				switch (shipDeckType)
				{
					case DeckType.FourDeck:
						{
							break;
						}
					case DeckType.ThreeDeck:
						{
							break;
						}
					case DeckType.TwoDeck:
						{
							break;
						}
					case DeckType.OneDeck:
						{
							bool shipPlaced = false;
							while (!shipPlaced)
							{
								var cell = field[r.Next(0, FieldHeight - 2), r.Next(0, FieldLength - 2)];

								if (cell.FieldUnit != null || IsBorder(cell))
								{
									continue;
								}




							}
							break;
						}
					default:
						{
							throw new ArgumentException("Deck Type was not found");
						}
				}
			}
		}

		private bool IsBorder(FieldCell cell)
		{
			if (cell.X == 0 || cell.X == FieldLength + 1)
				return false;

			if (cell.Y == 0 || cell.Y == FieldHeight + 1)
				return false;

			return true;
		}
	}
}
