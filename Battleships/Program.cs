using Battleships.Models;
using Battleships.Models.FuildBuildStrategies;

namespace Battleships
{
	class Program
	{
		static void Main(string[] args)
		{
			Battlefield battlefield = new Battlefield(10, 10);

			var fieldBuildStrategy = new StandardBattleshipFleet(battlefield.FieldLength, battlefield.FieldHeight);

			battlefield.Build(fieldBuildStrategy);

			battlefield.Show();
		}
	}
}
