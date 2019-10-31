using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        //public MilitaryType _type;
        public MilitaryType militaryType { get; private set; }

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            //_type = type;
            this.militaryType = militaryType;
        }

        public override bool Equals(object objectToCompare)
        {
            var plane = objectToCompare as MilitaryPlane;
            //return plane != null && base.Equals(obj) && _type == plane._type;
            return (objectToCompare as MilitaryPlane) != null && base.Equals(objectToCompare) && militaryType == (objectToCompare as MilitaryPlane).militaryType;
        }

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            //hashCode = hashCode * -1521134295 + base.GetHashCode();
            //hashCode = hashCode * -1521134295 + _type.GetHashCode();
            //return hashCode;
            return (hashCode * -1521134295 + base.GetHashCode()) * hashCode * -1521134295 + militaryType.GetHashCode();
        }

        public MilitaryType GetPlaneTypeIs()
        {
            return militaryType;
        }


        public override string ToString()
        {
            //return base.ToString().Replace("}", ", type=" + _type +'}');
            return base.ToString().Replace("}", ", type=" + militaryType + '}');

        }
    }
}
