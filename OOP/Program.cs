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
            car.GetEngineCar().VolumeEngine();
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
        private string modelEngine;
        private double horsepower;

        public Engine(string modelEngine, double horsepower, int numberOfCylinders, double volumeOfCylinders)
            :base(numberOfCylinders, volumeOfCylinders)
        {
            this.modelEngine = modelEngine;
            this.horsepower = horsepower;
        }
        public string getModelEngine()
        {
            return modelEngine;
        }

        public void VolumeEngine()
        {
            double volumeEngine = numberOfCylinders * volumeOfCylinders;
            Console.WriteLine("Объем двигателя модели " + modelEngine + " = " + volumeEngine);
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
        private string modelCar;
        private Engine engineCar;
        public Car(string name, double maxSpeed, string modelCar, Engine engineCar)
            :base(name, maxSpeed)
        {
            this.modelCar = modelCar;
            this.engineCar = engineCar;            
        }

        public string getModelCar()
        {
            return modelCar;
        }
        public Engine GetEngineCar()
        {
            return engineCar;
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
    
}
