using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using QingCloudSDK.utils;
using QingCloudSDK.constants;
using QingCloudSDK.model;

using System.Net.Http;
using System.Net;
using System.Net.Mime;
using System.IO;

namespace QingCloudSDK.request
{
    class HttpRequestClient
    {
        private static ILog logger = LoggerUtil.setLoggerHanlder(typeof(HttpRequestClient).Name);
        private HttpClient client = null;
        private static HttpRequestClient ins;

        protected HttpRequestClient() 
        {
            intiOkHttpClient();
        }

        public void intiOkHttpClient() 
        {
            client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(Constant.HTTPCLIENT_CONNECTION_TIME_OUT*1000);
        }

        public static HttpRequestClient getInstance() 
        {
            if (ins == null) 
            {
                ins = new HttpRequestClient();
            }
            return ins;
        }

        public OutputModel requestAction(HttpWebRequest request, Boolean bSafe, Type outputClass)
        {
            HttpWebResponse response = null;
            try 
            {
                OutputModel model = (OutputModel) ParamInvokeUtil.getOutputModel(outputClass);
                response = (HttpWebResponse)request.GetResponse();
                fillResponseValue2Object(response, model);
                return model;
            } 
            catch (WebException e) 
            {
                logger.Fatal(e.Message);
                Stream stream = e.Response.GetResponseStream();
                StreamReader st = new StreamReader(stream);
                string str = st.ReadToEnd();
                System.Console.WriteLine(str);
            }
            return null;
        }

       /**
        * 
        * @param singedUrl with singed parameter url
        * @return
        */
        public HttpWebRequest buildUrlRequest(string singedUrl) 
        {
           
            HttpWebRequest request =(HttpWebRequest)HttpWebRequest.Create(singedUrl);
            return request;
        }

        private void fillResponseValue2Object(HttpWebResponse response, OutputModel target)
        {
            int code = Convert.ToInt32(response.StatusCode);
            Stream receviceStream = response.GetResponseStream();
            StreamReader readerOfStream = new StreamReader(receviceStream);
            string strHTML = readerOfStream.ReadToEnd();
            string body = strHTML;//.Replace("\"","");//System.Text.RegularExpressions.Regex.Replace(strHTML,"(?is)(?<=<body>).*(?=</body>)","");
            String st = JSONUtil.toJSONObject("");
            st = JSONUtil.putJsonData(st, Constant.PARAM_TYPE_BODYINPUTSTREAM,body);
            if (target!=null) 
            {
                if (!JSONUtil.jsonObjFillValue2Object(st, target)) 
                {
                    try 
                    {
                        string responseInfo = body;
                        // Deserialize HTTP response to concrete type.
                        if (!StringUtil.isEmpty(responseInfo)) 
                        {
                            JSONUtil.jsonFillValue2Object(responseInfo, target);
                        }
                    } 
                    catch (Exception e) 
                    {
                        throw new Exception(e.Message);
                    }
                }
                WebHeaderCollection responseHeaders = response.Headers;
                int iHeads = responseHeaders.Count;
                string headJson = JSONUtil.toJSONObject("");
                headJson = JSONUtil.putJsonData(headJson, Constant.QC_CODE_FIELD_NAME, code);
                for (int i = 0; i < iHeads; i++) 
                {
                    JSONUtil.putJsonData(headJson,responseHeaders.GetKey(i), responseHeaders.GetValues(i));
                }
                JSONUtil.jsonObjFillValue2Object(headJson, target);
            }
        }

        public static void fillResponseCallbackModel(int code, Object content, OutputModel model) 
        {
            string errorJson = "{'"+Constant.QC_CODE_FIELD_NAME+"':"+code +",'"+ Constant.QC_MESSAGE_FIELD_NAME +"':'"+content+"'}";
            JSONUtil.jsonFillValue2Object(errorJson, model);
        }
        private void onOkhttpFailure(String message, ResponseCallBack callBack) 
        {
            try 
            {
                if (callBack != null) 
                {
                    OutputModel m = ParamInvokeUtil.getOutputModel(callBack);
                    fillResponseCallbackModel(Constant.REQUEST_ERROR_CODE, message, m);
                    callBack.onAPIResponse(m);
                }
            } 
            catch (Exception ee) 
            {
                logger.Fatal(ee.Message);
                throw new Exception(ee.Message);
            }
        }

         public delegate OutputModel Asyncdelegate(HttpWebRequest request, Boolean bSafe,ResponseCallBack callBack);  
  
     
        private void CallbackMethod(IAsyncResult ar)  
        {  
            Asyncdelegate dlgt = (Asyncdelegate)ar.AsyncState;  
            dlgt.EndInvoke(ar);  
        }  
  
      
        public virtual OutputModel RunrequestActionAsync(HttpWebRequest request, Boolean bSafe,ResponseCallBack callBack)  
        {  
            Asyncdelegate isgt = new Asyncdelegate(requestActionAsync);  
            IAsyncResult ar = isgt.BeginInvoke(request,bSafe,callBack,new AsyncCallback(CallbackMethod),isgt);
            return null;
        }  

        public virtual OutputModel requestActionAsync(HttpWebRequest request, Boolean bSafe,ResponseCallBack callBack)
        {
            HttpWebResponse response=(HttpWebResponse)request.GetResponse();
            try
            {
                if (callBack != null) 
                {
                    OutputModel m = ParamInvokeUtil.getOutputModel(callBack);
                    fillResponseValue2Object(response, m);
                    callBack.onAPIResponse(m);
                }
            } 
            catch (Exception e) 
            {
                logger.Fatal(e.Message);
                onOkhttpFailure(e.Message, callBack);
            } 
            finally 
            {
                if (response != null) 
                {
                    response.Close();
                }
            }
            return null;
        }

       /**
        * 
        * @param method  request method name
        * @param bodyContent body params
        * @param signedUrl  with signed param url
        * @param headParams http head params
        * @return
        * 
        */
        public object getBodyContent(Dictionary<object,object> bodyContent)
        {
            Dictionary<object, object>.Enumerator iterator = new Dictionary<object, object>.Enumerator();
    	    iterator = bodyContent.GetEnumerator();
            int i=0;
            for(i=0;i<bodyContent.Count;i++)
            {
                iterator.MoveNext();
                string key = iterator.Current.Key.ToString();
                Object bodyObj = bodyContent[key];
                if(Constant.PARAM_TYPE_BODYINPUTFILESTREAM.Equals(key) 
            		|| Constant.PARAM_TYPE_BODYINPUTSTREAM.Equals(key)
            		|| Constant.PARAM_TYPE_BODYINPUTSTRING.Equals(key))
                {
                    return iterator.Current.Value;
                }
                
            }
            object jsonStr = StringUtil.getDictionaryToJson(bodyContent);
            return jsonStr;
        }
        public HttpWebRequest buildCloudRequest(
            string method,
            Dictionary<object, object> bodyContent,
            string signedUrlFirst,
            Dictionary<object, object> headParams)
        {
            String signedUrl = null;

            //System.Console.WriteLine(signedUrl);

            signedUrl = signedUrlFirst;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(signedUrl);
            //request.Headers.Add("qy_access_key_id",)
            request.Method = method;
            return request;
        }
    
    }
}
