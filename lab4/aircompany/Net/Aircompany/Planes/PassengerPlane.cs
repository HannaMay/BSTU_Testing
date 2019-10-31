using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        //public int _passengersCapacity;
        public int passengersCapacity { get; private set; }


        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            //_passengersCapacity = passengersCapacity;
            this.passengersCapacity = passengersCapacity;
        }

        public override bool Equals(object objectToCompare)
        {
            //var plane = obj as PassengerPlane;
            //return plane != null && base.Equals(obj) && _passengersCapacity == plane._passengersCapacity;
            return (objectToCompare as PassengerPlane) != null && base.Equals(objectToCompare) &&  passengersCapacity == (objectToCompare as PassengerPlane).passengersCapacity;
        }

        public override int GetHashCode()
        {
            var hashCode = 751774561;
            //hashCode = hashCode * -1521134295 + base.GetHashCode();
            //hashCode = hashCode * -1521134295 + _passengersCapacity.GetHashCode();
            //return hashCode;
            return (hashCode * -1521134295 + base.GetHashCode()) * hashCode * -1521134295 + passengersCapacity.GetHashCode();

        }

        public int GetPassengersCapacityIs()
        {
            return passengersCapacity;
        }


        public override string ToString()
        {
            //return base.ToString().Replace("}", ", passengersCapacity=" + _passengersCapacity + '}');
            return base.ToString().Replace("}", ", passengersCapacity=" + passengersCapacity + '}');
        }       
        
    }
}
