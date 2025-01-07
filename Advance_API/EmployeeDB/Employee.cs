namespace EmployeeDB
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(int id, string nme, double sal)
        {
            Id = id;
            Name = nme;
            Salary = sal;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Id: {Id} Name: {Name} Salary: {Salary}");
        }
    }
}