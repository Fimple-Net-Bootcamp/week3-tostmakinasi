using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Service.Exceptions
{
    /// <summary>
    /// Represents an exception that occurs on the client side due to invalid or unexpected client behavior.
    /// </summary>
    public class ClientSideException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSideException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ClientSideException(string message) : base(message)
        {

        }
    }
}
