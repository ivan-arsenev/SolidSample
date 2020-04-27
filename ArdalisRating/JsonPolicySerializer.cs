using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
   public class JsonPolicySerializer
    {

        public Policy GetPolicyFromJson(string policyJson)
        {
           return JsonConvert.DeserializeObject<Policy>(policyJson, new StringEnumConverter());
        }
      
    }
}
