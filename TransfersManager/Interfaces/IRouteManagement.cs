namespace TransfersManager;

public interface IRouteManagement
{
    public void PrintRouteInfo();
    public void EditRoute(Station source, Station destination, float distance);

}
