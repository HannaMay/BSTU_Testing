using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        //public string _model;
        //public int _maxSpeed;
        //public int _maxFlightDistance;
        //public int _maxLoadCapacity;
        public string modelAirplane;
        public int maxSpeedAirplane;
        public int maxFlightDistanceAirplane;
        public int maxLoadCapacityAirplane;

        //public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        //{
        //    _model = model;
        //    _maxSpeed = maxSpeed;
        //    _maxFlightDistance = maxFlightDistance;
        //    _maxLoadCapacity = maxLoadCapacity;
        //}
        public Plane(string modelAirplane, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            this.modelAirplane = modelAirplane;
            this.maxSpeedAirplane = maxSpeed;
            this.maxFlightDistanceAirplane = maxFlightDistance;
            this.maxLoadCapacityAirplane = maxLoadCapacity;
        }

        public string GetModel()
        {
            //return _model;
            return this.modelAirplane;
        }

        public int GetMaxSpeed()
        {
            //return _maxSpeed;
            return this.maxSpeedAirplane;
        }

        public int GetMaxFlightDistance()
        {
            //return _maxFlightDistance;
            return this.maxFlightDistanceAirplane;
        }

        public int GetMaxLoadCapacity()
        {
            return this.maxLoadCapacityAirplane;
        } 

        public override string ToString()
        {
            return "Plane{" +
                "model='" + this.modelAirplane + '\'' +
                ", maxSpeed=" + this.maxSpeedAirplane +
                ", maxFlightDistance=" + this.maxFlightDistanceAirplane +
                ", maxLoadCapacity=" + this.maxLoadCapacityAirplane +
                '}';
        }

        public override bool Equals(object objectToCompare)
        {
            //var plane = obj as Plane;
            //return plane != null &&
            //       _model == plane._model &&
            //       _maxSpeed == plane._maxSpeed &&
            //       _maxFlightDistance == plane._maxFlightDistance &&
            //       _maxLoadCapacity == plane._maxLoadCapacity;
            return (objectToCompare as Plane) != null &&
                   modelAirplane == (objectToCompare as Plane).modelAirplane &&
                   maxSpeedAirplane == (objectToCompare as Plane).maxSpeedAirplane &&
                   maxFlightDistanceAirplane == (objectToCompare as Plane).maxFlightDistanceAirplane &&
                   maxLoadCapacityAirplane == (objectToCompare as Plane).maxLoadCapacityAirplane;
        }

        public override int GetHashCode()
        {
        var hashCode = -1043886837;
        return (((hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(modelAirplane))
            * -1521134295 + maxSpeedAirplane.GetHashCode()) * hashCode * -1521134295 + maxFlightDistanceAirplane.GetHashCode())
            * hashCode * -1521134295 + maxLoadCapacityAirplane.GetHashCode();
        }
    }
}
