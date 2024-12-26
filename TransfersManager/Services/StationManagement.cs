namespace TransfersManager;

public class StationManagement : IStationManagement
{

    private DatabaseSimulator _db;
    public StationManagement(DatabaseSimulator context)
    {
        _db = context;
    }



    public void AddStation(string stationName)
    {
        _db.ID_Cunter++;
        var station = new Station()
        {
            ID = _db.ID_Cunter,
            Name = stationName,
        };

        _db.Stations.Add(station);
    }

    public void AddVehicleToStation(int stationId, int vehicleId)
    {
        if (vehicleExistCheck(vehicleId))
        {
            var station = GetStation(stationId);

            foreach (var item in station.VehicleIDs)
            {
                if (item == vehicleId)
                    throw new Exception("This vehicle has been existed.");
            }

            foreach (var item in _db.Stations)
            {
                if (item.VehicleIDs.Contains(vehicleId))
                {
                    throw new Exception("This vehicle has been existed on another station.");
                }
            }

            station?.VehicleIDs?.Add(vehicleId);
        }

        else
            throw new Exception("Vehicle is not defined.");
    }

    public void RemoveVehicleFromStation(int stationId, int vehicleId)
    {
        if (vehicleExistCheck(vehicleId))
        {
            var station = GetStation(stationId);
            station.VehicleIDs.Remove(vehicleId);
        }
        else
            throw new Exception("Vehicle is not defined.");

    }

    public void RemoveStation(int stationId)
    {
        var station = GetStation(stationId);
        _db.Stations.Remove(station!);
    }





    public void DisplayStations()
    {
        int index = -1;
        foreach (var item in _db.Stations)
        {
            index++;

            Console.WriteLine("\nStation ID : " + item.ID + "\n" +
            "Station Name : " + item.Name);
            Console.Write("Vehicles Existing (by ID): ");
            Console.Write("[");
            item.VehicleIDs.ForEach(delegate (int numbers)
            {
                Console.Write(" " + numbers + " , ");
            });
            Console.Write("]");
            Console.Write("\n");
        }
    }

    public Station GetStation(int stationId) => _db.Stations.Find(i => i.ID == stationId)!;
    private bool vehicleExistCheck(int vehicleId)
    {
        var vehicles = _db.Vehicles;
        foreach (var item in vehicles)
        {
            if (item.ID == vehicleId)
                return true;
        }

        return false;

    }
}
