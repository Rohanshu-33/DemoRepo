using System;
using ORMConsoleApp.Models.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMConsoleApp.BL.Service
{
    internal class DTOValidateHelper
    {
        internal static List<string> ValidateDTO(DTOUSR01 dto)
        {
            var context = new ValidationContext(dto, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(dto, context, results, true))
            {
                return results.Select(r => r.ErrorMessage).ToList();
            }

            return new List<string>(); // No errors
        }

    }
}
