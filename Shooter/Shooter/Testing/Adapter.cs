using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Adapter : ITarget, IAdaptee
    {
        public void Request()
        {
            SpecificRequest();
        }

        public void SpecificRequest()
        {
            throw new NotImplementedException();
        }
    }
}
