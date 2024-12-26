namespace TransfersManager;

public class Passenger
{
    private int _passengerCount = 0;
    public Passenger(int passengerCount)
    {
        _passengerCount = passengerCount;
    }
    public int PassengerCount
    {
        get
        {
            return _passengerCount;
        }
    }
}
