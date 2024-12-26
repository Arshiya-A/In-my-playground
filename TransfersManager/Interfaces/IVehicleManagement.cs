namespace TransfersManager;

public interface IVehicleManagement
{
    public void Insert(Vehicle vehicle);
    public void Remove(Vehicle vehicle);
    public void DisplayAllVehicles();
    public Vehicle GetByID(int Id);
}
