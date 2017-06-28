using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QingCloudSDK.service;
using QingCloudSDK.Attribute;
using QingCloudSDK.config;
using QingCloudSDK.constants;
using QingCloudSDK.exception;
using QingCloudSDK.model;
using QingCloudSDK.request;
using QingCloudSDK.utils;

namespace QingCloudSDK.service
{
    public class UserData
    {
        private String zone;
        private Config Config;

        public UserData(Config Config) 
        {
            this.Config = Config;
            this.zone = Constant.CLOUD_DEFAULT_ZONE;
        }

        public UserData(Config Config, String zone) 
        {
            this.Config = Config;
            this.zone = zone;
        }

        public class UploadUserDataAttachmentInput:RequestInputModel
        {
            private String attachmentContent;
            [Param(paramType = "header", paramName = "attachment_content")]
            public String getAttachmentContent()
            {
                return this.attachmentContent;
            }

            public void setAttachmentContent(String attachmentContent)
            {
                this.attachmentContent = attachmentContent;
            }

            private String attachmentName;
            [Param(paramType = "header", paramName = "attachment_name")]
            public String getAttachmentName()
            {
                return this.attachmentName;
            }

            public void setAttachmentName(String attachmentName)
            {
                this.attachmentName = attachmentName;
            }

            private String zone;
            [Param(paramType = "header", paramName = "zone")]
            public String getZone()
            {
                return this.zone;
            }

            public void setZone(String zone)
            {
                this.zone = zone;
            }

            public override String validateParam()
            {

                return null;
            }
        }

        public class UploadUserDataAttachmentOutput:OutputModel
        {
            private String attachmentId;
            [Param(paramType = "query", paramName = "attachment_id")]
            public String getAttachmentId()
            {
                return this.action;
            }
            public void setAttachmentId(String attachmentId)
            {
                this.attachmentId = attachmentId;
            }

            private String action;
            [Param(paramType = "query", paramName = "action")]
            public String getAction()
            {
                return this.action;
            }
            public void setAction(String action)
            {
                this.action = action;
            }

            private int retCode;
            [Param(paramType = "query", paramName = "ret_code")]
            public int getRetCode()
            {
                return this.retCode;
            }
            public void setRetCode(int retCode)
            {
                this.retCode = retCode;
            }
        }

        public UploadUserDataAttachmentOutput UploadUserDataAttachment(UploadUserDataAttachmentInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "DescribeInstances");
            context.Add("APIName", "DescribeInstances");
            context.Add("ServiceName", "Describe Instances");
            context.Add("RequestMethod", "POST");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(UploadUserDataAttachmentOutput));
            if (backModel != null)
            {
                return (UploadUserDataAttachmentOutput)backModel;
            }
            return null;
        }
    }
}
