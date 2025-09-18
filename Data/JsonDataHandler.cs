using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using CustomerOrderManagement.Models;

namespace CustomerOrderManagement.Data
{
    public class JsonDataHandler
    {
        private readonly string _filePath = "data.json";

        public List<Customer> LoadCustomers ()
        {
        if (!File.Exists(_filePath)) return new List<Customer>();

        string json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
        }

        public void SaveCustomers (List<Customer> customers)
        {
        string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
        File.WriteAllText(_filePath, json);
        }
    }
}
