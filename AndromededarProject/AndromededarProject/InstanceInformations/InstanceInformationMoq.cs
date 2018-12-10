using Andromedarproject.MessageRouter.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.InstanceInformations
{
    public class InstanceInformationMoq : IInstanceInformation
    {
        public string Name()
        {
            return "MyHome";
        }
    }
}
