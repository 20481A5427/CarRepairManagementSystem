using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRepairManagementSystem
{
    class Program
    {
        static List<Vehicle> vehicles = new List<Vehicle>();
        static List<Inventory> inventory = new List<Inventory>();
        static List<Repair> repairs = new List<Repair>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu 1: \nWelcome, please choose a command:");
                Console.WriteLine("Press 1 to modify vehicles");
                Console.WriteLine("Press 2 to modify inventory");
                Console.WriteLine("Press 3 to modify repair");
                Console.WriteLine("Press 4 to exit program");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        VehicleMenu();
                        break;
                    case "2":
                        InventoryMenu();
                        break;
                    case "3":
                        RepairMenu();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void VehicleMenu()
        {
            bool backToMainMenu = false;
            while (!backToMainMenu)
            {
                Console.WriteLine("Menu 2: \nPress 1 to list all vehicles");
                Console.WriteLine("Press 2 to add a new vehicle");
                Console.WriteLine("Press 3 to update a vehicle");
                Console.WriteLine("Press 4 to delete a vehicle");
                Console.WriteLine("Press 5 to return to the main menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ListVehicles();
                        break;
                    case "2":
                        AddVehicle();
                        break;
                    case "3":
                        UpdateVehicle();
                        break;
                    case "4":
                        DeleteVehicle();
                        break;
                    case "5":
                        backToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ListVehicles()
        {
            Console.WriteLine("List of Vehicles:");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.ID} - {vehicle.Make} {vehicle.Model} ({vehicle.Year}) {(vehicle.IsNew ? "New" : "Used")}");
            }
        }

        static void AddVehicle()
        {
            Console.WriteLine("Enter vehicle details:");
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Make: ");
            string make = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("New or Used (N/U): ");
            bool isNew = Console.ReadLine().ToLower() == "n";

            vehicles.Add(new Vehicle(id, make, model, year, isNew));
            Console.WriteLine("Vehicle added successfully!");
        }

        static void UpdateVehicle()
        {
            Console.Write("Enter the ID of the vehicle to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var vehicle = vehicles.FirstOrDefault(v => v.ID == id);
            if (vehicle != null)
            {
                Console.WriteLine("Enter new vehicle details:");
                Console.Write("Make: ");
                string make = Console.ReadLine();
                Console.Write("Model: ");
                string model = Console.ReadLine();
                Console.Write("Year: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("New or Used (N/U): ");
                bool isNew = Console.ReadLine().ToLower() == "n";

                vehicle.Make = make;
                vehicle.Model = model;
                vehicle.Year = year;
                vehicle.IsNew = isNew;

                Console.WriteLine("Vehicle updated successfully!");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        static void DeleteVehicle()
        {
            Console.Write("Enter the ID of the vehicle to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var vehicle = vehicles.FirstOrDefault(v => v.ID == id);
            if (vehicle != null)
            {
                vehicles.Remove(vehicle);
                Console.WriteLine("Vehicle deleted successfully!");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        static void InventoryMenu()
        {
            bool backToMainMenu = false;
            while (!backToMainMenu)
            {
                Console.WriteLine("Menu 3: \nPress 1 to insert new inventory");
                Console.WriteLine("Press 2 to view inventory for a vehicle");
                Console.WriteLine("Press 3 to return to the main menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        InsertInventory();
                        break;
                    case "2":
                        ViewInventory();
                        break;
                    case "3":
                        backToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void InsertInventory()
        {
            Console.WriteLine("Enter inventory details:");
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Vehicle ID: ");
            int vehicleId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number on Hand: ");
            int numberOnHand = Convert.ToInt32(Console.ReadLine());
            Console.Write("Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Cost: ");
            decimal cost = Convert.ToDecimal(Console.ReadLine());

            inventory.Add(new Inventory(id, vehicleId, numberOnHand, price, cost));
            Console.WriteLine("Inventory inserted successfully!");
        }

        static void ViewInventory()
        {
            Console.Write("Enter the ID of the vehicle to view its inventory: ");
            int vehicleId = Convert.ToInt32(Console.ReadLine());

            var vehicleInventory = inventory.Where(i => i.VehicleID == vehicleId);
            if (vehicleInventory.Any())
            {
                Console.WriteLine($"Inventory for Vehicle ID {vehicleId}:");
                foreach (var item in vehicleInventory)
                {
                    Console.WriteLine($"ID: {item.ID}, Number on Hand: {item.NumberOnHand}, Price: {item.Price}, Cost: {item.Cost}");
                }
            }
            else
            {
                Console.WriteLine("No inventory found for the specified vehicle.");
            }
        }

        static void RepairMenu()
        {
            bool backToMainMenu = false;
            while (!backToMainMenu)
            {
                Console.WriteLine("Menu 4: \nPress 1 to view all repairs");
                Console.WriteLine("Press 2 to ...");
                Console.WriteLine("Press... to return to the main menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewRepairs();
                        break;
                    case "2":
                        // Add other repair operations here
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ViewRepairs()
        {
            Console.WriteLine("List of Repairs:");
            foreach (var repair in repairs)
            {
                Console.WriteLine($"{repair.ID} - Inventory ID: {repair.InventoryID}, What to Repair: {repair.WhatToRepair}");
            }
        }
    }

    class Vehicle
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsNew { get; set; }

        public Vehicle(int id, string make, string model, int year, bool isNew)
        {
            ID = id;
            Make = make;
            Model = model;
            Year = year;
            IsNew = isNew;
        }
    }

    class Inventory
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public int NumberOnHand { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        public Inventory(int id, int vehicleId, int numberOnHand, decimal price, decimal cost)
        {
            ID = id;
            VehicleID = vehicleId;
            NumberOnHand = numberOnHand;
            Price = price;
            Cost = cost;
        }
    }

    class Repair
    {
        public int ID { get; set; }
        public int InventoryID { get; set; }
        public string WhatToRepair { get; set; }

        public Repair(int id, int inventoryId, string whatToRepair)
        {
            ID = id;
            InventoryID = inventoryId;
            WhatToRepair = whatToRepair;
        }
    }
}
