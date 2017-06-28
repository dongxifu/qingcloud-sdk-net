using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingCloudSDK.Attribute;

namespace QingCloudSDK.model
{
    public class OutputModel
    {
        private string message;

        private int retCode;

        private int statueCode;

        [Param(paramType="query",paramName="statue_code")]
        public int getStatueCode() 
        {
            return statueCode;
        }

        public void setStatueCode(int statueCode) 
        {
            this.statueCode = statueCode;
        }
        
        [Param(paramType = "query", paramName = "ret_code")]
        public int getRetCode() 
        {
            return retCode;
        }
        public void setRetCode(int retCode) 
        {
            this.retCode = retCode;
        }

        [Param(paramType = "query", paramName = "message")]
        public string getMessage() 
        {
            return message;
        }

        public void setMessage(string message) 
        {
            this.message = message;
        }
    }
}
