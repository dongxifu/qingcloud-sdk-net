using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QingCloudSDK.model
{
    class ResponseCallbackModel
    {
        private int callbackCode;

        private OutputModel callbackModel;

        public int getCallbackCode()
        {
            return callbackCode;
        }

        public void setCallbackCode(int callbackCode)
        {
            this.callbackCode = callbackCode;
        }

        public OutputModel getCallbackModel()
        {
            return callbackModel;
        }

        public void setCallbackModel(OutputModel callbackModel)
        {
            this.callbackModel = callbackModel;
        }
    }
}
