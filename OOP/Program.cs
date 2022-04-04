using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine("nimbus2000", 200, 5, 5.5);
            engine.VolumeEngine();
            Car car = new Car("suzuki", 200, "1002L", engine);
            car.Gas();
            Bycicle bycicle = new Bycicle("byciclePro", 2, "Mountain bike");
            bycicle.Gas();
        }
    }

   
    class Transport
    {
        private string name;
        private double maxSpeed;

        
        public Transport(string name, double maxSpeed)
        {
            this.name = name;
            this.maxSpeed = maxSpeed;            
        }

        public string getName()
        {
            return name;
        }
        public double getMaxSpeed()
        {
            return maxSpeed;
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
        public Car(string name, double maxSpeed, string model, Engine engine)
            :base(name, maxSpeed)
        {
            this.model = model;
            this.engine = engine;            
        }

        public string getModel()
        {
            return model;
        }
       public void Brake()
        {
            Console.WriteLine("Машина " + getName() + " тормозит");
        }

        public void Gas()
        {
            Console.WriteLine("Машина " + getName() + " газует");
        }

        public void LeftTurn()
        {
            Console.WriteLine("Машина " + getName() + " поворачивает налево");
        }

        public void RightTurn()
        {
            Console.WriteLine("Машина" + getName() + "поворачивает направо");
        }
    }
    class Bycicle : Transport, IDrive
    {
        private string type;
        public Bycicle(string name, double maxSpeed, string type)
            :base(name, maxSpeed)
        {
            this.type = type;
        }
        public void Brake()
        {
            Console.WriteLine("Велосипед" + getName() + " типа "+type+" тормозит");
        }

        public void Gas()
        {
            Console.WriteLine("На велосипеде " + getName() + " типа " + type + " активно крутятся педали");
        }

        public void LeftTurn()
        {
            Console.WriteLine("Велосипед" + getName() + "поворачивает налево");
        }

        public void RightTurn()
        {
            Console.WriteLine("Велосипед" + getName() + "поворачивает направо");
        }
    }
}
