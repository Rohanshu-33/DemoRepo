using ORMConsoleApp.Controllers;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Start of main program.");

        int choice = int.MaxValue;
        while (choice != 0)
        {
            Console.Clear();
            Console.WriteLine("User Management Console App");
            Console.WriteLine("1. Get All Users");
            Console.WriteLine("2. Get User by ID");
            Console.WriteLine("3. Add New User");
            Console.WriteLine("4. Update User");
            Console.WriteLine("5. Delete User");
            Console.WriteLine("0. Exit");
            Console.Write("Please enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CRUDClass.GetAllUsers();
                    break;
                case 2:
                    CRUDClass.GetUserById();
                    break;
                case 3:
                    CRUDClass.AddNewUser();
                    break;
                case 4:
                    CRUDClass.UpdateUser();
                    break;
                case 5:
                    CRUDClass.DeleteUser();
                    break;
                case 0:
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (choice != 0)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        Console.WriteLine("End of main program.");
    }
}