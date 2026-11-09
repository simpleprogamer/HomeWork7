using System;
using System.ComponentModel.Design;
using System.Text;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Create ChristmasTree and two Decorators
            ChristmasTree tree = new ChristmasTree();
            OrnamentsDecorator d1 = new OrnamentsDecorator("кульки", 20);
            GarlandDecorator d2 = new GarlandDecorator("різнокольорова");

            // Проста ялинка
            tree.Operation();
            tree.Light();
            Console.WriteLine();

            // Link decorators: ялинка -> прикраси -> гірлянда
            d1.SetComponent(tree);
            d2.SetComponent(d1);

            d2.Operation();   
            d2.Light();       

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        public abstract void Operation();
        public abstract void Light();
    
    }

    // "ChristmasTree"
    class ChristmasTree : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Ялинка");
        }

        public override void Light()
        {
            Console.WriteLine("Ялинка не світиться (немає гірлянди)");
        }
    }
    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
        public override void Light()
        {
            if (component != null)
            {
                component.Light();
            }
        }
    }

    // "OrnamentsDecorator"
    class OrnamentsDecorator : Decorator
    {
        private string ornamentType;  
        private int count;            

        public OrnamentsDecorator(string ornamentType, int count)
        {
            this.ornamentType = ornamentType;
            this.count = count;
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("  + прикраси: " + ornamentType + ", " + count + " шт.");
        }
    }

    // "GarlandDecorator" 
    class GarlandDecorator : Decorator
    {
        private string color;

        public GarlandDecorator(string color)
        {
            this.color = color;
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("  + гірлянда: " + color);
        }

        public override void Light()
        {
            Console.WriteLine("Ялинка світиться: гірлянда " + color + " увімкнена!");
        }
    }
}
