using APIGame.APIGame.API.Buildings;

namespace APIGame.APIGame.API.Traveling
{
    public class Airplane
    {
        public PlaneModel Model { get; set; }
        public Airport? CurrentAirport { get; set; }
        public int FuelLevel { get; set; }
        public int PassengerCapacity { get; set; }
        public int CurrentPassengers { get; set; }
        public bool IsInMaintenance { get; set; }
        public string FlightStatus { get; set; }

        public Airplane(PlaneModel model, int passengerCapacity)
        {
            Model = model;
            PassengerCapacity = passengerCapacity;
            FuelLevel = 100; // Assume full tank
            CurrentPassengers = 0;
            IsInMaintenance = false;
            FlightStatus = "On Ground";
        }

        public void LandAt(Airport airport)
        {
            if (IsInMaintenance)
            {
                Console.WriteLine($"The airplane {Model} is in maintenance and cannot land.");
                return;
            }

            CurrentAirport = airport;
            airport.LandPlane(this);
            FlightStatus = "On Ground";
            Console.WriteLine($"The airplane {Model} has landed at {airport.Address}.");
        }

        public void TakeOff()
        {
            if (IsInMaintenance)
            {
                Console.WriteLine($"The airplane {Model} is in maintenance and cannot take off.");
                return;
            }

            if (CurrentAirport != null)
            {
                CurrentAirport.Airplanes.Remove(this);
                FlightStatus = "In Flight";
                Console.WriteLine($"The airplane {Model} has taken off from {CurrentAirport.Address}.");
                CurrentAirport = null;
            }
            else
            {
                Console.WriteLine("The airplane is not at any airport.");
            }
        }

        public void Refuel(int amount)
        {
            if (IsInMaintenance)
            {
                Console.WriteLine($"The airplane {Model} is in maintenance and cannot be refueled.");
                return;
            }

            FuelLevel += amount;
            if (FuelLevel > 100)
            {
                FuelLevel = 100; // Cap the fuel level at 100
            }
            Console.WriteLine($"The airplane {Model} has been refueled to {FuelLevel}%.");
        }

        public void BoardPassengers(int numberOfPassengers)
        {
            if (IsInMaintenance)
            {
                Console.WriteLine($"The airplane {Model} is in maintenance and cannot board passengers.");
                return;
            }

            if (CurrentPassengers + numberOfPassengers <= PassengerCapacity)
            {
                CurrentPassengers += numberOfPassengers;
                Console.WriteLine($"{numberOfPassengers} passengers have boarded the airplane {Model}. Current passengers: {CurrentPassengers}.");
            }
            else
            {
                Console.WriteLine("Not enough capacity to board all passengers.");
            }
        }

        public void DisembarkPassengers(int numberOfPassengers)
        {
            if (IsInMaintenance)
            {
                Console.WriteLine($"The airplane {Model} is in maintenance and cannot disembark passengers.");
                return;
            }

            if (numberOfPassengers <= CurrentPassengers)
            {
                CurrentPassengers -= numberOfPassengers;
                Console.WriteLine($"{numberOfPassengers} passengers have disembarked from the airplane {Model}. Current passengers: {CurrentPassengers}.");
            }
            else
            {
                Console.WriteLine("Not enough passengers to disembark.");
            }
        }

        public void StartMaintenance()
        {
            IsInMaintenance = true;
            FlightStatus = "In Maintenance";
            Console.WriteLine($"The airplane {Model} is now in maintenance.");
        }

        public void EndMaintenance()
        {
            IsInMaintenance = false;
            FlightStatus = "On Ground";
            Console.WriteLine($"The airplane {Model} has completed maintenance.");
        }
    }
}