using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using log4net;
using System.Security.Cryptography;
using System.IO;
using System.Web;

using QingCloudSDK.config;
using QingCloudSDK.constants;
using QingCloudSDK.exception;
using QingCloudSDK.model;
using QingCloudSDK.utils;
using QingCloudSDK.request;

namespace QingCloudSDK.request
{
    class Request:ResourceRequest
    {
        private static ILog logger = LoggerUtil.setLoggerHanlder(typeof(Request).Name);

        private static string REQUEST_PREFIX = "/";

        public void sendApiRequestAsync(
            Dictionary<object,object> context, RequestInputModel paramBean, ResponseCallBack callback)
        {
            string validate = paramBean != null ? paramBean.validateParam() : "";
            Config Config = (Config) context[Constant.CONFIG_CONTEXT_KEY];
            string configValidate = Config.validateParam();
            if (!StringUtil.isEmpty(validate) || !StringUtil.isEmpty(configValidate)) 
            {
                if (StringUtil.isEmpty(validate)) 
                {
                    validate = configValidate;
                }
                OutputModel Out = ParamInvokeUtil.getOutputModel(callback);
                HttpRequestClient.fillResponseCallbackModel(Constant.REQUEST_ERROR_CODE, validate, Out);
                callback.onAPIResponse(Out);
            } 
            else 
            {
                HttpWebRequest request = buildRequest(context, paramBean);
            HttpRequestClient.getInstance()
                    .requestActionAsync(request, Config.isSafeOkHttp(), callback);
            }
        }
        private byte[] GetBodyFile(String FilePath)
        {
            try
            {
                //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(signedUrl);
                FileStream fs = File.OpenRead(FilePath);
              
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                fs.Close();

                //Stream outstream = request.GetRequestStream();
                //outstream.Write(data, 0, data.Length);
                //outstream.Close();
                return data;
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return null;
        }
        private HttpWebRequest buildRequest(Dictionary<object,object> context, RequestInputModel Params)
        {
            Config Config = (Config) context[Constant.CONFIG_CONTEXT_KEY];
            string zone = (string) context[Constant.PARAM_KEY_REQUEST_ZONE];

            Dictionary<object,object> paramsQuery = ParamInvokeUtil.getRequestParams(Params, Constant.PARAM_TYPE_QUERY);
            Dictionary<object, object> paramsBody = ParamInvokeUtil.getRequestParams(Params, Constant.PARAM_TYPE_BODY);
            Dictionary<object, object> paramsHeaders = ParamInvokeUtil.getRequestParams(Params, Constant.PARAM_TYPE_HEADER);

            paramsHeaders.Add("action", context["action"]);
            paramsHeaders.Add("zone", zone);

            if (context.ContainsKey(Constant.PARAM_KEY_USER_AGENT))
            {
                paramsHeaders.Add(Constant.PARAM_KEY_USER_AGENT, context[Constant.PARAM_KEY_USER_AGENT]);
            }

            String requestApi = (String)context[Constant.PARAM_KEY_REQUEST_APINAME];
            //string FileBody = GetBodyFile(context[Constant.PARAM_KEY_OBJECT_NAME].ToString()).ToString();
        
            string method = (string) context[Constant.PARAM_KEY_REQUEST_METHOD];          
            string requestPath = Config.getHost() +Config.getUri();
            string singedUrl =
                SignatureUtil.getURL(
                        Config.getAccessKey(),
                        Config.getAccessSecret(),
                        method,
                        requestPath,
                        paramsQuery,
                        paramsHeaders);
            singedUrl = Config.getProtocol() + "://" + singedUrl;
          
            logger.Info(singedUrl);
          
            //System.Console.WriteLine(singedUrl);
            HttpWebRequest request =
            HttpRequestClient.getInstance()
                            .buildCloudRequest(method, paramsBody, singedUrl, paramsHeaders);
            return request;
            
        }
       
        private static string getSignedUrl(
            string serviceUrl,
            string zone,
            string bucketName,
            Dictionary<object,object> paramsQuery,
            string requestSuffixPath)
        {
            if ("".Equals(bucketName) || bucketName == null) 
            {
                return SignatureUtil.generateQSURL(paramsQuery, serviceUrl + requestSuffixPath);
            } 
            else 
            {
                string storRequestUrl = serviceUrl.Replace("://", "://" + zone + ".");
                return SignatureUtil.generateQSURL(
                    paramsQuery, storRequestUrl.Replace("://","://"+bucketName+".") + requestSuffixPath);
            }
        }
        public void sendApiRequestAsync(String requestUrl, Dictionary<object,object> context, ResponseCallBack callback)
        {
            Config Config = (Config) context[Constant.CONFIG_CONTEXT_KEY];
            HttpWebRequest request = HttpRequestClient.getInstance().buildUrlRequest(requestUrl);
            HttpRequestClient.getInstance().requestActionAsync(request, Config.isSafeOkHttp(), callback);
        }

        public OutputModel sendApiRequest(
            string requestUrl, Dictionary<object,object> context, Type outputClass)
        {
            Config Config = (Config) context[Constant.CONFIG_CONTEXT_KEY];
            HttpWebRequest request = HttpRequestClient.getInstance().buildUrlRequest(requestUrl);
            return HttpRequestClient.getInstance()
                .requestAction(request, Config.isSafeOkHttp(), outputClass);
        }

        public OutputModel sendApiRequest(Dictionary<object,object> context, RequestInputModel paramBean, Type outputClass)
        {
            string validate = paramBean != null ? paramBean.validateParam() : "";
            Config Config = (Config) context[Constant.CONFIG_CONTEXT_KEY];
            string configValidate = Config.validateParam();
            if (!StringUtil.isEmpty(validate) || !StringUtil.isEmpty(configValidate)) 
            {
                if (StringUtil.isEmpty(validate)) 
                {
                    validate = configValidate;
                }
                try 
                {
                    OutputModel model = (OutputModel)Activator.CreateInstance(outputClass);
                    HttpRequestClient.fillResponseCallbackModel(Constant.REQUEST_ERROR_CODE, validate, model);
                    return model;
                } 
                catch (Exception e) 
                {
                    logger.Fatal(e.Message);
                    throw new QCException(e.Message);
                }
            } 
            else 
            {
                HttpWebRequest request = buildRequest(context, paramBean);
                return HttpRequestClient.getInstance().requestAction(request, Config.isSafeOkHttp(), outputClass);
            }
        }

    }
}
