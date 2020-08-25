using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_de_Aerolinea
{
    //Uso de interfaz y no clases abstractas
    public interface IPassengerType<T>
    {
        string Owner { get; set; }
        decimal Weight { get; set; }
        int Age { get; set;}
        T ID { get; set; }
        decimal LuggageWeight { get; set; }
        decimal TicketPrice { get; set; }
        int SnacksQuantity { get; set; }
        T NumberOfFlight { get; set; }
        decimal GetTotalPrice();
        string GetBrand();
        PassengerInformation<T> GetPassengerInformation();

    }
}

