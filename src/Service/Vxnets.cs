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
    public class Vxnets
    {
        private String zone;
        private Config Config;

        public Vxnets(Config Config) 
        {
            this.Config = Config;
            this.zone = Constant.CLOUD_DEFAULT_ZONE;
        }   
     
        public Vxnets(Config Config, String zone) 
        {
            this.Config = Config;
            this.zone = zone;
        }

        public class DescribeVxnetsInput:RequestInputModel
        {
            private String[] vxnets;
            [Param(paramType = "header", paramName = "vxnets")]
            public String[] getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String[] vxnets)
            {
                this.vxnets = new String[vxnets.Length];
                this.vxnets = vxnets;
            }

            private int vxnetType;
            [Param(paramType = "header", paramName = "vxnet_type")]
            public int getVxnetType()
            {
                return this.vxnetType;
            }

            public void setvxnetType(int vxnetType)
            {
                this.vxnetType = vxnetType;
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
                this.tags = new String[tags.Length];
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

        public class DescribeVxnetsOutput:OutputModel
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

            private String vxnetSet;
            [Param(paramType = "query", paramName = "vxnet_set")]
            public String getVxnetSet()
            {
                return this.vxnetSet;
            }
            public void setVxnetSet(String vxnetSet)
            {
                this.vxnetSet = vxnetSet;
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

            private String vxnetId;
            [Param(paramType = "query", paramName = "vxnet_id")]
            public String getVxnetId()
            {
                return this.vxnetId;
            }
            public void setVxnetId(String vxnetId)
            {
                this.vxnetId = vxnetId;
            }

            private String vxnetName;
            [Param(paramType = "query", paramName = "vxnet_name")]
            public String getVxnetName()
            {
                return this.vxnetName;
            }
            public void setVxnetName(String vxnetName)
            {
                this.vxnetName = vxnetName;
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

            private String instanceIds;
            [Param(paramType = "query", paramName = "instance_ids")]
            public String getInstanceIds()
            {
                return this.instanceIds;
            }
            public void setInstanceIds(String instanceIds)
            {
                this.instanceIds = instanceIds;
            }
            private Dictionary<object, object> router;
            [Param(paramType = "query", paramName = "router")]
            public Dictionary<object, object> getRouter()
            {
                return this.router;
            }
            public void setRouter(Dictionary<object, object> router)
            {
                this.router = router;
            }
        }

        public DescribeVxnetsOutput DescribeVxnets(DescribeVxnetsInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "DescribeVxnets");
            context.Add("APIName", "DescribeVxnets");
            context.Add("ServiceName", "Describe Vxnets");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DescribeVxnetsOutput));
            if (backModel != null)
            {
                return (DescribeVxnetsOutput)backModel;
            }
            return null;
        }

        public class CreateVxnetsInput:RequestInputModel
        {
            private String vxnetName;
            [Param(paramType = "header", paramName = "vxnet_name")]
            public String getVxnetName()
            {
                return this.vxnetName;
            }
            public void setVxnetName(String vxnetName)
            {
                this.vxnetName = vxnetName;
            }

            private int vxnetType;
            [Param(paramType = "header", paramName = "vxnet_type")]
            public int getVxnetType()
            {
                return this.vxnetType;
            }
            public void setVxnetType(int vxnetType)
            {
                this.vxnetType = vxnetType;
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

        public class CreateVxnetsOutput:OutputModel
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

            private String vxnets;
            [Param(paramType = "query", paramName = "vxnets")]
            public String getVxnets()
            {
                return this.vxnets;
            }
            public void setVxnets(String vxnets)
            {
                this.vxnets = vxnets;
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

        public CreateVxnetsOutput CreateVxnets(CreateVxnetsInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "CreateVxnets");
            context.Add("APIName", "CreateVxnets");
            context.Add("ServiceName", "Create Vxnets");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(CreateVxnetsOutput));
            if (backModel != null)
            {
                return (CreateVxnetsOutput)backModel;
            }
            return null;
        }

        public class DeleteVxnetsInput:RequestInputModel
        {
            private String[] vxnets;
            [Param(paramType = "header", paramName = "vxnets")]
            public String[] getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String[] vxnets)
            {
                this.vxnets = new String[vxnets.Length];
                this.vxnets = vxnets;
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

        public class DeleteVxnetsOutput:OutputModel
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

            private String vxnets;
            [Param(paramType = "query", paramName = "vxnets")]
            public String getVxnets()
            {
                return this.vxnets;
            }
            public void setVxnets(String vxnets)
            {
                this.vxnets = vxnets;
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

        public DeleteVxnetsOutput DeleteVxnets(DeleteVxnetsInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "DeleteVxnets");
            context.Add("APIName", "DeleteVxnets");
            context.Add("ServiceName", "Delete Vxnets");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DeleteVxnetsOutput));
            if (backModel != null)
            {
                return (DeleteVxnetsOutput)backModel;
            }
            return null;
        }

        public class JoinVxnetInput:RequestInputModel
        {
            private String vxnets;
            [Param(paramType = "header", paramName = "vxnets")]
            public String getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String vxnets)
            {
                //this.vxnets = new String[vxnets.Length];
                this.vxnets = vxnets;
            }

            private String[] instances;
            [Param(paramType = "header", paramName = "instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
                this.instances = new String[instances.Length];
                this.instances = instances;
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

        public class JoinVxnetOutput:OutputModel
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

        public JoinVxnetOutput DeleteVxnets(JoinVxnetInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "JoinVxnet");
            context.Add("APIName", "JoinVxnet");
            context.Add("ServiceName", "Join Vxnet");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(JoinVxnetOutput));
            if (backModel != null)
            {
                return (JoinVxnetOutput)backModel;
            }
            return null;
        }

        public class LeaveVxnetInput:RequestInputModel
        {
            private String vxnets;
            [Param(paramType = "header", paramName = "vxnets")]
            public String getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String vxnets)
            {
                //this.vxnets = new String[vxnets.Length];
                this.vxnets = vxnets;
            }

            private String[] instances;
            [Param(paramType = "header", paramName = "instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
                this.instances = new String[instances.Length];
                this.instances = instances;
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

        public class LeaveVxnetOutput:OutputModel
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

        public LeaveVxnetOutput LeaveVxnet(LeaveVxnetInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "LeaveVxnet");
            context.Add("APIName", "LeaveVxnet");
            context.Add("ServiceName", "Leave Vxnet");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(LeaveVxnetOutput));
            if (backModel != null)
            {
                return (LeaveVxnetOutput)backModel;
            }
            return null;
        }

        public class ModifyVxnetAttributesInput:RequestInputModel
        {
            private String vxnets;
            [Param(paramType = "header", paramName = "vxnets")]
            public String getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String vxnets)
            {
                //this.vxnets = new String[vxnets.Length];
                this.vxnets = vxnets;
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

            private String vxnetName;
            [Param(paramType = "header", paramName = "vxnet_name")]
            public String getVxnetName()
            {
                return this.vxnetName;
            }

            public void setVxnetName(String vxnetName)
            {

                this.vxnetName = vxnetName;
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

        public class ModifyVxnetAttributesOutput:OutputModel
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

        public ModifyVxnetAttributesOutput ModifyVxnetAttributes(ModifyVxnetAttributesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "ModifyVxnetAttributes");
            context.Add("APIName", "ModifyVxnetAttributes");
            context.Add("ServiceName", "Modify Vxnet Attributes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ModifyVxnetAttributesOutput));
            if (backModel != null)
            {
                return (ModifyVxnetAttributesOutput)backModel;
            }
            return null;
        }

        public class DescribeVxnetInstancesInput:RequestInputModel
        {
            private String vxnet;
            [Param(paramType = "header", paramName = "vxnet")]
            public String getVxnet()
            {
                return this.vxnet;
            }

            public void setVxnet(String vxnet)
            {
                //this.vxnets = new String[vxnets.Length];
                this.vxnet = vxnet;
            }

            private String[] instances;
            [Param(paramType = "header", paramName = "instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
                this.instances = new String[instances.Length];
                this.instances = instances;
            }

            private String instanceType;
            [Param(paramType = "header", paramName = "instance_type")]
            public String getInstanceType()
            {
                return this.instanceType;
            }

            public void setInstanceType(String instanceType)
            {
                //this.vxnets = new String[vxnets.Length];
                this.instanceType = instanceType;
            }

            private String status;
            [Param(paramType = "header", paramName = "status")]
            public String getStatus()
            {
                return this.status;
            }

            public void setStatus(String status)
            {
                //this.vxnets = new String[vxnets.Length];
                this.status = status;
            }

            private String image;
            [Param(paramType = "header", paramName = "image")]
            public String getImage()
            {
                return this.image;
            }

            public void setImage(String image)
            {
                //this.vxnets = new String[vxnets.Length];
                this.image = image;
            }

            private int offset;
            [Param(paramType = "header", paramName = "offset")]
            public int getOffset()
            {
                return this.offset;
            }

            public void setOffset(int offset)
            {
                //this.vxnets = new String[vxnets.Length];
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
                //this.vxnets = new String[vxnets.Length];
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
                //this.vxnets = new String[vxnets.Length];
                this.zone = zone;
            }
            public override String validateParam()
            {

                return null;
            }
        }

        public class DescribeVxnetInstancesOutput:OutputModel
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

            private String instanceSet;
            [Param(paramType = "query", paramName = "instance_set")]
            public String getInstanceSet()
            {
                return this.instanceSet;
            }
            public void setInstanceSet(String instanceSet)
            {
                this.instanceSet = instanceSet;
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

            private String vxnetId;
            [Param(paramType = "query", paramName = "vxnet_id")]
            public String getVxnetId()
            {
                return this.vxnetId;
            }
            public void setVxnetId(String vxnetId)
            {
                this.vxnetId = vxnetId;
            }

            private String instanceName;
            [Param(paramType = "query", paramName = "instance_name")]
            public String getInstanceName()
            {
                return this.instanceName;
            }
            public void setInstanceName(String instanceName)
            {
                this.instanceName = instanceName;
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

            private String instanceType;
            [Param(paramType = "query", paramName = "instance_type")]
            public String getInstanceType()
            {
                return this.instanceType;
            }
            public void setInstanceType(String instanceType)
            {
                this.instanceType = instanceType;
            }

            private int vcpusCurrent;
            [Param(paramType = "query", paramName = "vcpus_current")]
            public int getVcpusCurrent()
            {
                return this.vcpusCurrent;
            }
            public void setVcpusCurrent(int vcpusCurrent)
            {
                this.vcpusCurrent = vcpusCurrent;
            }

            private int memoryCurrent;
            [Param(paramType = "query", paramName = "memory_current")]
            public int getMemoryCurrent()
            {
                return this.memoryCurrent;
            }
            public void setMemoryCurrent(int memoryCurrent)
            {
                this.memoryCurrent = memoryCurrent;
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

            private String imageId;
            [Param(paramType = "query", paramName = "image_id")]
            public String getImageId()
            {
                return this.imageId;
            }
            public void setImageId(String imageId)
            {
                this.imageId = imageId;
            }

            private Dictionary<object,object> dhcpOptions;
            [Param(paramType = "query", paramName = "dhcp_options")]
            public Dictionary<object, object> getDhcpOptions()
            {
                return this.dhcpOptions;
            }
            public void setDhcpOptions(Dictionary<object, object> dhcpOptions)
            {
                this.dhcpOptions = dhcpOptions;
            }

            private String privateIp;
            [Param(paramType = "query", paramName = "private_ip")]
            public String getPrivateIp()
            {
                return this.privateIp;
            }
            public void setPrivateIp(String privateIp)
            {
                this.privateIp = privateIp;
            }
        }

        public DescribeVxnetInstancesOutput DescribeVxnetInstances(DescribeVxnetInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "DescribeVxnetInstances");
            context.Add("APIName", "DescribeVxnetInstances");
            context.Add("ServiceName", "Describe Vxnet Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DescribeVxnetInstancesOutput));
            if (backModel != null)
            {
                return (DescribeVxnetInstancesOutput)backModel;
            }
            return null;
        }

    }
}
