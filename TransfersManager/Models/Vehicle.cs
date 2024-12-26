namespace TransfersManager;

public class Vehicle
{
    public int ID { get; set; }
    public VehicleType VehicleType { get; set; }
    public int Capacity { get; set; }

    public Passenger? SetCurrentPassangers { private get; set; }
    public Passenger? GetCurrentPassangers
    {
        get
        {
            return SetCurrentPassangers;
        }
    }

}
