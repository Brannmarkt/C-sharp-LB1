using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp1
{
    enum Drinks
    {
        Strong,
        Default,
        Cappuccino,
        Latte,
        Americano
    }

    enum Ingridients
    {
        Coffee, 
        Milk,
        Water,
        Sugar
    }

    class CoffeeMachine
    {
        private double max_value;
        public double Max_Value
        {
            get { return max_value; }
            set
            {
                    max_value = value;
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set 
            {
                    name = value;
            }
        }

        private double coffee;
        public double Coffee
        {
            get { return coffee; }
            set
            {
                    coffee = value;
            }
        }

        private double milk;
        public double Milk
        {
            get { return milk; }
            set
            {
                    milk = value;
            }
        }

        private double water;
        public double Water
        {
            get { return water; }
            set
            {
                    water = value;
            }
        }

        private double sugar;
        public double Sugar
        {
            get { return sugar; }
            set
            {
                    sugar = value;
            }
        }

        private double money;
        public double Money
        {
            get { return money; }
            set
            {
                    money += value;
            }
        }

        public CoffeeMachine(string name_, double max_value_, double coffee_, double milk_, double water_, double sugar_) 
        {
            Name = name_;
            Max_Value = max_value_;
            Coffee = coffee_;
            Milk = milk_;
            Water = water_;
            Sugar = sugar_;
        }

        public static CoffeeMachine Create_Coffee_Machine(string name_, double max_value_, double coffee_, double milk_, double water_, double sugar_)
        {
            bool check_maxvalue, check_coffee, check_milk, check_water, check_sugar;

            check_maxvalue = max_value_ > 0;

            check_coffee = coffee_ > 0 || coffee_ <= max_value_;

            check_milk = milk_ > 0 || milk_ <= max_value_;

            check_water = water_ > 0 || water_ <= max_value_;

            check_sugar = sugar_ > 0 || sugar_ <= max_value_;

            if (check_maxvalue && check_coffee && check_milk && check_water && check_sugar)
            {
                CoffeeMachine machine = new CoffeeMachine(name_, max_value_, coffee_, milk_, water_, sugar_);
                Console.WriteLine("Coffee machine is created: " + name_);
                return machine;
            }
            else
            {
                Console.WriteLine("Creating coffee machine failed. Try again");
                return null;
            }
        }

        public void Show_Info()
        {
            Console.WriteLine("\n\nName: " + Name + "\nMoney: " + Money + "\nCoffee: " + Coffee + "\nMilk: " + Milk + "\nWater: " + Water + "\nSugar: " + Sugar);
        }

        private bool Drink_Needs(double coffee_, double milk_, double water_, double sugar_)
        {
            if ((Coffee - coffee_) >= 0 && (Milk - milk_) >= 0 && (Water - water_) >= 0 && (Sugar - sugar_) >= 0)
            {
                Coffee -= coffee_;
                Milk -= milk_;
                Water -= water_;
                Sugar -= sugar_;
                return true;
            }
            else
                return false;
        }

        public void Add_Ingridients(Ingridients ingridient, double value)
        {
            switch(ingridient)
            {
                case Ingridients.Coffee:
                    if ((Coffee + value) <= Max_Value)
                    {
                        Coffee += value;
                    }
                    else
                        Console.WriteLine("Too much amount of coffee");
                    break;
                case Ingridients.Milk:
                    if ((Milk + value) <= Max_Value)
                    {
                        Milk += value;
                    }
                    else
                        Console.WriteLine("Too much amount of milk");
                    break;
                case Ingridients.Water:
                    if ((Water + value) <= Max_Value)
                    {
                        Water += value;
                    }
                    else
                        Console.WriteLine("Too much amount of water");
                    break;
                case Ingridients.Sugar:
                    if ((Sugar + value) <= Max_Value)
                    {
                        Sugar += value;
                    }
                    else
                        Console.WriteLine("Too much amount of sugar");
                    break;
            }
        }

        public void Make_Drink(Drinks drink)
        {
            switch (drink)
            {
                case Drinks.Default:
                    if (Drink_Needs(10, 30, 20, 5))
                    {
                        Money += 30;
                        Console.WriteLine("Default coffee is made");
                    }
                    else
                        Console.WriteLine("Not enough ingredients");
                    break;
                case Drinks.Strong:
                    if (Drink_Needs(20, 20, 20, 3))
                    {
                        Money += 35;
                        Console.WriteLine("Strong coffee is made");
                    }
                    else
                        Console.WriteLine("Not enough ingredients");
                    break;
                case Drinks.Cappuccino:
                    if (Drink_Needs(15, 35, 20, 10))
                    {
                        Money += 40;
                        Console.WriteLine("Cappuccino coffee is made");
                    }
                    else
                        Console.WriteLine("Not enough ingredients");
                    break;
                case Drinks.Latte:
                    if (Drink_Needs(18, 20, 15, 10))
                    {
                        Money += 35;
                        Console.WriteLine("Latte coffee is made");
                    }
                    else
                        Console.WriteLine("Not enough ingredients");
                    break;
                case Drinks.Americano:
                    if (Drink_Needs(14, 25, 18, 8))
                    {
                        Money += 45;
                        Console.WriteLine("Americano coffee is made");
                    }
                    else
                        Console.WriteLine("Not enough ingredients");
                    break;
            }
        }

        public void Make_Drinks(int strong_, int default_, int cappuccino_, int latte_, int americano_)
        {
            if(strong_ > 0 && (Drink_Needs(20 * strong_, 20 * strong_, 20 * strong_, 3 * strong_)))
            {
                Money += 35 * strong_;
                Console.WriteLine(strong_ + " portions of strong coffee are made");
            }
            if(default_ > 0 && Drink_Needs(10 * default_, 30 * default_, 20 * default_, 5 * default_))
            {
                Money += 30 * default_;
                Console.WriteLine(default_ + " portions of default coffee are made");
            }
            if(cappuccino_ > 0 && Drink_Needs(15 * cappuccino_, 35 * cappuccino_, 20 * cappuccino_, 10 * cappuccino_))
            {
                Money += 40 * cappuccino_;
                Console.WriteLine(cappuccino_ + " portions of cappuccino are made");
            }
            if(latte_ > 0 && Drink_Needs(18 * latte_, 20 * latte_, 15 * latte_, 10 * latte_))
            {
                Money += 35 * latte_;
                Console.WriteLine(latte_ + " portions of latte are made");
            }
            if(americano_ > 0 && Drink_Needs(14 * americano_, 25 * americano_, 18 * americano_, 8 * americano_))
            {
                Money += 45 * americano_;
                Console.WriteLine(americano_ + " portions of americano are made");
            }
        }
    }
}
