using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sistema_de_Aerolinea
{
    class Program
    {
        static void Main(string[] args)
        {
            int PassengerMoney = 1500;
            //Uso de delegates con Action llamando a funcion
            Action<IPassengerType<int>, string, int, int, decimal, decimal, int, decimal, int> action = AssignValuesToAPassenger;
        
           
            //Uso de Generics en la mayoria de clases
            PassengerAllocator<int>.type = PassengerType.EconomyClass;
            IPassengerType<int> EconomyPassengerTicket= PassengerAllocator<int>.Create();
            action(EconomyPassengerTicket, "Gregory", 19, 998578, 28.6m, 50.6m, 1, 455.8m, 5);
            PayTheFlight(EconomyPassengerTicket, PassengerMoney);

            Console.WriteLine("__________________________________________");

            PassengerAllocator<int>.type = PassengerType.ExecutiveClass;
            IPassengerType<int> ExecutivePassengerTicket = PassengerAllocator<int>.Create();
            action(ExecutivePassengerTicket, "Valeria", 38, 3488088, 54.9m, 254.3m, 1, 815.6m, 2);    
            PayTheFlight(ExecutivePassengerTicket, PassengerMoney);

            Console.WriteLine("__________________________________________");

            PassengerAllocator<int>.type = PassengerType.FirstClass;
            IPassengerType<int> FirstPassengerTicket = PassengerAllocator<int>.Create();
            action(FirstPassengerTicket, "Daniel", 20, 5918928, 68.6m, 125.6m, 1, 1278.8m, 9);            
            PayTheFlight(FirstPassengerTicket, PassengerMoney);



            //LINQ
            var planeOne = GenerateFlight();
            var PassengersLessThan25 = from passenger in planeOne
                               where passenger.Age < 25
                               select passenger;
            var PassengerfirstNameWithD = planeOne.FirstOrDefault(passenger => passenger.Owner.StartsWith("D")) ?? new FirstClassPassenger<int>();
            var PassengerOrderedlistBySnackQuantityAsc = from passenger in planeOne
                                       orderby passenger.SnacksQuantity, passenger.SnacksQuantity descending
                                       select passenger;
            Console.WriteLine("\nPassengers that are less than 25 years old:\n");
            foreach (var passenger in PassengersLessThan25)
                Console.WriteLine($"\tPassenger: {passenger.Owner} with: {passenger.Age} years\n");
            
            Console.WriteLine("Passengers which name start with 'D'\n");
            Console.WriteLine($"\t{PassengerfirstNameWithD.Owner}");

            Console.WriteLine("\nAmount of Snacks eaten:\n");
            foreach (var passenger in PassengerOrderedlistBySnackQuantityAsc)
                Console.WriteLine($"\tPassenger: {passenger.Owner} with: {passenger.SnacksQuantity} snacks eaten\n");


        }

        private static void PayTheFlight(IPassengerType<int> passenger, int currentMoney)
        {
            Console.WriteLine($"\nBrand: {passenger.GetBrand()}");
            var passengerInformation = passenger.GetPassengerInformation();
            Console.WriteLine($"Dear :{passengerInformation.PassengerName} with ID: {passengerInformation.PassengerID}");
            var totalPrice = passenger.GetTotalPrice();
            Console.WriteLine($"You have to pay: {totalPrice}$ and you will keep with {currentMoney-totalPrice}$");
            Console.WriteLine($"Because u eat: {passenger.SnacksQuantity} snacks  at 10$ each one");
            Console.WriteLine($"Your luggage tax is: {passenger.LuggageWeight * 0.5m}$ for carrying {passenger.LuggageWeight}kg");
            Console.WriteLine($"And your ticket price was {passenger.TicketPrice}$\n");

        }
        public static void AssignValuesToAPassenger(IPassengerType<int> passenger, string name, int age, 
                    int id, decimal weight, decimal luggageWeight, int numberOfFlight, decimal 
                    ticketPrice,int snacksQuantity)
        {
            passenger.Owner = name;
            passenger.Age = age;
            passenger.ID = id;
            passenger.Weight = weight;
            passenger.LuggageWeight = luggageWeight;
            passenger.NumberOfFlight = numberOfFlight;
            passenger.TicketPrice = ticketPrice;
            passenger.SnacksQuantity = snacksQuantity;
        }

        public static List<IPassengerType<int>> GenerateFlight()
        {
            //Uso de delegates con Action con lambda
            Action<IPassengerType<int>, string, int, int, decimal, decimal, int, decimal, int> LambdaAction = (passenger,
                name, age, id, weight, luggageWeight, numberOfFlight, ticketPrice, snacksQuantity) => {
                    passenger.Owner = name;
                    passenger.Age = age;
                    passenger.ID = id;
                    passenger.Weight = weight;
                    passenger.LuggageWeight = luggageWeight;
                    passenger.NumberOfFlight = numberOfFlight;
                    passenger.TicketPrice = ticketPrice;
                    passenger.SnacksQuantity = snacksQuantity;
                };
            var Flight1 = new List<IPassengerType<int>>();
            PassengerAllocator<int>.type = PassengerType.EconomyClass;
            IPassengerType<int> EconomyPassengerTicket = PassengerAllocator<int>.Create();
            LambdaAction(EconomyPassengerTicket, "Gregory", 19, 998578, 28.6m, 50.6m, 1, 455.8m, 5);
            Flight1.Add(EconomyPassengerTicket);
            PassengerAllocator<int>.type = PassengerType.ExecutiveClass;
            IPassengerType<int> ExecutivePassengerTicket = PassengerAllocator<int>.Create();
            LambdaAction(ExecutivePassengerTicket, "Valeria", 38, 3488088, 54.9m, 254.3m, 1, 815.6m, 2);
            Flight1.Add(ExecutivePassengerTicket);
            PassengerAllocator<int>.type = PassengerType.FirstClass;
            IPassengerType<int> FirstPassengerTicket = PassengerAllocator<int>.Create();
            LambdaAction(FirstPassengerTicket, "Daniel", 20, 5918928, 68.6m, 125.6m, 1, 1278.8m, 9);
            Flight1.Add(FirstPassengerTicket);
            return Flight1;
        }
    }
}
