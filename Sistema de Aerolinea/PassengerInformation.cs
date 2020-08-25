using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_de_Aerolinea
{
    public class PassengerInformation<T>
    {
        public string PassengerName { get; set; }
        public int PassengerAge { get; set; }
        public T PassengerID { get; set;}
        public decimal PassengerWeight { get; set; }
        public decimal PassengerLuggageWeight { get; set; }
    }
}
