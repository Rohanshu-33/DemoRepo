using System;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1_PC
{
    public class XMLSerializeDeserialize
    {
        // Make the Employee class public
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public float Salary { get; set; }
            public Address Address { get; set; }  // Nested Address object
        }

        // Make the Address class public
        public class Address
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
        }

        public static void XMLSerializeDeserializeDemo()
        {
            Employee e1 = new Employee
            {
                Id = 1,
                Name = "Rohanshu",
                Salary = 10000.00F,
                Address = new Address
                {
                    Street = "Vastrapur",
                    City = "Ahmedabad",
                    Country = "India"
                }
            };

            // Create the XmlSerializer for the Employee type
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));

            // Serialize the Employee object to XML
            using (StreamWriter writer = new StreamWriter("Employee.xml"))
            {
                serializer.Serialize(writer, e1);
            }
            Console.WriteLine("Employee object serialized to 'Employee.xml' using StreamWriter.");

            // Deserialize the XML back to an Employee object
            using (StreamReader reader = new StreamReader("Employee.xml"))
            {
                Employee e = (Employee)serializer.Deserialize(reader);
                Console.WriteLine("\nDeserialized Employee Object:");
                Console.WriteLine($"Id: {e.Id}");
                Console.WriteLine($"Name: {e.Name}");
                Console.WriteLine($"Salary: {e.Salary}");
                Console.WriteLine($"Address: {e.Address.Street}, {e.Address.City}, {e.Address.Country}");
            }
        }
    }
}
