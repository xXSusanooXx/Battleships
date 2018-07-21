using Battleships.Enums;
using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
