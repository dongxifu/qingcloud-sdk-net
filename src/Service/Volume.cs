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
    public class Volume
    {
        private String zone;
        private Config Config;

        public Volume(Config Config) 
        {
            this.Config = Config;
            this.zone = Constant.CLOUD_DEFAULT_ZONE;
        }   
     
        public Volume(Config Config, String zone) 
        {
            this.Config = Config;
            this.zone = zone;
        }

        public class DescribeVolumesInput : RequestInputModel
        {
            private String[] volumes;
            [Param(paramType = "header", paramName = "volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setVolumes(String[] volumes)
            {
                this.volumes = new String[volumes.Length];
                this.volumes = volumes;
            }

            private int volumeType;
            [Param(paramType = "header", paramName = "volume_type")]
            public int getVolumeType()
            {
                return this.volumeType;
            }

            public void setVolumeType(int volumeType)
            {
                this.volumeType = volumeType;
            }

            private String[] status;
            [Param(paramType = "header", paramName = "status")]
            public String[] getStatus()
            {
                return this.status;
            }

            public void setStatus(String[] status)
            {
                this.status = status;
            }

            private String searchWord;
            [Param(paramType = "header", paramName = "search_word")]
            public String getSearchWord()
            {
                return this.searchWord;
            }

            public void setSearchWord(String searchWord)
            {
                this.searchWord = searchWord;
            }

            private String[] tags;
            [Param(paramType = "header", paramName = "tags")]
            public String[] getTags()
            {
                return this.tags;
            }

            public void setTags(String[] tags)
            {
                this.tags = tags;
            }

            private int verbose;
            [Param(paramType = "header", paramName = "verbose")]
            public int getVerbose()
            {
                return this.verbose;
            }

            public void setVerbose(int verbose)
            {
                this.verbose = verbose;
            }

            private int offset;
            [Param(paramType = "header", paramName = "offset")]
            public int getOffset()
            {
                return this.offset;
            }

            public void setOffset(int offset)
            {
                this.offset = offset;
            }

            private int limit;
            [Param(paramType = "header", paramName = "limit")]
            public int getLimit()
            {
                return this.limit;
            }

            public void setLimit(int limit)
            {
                this.limit = limit;
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

        public class DescribeVolumesOutput : OutputModel
        {
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

            private String volumeSet;
            [Param(paramType = "query", paramName = "volume_set")]
            public String getVolumeSet()
            {
                return this.volumeSet;
            }
            public void setVolumeSet(String volumeSet)
            {
                this.volumeSet = volumeSet;
            }

            private int totalCount;
            [Param(paramType = "query", paramName = "total_count")]
            public int getTotalCount()
            {
                return this.totalCount;
            }
            public void setTotalCount(int totalCount)
            {
                this.totalCount = totalCount;
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

            private String volumeId;
            [Param(paramType = "query", paramName = "volume_id")]
            public String getVolumeId()
            {
                return this.volumeId;
            }
            public void setVolumeId(String volumeId)
            {
                this.volumeId = volumeId;
            }

            private String volumeName;
            [Param(paramType = "query", paramName = "volume_name")]
            public String getVolumeName()
            {
                return this.volumeName;
            }
            public void setVolumeName(String volumeName)
            {
                this.volumeName = volumeName;
            }

            private String description;
            [Param(paramType = "query", paramName = "description")]
            public String getDescription()
            {
                return this.description;
            }
            public void setDescription(String description)
            {
                this.description = description;
            }

            private String size;
            [Param(paramType = "query", paramName = "size")]
            public String getSize()
            {
                return this.size;
            }
            public void setSize(String size)
            {
                this.size = size;
            }

            private String status;
            [Param(paramType = "query", paramName = "status")]
            public String getStatus()
            {
                return this.status;
            }
            public void setStatus(String status)
            {
                this.status = status;
            }

            private String transitionStatus;
            [Param(paramType = "query", paramName = "transition_status")]
            public String getTransitionStatus()
            {
                return this.transitionStatus;
            }
            public void setTransitionStatus(String transitionStatus)
            {
                this.transitionStatus = transitionStatus;
            }

            private DateTime createTime;
            [Param(paramType = "query", paramName = "create_time")]
            public DateTime getCreateTime()
            {
                return this.createTime;
            }
            public void setCreateTime(DateTime createTime)
            {
                this.createTime = createTime;
            }

            private DateTime statusTime;
            [Param(paramType = "query", paramName = "status_time")]
            public DateTime getStatusTime()
            {
                return this.statusTime;
            }
            public void setStatusTime(DateTime statusTime)
            {
                this.statusTime = statusTime;
            }

            private Dictionary<object,object> instance;
            [Param(paramType = "query", paramName = "instance")]
            public Dictionary<object, object> getInstance()
            {
                return this.instance;
            }
            public void setInstance(Dictionary<object, object> instance)
            {
                this.instance = instance;
            }
        }

        public DescribeVolumesOutput DescribeVolumes(DescribeVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "DescribeVolumes");
            context.Add("APIName", "DescribeVolumes");
            context.Add("ServiceName", "Describe Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DescribeVolumesOutput));
            if (backModel != null)
            {
                return (DescribeVolumesOutput)backModel;
            }
            return null;
        }

        public class CreateVolumesInput:RequestInputModel
        {
            private int size;
            [Param(paramType = "header", paramName = "size")]
            public int getSize()
            {
                return this.size;
            }

            public void setSize(int size)
            {
                this.size = size;
            }

            private String volumeName;
            [Param(paramType = "header", paramName = "volume_name")]
            public String getVolumeName()
            {
                return this.volumeName;
            }

            public void setVolumeName(String volumeName)
            {
                this.volumeName = volumeName;
            }

            private int volumeType;
            [Param(paramType = "header", paramName = "volume_type")]
            public int getVolumeType()
            {
                return this.volumeType;
            }

            public void setVolumeType(int volumeType)
            {
                this.volumeType = volumeType;
            }

            private int count;
            [Param(paramType = "header", paramName = "count")]
            public int getCount()
            {
                return this.count;
            }

            public void setCount(int count)
            {
                this.count = count;
            }

            private String targetUser;
            [Param(paramType = "header", paramName = "target_user")]
            public String getTargetUser()
            {
                return this.targetUser;
            }

            public void setTargetUser(String targetUser)
            {
                this.targetUser = targetUser;
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

        public class CreateVolumesOutput:OutputModel
        {
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

            private String jobId;
            [Param(paramType = "query", paramName = "job_id")]
            public String getJobId()
            {
                return this.jobId;
            }
            public void setJobId(String jobId)
            {
                this.jobId = jobId;
            }

            private String volumes;
            [Param(paramType = "query", paramName = "volumes")]
            public String getVolumes()
            {
                return this.volumes;
            }
            public void setVolumes(String volumes)
            {
                this.volumes = volumes;
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

        public CreateVolumesOutput CreateVolumes(CreateVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "CreateVolumes");
            context.Add("APIName", "CreateVolumes");
            context.Add("ServiceName", "Create Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(CreateVolumesOutput));
            if (backModel != null)
            {
                return (CreateVolumesOutput)backModel;
            }
            return null;
        }

        public class DeleteVolumesInput :RequestInputModel
        {
            private String[] volumes;
            [Param(paramType = "header", paramName = "volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setVolumes(String[] volumes)
            {
                volumes = new String[volumes.Length];
                this.volumes = volumes;
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

        public class DeleteVolumesOutput : OutputModel
        {
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

            private String jobId;
            [Param(paramType = "query", paramName = "job_id")]
            public String getJobId()
            {
                return this.jobId;
            }
            public void setJobId(String jobId)
            {
                this.jobId = jobId;
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

        public DeleteVolumesOutput DeleteVolumes(DeleteVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "DeleteVolumes");
            context.Add("APIName", "DeleteVolumes");
            context.Add("ServiceName", "Delete Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DeleteVolumesOutput));
            if (backModel != null)
            {
                return (DeleteVolumesOutput)backModel;
            }
            return null;
        }
        
        public class AttachVolumesInput:RequestInputModel
        {
            private String[] volumes;
            [Param(paramType = "header", paramName = "volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setVolumes(String[] volumes)
            {
                volumes = new String[volumes.Length];
                this.volumes = volumes;
            }

            private String instance;
            [Param(paramType = "header", paramName = "instance")]
            public String getInstance()
            {
                return this.instance;
            }

            public void setInstance(String instance)
            {
                this.instance = instance;
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

        public class AttachVolumesOutput:OutputModel
        {
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

            private String jobId;
            [Param(paramType = "query", paramName = "job_id")]
            public String getJobId()
            {
                return this.jobId;
            }
            public void setJobId(String jobId)
            {
                this.jobId = jobId;
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

        public AttachVolumesOutput AttachVolumes(AttachVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "AttachVolumes");
            context.Add("APIName", "AttachVolumes");
            context.Add("ServiceName", "Attach Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(AttachVolumesOutput));
            if (backModel != null)
            {
                return (AttachVolumesOutput)backModel;
            }
            return null;
        }

        public class DetachVolumesInput :RequestInputModel
        {
            private String[] volumes;
            [Param(paramType = "header", paramName = "volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setVolumes(String[] volumes)
            {
                volumes = new String[volumes.Length];
                this.volumes = volumes;
            }

            private String instance;
            [Param(paramType = "header", paramName = "instance")]
            public String getInstance()
            {
                return this.instance;
            }

            public void setInstance(String instance)
            {
                this.instance = instance;
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

        public class DetachVolumesOutput :OutputModel
        {
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

            private String jobId;
            [Param(paramType = "query", paramName = "job_id")]
            public String getJobId()
            {
                return this.jobId;
            }
            public void setJobId(String jobId)
            {
                this.jobId = jobId;
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

        public DetachVolumesOutput DetachVolumes(DetachVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "DetachVolumes");
            context.Add("APIName", "DetachVolumes");
            context.Add("ServiceName", "Detach Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DetachVolumesOutput));
            if (backModel != null)
            {
                return (DetachVolumesOutput)backModel;
            }
            return null;
        }

        public class ResizeVolumesInput:RequestInputModel
        {
            private String[] volumes;
            [Param(paramType = "header", paramName = "volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setVolumes(String[] volumes)
            {
                volumes = new String[volumes.Length];
                this.volumes = volumes;
            }

            private int size;
            [Param(paramType = "header", paramName = "size")]
            public int getSize()
            {
                return this.size;
            }

            public void setSize(int size)
            {
                this.size = size;
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

        public class ResizeVolumesOutput:OutputModel
        {
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

            private String jobId;
            [Param(paramType = "query", paramName = "job_id")]
            public String getJobId()
            {
                return this.jobId;
            }
            public void setJobId(String jobId)
            {
                this.jobId = jobId;
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

        public ResizeVolumesOutput ResizeVolumes(ResizeVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "ResizeVolumes");
            context.Add("APIName", "ResizeVolumes");
            context.Add("ServiceName", "Resize Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ResizeVolumesOutput));
            if (backModel != null)
            {
                return (ResizeVolumesOutput)backModel;
            }
            return null;
        }

        public class ModifyVolumeAttributesInput : RequestInputModel
        {
            private String volume;
            [Param(paramType = "header", paramName = "volume")]
            public String getVolume()
            {
                return this.volume;
            }

            public void setVolume(String volume)
            {
                this.volume = volume;
            }

            private String volumeName;
            [Param(paramType = "header", paramName = "volume_name")]
            public String getVolumeName()
            {
                return this.volumeName;
            }

            public void setVolumeName(String volumeName)
            {
                this.volumeName = volumeName;
            }

            private String description;
            [Param(paramType = "header", paramName = "description")]
            public String getDescription()
            {
                return this.description;
            }

            public void setDescription(String description)
            {
                this.description = description;
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

        public class ModifyVolumeAttributesOutput:OutputModel
        {
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

        public ModifyVolumeAttributesOutput ResizeVolumes(ModifyVolumeAttributesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "ModifyVolumeAttributes");
            context.Add("APIName", "ModifyVolumeAttributes");
            context.Add("ServiceName", "Modify Volume Attributes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ModifyVolumeAttributesOutput));
            if (backModel != null)
            {
                return (ModifyVolumeAttributesOutput)backModel;
            }
            return null;
        }

        
    }
}
