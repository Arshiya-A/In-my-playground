namespace TransfersManager;

public class RouteManagement : IRouteManagement
{

    private DatabaseSimulator _db;
    public RouteManagement(DatabaseSimulator context)
    {
        _db = context;
    }
    public void EditRoute(Station source, Station destination, float distance)
    {
        var route = new Route()
        {
            SourceStation = source,
            DestinationStation = destination,
            Distance = distance,
        };
        _db.Route = route;
    }
    public void PrintRouteInfo()
    {
        System.Console.WriteLine("Route Info : ");
        System.Console.WriteLine("Source Station : " + _db.Route.SourceStation!.Name);
        System.Console.WriteLine("Destination Station : " + _db.Route.DestinationStation!.Name);
        System.Console.WriteLine("Distance : " + _db.Route.Distance + " Km");
    }



}
