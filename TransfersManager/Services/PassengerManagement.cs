namespace TransfersManager;

public class PassengerManagement : IPassengerManagement
{
    private Vehicle? _vehicle;
    public void SelectVehile(Vehicle vehicle) => _vehicle = vehicle;

    public void SetCount(int count)
    {
        Passenger passenger = new(count);
       
    
        if (count < 1)
            passenger = new(0);

        if (passenger.PassengerCount > _vehicle?.Capacity)
            throw new Exception("This Vehicle have maximum space.");


        _vehicle.SetCurrentPassangers = passenger;
    }




}
