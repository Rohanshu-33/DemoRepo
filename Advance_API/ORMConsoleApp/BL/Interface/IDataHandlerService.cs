using System;
using ORMConsoleApp.Models;
using ORMConsoleApp.Models.DTO;
using ORMConsoleApp.Models.ENUM;

namespace ORMConsoleApp.BL.Interface
{
    public interface IDataHandlerService<T> where T : class 
    {
        /// <summary>
        /// Gets or sets the type of opration (Edit, Add).
        /// </summary>
        EnmType Type { get; set; }

        /// <summary>
        /// Validates the data before saving.
        /// </summary>
        /// <returns>A response indicating whether the validation was successful.</returns>
        Response Validation(DTOUSR01 usr);

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>A response indicating the result of the save operation.</returns>
        Response Save();
    }
}
