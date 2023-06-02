using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRepairManagementSystem
{
    class Vehicle
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsNew { get; set; }
    }

    class Inventory
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public int NumberOnHand { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }

    class Repair
    {
        public int ID { get; set; }
        public int InventoryID { get; set; }
        public string WhatToRepair { get; set; }
    }

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
                Console.WriteLine("Welcome, please choose a command:");
                Console.WriteLine("1. Modify vehicles");
                Console.WriteLine("2. Modify inventory");
                Console.WriteLine("3. Modify repairs");
                Console.WriteLine("4. Exit program");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ModifyVehicles();
                        break;
                    case "2":
                        ModifyInventory();
                        break;
                    case "3":
                        ModifyRepairs();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ModifyVehicles()
        {
            bool returnToMenu = false;
            while (!returnToMenu)
            {
                Console.WriteLine("VEHICLES MENU");
                Console.WriteLine("1. List all vehicles");
                Console.WriteLine("2. Add a new vehicle");
                Console.WriteLine("3. Update a vehicle");
                Console.WriteLine("4. Delete a vehicle");
                Console.WriteLine("5. Return to main menu");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
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
                        returnToMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ListVehicles()
        {
            Console.WriteLine("LIST OF VEHICLES");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"ID: {vehicle.ID}, Make: {vehicle.Make}, Model: {vehicle.Model}, Year: {vehicle.Year}, New/Used: {(vehicle.IsNew ? "New" : "Used")}");
            }
        }

        static void AddVehicle()
        {
            Console.WriteLine("ADD A NEW VEHICLE");
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Make: ");
            string make = Console.ReadLine();
            Console.Write("Enter Model: ");
            string model = Console.ReadLine();
            Console.Write("Enter Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Is it New? (y/n): ");
            bool isNew = Console.ReadLine().ToLower() == "y";

            vehicles.Add(new Vehicle
            {
                ID = id,
                Make = make,
                Model = model,
                Year = year,
                IsNew = isNew
            });

            Console.WriteLine("Vehicle added successfully.");
        }

        static void UpdateVehicle()
        {
            Console.WriteLine("UPDATE A VEHICLE");
            Console.Write("Enter the ID of the vehicle to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Vehicle vehicle = vehicles.FirstOrDefault(v => v.ID == id);

            if (vehicle != null)
            {
                Console.Write("Enter new Make: ");
                string make = Console.ReadLine();
                Console.Write("Enter new Model: ");
                string model = Console.ReadLine();
                Console.Write("Enter new Year: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Is it New? (y/n): ");
                bool isNew = Console.ReadLine().ToLower() == "y";

                vehicle.Make = make;
                vehicle.Model = model;
                vehicle.Year = year;
                vehicle.IsNew = isNew;

                Console.WriteLine("Vehicle updated successfully.");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        static void DeleteVehicle()
        {
            Console.WriteLine("DELETE A VEHICLE");
            Console.Write("Enter the ID of the vehicle to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Vehicle vehicle = vehicles.FirstOrDefault(v => v.ID == id);

            if (vehicle != null)
            {
                vehicles.Remove(vehicle);
                Console.WriteLine("Vehicle deleted successfully.");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        static void ModifyInventory()
        {
            bool returnToMenu = false;
            while (!returnToMenu)
            {
                Console.WriteLine("INVENTORY MENU");
                Console.WriteLine("1. Insert new inventory");
                Console.WriteLine("2. View inventory for a vehicle");
                Console.WriteLine("3. Return to main menu");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        InsertInventory();
                        break;
                    case "2":
                        ViewInventory();
                        break;
                    case "3":
                        returnToMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void InsertInventory()
        {
            Console.WriteLine("INSERT NEW INVENTORY");
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Vehicle ID: ");
            int vehicleId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number on Hand: ");
            int numberOnHand = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Cost: ");
            decimal cost = Convert.ToDecimal(Console.ReadLine());

            inventory.Add(new Inventory
            {
                ID = id,
                VehicleID = vehicleId,
                NumberOnHand = numberOnHand,
                Price = price,
                Cost = cost
            });

            Console.WriteLine("Inventory added successfully.");
        }

        static void ViewInventory()
        {
            Console.WriteLine("VIEW INVENTORY FOR A VEHICLE");
            Console.Write("Enter the Vehicle ID: ");
            int vehicleId = Convert.ToInt32(Console.ReadLine());

            var vehicleInventory = inventory.Where(i => i.VehicleID == vehicleId);
            if (vehicleInventory.Any())
            {
                Console.WriteLine($"INVENTORY FOR VEHICLE ID {vehicleId}:");
                foreach (var item in vehicleInventory)
                {
                    Console.WriteLine($"ID: {item.ID}, Number on Hand: {item.NumberOnHand}, Price: {item.Price}, Cost: {item.Cost}");
                }
            }
            else
            {
                Console.WriteLine("No inventory found for the specified vehicle ID.");
            }
        }

        static void ModifyRepairs()
        {
            bool returnToMenu = false;
            while (!returnToMenu)
            {
                Console.WriteLine("REPAIRS MENU");
                Console.WriteLine("1. View all repairs");
                Console.WriteLine("2. ...");
                Console.WriteLine("3. Return to main menu");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ViewRepairs();
                        break;
                    case "2":
                        // Add more options for modifying repairs
                        break;
                    case "3":
                        returnToMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ViewRepairs()
        {
            Console.WriteLine("VIEW ALL REPAIRS");
            foreach (var repair in repairs)
            {
                Console.WriteLine($"ID: {repair.ID}, Inventory ID: {repair.InventoryID}, What to Repair: {repair.WhatToRepair}");
            }
        }
    }
}
