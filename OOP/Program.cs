using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine("nimbus2000", 200, 5, 5.5);
            engine.VolumeEngine();
            Car car = new Car("suzuki", 4, "1002L", engine);
            car.Gas();
            Bycicle bycicle = new Bycicle("byciclePro", 2, "Mountain bike");
            bycicle.Gas();
        }
    }

   
    class Transport
    {
        protected string name;
        private int countWheel;
        
        public Transport(string name, int countWheel)
        {
            this.name = name;
            this.countWheel = countWheel;            
        }
        
    }
    class Cylinders
    {
        protected int numberOfCylinders;
        protected double volumeOfCylinders;
        public Cylinders(int numberOfCylinders, double volumeOfCylinders)
        {
            this.numberOfCylinders = numberOfCylinders;
            this.volumeOfCylinders = volumeOfCylinders;
        }
        
    }
    class Engine:Cylinders
    {
        private string model;
        private double horsepower;

        public Engine(string model, double horsepower, int numberOfCylinders, double volumeOfCylinders)
            :base(numberOfCylinders, volumeOfCylinders)
        {
            this.model = model;
            this.horsepower = horsepower;
        }

        public void VolumeEngine()
        {
            double volumeEngine = numberOfCylinders * volumeOfCylinders;
            Console.WriteLine("Объем двигателя модели " + model + " = " + volumeEngine);
        }

    }
    public interface IDrive
    {
        void Gas();
        void Brake();
        void LeftTurn();
        void RightTurn();

    }
    class Car : Transport, IDrive
    {
        private string model;
        private Engine engine;
        public Car(string name, int countWheel, string model, Engine engine)
            :base(name, countWheel)
        {
            this.model = model;
            this.engine = engine;
            
        }

       public void Brake()
        {
            Console.WriteLine("Машина " + name + " тормозит");
        }

        public void Gas()
        {
            Console.WriteLine("Машина " + name + " газует");
        }

        public void LeftTurn()
        {
            Console.WriteLine("Машина " + name + " поворачивает налево");
        }

        public void RightTurn()
        {
            Console.WriteLine("Машина" + name + "поворачивает направо");
        }
    }
    class Bycicle : Transport, IDrive
    {
        private string type;
        public Bycicle(string name, int countWheel, string type)
            :base(name, countWheel)
        {
            this.type = type;
        }
        public void Brake()
        {
            Console.WriteLine("Велосипед" + name + " типа "+type+" тормозит");
        }

        public void Gas()
        {
            Console.WriteLine("На велосипеде " + name + " типа " + type + " активно крутятся педали");
        }

        public void LeftTurn()
        {
            Console.WriteLine("Велосипед" + name + "поворачивает налево");
        }

        public void RightTurn()
        {
            Console.WriteLine("Велосипед" + name + "поворачивает направо");
        }
    }
}
