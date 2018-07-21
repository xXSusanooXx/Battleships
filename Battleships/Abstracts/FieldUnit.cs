using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Abstracts
{
	public abstract class FieldUnit
    {
		public virtual FieldCell[] Cells { get; set; }
    }
}
