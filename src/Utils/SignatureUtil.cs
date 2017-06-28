using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using QingCloudSDK.constants;
using QingCloudSDK.exception;
using QingCloudSDK.config;
using QingCloudSDK.model;

using System.Security.Cryptography;
using System.Web;

namespace QingCloudSDK.utils
{
    class SignatureUtil
    {
        private static ILog logger = LoggerUtil.setLoggerHanlder(typeof(SignatureUtil).Name);
        private static Dictionary<object,object> keysDictionary;

        public static string generateQSURL(Dictionary<object, object> parameters, string requestUrl)
        {
            parameters = ParamInvokeUtil.serializeParams(parameters);
            StringBuilder sbStringToSign = new StringBuilder();
            string[] sortedKeys=new string[200];
            int i=0;
            foreach(var key in parameters.Keys)
            {
                sortedKeys[i]=key.ToString();
                i++;
            }
            //Array.Sort(sortedKeys);
            int j;
            int count = 0;
            try 
            {
                for (j=0;j<i;j++) 
                {
                    string key=sortedKeys[j];
                    if (count != 0) 
                    {
                        sbStringToSign.Append("&");
                    }
                    sbStringToSign
                        .Append(StringUtil.percentEncode(key, Constant.ENCODING_UTF8))
                        .Append("=")
                        .Append(StringUtil.percentEncode(parameters[key].ToString(), Constant.ENCODING_UTF8));
                    count++;
                }
            } 
            catch (Exception e) 
            {
                logger.Error(e.Message);
                System.Console.WriteLine(e.Message);
            }

            if (sbStringToSign.Length > 0) 
            {

                if (requestUrl.IndexOf("?") > 0) 
                {
                    return (requestUrl + "&" + sbStringToSign.ToString());
                } 
                else 
                {
                    return (requestUrl + "?" + sbStringToSign.ToString());
                }
            }
            return requestUrl;
        }

       /**
        * Generate signature for request against QingStor.
        *
        * @param accessKey: API access key ID
        * @param secretKey: API secret access key ID
        * @param method: HTTP method
        * @param authPath:
        * @param params: HTTP request parameters
        * @param headers: HTTP request headers
        * @return a string which can be used as value of HTTP request header field "Authorization"
        *     directly.
        *     <p>See https://docs.qingcloud.com/qingstor/api/common/signature.html for more details
        *     about how to do signature of request against QingStor.
        */
        public static string getURL(string accessKey,string secretKey,string method,string authPath,Dictionary<object, object> Params,Dictionary<object, object> headers) 
        {
            string URL = getSignature(accessKey, secretKey, method, authPath, Params, headers);
            return URL;
        }

