using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_de_Aerolinea
{
    class FirstClassPassenger<T> : IPassengerType<T>
    {
        private string owner;
        private int snacksQuantity;
        private T numberOfFlight;
        private decimal weight;
        private int age;
        private decimal luggageWeight;
        private decimal ticketPrice;
        private T id;
        private const string brand = "First Class";
        private const int ageLimit = 18;

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public int SnacksQuantity
        {
            get { return snacksQuantity; }
            set { snacksQuantity = value; }
        }
        public T NumberOfFlight
        {
            get { return numberOfFlight; }
            set { numberOfFlight = value; }
        }
        public decimal Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public decimal LuggageWeight
        {
            get { return luggageWeight; }
            set { luggageWeight = value; }
        }
        public decimal TicketPrice
        {
            get { return ticketPrice; }
            set { ticketPrice = value; }
        }
        public T ID
        {
            get { return id; }
            set { id = value; }
        }

        public string GetBrand()
        {
            return brand;
        }

        public PassengerInformation<T> GetPassengerInformation()
        {
            return new PassengerInformation<T>()
            {
                PassengerName = owner,
                PassengerAge = age,
                PassengerID = id,
                PassengerWeight = weight,
                PassengerLuggageWeight = luggageWeight
            };
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            Func<int, int, bool> esMayorDeEdad = (passengerAge, passengerAgeLimit) => { return passengerAge > passengerAgeLimit; };
            totalPrice = ticketPrice + snacksQuantity * 10 + LuggageWeight * 0.5m;
            if (!esMayorDeEdad(age, ageLimit))
                totalPrice *= 0.6m;
            return totalPrice;
        }
    }
}
