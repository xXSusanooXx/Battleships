using Battleships.Enums;
using Battleships.Models;

namespace Battleships.Abstracts
{
	public class Ship: FieldUnit
    {
		public DeckType DeckType { get; protected set; }

		public ShipDirection? ShipDirection { get; protected set; }

		public Ship(DeckType deckType, FieldCell[] cells, ShipDirection? shipDirection = null)
		{
			DeckType = deckType;
			Cells = cells;
			ShipDirection = shipDirection;
		}
	}
}
