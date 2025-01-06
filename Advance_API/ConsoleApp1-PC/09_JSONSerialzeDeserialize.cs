using System;
using System.Text.Json;

namespace ConsoleApp1_PC
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Salary { get; set; }
    }

    internal class JSONSerialzeDeserialize
    {
        public static void JSONSerializeDeserializeDemo()
        {
            Employee e1 = new Employee
            {
                Id = 1,
                Name = "rohanshu",
                Salary = 10000.00F
            };

            // Serialization

            string jsonString = JsonSerializer.Serialize<Employee>(e1);

            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.WriteIndented = true;  // json format like of postman
            string jsonString2 = JsonSerializer.Serialize<Employee>(e1, options);

            byte[] byteJsonString = JsonSerializer.SerializeToUtf8Bytes<Employee>(e1);

            File.WriteAllText("Employees.json", jsonString);


            // Deserialization

            string jsonContent = File.ReadAllText("Employees.json");
            Employee e = JsonSerializer.Deserialize<Employee>(jsonContent);

        }
    }
}
