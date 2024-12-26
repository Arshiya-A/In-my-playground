namespace TransfersManager;

public interface IStationManagement
{
    public void AddStation(string stationName);
    public void RemoveStation(int stationId);
    public void AddVehicleToStation(int stationId, int vehicleId);
    public void RemoveVehicleFromStation(int stationId, int vehicleId);
    public Station GetStation(int stationId);

    public void DisplayStations();
}
