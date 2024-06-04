using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Projekt_xl
{
    class Program
    {
        static List<Vehicle> vehicleList = new List<Vehicle>();
        static List<string> genralCarBrands = new List<string>
        {
            "Saab", "Volvo", "Toyota", "Volkswagen", "BMW", "Audi", "Porche", "Nissan",
            "Mazda", "Koenigsegg", "Lotus"
        };
        static List<string> popularMcTypes = new List<string>
        {
            "Street", "Naked", "Chopper", "Cruiser", "Touring", "Off-Road", "Scooter"
        };
        const int MinTruckWeight = 5;
        const int MaxTruckWeight = 100;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add a car");
                Console.WriteLine("2. Add a motorbike");
                Console.WriteLine("3. Add a truck");
                Console.WriteLine("4. Show the list of vehicles");
                Console.WriteLine("5. Close the program");
                Console.Write("Choose an alternative: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Incorrect entry. Enter a valid number from the menu.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddCar();
                        break;
                    case 2:
                        AddMC();
                        break;
                    case 3:
                        AddTruck();
                        break;
                    case 4:
                        ShowFordonList();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid selection, please try again.");
                        break;
                }
            }
        }

        private static void AddCar()
        {

            string licenseplate = GetValidRegistrationNumber();
            int modelyear = GetValidYearModel();

            string carBrand = GetValidCarBrand();

            Car car = new Car(licenseplate, modelyear, carBrand);
            vehicleList.Add(car);
        }

        private static void AddMC()
        {
            string licenseplate = GetValidRegistrationNumber();
            int modelyear = GetValidYearModel();

            string mcType = GetValidMotorcycleType();


            Mc mc = new Mc(licenseplate, modelyear, mcType);
            vehicleList.Add(mc);
        }
        private static void AddTruck()
        {
            string licenseplate = GetValidRegistrationNumber();
            int modelyear = GetValidYearModel();

            int truckWeight = GetValidTruckWeight();


            Truck truck = new Truck(licenseplate, modelyear, truckWeight);
            vehicleList.Add(truck);
        }

        private static void ShowFordonList()
        {
            foreach (Vehicle item in vehicleList)
            {
                Console.WriteLine("License plate number: {0}", item.Registernummer);
                Console.WriteLine("Year model: {0}", item.Yearmoddel);
                if (item is Car)
                {
                    Console.WriteLine("Car Brand: {0}", ((Car)item).CarBrand);
                }
                else if (item is Mc)
                {
                    Console.WriteLine("Motorbike typ: {0}", ((Mc)item).McType);
                }
                else if (item is Truck)
                {
                    Console.WriteLine("Truck weight: {0}", ((Truck)item).TruckWeight);
                }
                Console.WriteLine("------------------");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        private static string GetValidRegistrationNumber()
        {
            string licenseplate;
            Regex regex = new Regex(@"^[A-Za-z]{3}\d{3}$");
            while (true)
            {
                Console.Write("Licence plate number (three letters followed by three numbers) (WITHOUT SPACES): ");
                licenseplate = Console.ReadLine();
                if (regex.IsMatch(licenseplate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid license plate number, please try again.");
                }
            }
            return licenseplate;
        }

        private static int GetValidYearModel()
        {
            int modelyear;

            while (true)
            {
                Console.Write("Year model (between 1900 and 2024): ");
                try
                {
                    modelyear = int.Parse(Console.ReadLine());
                    if (modelyear >= 1900 && modelyear <= 2024)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Model year must be between 1900 and 2024, please try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Enter an integer.");
                }
            }
            return modelyear;
        }
        private static string GetValidCarBrand()
        {
            string carBrand;
            while (true)
            {
                Console.WriteLine("Enter the car brand (only from the following list):");
                foreach (string brand in genralCarBrands)
                {
                    Console.WriteLine(brand);
                }

                carBrand = Console.ReadLine();
                if (genralCarBrands.Contains(carBrand))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid car brand, please try again.");
                }
            }
            return carBrand;
        }

        private static string GetValidMotorcycleType()
        {
            string mcType;
            while (true)
            {
                Console.WriteLine("Enter motorbike type (only from the following list):");
                foreach (string type in popularMcTypes)
                {
                    Console.WriteLine(type);
                }

                mcType = Console.ReadLine();
                if (popularMcTypes.Contains(mcType))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid motorcycle type, please try again.");
                }
            }
            return mcType;
        }

        private static int GetValidTruckWeight()
        {
            int truckWeight;
            while (true)
            {
                Console.Write($"Enter truck weight (between {MinTruckWeight} and {MaxTruckWeight} ton): ");
                if (!int.TryParse(Console.ReadLine(), out truckWeight))
                {
                    Console.WriteLine("Invalid value, please try again.");
                    continue;
                }

                if (truckWeight < MinTruckWeight || truckWeight > MaxTruckWeight)
                {
                    Console.WriteLine($"Please enter a value between {MinTruckWeight} and {MaxTruckWeight} ton.");
                }
                else
                {
                    break;
                }
            }
            return truckWeight;
        }
    }

}
