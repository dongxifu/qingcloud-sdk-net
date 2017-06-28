using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QingCloudSDK.constants;
using QingCloudSDK.utils;

using QingCloudSDK.Yaml;

namespace QingCloudSDK.config
{
    public class Config
    {
        public static string qingcloudIaasHost = "api.qingcloud.com";

        public static string qingcloudStorHost = "qingstor.com";
        public static string default_protocal = "https";
        public static string default_iaas_uri = "/iaas";
        
        private string accessKey;

        private string accessSecret;

        private string host = "api.qingcloud.com";
        private string port = "443";
        private string protocol = default_protocal;
        private string uri = "/iaas";
        private string log_level = Constant.LOGGER_ERROR;

        private bool safeOkHttp = true;

        public bool isSafeOkHttp() 
        {
            return safeOkHttp;
        }

        public void setSafeOkHttp(bool SafeOkHttp) 
        {
            this.safeOkHttp = SafeOkHttp;
        }

        public string getAccessKey() {
            return accessKey;
        }

        public void setAccessKey(string AccessKey) 
        {
            this.accessKey = AccessKey;
        }

        public string getAccessSecret() 
        {
            return accessSecret;
        }

        public void setAccessSecret(string AccessSecret) 
        {
            this.accessSecret = AccessSecret;
        }

        public string getHost() 
        {
            return host;
        }

        /** @param host example: qingstor.com */
        public void setHost(string Host) 
        {
            this.host = Host;
        }

        public string getPort() 
        {
            return port;
        }

        /** @param port example: 8080 */
        public void setPort(string Port) 
        {
            this.port = Port;
        }

        public string getProtocol() 
        {
            return protocol;
        }

        /** @param protocol example: https or http */
        public void setProtocol(string Protocol) 
        {
            this.protocol = Protocol;
        }

        public string getUri() 
        {
            return uri;
        }

        public string getRequestUrl() 
        {
            string joinUrl = this.getProtocol() + "://" + this.getHost();
            if (this.getPort() != null) {
                joinUrl += ":" + this.getPort();
            }
            if (this.getUri() != null) {
                joinUrl += this.getUri();
            }
            return joinUrl;
        }

        /** @param uri example: /iaas */
        public void setUri(string Uri) {
            this.uri = Uri;
            //Constant.FINNAL_URL = Uri;
        }

        private Config() {}

        public Config(string accessKey, string accessSecret) {
            this.setAccessKey(accessKey);
            this.setAccessSecret(accessSecret);
            this.setHost(qingcloudIaasHost);
            this.setProtocol("https");
            Constant.LOGGER_LEVEL = this.getLog_level();
        }

        public Boolean loadFromFile(string strConfigFile) 
        {
            if (File.Exists(strConfigFile))
            {
                try
                {
                    YamlStream YamlStream = CYamlParser.Load(strConfigFile);
                    if (YamlStream != null)
                    {
                        foreach (YamlDocument YamlDoc in YamlStream.Documents)
                        {
                            DataItem Item = YamlDoc.Root;
                            if (Item is Mapping)
                            {
                                Mapping Mapping = Item as Mapping;
                                if (Mapping != null)
                                {
                                    foreach (MappingEntry MapEntry in Mapping.Enties)
                                    {
                                        string strKey = (MapEntry.Key == null ? "" : MapEntry.Key.ToString());
                                        string strValue = (MapEntry.Value == null ? "" : MapEntry.Value.ToString());

                                        // access_key_id
                                        if (strKey.Equals("access_key_id"))
                                        {
                                            this.accessKey = strValue;
                                        }
                                        // secret_access_key
                                        else if (strKey.Equals("secret_access_key"))
                                        {
                                            this.accessSecret = strValue;
                                        }
                                        // host
                                        else if (strKey.Equals("host"))
                                        {
                                            this.host = strValue;
                                        }
                                        // port
                                        else if (strKey.Equals("port"))
                                        {
                                            this.port = strValue;
                                        }
                                        // protocol
                                        else if (strKey.Equals("protocol"))
                                        {
                                            this.protocol = strValue;
                                        }
                                  
                                    }  // foreach (MappingEntry MapEntry in Mapping.Enties)

                                    return true;
                                }  // if (Mapping != null)
                            }  // if (Item is Mapping)
                        }  // foreach (YamlDocument YamlDoc in YamlStream.Documents)
                    }  // if (YamlStream != null)

                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        
        }
    
        public String getLog_level() 
        {
            return log_level;
        }

	public void setLog_level(String log_level) 
        {
            if(!StringUtil.isEmpty(log_level))
            {
                Constant.LOGGER_LEVEL = log_level;
            }
            this.log_level = log_level;
        }
        public String validateParam() {
            if (StringUtil.isEmpty(getAccessKey())) {
                return StringUtil.getParameterRequired("AccessKey", "Config");
            }
            if (StringUtil.isEmpty(getAccessSecret())) {
                return StringUtil.getParameterRequired("AccessSecret", "Config");
            }
            if (StringUtil.isEmpty(getRequestUrl())) {
                return StringUtil.getParameterRequired("host", "Config");
            }
            return null;
        }
    }
}
