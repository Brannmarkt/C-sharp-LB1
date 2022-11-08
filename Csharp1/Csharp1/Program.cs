using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine machine1 = CoffeeMachine.Create_Coffee_Machine("Machine №1", 900, 900, 900, 900, 900);
            CoffeeMachine machine2 = CoffeeMachine.Create_Coffee_Machine("Machine №2", 0, 900, 900, 900, 900);

            machine1.Show_Info();

            machine1.Make_Drink(Drinks.Cappuccino);
            machine1.Make_Drinks(3, 0, 2, 2, 2);

            machine1.Show_Info();

            machine1.Add_Ingridients(Ingridients.Coffee, 100);

            machine1.Show_Info();

            Console.ReadKey();
        }
    }
}
