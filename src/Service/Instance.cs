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
    public class Instance
    {
        private String zone;
        private Config Config;

        public Instance(Config Config) 
        {
            this.Config = Config;
            this.zone = Constant.CLOUD_DEFAULT_ZONE;
        }   
     
        public Instance(Config Config, String zone) 
        {
            this.Config = Config;
            this.zone = zone;
        }
        public class DescribeInstancesInput : RequestInputModel
        {
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

            private String[] imageId;
            [Param(paramType = "header", paramName = "image_id")]
            public String[] getImageId()
            {
                return this.imageId;
            }

            public void setImageId(String[] imageId)
            {
                this.imageId = new String[imageId.Length];
                this.imageId = imageId;
            }

            private String[] instanceType;
            [Param(paramType = "header", paramName = "instance_type")]
            public String[] getInstanceType()
            {
                return this.instanceType;
            }

            public void setInstanceType(String[] instanceType)
            {
                this.instanceType = new String[instanceType.Length];
                this.instanceType = instanceType;
            }

            private String instanceClass;
            [Param(paramType = "header", paramName = "instance_class")]
            public String getInstanceClass()
            {
                return this.instanceClass;
            }

            public void setInstanceClass(String instanceClass)
            {
                this.instanceClass = instanceClass;
            }

            private String status;
            [Param(paramType = "header", paramName = "status")]
            public String getStatus()
            {
                return this.status;
            }

            public void setStatus(String status)
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

            private String tags;
            [Param(paramType = "header", paramName = "tags")]
            public String getTags()
            {
                return this.tags;
            }

            public void setTags(String tags)
            {
                this.tags = tags;
            }

            private String owner;
            [Param(paramType = "header", paramName = "owner")]
            public String getOwner()
            {
                return this.owner;
            }

            public void setOwner(String owner)
            {
                this.owner = owner;
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

        public class DescribeInstancesOutput : OutputModel 
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

            private String totalCount;
            [Param(paramType = "query", paramName = "total_count")]
            public String getTotalCount()
            {
                return this.totalCount;
            }
            public void setTotalCount(String totalCount)
            {
                this.totalCount = totalCount;
            }

            private String instanceId;
            [Param(paramType = "query", paramName = "instance_id")]
            public String getInstanceId()
            {
                return this.instanceId;
            }
            public void setInstanceId(String instanceId)
            {
                this.instanceId = instanceId;
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

            private Dictionary<object,object> image;
            [Param(paramType = "query", paramName = "image")]
            public Dictionary<object, object> getImage()
            {
                return this.image;
            }
            public void setImage(Dictionary<object, object> image)
            {
                this.image = image;
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

            private Dictionary<object,object> eip;
            [Param(paramType = "query", paramName = "eip")]
            public Dictionary<object,object> getEip()
            {
                return this.eip;
            }
            public void setEip(Dictionary<object,object> eip)
            {
                this.eip = eip;
            }

            private Dictionary<object,object> securityGroup;
            [Param(paramType = "query", paramName = "security_group")]
            public Dictionary<object,object> getkeypairIds()
            {
                return this.securityGroup;
            }
            public void setSecurityGroup(Dictionary<object,object> securityGroup)
            {
                this.securityGroup = securityGroup;
            }

            private String volumeIds;
            [Param(paramType = "query", paramName = "volume_ids")]
            public String getVolumeIds()
            {
                return this.volumeIds;
            }
            public void setVolumeIds(String volumeIds)
            {
                this.volumeIds = volumeIds;
            }

            private String keypairIds;
            [Param(paramType = "query", paramName = "keypair_ids")]
            public String getKeypairIds()
            {
                return this.keypairIds;
            }
            public void setKeypairIds(String keypairIds)
            {
                this.keypairIds = keypairIds;
            }

            private String graphicsProtocol;
            [Param(paramType = "query", paramName = "graphics_protocol")]
            public String getGraphicsProtocol()
            {
                return this.graphicsProtocol;
            }
            public void setGraphicsProtocol(String graphicsProtocol)
            {
                this.graphicsProtocol = graphicsProtocol;
            }

            private String graphicsPassword;
            [Param(paramType = "query", paramName = "graphics_password")]
            public String getGraphicsPassword()
            {
                return this.graphicsPassword;
            }
            public void setGraphicsPassword(String graphicsPassword)
            {
                this.graphicsPassword = graphicsPassword;
            }
        }


        public DescribeInstancesOutput DescribeInstances(DescribeInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "DescribeInstances");
            context.Add("APIName", "DescribeInstances");
            context.Add("ServiceName", "Describe Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DescribeInstancesOutput));
            if (backModel != null)
            {
                return (DescribeInstancesOutput)backModel;
            }
            return null;
        }
        
        public class RunInstancesInput : RequestInputModel
        {
            private String imageId;
            [Param(paramType = "header", paramName = "image_id")]
            public String getImageId()
            {
                return this.imageId;
            }

            public void setImageId(String imageId)
            {
                this.imageId = imageId;
            }
            
            private int cpu;
            [Param(paramType = "header", paramName = "cpu")]
            public int getCpu()
            {
                return this.cpu;
            }

            public void setCpu(int cpu)
            {
                this.cpu = cpu;
            }
            
            private int memory;
            [Param(paramType = "header", paramName = "memory")]
            public int getMemory()
            {
                return this.memory;
            }

            public void setMemory(int memory)
            {
                this.memory = memory;
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

            private String instanceName;
            [Param(paramType = "header", paramName = "instance_name")]
            public String getInstanceName()
            {
                return this.instanceName;
            }

            public void setInstanceName(String instanceName)
            {
                this.instanceName = instanceName;
            }

            private String loginMode;
            [Param(paramType = "header", paramName = "login_mode")]
            public String getLoginMode()
            {
                return this.loginMode;
            }

            public void setLoginMode(String loginMode)
            {
                this.loginMode = loginMode;
            }

            private String loginKeypair;
            [Param(paramType = "header", paramName = "login_keypair")]
            public String getLoginKeypair()
            {
                return this.loginKeypair;
            }

            public void setLoginKeypair(String loginKeypair)
            {
                this.loginKeypair = loginKeypair;
            }

            private String loginPassword;
            [Param(paramType = "header", paramName = "login_password")]
            public String getLoginPassword()
            {
                return this.loginPassword;
            }

            public void setLoginPassword(String loginPassword)
            {
                this.loginPassword = loginPassword;
            }

            private String[] vxnets;
            [Param(paramType = "header", paramName = "vxnets")]
            public String[] getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String[] vxnets)
            {
                this.vxnets = vxnets;
            }

            private String securityGroup;
            [Param(paramType = "header", paramName = "security_group")]
            public String getSecurityGroup()
            {
                return this.securityGroup;
            }

            public void setSecurityGroup(String securityGroup)
            {
                this.securityGroup = securityGroup;
            }

            private String[] volumes;
            [Param(paramType = "header", paramName = "volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setimageId(String[] volumes)
            {
                this.volumes = volumes;
            }

            private String hostname;
            [Param(paramType = "header", paramName = "hostname")]
            public String getHostname()
            {
                return this.hostname;
            }

            public void setHostname(String hostname)
            {
                this.hostname = hostname;
            }

            private int needNewsid;
            [Param(paramType = "header", paramName = "need_newsid")]
            public int getNeedNewsid()
            {
                return this.needNewsid;
            }

            public void setNeedNewsid(int needNewsid)
            {
                this.needNewsid = needNewsid;
            }

            private int needUserdata;
            [Param(paramType = "header", paramName = "need_userdata")]
            public int getNeedUserdata()
            {
                return this.needUserdata;
            }

            public void setNeedUserdata(int needUserdata)
            {
                this.needUserdata = needUserdata;
            }

            private String userdataType;
            [Param(paramType = "header", paramName = "userdata_type")]
            public String getUserdataType()
            {
                return this.userdataType;
            }

            public void setUserdataType(String userdataType)
            {
                this.userdataType = userdataType;
            }

            private String userdataValue;
            [Param(paramType = "header", paramName = "userdata_value")]
            public String getUserdataValue()
            {
                return this.userdataValue;
            }

            public void setUserdataValue(String userdataValue)
            {
                this.userdataValue = userdataValue;
            }

            private String instanceClass;
            [Param(paramType = "header", paramName = "instance_class")]
            public String getInstanceClass()
            {
                return this.instanceClass;
            }

            public void setInstanceClass(String instanceClass)
            {
                this.instanceClass = instanceClass;
            }

            private String cpuModel;
            [Param(paramType = "header", paramName = "cpu_model")]
            public String getCpuModel()
            {
                return this.cpuModel;
            }

            public void setCpuModel(String cpuModel)
            {
                this.cpuModel = cpuModel;
            }

            private String cpuTopology;
            [Param(paramType = "header", paramName = "cpu_topology")]
            public String getCpuTopology()
            {
                return this.cpuTopology;
            }

            public void setCpuTopology(String cpuTopology)
            {
                this.cpuTopology = cpuTopology;
            }

            private int nicMqueue;
            [Param(paramType = "header", paramName = "nic_mqueue")]
            public int getNicMqueue()
            {
                return this.nicMqueue;
            }

            public void setNicMqueue(int nicMqueue)
            {
                this.nicMqueue = nicMqueue;
            }

            private String userdataPath;
            [Param(paramType = "header", paramName = "userdata_path")]
            public String getUserdataPath()
            {
                return this.userdataPath;
            }

            public void setUserdataPath(String userdataPath)
            {
                this.userdataPath = userdataPath;
            }

            private String userdataFile;
            [Param(paramType = "header", paramName = "userdata_file")]
            public String getUserdataFile()
            {
                return this.userdataFile;
            }

            public void setUserdataFile(String userdataFile)
            {
                this.userdataFile = userdataFile;
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

        public class RunInstancesOutput: OutputModel
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

            private String instances;
            [Param(paramType = "query", paramName = "instances")]
            public String getInstances()
            {
                return this.instances;
            }

            public void setInstances(String instances)
            {
                this.instances = instances;
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

        public RunInstancesOutput RunInstances(RunInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "RunInstances");
            context.Add("APIName", "RunInstances");
            context.Add("ServiceName", "Run Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(RunInstancesOutput));
            if (backModel != null)
            {
                return (RunInstancesOutput)backModel;
            }
            return null;
        }

        public class TerminateInstancesInput : RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
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

        public class TerminateInstancesOutput : OutputModel
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

        public TerminateInstancesOutput TerminateInstances(TerminateInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "TerminateInstances");
            context.Add("APIName", "TerminateInstances");
            context.Add("ServiceName", "Terminate Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(TerminateInstancesOutput));
            if (backModel != null)
            {
                return (TerminateInstancesOutput)backModel;
            }
            return null;
        }

        public class StartInstancesInput:RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
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

        public class StartInstancesOutput : OutputModel
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

        public StartInstancesOutput StartInstances(StartInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "StartInstances");
            context.Add("APIName", "StartInstances");
            context.Add("ServiceName", "Start Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(StartInstancesOutput));
            if (backModel != null)
            {
                return (StartInstancesOutput)backModel;
            }
            return null;
        }

        public class StopInstancesInput :　RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
                this.instances = instances;
            }

            private int force;
            [Param(paramType = "header", paramName = "force")]
            public int getForce()
            {
                return this.force;
            }

            public void setForce(int force)
            {

                this.force = force;
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

        public class StopInstancesOutput :OutputModel
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

        public StopInstancesOutput StopInstances(StopInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "StopInstances");
            context.Add("APIName", "StopInstances");
            context.Add("ServiceName", "Stop Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(StopInstancesOutput));
            if (backModel != null)
            {
                return (StopInstancesOutput)backModel;
            }
            return null;
        }

        public class RestartInstancesInput :RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
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

        public class RestartInstancesOutput :OutputModel
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

        public RestartInstancesOutput RestartInstances(RestartInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "RestartInstances");
            context.Add("APIName", "RestartInstances");
            context.Add("ServiceName", "Restart Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(RestartInstancesOutput));
            if (backModel != null)
            {
                return (RestartInstancesOutput)backModel;
            }
            return null;
        }

        public class ResetInstancesInput : RequestInputModel
        {
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

            
            private String loginMode;
            [Param(paramType = "header", paramName = "login_mode")]
            public String getLoginMode()
            {
                return this.loginMode;
            }

            public void setLoginMode(String loginMode)
            {
                this.loginMode = loginMode;
            }

            private String loginKeypair;
            [Param(paramType = "header", paramName = "login_keypair")]
            public String getLoginKeypair()
            {
                return this.loginKeypair;
            }

            public void setLoginKeypair(String loginKeypair)
            {
                this.loginKeypair = loginKeypair;
            }

            private String loginPassword;
            [Param(paramType = "header", paramName = "login_password")]
            public String getLoginPassword()
            {
                return this.loginPassword;
            }

            public void setLoginPassword(String loginPassword)
            {
                this.loginPassword = loginPassword;
            }

            private String loginNewsid;
            [Param(paramType = "header", paramName = "login_newsid")]
            public String getLoginNewsid()
            {
                return this.loginNewsid;
            }

            public void setLoginNewsid(String loginNewsid)
            {
                this.loginNewsid = loginNewsid;
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

        public class ResetInstancesOutput : OutputModel
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

        public ResetInstancesOutput ResetInstances(ResetInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "ResetInstances");
            context.Add("APIName", "ResetInstances");
            context.Add("ServiceName", "Reset Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ResetInstancesOutput));
            if (backModel != null)
            {
                return (ResetInstancesOutput)backModel;
            }
            return null;
        }

        public class ResizeInstancesInput : RequestInputModel
        {
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
               
                this.instanceType = instanceType;
            }

            private int cpu;
            [Param(paramType = "header", paramName = "cpu")]
            public int getCpu()
            {
                return this.cpu;
            }

            public void setCpu(int cpu)
            {

                this.cpu = cpu;
            }

            private String memory;
            [Param(paramType = "header", paramName = "memory")]
            public String getMemory()
            {
                return this.memory;
            }

            public void setMemory(String memory)
            {

                this.memory = memory;
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

        public class ResizeInstancesOutput:OutputModel
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
        
        public ResizeInstancesOutput ResizeInstances(ResizeInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "ResizeInstances");
            context.Add("APIName", "ResizeInstances");
            context.Add("ServiceName", "Resize Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ResizeInstancesOutput));
            if (backModel != null)
            {
                return (ResizeInstancesOutput)backModel;
            }
            return null;
        }

        public class ModifyInstanceAttributesInput:RequestInputModel
        {
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

            private String instanceName;
            [Param(paramType = "header", paramName = "instance_name")]
            public String getInstanceName()
            {
                return this.instanceName;
            }

            public void setInstanceName(String instanceName)
            {

                this.instanceName = instanceName;
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

            private int nicMqueue;
            [Param(paramType = "header", paramName = "nic_mqueue")]
            public int getNicMqueue()
            {
                return this.nicMqueue;
            }

            public void setNicMqueue(int nicMqueue)
            {

                this.nicMqueue = nicMqueue;
            }

            public override String validateParam()
            {

                return null;
            }
        }

        public class ModifyInstanceAttributesOutput:OutputModel
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

        public ModifyInstanceAttributesOutput ModifyInstanceAttributes(ModifyInstanceAttributesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "ModifyInstanceAttributes");
            context.Add("APIName", "ModifyInstanceAttributes");
            context.Add("ServiceName", "Modify Instance Attributes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ModifyInstanceAttributesOutput));
            if (backModel != null)
            {
                return (ModifyInstanceAttributesOutput)backModel;
            }
            return null;
        }

        public class DescribeInstanceTypesInput : RequestInputModel
        {
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

            private String instanceTypes;
            [Param(paramType = "header", paramName = "instance_types")]
            public String getInstanceTypes()
            {
                return this.instanceTypes;
            }

            public void setInstanceTypes(String instanceTypes)
            {

                this.instanceTypes = instanceTypes;
            }

            public override String validateParam()
            {

                return null;
            }
        }

        public class DescribeInstanceTypesOutput:OutputModel
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

            private String instanceTypeSet;
            [Param(paramType = "query", paramName = "instance_type_set")]
            public String getInstanceTypeSet()
            {
                return this.instanceTypeSet;
            }
            public void setInstanceTypeSet(String instanceTypeSet)
            {
                this.instanceTypeSet = instanceTypeSet;
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

            private String instanceTypeId;
            [Param(paramType = "query", paramName = "instance_type_id")]
            public String getInstanceTypeId()
            {
                return this.instanceTypeId;
            }
            public void setInstanceTypeId(String instanceTypeId)
            {
                this.instanceTypeId = instanceTypeId;
            }

            private String instanceTypeName;
            [Param(paramType = "query", paramName = "instance_type_name")]
            public String getInstanceTypeName()
            {
                return this.instanceTypeName;
            }
            public void setInstanceTypeName(String instanceTypeName)
            {
                this.instanceTypeName = instanceTypeName;
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
        }

        public DescribeInstanceTypesOutput DescribeInstanceTypes(DescribeInstanceTypesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "DescribeInstanceTypes");
            context.Add("APIName", "DescribeInstanceTypes");
            context.Add("ServiceName", "Describe Instance Types");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DescribeInstanceTypesOutput));
            if (backModel != null)
            {
                return (DescribeInstanceTypesOutput)backModel;
            }
            return null;
        }

        public class CreateBrokersInput : RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {

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

        public class CreateBrokersOutput : OutputModel
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

            private String brokers;
            [Param(paramType = "query", paramName = "brokers")]
            public String getBrokers()
            {
                return this.brokers;
            }
            public void setBrokers(String brokers)
            {
                this.brokers = brokers;
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

            private String instanceId;
            [Param(paramType = "query", paramName = "instance_id")]
            public String getInstanceId()
            {
                return this.instanceId;
            }
            public void setInstanceId(String instanceId)
            {
                this.instanceId = instanceId;
            }

            private String brokerHost;
            [Param(paramType = "query", paramName = "broker_host")]
            public String getBrokerHost()
            {
                return this.brokerHost;
            }
            public void setBrokerHost(String brokerHost)
            {
                this.brokerHost = brokerHost;
            }

            private int brokerPort;
            [Param(paramType = "query", paramName = "broker_port")]
            public int getBrokerPort()
            {
                return this.brokerPort;
            }
            public void setBrokerPort(int brokerPort)
            {
                this.brokerPort = brokerPort;
            }
        }

        public CreateBrokersOutput CreateBrokers(CreateBrokersInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "CreateBrokers");
            context.Add("APIName", "CreateBrokers");
            context.Add("ServiceName", "Create Brokers");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(CreateBrokersOutput));
            if (backModel != null)
            {
                return (CreateBrokersOutput)backModel;
            }
            return null;
        }

        public class DeleteBrokersInput : RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {

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

        public class DeleteBrokersOutput : OutputModel
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

            private String brokers;
            [Param(paramType = "query", paramName = "brokers")]
            public String getBrokers()
            {
                return this.brokers;
            }
            public void setBrokers(String brokers)
            {
                this.brokers = brokers;
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

        public DeleteBrokersOutput DeleteBrokers(DeleteBrokersInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(Constant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(Constant.CONFIG_CONTEXT_KEY, this.Config);
            context.Add("action", "DeleteBrokers");
            context.Add("APIName", "DeleteBrokers");
            context.Add("ServiceName", "Delete Brokers");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instanceName);

            if (StringUtil.isEmpty(zone))
            {
                throw new QCException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DeleteBrokersOutput));
            if (backModel != null)
            {
                return (DeleteBrokersOutput)backModel;
            }
            return null;
        }
    }
}
