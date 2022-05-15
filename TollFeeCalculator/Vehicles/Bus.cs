

namespace TollFeeCalculator.Vehicles
{
    internal class Bus : IVehicle
    {
        public int weight { get; set; } 
        public bool IsTollFree => weight > 14000;
    }
}
