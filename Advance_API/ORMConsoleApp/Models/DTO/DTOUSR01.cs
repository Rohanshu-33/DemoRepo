using System;
using Newtonsoft.Json;
//using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ORMConsoleApp.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for User.
    ///  </summary>
    ///  
    // these annotations are stored in the metadata of the class,
    // specifically in the PropertyDescriptor for each property
    public class DTOUSR01
    {
        /// <summary>
        /// Get or Set user id
        /// </summary>
        [JsonProperty("P01101")]
        [Range(1, int.MaxValue, ErrorMessage = "User id must be a positive value.")]
        public int P01F01 { get; set; }
        
        /// <summary>
        /// Get or Set user name
        /// </summary>
        [JsonProperty("P01102")]
        [Required(ErrorMessage = "Username is required.")]
        public string P01F02 { get; set; }

        /// <summary>
        /// Get or Set user password
        /// </summary>
        [JsonProperty("P01103")]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 16 characters.")]
        public string P01F03 { get; set; }

        /// <summary>
        /// Get or Set user age
        /// </summary>
        [JsonProperty("P01104")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int P01F04 { get; set; }

        /// <summary>
        /// Get or Set user creation date
        /// </summary>
        [JsonProperty("P01105")]
        [Required(ErrorMessage = "Creation Date is required.")]
        public DateTime P01F05 { get; set; }

    }
}
