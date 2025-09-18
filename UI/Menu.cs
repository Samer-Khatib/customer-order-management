using System;
using CustomerOrderManagement.Services;

namespace CustomerOrderManagement.UI
{
    public class Menu
    {
        private readonly OrderService _service;

        public Menu (OrderService service)
        {
        _service = service;
        }

        public void ShowMenu ()
        {
        while (true) {
        Console.WriteLine("\nCustomer Order Management System");
        Console.WriteLine("1. Add Customer");
        Console.WriteLine("2. Add Order");
        Console.WriteLine("3. View Customers");
        Console.WriteLine("4. View Orders");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine() ?? string.Empty;

        switch (choice) {
            case "1":
                AddCustomer();
                break;
            case "2":
                AddOrder();
                break;
            case "3":
                ViewCustomers();
                break;
            case "4":
                ViewOrders();
                break;
            case "5":
                return;
            default:
                Console.WriteLine("Invalid option, try again.");
                break;
        }
        }
        }

        private void AddCustomer ()
        {
        Console.Write("Enter Customer Name: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) {
        Console.WriteLine("Invalid input. Name cannot be empty.");
        return;
        }

        Console.Write("Enter Customer Email: ");
        string? email = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(email)) {
        Console.WriteLine("Invalid input. Email cannot be empty.");
        return;
        }

        _service.AddCustomer(name, email);
        Console.WriteLine("Customer added successfully!");
        }

        private void AddOrder ()
        {
        Console.Write("Enter Customer ID: ");
        if (!int.TryParse(Console.ReadLine(), out int customerId)) {
        Console.WriteLine("Invalid input. Please enter a valid Customer ID.");
        return;
        }

        Console.Write("Enter Product Name: ");
        string? productName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(productName)) {
        Console.WriteLine("Invalid input. Product name cannot be empty.");
        return;
        }

        Console.Write("Enter Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity)) {
        Console.WriteLine("Invalid input. Please enter a valid integer.");
        return;
        }

        Console.Write("Enter Price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price)) {
        Console.WriteLine("Invalid input. Please enter a valid decimal number.");
        return;
        }

        _service.AddOrder(customerId, productName, quantity, price);
        Console.WriteLine("Order added successfully!");
        }

        private void ViewCustomers ()
        {
        var customers = _service.GetCustomers();
        if (customers.Count == 0) {
        Console.WriteLine("No customers found.");
        return;
        }

        foreach (var c in customers) {
        Console.WriteLine($"ID: {c.Id}, Name: {c.Name}, Email: {c.Email}");
        }
        }

        private void ViewOrders ()
        {
        Console.Write("Enter Customer ID: ");
        if (!int.TryParse(Console.ReadLine(), out int customerId)) {
        Console.WriteLine("Invalid input. Please enter a valid Customer ID.");
        return;
        }

        var orders = _service.GetOrders(customerId);
        if (orders.Count == 0) {
        Console.WriteLine("No orders found for this customer.");
        return;
        }

        foreach (var order in orders) {
        Console.WriteLine($"Order ID: {order.Id}, Product: {order.ProductName}, Quantity: {order.Quantity}, Price: {order.Price}");
        }
        }
    }
}
