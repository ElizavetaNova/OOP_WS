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
            car.Brake();
            car.Gas();
            car.GetEngineCar().VolumeEngine();
        }
    }

   
    public class Transport
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
    public class Cylinders
    {
        protected int numberOfCylinders;
        protected double volumeOfCylinders;
        public Cylinders(int numberOfCylinders, double volumeOfCylinders)
        {
            this.numberOfCylinders = numberOfCylinders;
            this.volumeOfCylinders = volumeOfCylinders;
        }
        
    }
    public class Engine:Cylinders
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

        public double VolumeEngine()
        {
            double volumeEngine = numberOfCylinders * volumeOfCylinders;
            Console.WriteLine("Объем двигателя модели " + modelEngine + " = " + volumeEngine);
            return volumeEngine;
        }

    }
    public interface IDrive
    {
        double Gas();
        double Brake();
        void LeftTurn();
        void RightTurn();

    }
    public class Car : Transport, IDrive
    {
        private string modelCar;
        private Engine engineCar;
        private double speedNow = 0;
        public Car(string name, double maxSpeed, string modelCar, Engine engineCar)
            : base(name, maxSpeed)
        {
            this.modelCar = modelCar;
            this.engineCar = engineCar;

        }
        public double GetSpeedNow()
        {
            return speedNow;
        }
        public string getModelCar()
        {
            return modelCar;
        }
        public Engine GetEngineCar()
        {
            return engineCar;
        }

       public double Brake()
        {
            if (speedNow - 20 >= 0)
            {
                Console.WriteLine("Машина " + getName() + " тормозит");
                speedNow -=20;
                return speedNow;
            }
            else if (speedNow == 0)
            {
                Console.WriteLine("Машина " + getName() + " уже и так стоит");
                return speedNow;
            }
            else
            {
                Console.WriteLine("Машина " + getName() + " не может тормозить");
                return speedNow;
            }
                
                
        }

        public double Gas()
        {
            if (speedNow + 40 < getMaxSpeed())
            {                
                speedNow += 40;
                Console.WriteLine("Машина " + getName() + " газует");
                return speedNow;
            }
            else
            {
                Console.WriteLine("Нельзя так гнать");
                return speedNow;
            }
                           
            
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
