namespace TransfersManager;

public class Station
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public List<int>? VehicleIDs { get; set; } = new List<int>();
}
