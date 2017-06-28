using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingCloudSDK.model;
using QingCloudSDK.exception;

namespace QingCloudSDK.request 
{
    interface ResponseCallBack
    {
        void onAPIResponse(object output);
    }
}
