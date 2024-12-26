namespace TransfersManager;

public class DatabaseSimulator
{
    public List<Vehicle> Vehicles;
    public List<Station> Stations;
    public Route Route;
    public int ID_Cunter = 0;

    public DatabaseSimulator()
    {
        Vehicles = new List<Vehicle>();
        Stations = new List<Station>();
        Route = new Route();
    }
}
