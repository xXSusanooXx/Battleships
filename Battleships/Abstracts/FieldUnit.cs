using Battleships.Models;

namespace Battleships.Abstracts
{
	public abstract class FieldUnit
    {
		public virtual FieldCell[] Cells { get; set; }
    }
}
