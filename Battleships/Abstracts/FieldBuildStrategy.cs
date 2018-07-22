using Battleships.Models;
using System;

namespace Battleships.Abstracts
{
	public abstract class FieldBuildStrategy
	{
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
					throw new ArgumentOutOfRangeException("Length cannot be negative");
				}
				_fieldHeight = value;
			}
		}

		public FieldBuildStrategy(int length, int height)
		{
			this.FieldLength = length;
			this.FieldHeight = height;
		}

		public abstract FieldCell[,] Build();
	}
}
