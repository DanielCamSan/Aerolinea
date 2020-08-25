using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_de_Aerolinea
{
    public enum PassengerType
    {
        EconomyClass,
        ExecutiveClass,
        FirstClass
    }
    public static class PassengerAllocator<T>
    {
        public static PassengerType type;

        public static IPassengerType<T> Create()
        {
            switch (type)
            {
                case PassengerType.EconomyClass:
                    return new EconomyClassPassenger<T>();
                case PassengerType.ExecutiveClass:               
                    return new ExecutiveClassPassenger<T>();
                case PassengerType.FirstClass:                
                    return new FirstClassPassenger<T>();
                default:
                    return null;
            }
        }

    }
}
