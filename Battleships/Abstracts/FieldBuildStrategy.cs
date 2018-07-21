using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Abstracts
{
    public abstract class FieldBuildStrategy
    {
		public int FieldLength { get; protected set; }
		public int FieldHeight { get; protected set; }

		public abstract FieldCell[,] Build();
    }
}
