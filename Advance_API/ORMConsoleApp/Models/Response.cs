using System;

namespace ORMConsoleApp.Models
{
    public class Response
    {
        /// <summary>
        /// Gets or sets the message describing the result of the operation.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data returned as part of the response, if applicable.
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an error occurred.
        /// </summary>
        public bool IsError { get; set; }
    }
}
