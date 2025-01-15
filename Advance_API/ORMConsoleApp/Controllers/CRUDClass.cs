using System;
using ORMConsoleApp.BL.Interface;
using ORMConsoleApp.BL.Service;
using ORMConsoleApp.Models.DTO;
using ORMConsoleApp.Models.ENUM;
using ORMConsoleApp.Models.POCO;

namespace ORMConsoleApp.Controllers
{
    public class CRUDClass
    {
        internal static BLUser _objBLUser = new BLUser();


        // retrieve all users. (to be called from program.cs)
        internal static void GetAllUsers()
        {
            var users = _objBLUser.GetAll();
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.P01F01}, Username: {user.P01F02}," +
                        $" Password: {user.P01F03}, Age: {user.P01F04}, Created At: {user.P01F05}");
                }
            }
            else
            {
                Console.WriteLine("No users found.");
            }
        }

        // get user by id (to be called from program.cs)
        internal static void GetUserById()
        {
            Console.Write("Enter User ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var user = _objBLUser.Get(id);
            if (user != null)
            {
                Console.WriteLine($"ID: {user.P01F01}, Username: {user.P01F02}," +
                        $" Password: {user.P01F03}, Age: {user.P01F04}, Created At: {user.P01F05}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        // adding new user to db (to be called from program.cs)
        internal static void AddNewUser()
        {
            Console.Write("Enter User ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var user = new DTOUSR01
            {
                P01F01 = id,
                P01F02 = GetStringInput("Enter username: "),
                P01F03 = GetStringInput("Enter password: "),
                P01F04 = GetIntInput("Enter user age: "),
                P01F05 = DateTime.Now
            };

            // Validate the DTO
            var validationResults = DTOValidateHelper.ValidateDTO(user);
            if (validationResults.Count > 0)
            {
                foreach (var error in validationResults)
                {
                    Console.WriteLine($"Validation Error: {error}");
                }
                return; // Exit the method if validation fails
            }

            _objBLUser.Type = EnmType.A;
            var response = _objBLUser.Validation(user);
            if (response.IsError == true)
            {
                Console.WriteLine(response.Message);
                return;
            }
            response = _objBLUser.Save();
            Console.WriteLine($"Error: {response.IsError} Message: {response.Message}");
        }


        // update a user (to be called from program.cs)
        internal static void UpdateUser()
        {
            Console.Write("Enter User ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var user = _objBLUser.Get(id);

            if (user != null)
            {
                var updatedUser = new DTOUSR01
                {
                    P01F01 = id,
                    P01F02 = GetStringInput("Enter user's new name: ", user.P01F02),
                    P01F03 = GetStringInput("Enter user's new password: ", user.P01F03),
                    P01F04 = GetIntInput("Enter user's new age: ", user.P01F04),
                    P01F05 = user.P01F05
                };

                // Validate the DTO
                var validationResults = DTOValidateHelper.ValidateDTO(updatedUser);
                if (validationResults.Count > 0)
                {
                    foreach (var error in validationResults)
                    {
                        Console.WriteLine($"Validation Error: {error}");
                    }
                    return; // Exit the method if validation fails
                }


                _objBLUser.Type = EnmType.E;
                var response = _objBLUser.Validation(updatedUser);
                if (response.IsError == true)
                {
                    Console.WriteLine(response.Message);
                    return;
                }

                response = _objBLUser.Save();
                Console.WriteLine($"Error: {response.IsError} Message: {response.Message}");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }


        // delete the user
        internal static void DeleteUser()
        {
            Console.Write("Enter User ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var response = _objBLUser.Delete(id);
            Console.WriteLine(response.Message);
        }


        // Helper methods
        static string GetStringInput(string prompt, string defaultValue = "")
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? defaultValue : input;
        }

        static int GetIntInput(string prompt, int defaultValue = 0)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return int.TryParse(input, out int result) ? result : defaultValue;
        }
    }
}
