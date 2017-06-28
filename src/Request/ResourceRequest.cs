using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingCloudSDK.exception;
using QingCloudSDK.model;

namespace QingCloudSDK.request
{
    interface ResourceRequest
    {
         void sendApiRequestAsync(Dictionary<object,object> context, RequestInputModel paramBean, ResponseCallBack callback);

       /**
        * @param context
        * @param paramBean
        * @param outputClass
        * @throws QCException
        */
        OutputModel sendApiRequest(Dictionary<object,object> context, RequestInputModel paramBean, Type outputClass);

       /**
        * @param requestUrl
        * @param context
        * @param callback
        * @throws QCException
        */
        void sendApiRequestAsync(String requestUrl, Dictionary<object,object> context, ResponseCallBack callback);

       /**
        * @param requestUrl
        * @param context
        * @param outputClass
        * @return
        * @throws QCException
        */
        OutputModel sendApiRequest(string requestUrl,Dictionary<object,object> context,Type outputClass);
    }
}
