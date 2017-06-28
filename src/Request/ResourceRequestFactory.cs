using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingCloudSDK.request;

namespace QingCloudSDK.request
{
    class ResourceRequestFactory
    {
        public static ResourceRequest getResourceRequest()
        {
            return new Request();
        }
    }
}
