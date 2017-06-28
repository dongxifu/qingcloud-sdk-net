using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QingCloudSDK.Attribute
{
    [AttributeUsage(AttributeTargets.All)]
    class ParamAttribute:System.Attribute
    {
        private string Type="body";
        private string Name="";
        public string paramType
        {
            get
            {
                return Type;
            }
            set
            {
                Type=value;
            }
        }
        public string paramName
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        
    }
}
