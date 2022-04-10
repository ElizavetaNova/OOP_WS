using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Engine engine = new Engine("nimbus2000", 200, 5, 5.5);
            //engine.VolumeEngine();
            //Car car = new Car("suzuki", 200, "1002L", engine);
            //car.Brake();
            //car.Gas();
            //car.GetEngineCar().VolumeEngine();
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
        private string type;
        public int degreeOfWear;
        private int speedBoost;

        public Engine(string modelEngine, double horsepower, int numberOfCylinders, double volumeOfCylinders, string type)
            :base(numberOfCylinders, volumeOfCylinders)
        {
            this.modelEngine = modelEngine;
            this.horsepower = horsepower;
            this.type = type;
            degreeOfWear = 0;
        }
        
        public int getSpeedBoost()
        {
            if (type == "sport")
            {
                speedBoost = 40;
                return speedBoost;
            }
            else
            {
                speedBoost = 20;
                return speedBoost;
            }
        }
        public string getTypeEngine()
        {
            return type;
        }
        public int getDegreeWearEngine()
        {
            return degreeOfWear;
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
        public bool CheckDegreeOfWear()
        {
            if (degreeOfWear < 100)
                return true;
            else
                return false;
        }
        public int DegreeOfWearUp()
        {
            degreeOfWear += 40;
            return degreeOfWear;
        }
    }
    public interface IDrive
    {
        double Gas();
        double Brake(int speedDown);
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

       public double Brake(int speedDown)
        {
            if (speedNow - speedDown >= 0)
            {                
                speedNow -= speedDown;
                return speedNow;
            }
            else if (speedNow == 0)
            {
                throw new Exception("Машина и так стоит");
            }
            else
            {
                throw new Exception("Машина не может затормозить на такое значение");                
            }
       }       

        public double Gas()
        {
            if (GetEngineCar().CheckDegreeOfWear() == true)
            {
                if (speedNow + GetEngineCar().getSpeedBoost() < getMaxSpeed())
                {
                    speedNow += GetEngineCar().getSpeedBoost();
                    return speedNow;
                }
                else if (speedNow + GetEngineCar().getSpeedBoost() == getMaxSpeed())
                {
                    speedNow += GetEngineCar().getSpeedBoost();
                    engineCar.DegreeOfWearUp();
                    return speedNow;
                }
                else
                {
                    throw new Exception("Нельзя превысить максимальную скорость");
                }
            }
            else
            {
                speedNow = 0;                
                throw new Exception("Двигатель умер, машина больше не поедет");
                
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
