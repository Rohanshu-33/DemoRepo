using System;
using ORMConsoleApp.Models.DTO;
using ORMConsoleApp.Models.POCO;

namespace ORMConsoleApp.Extensions
{
    /// <summary>
    /// Converts a USR01DTO object to a USR01 POCO object.
    /// </summary>
    public static class DTOToPOCOExtension
    {
        public static USR01 ConvertToPOCO(this DTOUSR01 dto)
        {
            var poco = new USR01
            {
                P01F01 = dto.P01F01,  // userid
                P01F02 = dto.P01F02,  // username
                P01F03 = dto.P01F03,  // password
                P01F04 = dto.P01F04,  // age
                P01F05 = dto.P01F05   // creation time 
            };

            return poco;
        }
    }
}
