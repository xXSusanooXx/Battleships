using Battleships.Abstracts;
using Battleships.Enums;
using System;
using System.Collections.Generic;

namespace Battleships.Models.FuildBuildStrategies
{
	public class StandardBattleshipFleet : FieldBuildStrategy
	{
		public StandardBattleshipFleet(int fieldLength, int fieldHeight) : base(fieldLength, fieldHeight) { }

		public override FieldCell[,] Build()
		{
			FieldCell[,] field = new FieldCell[FieldHeight + 2, FieldLength + 2];//here we use larger field so that it would be easier to place ships

			for (var i = 0; i < FieldHeight + 2; i++)
			{
				for (var j = 0; j < FieldLength + 2; j++)
				{
					field[i, j] = new FieldCell(j, i);
				}
			}

			PlaceShips(field, DeckType.FourDeck, 1);
			PlaceShips(field, DeckType.ThreeDeck, 2);
			PlaceShips(field, DeckType.TwoDeck, 3);
			PlaceShips(field, DeckType.OneDeck, 4);

			var fieldWithoutBorders = new FieldCell[FieldHeight, FieldLength];

			for (var i = 0; i < FieldHeight + 2; i++)
			{
				if (i == 0 || i == FieldHeight + 1)
				{
					continue;
				}

				for (var j = 0; j < FieldLength + 2; j++)
				{
					if (j == 0 || j == FieldLength + 1)
					{
						continue;
					}

					fieldWithoutBorders[i - 1, j - 1] = field[j, i];
				}
			}

			return fieldWithoutBorders;
		}

		private void PlaceShips(FieldCell[,] field, DeckType shipDeckType, int nOfShips)
		{
			Random r = new Random();
			var shipLength = (int)shipDeckType;
			for (var i = 0; i < nOfShips; i++)
			{
				bool shipPlaced = false;
				while (!shipPlaced)
				{
					var cell = field[r.Next(1, FieldHeight + 1), r.Next(1, FieldLength + 1)];

					if (cell.FieldUnit != null)
					{
						continue;
					}

					var shipDirection = (ShipDirection)r.Next(1, 3);
					var shipCells = new List<FieldCell>();
					switch (shipDirection)
					{
						case ShipDirection.Horizontal:
							{
								for (var y = cell.Y - 1; y < cell.Y + 2; y++)
								{
									for (var x = cell.X - 1; x < cell.X + shipLength + 1; x++)
									{
										if (OutOfField(y, x) || field[y, x].FieldUnit != null)
										{
											goto breakOuterLoop;
										}

										if (x > cell.X - 1 && x < cell.X + shipLength && cell.Y == y)
										{
											shipCells.Add(field[y, x]);
										}

									}
								}

								var dirrection = shipDeckType == DeckType.OneDeck ? new ShipDirection?() : new ShipDirection?(shipDirection);

								var ship = new Ship(shipDeckType, shipCells.ToArray(), dirrection);

								shipCells.ForEach(c => c.FieldUnit = ship);

								shipPlaced = true;

								break;
							}
						case ShipDirection.Vertical:
							{
								for (var x = cell.X - 1; x < cell.X + 2; x++)
								{
									for (var y = cell.Y - 1; y < cell.Y + shipLength + 1; y++)
									{
										if (OutOfField(y, x) || field[y, x].FieldUnit != null)
										{
											goto breakOuterLoop;
										}

										if (y > cell.Y - 1 && y < cell.Y + shipLength && x == cell.X)
										{
											shipCells.Add(field[y, x]);
										}

									}
								}

								var dirrection = shipDeckType == DeckType.OneDeck ? new ShipDirection?() : new ShipDirection?(shipDirection);

								var ship = new Ship(shipDeckType, shipCells.ToArray(), dirrection);

								shipCells.ForEach(c => c.FieldUnit = ship);

								shipPlaced = true;

								break;
							}
					}

					breakOuterLoop:;
				}
			}

		}

		private bool OutOfField(int y, int x)
		{
			if (x < 0 || x > FieldLength + 1)
				return true;

			if (y < 0 || y > FieldHeight + 1)
				return true;

			return false;
		}
	}
}
