// DESAFIO: Sistema de Pedidos de Cafeteria

using System;

namespace DesignPatternChallenge
{
    public interface IBeverage
    {
        decimal GetCost();
        string GetDescription();
    }

    public class Espresso : IBeverage
    {
        public decimal GetCost() => 3.50m;
        public string GetDescription() => "Espresso";
    }

    public class Cappuccino : IBeverage
    {
        public decimal GetCost() => 4.50m;
        public string GetDescription() => "Cappuccino";
    }

    public class Cha : IBeverage
    {
        public decimal GetCost() => 2.50m;
        public string GetDescription() => "Chá";
    }

    public abstract class BeverageDecorator : IBeverage
    {
        protected readonly IBeverage _beverage;

        protected BeverageDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }

        public virtual decimal GetCost() => _beverage.GetCost();
        public virtual string GetDescription() => _beverage.GetDescription();
    }

    public class LeiteDecorator : BeverageDecorator
    {
        public LeiteDecorator(IBeverage beverage) : base(beverage) { }

        public override decimal GetCost() => _beverage.GetCost() + 0.50m;
        public override string GetDescription() => _beverage.GetDescription() + " com Leite";
    }

    public class ChocolateDecorator : BeverageDecorator
    {
        public ChocolateDecorator(IBeverage beverage) : base(beverage) { }

        public override decimal GetCost() => _beverage.GetCost() + 0.70m;
        public override string GetDescription() => _beverage.GetDescription() + " com Chocolate";
    }

    public class ChantillyDecorator : BeverageDecorator
    {
        public ChantillyDecorator(IBeverage beverage) : base(beverage) { }

        public override decimal GetCost() => _beverage.GetCost() + 1.00m;
        public override string GetDescription() => _beverage.GetDescription() + " com Chantilly";
    }

    public class CarameloDecorator : BeverageDecorator
    {
        public CarameloDecorator(IBeverage beverage) : base(beverage) { }

        public override decimal GetCost() => _beverage.GetCost() + 0.80m;
        public override string GetDescription() => _beverage.GetDescription() + " com Caramelo";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Pedidos - Cafeteria (Decorator Pattern) ===\n");

            IBeverage cafe1 = new Espresso();
            Console.WriteLine($"{cafe1.GetDescription()}: R$ {cafe1.GetCost():N2}");

            IBeverage cafe2 = new LeiteDecorator(new Espresso());
            Console.WriteLine($"{cafe2.GetDescription()}: R$ {cafe2.GetCost():N2}");

            IBeverage cafe3 = new ChocolateDecorator(new LeiteDecorator(new Espresso()));
            Console.WriteLine($"{cafe3.GetDescription()}: R$ {cafe3.GetCost():N2}");

            IBeverage cafe4 = new ChantillyDecorator(new ChocolateDecorator(new LeiteDecorator(new Cappuccino())));
            Console.WriteLine($"{cafe4.GetDescription()}: R$ {cafe4.GetCost():N2}");

            IBeverage cafe5 = new CarameloDecorator(new ChantillyDecorator(new ChocolateDecorator(new LeiteDecorator(new Espresso()))));
            Console.WriteLine($"{cafe5.GetDescription()}: R$ {cafe5.GetCost():N2}");
        }
    }
}
