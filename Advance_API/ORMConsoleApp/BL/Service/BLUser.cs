using System;
using ORMConsoleApp.BL.Interface;
using ORMConsoleApp.Extensions;
using ORMConsoleApp.Models;
using ORMConsoleApp.Models.DTO;
using ORMConsoleApp.Models.ENUM;
using ORMConsoleApp.Models.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace ORMConsoleApp.BL.Service
{
    public class BLUser : IDataHandlerService<DTOUSR01>
    {
        private USR01 _objUSR01;  // in POCO form
        private int _id;
        private Response _objResponse;
        private string _connectionString;
        private IDbConnectionFactory _dbFactory;  // ORMLite dbconnection factory
        public EnmType Type { get; set; }

        /// <summary>
        /// BLUser Constructor
        /// </summary>
        public BLUser()
        {
            _objResponse = new Response();
            _connectionString = "Server=localhost;Database=rbcollege;User=Admin;Password=gs@123;";
            _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }

        /// <summary>
        /// performs validation whether user exists or not before updating user data.
        /// </summary>
        /// <returns>Response object indicating success or failure of validation.</returns>
        public Response Validation(DTOUSR01 usr)
        {
            _id = usr.P01F01;
            _objUSR01 = usr.ConvertToPOCO();
            if (Type == EnmType.E)
            {
                bool isUSR01 = IsUSR01Exists(_id);
                if (!isUSR01)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "User Not Found";
                }
            }
            else if (Type == EnmType.A)
            {
                bool isUSR01 = IsUSR01Exists(_id);
                if (isUSR01)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "User already exists.";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves the user data (adding or updating a user) to the MySQL database.
        /// </summary>
        /// <returns>Response object indicating success or failure of saving operation</returns>
        public Response Save()
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    if (Type == EnmType.A)
                    {
                        db.Insert(_objUSR01);
                        _objResponse.Message = "User added successfully.";
                    }
                    if(Type == EnmType.E)
                    {
                        db.Update(_objUSR01);
                        _objResponse.Message = "Data updated successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }


        /// <summary>
        /// Checks whether a user with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>True if the user exists, otherwise false</returns>
        public bool IsUSR01Exists(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Exists<USR01>(u => u.P01F01 == id);
            }
        }


        /// <summary>
        /// Deletes a user by ID from the MySQL database.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Response indicating the success or failure of the operation</returns>
        public Response Delete(int id)
        {
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    db.DeleteById<USR01>(id);
                    _objResponse.Message = "User deleted successfully.";
                }
            }
            catch(Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves all users from the MySQL database.
        /// </summary>
        /// <returns>List of users</returns>
        public List<USR01> GetAll()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                // Querying all users using OrmLite
                return db.Select<USR01>();  // will return POCO Object
            }
        }

        /// <summary>
        /// Retrieves a user by ID from the database.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User with the specified ID</returns>
        public USR01 Get(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                // Querying user by ID using OrmLite
                return db.SingleById<USR01>(id);  // will return POCO Object
            }
        }
    }
}
