namespace TransfersManager;

internal class Program
{
    private static DatabaseSimulator _db = new DatabaseSimulator();
    private static string _command = "";
    static void Main(string[] args)
    {
        IVehicleManagement vehicleManagement = new VehicleManagement(_db);
        IPassengerManagement passengerManagement = new PassengerManagement();
        IStationManagement stationManagement = new StationManagement(_db);
        IRouteManagement routeManagement = new RouteManagement(_db);


        HomePage();

    }

    public static void HomePage()
    {
        Console.Clear();
        bool run = true;

        while (run)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Transfer Management");
            System.Console.WriteLine("This program is simulating intracity transfer \n");
            System.Console.WriteLine("Commands :");
            System.Console.WriteLine("[-v] => Vehicle manager");
            System.Console.WriteLine("[-p] => Passenger manager");
            System.Console.WriteLine("[-s] => Station manager");
            System.Console.WriteLine("[-r] => Edit Route");
            System.Console.WriteLine("[exit] => For exit program. \n");

            _command = Console.ReadLine();

            switch (_command)
            {
                case "-v":
                    VehicleManager();
                    break;
                case "-p":
                    PassengerManager();
                    break;
                case "-s":
                    StationManagerPage();
                    break;
                case "-r":
                    RouteManagerPage();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    break;
            }
        }
    }

    public static void VehicleManager()
    {
        Console.Clear();
        string id = "";

        while (true)
        {
            System.Console.WriteLine("Vehicle Manager :");

            System.Console.WriteLine("Commands :");
            System.Console.WriteLine("[-a] => Add Vehicle To List");
            System.Console.WriteLine("[-s] => Show Vehicles");
            System.Console.WriteLine("[-r] => Remove Vehicle");

            System.Console.WriteLine("[-b] => Back. \n");
            _command = Console.ReadLine();

            switch (_command)
            {
                case "-a":
                    AddVehiclePage();
                    break;

                case "-s":
                    Console.Clear();
                    ShowVehiclePage();
                    break;

                case "-b":
                    HomePage();
                    break;

                case "-r":
                    RemoveVehiclePage();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }

    public static void PassengerManager()
    {
        Console.Clear();
        string id = "";

        while (true)
        {
            System.Console.WriteLine("Passenger Manager :");

            System.Console.WriteLine("Commands :");
            System.Console.WriteLine("[-a] => Add Passenger to Vehicle");
            System.Console.WriteLine("[-r] => Remove Passenger from Vehicle");

            System.Console.WriteLine("[-b] => Back. \n");
            _command = Console.ReadLine();

            switch (_command)
            {
                case "-a":
                    AddPassengerPage();
                    break;
                case "-r":
                    RemovePassengerPage();
                    break;
                case "-b":
                    HomePage();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }




    public static void AddVehiclePage()
    {
        IVehicleManagement vehicleManagement = new VehicleManagement(_db);

        string vehicleType = "";
        string capacity = "";
        VehicleType type = VehicleType.Taxi;

        System.Console.WriteLine("Add Vehicle :");
        System.Console.WriteLine("Vehicle Type [1-Taxi , 2-Bus , 3-Subway]");
        System.Console.Write("\nType : ");
        vehicleType = Console.ReadLine();

        if (vehicleType == "1" || vehicleType == "2" || vehicleType == "3")
        {
            switch (vehicleType)
            {
                case "1":
                    type = VehicleType.Taxi;
                    break;
                case "2":
                    type = VehicleType.Bus;
                    break;
                case "3":
                    type = VehicleType.Subway;
                    break;

            }
            System.Console.WriteLine("Set Vehicle Capacity");
            System.Console.Write("\nCapacity : ");
            capacity = Console.ReadLine();

            vehicleManagement.Insert(new Vehicle()
            {
                Capacity = Convert.ToInt32(capacity),
                VehicleType = type,
            });

            System.Console.WriteLine("Vehicle created with successfully.");
            Console.ReadKey();
            VehicleManager();
        }
        else
            VehicleManager();

    }

    public static void RemoveVehiclePage()
    {
        int id = 0;

        System.Console.WriteLine("Remove Vehicle :");
        System.Console.WriteLine("Vehicle ID");
        System.Console.Write("\nID : ");

        _command = Console.ReadLine();
        id = Convert.ToInt32(_command);
        IVehicleManagement vehicleManagement = new VehicleManagement(_db);
        vehicleManagement.Remove(vehicleManagement.GetByID(id));

        System.Console.WriteLine("Vehicle removed.");
        Console.ReadKey();
    }

    public static void ShowVehiclePage()
    {
        Console.Clear();
        IVehicleManagement vehicleManagement = new VehicleManagement(_db);
        System.Console.WriteLine("Vehicles : \n");
        vehicleManagement.DisplayAllVehicles();

    }

    public static void AddPassengerPage()
    {
        IVehicleManagement vehicleManagement = new VehicleManagement(_db);
        IPassengerManagement passengerManagement = new PassengerManagement();

        int id = 0;

        System.Console.WriteLine("Add Passanger :");
        System.Console.WriteLine("Vehicle ID");
        System.Console.Write("\nID : ");
        _command = Console.ReadLine();
        id = Convert.ToInt32(_command);
        System.Console.WriteLine("Passanger Count :");
        System.Console.Write("Count : ");
        _command = Console.ReadLine();

        var vehicle = vehicleManagement.GetByID(id);
        passengerManagement.SelectVehile(vehicle);
        passengerManagement.SetCount(Convert.ToInt32(_command));

    }


    public static void RemovePassengerPage()
    {
        IVehicleManagement vehicleManagement = new VehicleManagement(_db);
        IPassengerManagement passengerManagement = new PassengerManagement();

        int id = 0;

        System.Console.WriteLine("Remove Passanger :");
        System.Console.WriteLine("Vehicle ID");
        System.Console.Write("\nID : ");
        _command = Console.ReadLine();
        id = Convert.ToInt32(_command);
        System.Console.WriteLine("Passanger Count :");
        System.Console.Write("Count : ");
        _command = Console.ReadLine();

        var vehicle = vehicleManagement.GetByID(id);
        passengerManagement.SelectVehile(vehicle);
        passengerManagement.SetCount(vehicle.GetCurrentPassangers!.PassengerCount - Convert.ToInt32(_command));

    }

    public static void StationManagerPage()
    {
        Console.Clear();
        string id = "";

        while (true)
        {
            System.Console.WriteLine("Station Manager :");

            System.Console.WriteLine("Commands :");
            System.Console.WriteLine("[-a -s] => Add Station");
            System.Console.WriteLine("[-a -v] => Add Vehicle to Station");
            System.Console.WriteLine("[-r -s] => Remove Station");
            System.Console.WriteLine("[-r -v] => Remove Vehicle from Station");
            System.Console.WriteLine("[-s] => Show Stations");

            System.Console.WriteLine("[-b] => Back. \n");
            _command = Console.ReadLine();

            switch (_command)
            {
                case "-a -s":
                    AddStationPage();
                    break;
                case "-a -v":
                    AddVehicleToStationPage();
                    break;
                case "-r -s":
                    RemoveStationPage();
                    break;
                case "-r -v":
                    RemoveVehicleFromStationPage();
                    break;
                case "-s":
                    ShowStaionPage();
                    break;
                case "-b":
                    HomePage();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }

    public static void AddStationPage()
    {
        Console.Clear();

        IStationManagement stationManagement = new StationManagement(_db);

        System.Console.WriteLine("Add Station :");
        System.Console.WriteLine("Station name : ");
        System.Console.Write("\nName : ");
        _command = Console.ReadLine();
        stationManagement.AddStation(_command);

        System.Console.WriteLine("Station created with successfully.");
        Console.ReadKey();
    }

    public static void RemoveStationPage()
    {
        Console.Clear();

        IStationManagement stationManagement = new StationManagement(_db);

        System.Console.WriteLine("Remove Station :");
        System.Console.WriteLine("Station ID : ");
        System.Console.Write("\nID : ");
        _command = Console.ReadLine();
        stationManagement.RemoveStation(Convert.ToInt32(_command));

        System.Console.WriteLine("Station removed.");
        Console.ReadKey();
    }


    public static void AddVehicleToStationPage()
    {
        Console.Clear();

        IStationManagement stationManagement = new StationManagement(_db);

        int stationId = 0;
        int vehicleId = 0;

        System.Console.WriteLine("Add Vehicle to Station :");
        System.Console.WriteLine("Station ID : ");
        System.Console.Write("\nID : ");
        _command = Console.ReadLine();
        stationId = Convert.ToInt32(_command);
        System.Console.WriteLine("\n");
        System.Console.WriteLine("Vehicle ID : ");
        System.Console.Write("\nID : ");
        _command = Console.ReadLine();
        vehicleId = Convert.ToInt32(_command);

        stationManagement.AddVehicleToStation(stationId, vehicleId);
    }

    public static void RemoveVehicleFromStationPage()
    {
        Console.Clear();

        IStationManagement stationManagement = new StationManagement(_db);

        int stationId = 0;
        int vehicleId = 0;

        System.Console.WriteLine("Remove Vehicle from Station :");
        System.Console.WriteLine("Station ID : ");
        System.Console.Write("\nID : ");
        _command = Console.ReadLine();
        stationId = Convert.ToInt32(_command);
        System.Console.WriteLine("\n");
        System.Console.WriteLine("Vehicle ID : ");
        System.Console.Write("\nID : ");
        _command = Console.ReadLine();
        vehicleId = Convert.ToInt32(_command);

        stationManagement.RemoveVehicleFromStation(stationId, vehicleId);
    }

    public static void ShowStaionPage()
    {
        Console.Clear();
        System.Console.WriteLine("Stations : ");
        IStationManagement stationManagement = new StationManagement(_db);

        stationManagement.DisplayStations();
    }

    public static void RouteManagerPage()
    {
        Console.Clear();
        string id = "";

        while (true)
        {
            System.Console.WriteLine("Route Manager :");

            System.Console.WriteLine("Commands :");
            System.Console.WriteLine("[-e] => Edit Route");
            System.Console.WriteLine("[-s] => Show Route");

            System.Console.WriteLine("[-b] => Back. \n");
            _command = Console.ReadLine();

            switch (_command)
            {
                case "-e":
                    EditRoutePage();
                    break;
                case "-s":
                    ShowRoutePage();
                    break;
                case "-b":
                    HomePage();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }

    private static void ShowRoutePage()
    {
        Console.Clear();

        IRouteManagement routeManagement = new RouteManagement(_db);
        routeManagement.PrintRouteInfo();
    }

    private static void EditRoutePage()
    {
        int sourceStationId = 0;
        int destinationStationId = 0;
        float distance = 0.0f;

        Console.Clear();
        IStationManagement stationManagement = new StationManagement(_db);
        IRouteManagement routeManagement = new RouteManagement(_db);

        System.Console.WriteLine("Source Station :");
        System.Console.WriteLine("Source Station ID : ");
        System.Console.Write("\nID : ");
        _command = Console.ReadLine();
        sourceStationId = Convert.ToInt32(_command);

        System.Console.WriteLine("\n");
        System.Console.WriteLine("Destination Station :");
        System.Console.WriteLine("Destination Station ID :");
        System.Console.Write("\nID : ");
        _command = Console.ReadLine();
        destinationStationId = Convert.ToInt32(_command);

        System.Console.WriteLine("\n");
        System.Console.WriteLine("Distance between two Stations :");
        System.Console.WriteLine("Distance :");
        System.Console.Write("\n Km : ");
        _command = Console.ReadLine();
        distance = (float)Convert.ToDouble(_command);

        if (stationManagement.GetStation(sourceStationId) is not null &&
         stationManagement.GetStation(destinationStationId) is not null)
        {
            routeManagement.EditRoute(stationManagement.GetStation(sourceStationId),
                   stationManagement.GetStation(destinationStationId), distance);
            System.Console.WriteLine("\n");
            System.Console.WriteLine("Route Edited.");
            Console.ReadKey();
            RouteManagerPage();
        }
        else
        {
            System.Console.WriteLine("Station is not defined.");
            Console.ReadKey();
        }



    }
}