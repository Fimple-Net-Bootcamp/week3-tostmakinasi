using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VirtualPetCare.Service.Validations
{
    public class ValidationResponse
    {
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public static ValidationResponse Fail(int statusCode, List<string> errors)
        {
            return new ValidationResponse { StatusCode = statusCode, Errors = errors };
        }


    }
}
