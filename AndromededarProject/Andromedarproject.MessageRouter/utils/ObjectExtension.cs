using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andromedarproject.MessageRouter.utils
{
    public static class ObjectExtension
    {
        public static T DeepCopy<T>(this T obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }
    }
}
