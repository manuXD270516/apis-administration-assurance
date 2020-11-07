using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_activate_assurance.Interfaces
{
    public interface IEndpointTemplate
    {

        public const string ENDPOINT_API = "api";
        public const string VERSION_ONE = "v1";

        public const string ENDPOINT_BASE = ENDPOINT_API + "/" + VERSION_ONE;



    }
}
