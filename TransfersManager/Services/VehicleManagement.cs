
namespace TransfersManager;

public class VehicleManagement : IVehicleManagement
{

    public DatabaseSimulator _db;
    public VehicleManagement(DatabaseSimulator context)
    {
        _db = context;
    }

    public void Insert(Vehicle vehicle)
    {
        _db.ID_Cunter++;
        vehicle.ID = _db.ID_Cunter++;
        _db.Vehicles.Add(vehicle);

    }
    public void Remove(Vehicle Vehicle) => _db.Vehicles.Remove(Vehicle);

    public Vehicle GetByID(int Id)
    {
        var result = _db.Vehicles.FirstOrDefault(i => i.ID == Id);
        if (result is not null)
            return result;

        throw new Exception("Vehicle is not found :(");
    }

    public void DisplayAllVehicles()
    {
        foreach (var item in _db.Vehicles)
        {
            Console.WriteLine("Vehicle ID : " + item.ID + "\n" +
            "Vehicle Type : " + item.VehicleType + "\n" +
            "Total Passanger : " + item.Capacity
             );

            int currentPassenger = 0;
            if (item.GetCurrentPassangers is not null)
                currentPassenger = item.GetCurrentPassangers.PassengerCount;

            System.Console.WriteLine("Current Passenger : " + currentPassenger + "\n");
        }

    }
}