       /**
        * Generate signature for request against QingStor.
        *
        * @param accessKey: API access key ID
        * @param secretKey: API secret access key ID
        * @param method: HTTP method
        * @param authPath:
        * @param params: HTTP request parameters
        * @param headers: HTTP request headers
        * @return a string which can be used as value of HTTP request header field "Authorization"
        *     directly.
        *     <p>See https://docs.qingcloud.com/qingstor/api/common/signature.html for more details
        *     about how to do signature of request against QingStor.
        */
        public static string getSignature(string accessKey,string secretKey,string method,string authPath,Dictionary<object, object> Params,Dictionary<object, object> headers) 
        {
            string SEPARATOR = "&";
            string signature = "";
            string strToSign = "";

            strToSign += method.ToUpper() + "\n";
            
            /*string contentMD5 = "";
            string contentType = "";*/

            headers.Add("access_key_id", accessKey);
            headers.Add("signature_method", "HmacSHA256");
            headers.Add("signature_version", "1");
            if(headers.ContainsKey("time_stamp"))
            {
                DateTime time = Convert.ToDateTime(headers["time_stamp"]);
                headers["time_stamp"] = time.ToString("yyyy-MM-ddTHH:mm:ssZ");
            }
          
            // Generate canonicalized query string.
            string canonicalized_query = null;
            if (Params != null) 
            {
                string[] sortedParamsKeys = new string[headers.Count];
                int keyindex2=0;
                foreach(var key in headers.Keys)
                {
                    sortedParamsKeys[keyindex2]=key.ToString();
                    keyindex2++;
                }
                Array.Sort(sortedParamsKeys);
                int i=0;
                for (i=0;i<keyindex2;i++) 
                {
                    string key=sortedParamsKeys[i];
                    key = HttpUtility.UrlEncode(key, Encoding.GetEncoding(Constant.ENCODING_UTF8));
                    if (canonicalized_query!=null) 
                    {
                        canonicalized_query += SEPARATOR;
                    }

                    try 
                    {
                        canonicalized_query += key;
                        string value = headers[key].ToString();
                        value = HttpUtility.UrlEncode(value, Encoding.GetEncoding(Constant.ENCODING_UTF8)).Replace("%2f", "%2F")
                            .Replace("%2b", "%2B")
                            .Replace("%3a", "%3A")
                            .Replace("%2b", "%2A")
                            .Replace("%7e", "%7E");
                        if (value!=null) 
                        {
                            canonicalized_query += "=" + value;
                        }
                    } 
                    catch (Exception e) 
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
            
            // Generate canonicalized resource.
            string PreSign = method.ToUpper() + "\n";
            string canonicalized_resource = authPath;
            PreSign += "/iaas/\n" + canonicalized_query;
            signature = genSignature(secretKey, PreSign);
            
            if (canonicalized_query!=null) 
            {
                canonicalized_resource += "/?" + canonicalized_query;
            }
            canonicalized_resource += "&signature=" + signature;
            return canonicalized_resource;
        }

        public static string genSignature(string secretKey, string strToSign) 
        {
            byte[] RstRes = null;
            try 
            {
                HMACSHA256 sha256=new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
                RstRes=sha256.ComputeHash(Encoding.UTF8.GetBytes(strToSign));
                // return new String(Base64.encodeBase64(signData));
            } 
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
            String temp = Convert.ToBase64String(RstRes);
            if(temp.IndexOf(' ')>=0)
            {
                temp = temp.Replace(' ','+');
            }
            return HttpUtility.UrlEncode(temp, Encoding.GetEncoding(Constant.ENCODING_UTF8));
        }

        public static Boolean isSubKey(string key) 
        {
            if (keysDictionary == null) 
            {
                keysDictionary = new Dictionary<object,object>();
                keysDictionary.Add("acl", "acl");
                keysDictionary.Add("cors", "cors");
                keysDictionary.Add("delete", "delete");
                keysDictionary.Add("mirror", "mirror");
                keysDictionary.Add("part_number", "part_number");
                keysDictionary.Add("policy", "policy");
                keysDictionary.Add("stats", "stats");
                keysDictionary.Add("upload_id", "upload_id");
                            
                keysDictionary.Add("response-expires", "response-expires");
                keysDictionary.Add("response-cache-control", "response-cache-control");
                keysDictionary.Add("response-content-type", "response-content-type");
                keysDictionary.Add("response-content-language", "response-content-language");
                keysDictionary.Add("response-content-encoding", "response-content-encoding");
                keysDictionary.Add("response-content-disposition", "response-content-disposition");
            }
            if (key != null)
                return keysDictionary.ContainsKey(key);
            else
                return false;
        }

        public static string formatIso8601Date(DateTime date) 
        {
            return date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:sszzzz");
        }

        public static string formatGmtDate(DateTime date) 
        {
            return date.ToUniversalTime().ToString("r");  
        }

        public static string getObjectAuthRequestUrl(
            Config Config,
            String zone,
            String bucketName,
            String objectName,
            int expiresSecond)
        {
            Dictionary<object,object> context = new Dictionary<object,object>();
            try 
            {
                objectName = percentEncode(objectName);
                context.Add(Constant.PARAM_KEY_REQUEST_ZONE, zone);
                context.Add(Constant.CONFIG_CONTEXT_KEY, Config);
                context.Add("OperationName", "GetObject");
                context.Add("APIName", "GetObject");
                context.Add("ServiceName", "QingStor");
                context.Add("RequestMethod", "GET");
                context.Add("RequestURI", "/<bucket-name>/<object-key>");
                context.Add("bucketNameInput", bucketName);
                context.Add("objectNameInput", objectName);
                DateTime fi=Convert.ToDateTime("1970-1-1");
                int expiresTime = (int) ((DateTime.Now-fi).Seconds + expiresSecond);
                string expireAuth = getExpireAuth(context, expiresTime, new RequestInputModel());
                string serviceUrl = Config.getRequestUrl();
                string storRequestUrl = serviceUrl.Replace("://", "://" + zone + ".");
                if (objectName != null && objectName.IndexOf("?") > 0) 
                {
                    return (storRequestUrl + "/" + bucketName + "/" + objectName +
                        "&access_key_id=" + Config.getAccessKey() + "&expires=" + expiresTime.ToString() + "&signature=" + expireAuth);
                        
                } 
                else 
                {
                    return (storRequestUrl + "/" + bucketName + "/" + objectName +
                        "?&access_key_id=" + Config.getAccessKey() + "&expires=" + expiresTime.ToString() + "&signature=" + expireAuth);
                }
            } 
            catch (Exception e) 
            {
                throw new QCException(e.Message);
            }
        }

        public static String percentEncode(string value)
        {
            return value != null
                    ? HttpUtility.UrlEncode(value, Encoding.GetEncoding(Constant.ENCODING_UTF8))
                            .Replace("%2F", "/")
                            .Replace("%2B", "+")
                            .Replace("%2A", "*")
                            .Replace("%7E", "~")
                    : null;
        }

        public static String getExpireAuth(Dictionary<object,object> context, int expiresSecond, RequestInputModel Params)
        {
            Config Config = (Config) context[Constant.CONFIG_CONTEXT_KEY];

            Dictionary<object,object> paramsQuery = ParamInvokeUtil.getRequestParams(Params, Constant.PARAM_TYPE_QUERY);
            Dictionary<object,object> paramsHeaders =   ParamInvokeUtil.getRequestParams(Params, Constant.PARAM_TYPE_HEADER);
            paramsHeaders.Remove(Constant.HEADER_PARAM_KEY_DATE);
            paramsHeaders.Clear();
            paramsHeaders.Add(Constant.HEADER_PARAM_KEY_EXPIRES, expiresSecond + "");

            string method = (string) context[Constant.PARAM_KEY_REQUEST_METHOD];
          
            string requestPath = Config.getHost() + Config.getUri();
            string authSign = getSignature(
                        Config.getAccessKey(),
                        Config.getAccessSecret(),
                        method,
                        requestPath,
                        paramsQuery,
                        paramsHeaders);

            return HttpUtility.UrlEncode(authSign, Encoding.GetEncoding(Constant.ENCODING_UTF8));
        }
    }
}
