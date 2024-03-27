using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Service.Exceptions
{
    [Serializable]
    public class ClientSideException:Exception
    {
        public ClientSideException(string massage):base(massage)
        {
            
        }

        protected ClientSideException(SerializationInfo info, StreamingContext context):base(info, context) 
        {

        }
    }
}
