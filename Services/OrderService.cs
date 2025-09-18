using System;
using System.Collections.Generic;
using System.Linq;
using CustomerOrderManagement.Models;
using CustomerOrderManagement.Data;
using Microsoft.Extensions.Logging;

namespace CustomerOrderManagement.Services
{
    public class OrderService
    {
        private readonly JsonDataHandler _dataHandler;
        private List<Customer> _customers;
        private readonly ILogger<OrderService> _logger;

        public OrderService ()
        {
        _dataHandler = new JsonDataHandler();
        _customers = _dataHandler.LoadCustomers();

        var loggerFactory = LoggerFactory.Create(builder =>
        {
        builder.AddConsole();
        });

        _logger = loggerFactory.CreateLogger<OrderService>();
        }

        public void AddCustomer (string name, string email)
        {
        try {
        int newId = _customers.Any() ? _customers.Max(c => c.Id) + 1 : 1;
        var newCustomer = new Customer { Id = newId, Name = name, Email = email };
        _customers.Add(newCustomer);
        _dataHandler.SaveCustomers(_customers);
        _logger.LogInformation($"Customer {name} added successfully.");
        }
        catch (Exception ex) {
        _logger.LogError($"Error adding customer: {ex.Message}");
        }
        }

        public void AddOrder (int customerId, string productName, int quantity, decimal price)
        {
        try {
        var customer = _customers.FirstOrDefault(c => c.Id == customerId);
        if (customer == null) {
        _logger.LogWarning($"Customer ID {customerId} not found.");
        return;
        }

        int newOrderId = customer.Orders.Any() ? customer.Orders.Max(o => o.Id) + 1 : 1;
        var order = new Order
        {
            Id = newOrderId,
            CustomerId = customerId,
            ProductName = productName,
            Quantity = quantity,
            Price = price
        };

        customer.Orders.Add(order);
        _dataHandler.SaveCustomers(_customers);
        _logger.LogInformation($"Order {newOrderId} added for Customer ID {customerId}.");
        }
        catch (Exception ex) {
        _logger.LogError($"Error adding order: {ex.Message}");
        }
        }

        public List<Customer> GetCustomers ()
        {
        return _customers;
        }

        public List<Order> GetOrders (int customerId)
        {
        var customer = _customers.FirstOrDefault(c => c.Id == customerId);
        return customer?.Orders ?? new List<Order>();
        }
    }
}
