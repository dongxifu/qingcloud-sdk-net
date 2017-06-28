using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingCloudSDK.constants;
using QingCloudSDK.exception;
using System.Web;

namespace QingCloudSDK.utils
{
    class StringUtil
    {
        public static string getDictionaryToJson(Dictionary<object,object> Params) 
        {
            Dictionary<object ,object>.Enumerator en = Params.GetEnumerator();
            StringBuilder buffer = new StringBuilder("{");
            for(int i=0;i<Params.Count;i++) 
            {
                en.MoveNext();
                string key = en.Current.Key.ToString();
                object bodyObj = Params[key];
                buffer.Append(objectJSONKeyValue(key,bodyObj));
                if(i+1!=Params.Count)
                    buffer.Append(",");
                
            }
            /*if (buffer.Length > 1) 
            {
                buffer.Capacity = buffer.Length - 1;
            }*/
            buffer.Append("}");
            return buffer.ToString();
        }
        private static string objectJSONValue(object o) 
        {
            StringBuilder buffer = new StringBuilder();
            if (o is List<object>) 
            {
                List<object> lst = (List<object>)o;
                buffer.Append("[");
                for (int i = 0; i < lst.Count; i++) 
                {
                    buffer.Append(objectJSONValue(lst[i]));
                    if (i + 1 < lst.Count) 
                    {
                        buffer.Append(",");
                    }
                }
                buffer.Append("]");
            } 
            else if (o is Dictionary<object,object>) 
            {
                Dictionary<object,object>  m = (Dictionary<object,object>)o;
                buffer.Append(getDictionaryToJson(m));
            } 
            else if (o is int
                || o is Double
                || o is double
                || o is Boolean
                || o is bool
                || o is long
                || o is float) 
            {
                buffer.Append(o);
            }
            else if (o is string) 
            {
                buffer.Append("\"").Append(o).Append("\"");
            }
            else 
            {
                Dictionary<object,object> objMap = ParamInvokeUtil.getRequestParams(o,"");
                buffer.Append(getDictionaryToJson(objMap));
            }
            return buffer.ToString();
        }
        private static string objectJSONKeyValue(string key, object o) 
        {
            StringBuilder buffer = new StringBuilder(" \"" + key + "\":");
            buffer.Append(objectJSONValue(o));
            return buffer.ToString();
        }
        public static string objectToJson(string key, object o) 
        {
            
            StringBuilder buffer = new StringBuilder("{ \"" + key + "\":");
            buffer.Append(objectJSONKeyValue(key,o));
            buffer.Append("}");
            return buffer.ToString();
        }
        
        public static string percentEncode(string value, string encoding)
        {
            return value != null
                ? HttpUtility.UrlEncode(value,Encoding.GetEncoding(encoding))
                        .Replace("+", "%20")
                        .Replace("*", "%2A")
                        .Replace("%7E", "~")
                : null;
        }

        public static Boolean isEmpty(string str) 
        {
            if (str == null || "".Equals(str.Trim()) || "null".Equals(str,StringComparison.CurrentCultureIgnoreCase)) 
            {
                return true;
            }
            return false;
        }

        public static string getUserAgent() 
        {
    	    string osName = System.Environment.OSVersion.ToString();
            string NetVersion = System.Environment.Version.ToString();
            string userAgent =
                Constant.CLOUD_NAME
                        + "/"
                        + Constant.SDK_VERSION
                        + " ( c# v"
                        + NetVersion
                        + ";"
                        + osName
                        + ")";
            return userAgent;
        }

        public static string getParameterRequired(string paraName, string value) 
        {
            return (paraName + " is required in "+value);
        }

        public static string getParameterValueNotAllowedError(string paraName, string value, string[] values) 
        {
            StringBuilder buf = new StringBuilder();
            int i;
            for (i=0;i<values.Length;i++) 
            {
                object o= values[i];
                buf.Append(o.ToString());
                if(i+1!=values.Length)
                    buf.Append(",");
            }
           
            return paraName + " value "+ value +" is not allowed, should be one of " + buf.ToString();
        }
    
       /**
        * Chinese characters transform
        *
        * @param str
        * @return
        */
        public static string chineseCharactersEncoding(string str)
        {
            if (StringUtil.isEmpty(str)) 
            {
                return "";
            }
            StringBuilder buffer = new StringBuilder();
            try 
            {
                for (int i = 0; i < str.Length; i++) 
                {
                    string temp = str.Substring(i, 1);
                    if (Encoding.UTF8.GetBytes(temp).Length > 1) 
                    {
                        buffer.Append(HttpUtility.UrlEncode(temp,Encoding.GetEncoding(Constant.ENCODING_UTF8)));
                    } 
                    else 
                    {
                        buffer.Append(temp);
                    }
                }
                return buffer.ToString();
            } 
            catch (Exception e) 
            {
                System.Console.WriteLine(e.Message);
            }
            return null;
        }
        public static String asciiCharactersEncoding(String str)
        {
            if (StringUtil.isEmpty(str)) 
            {
                return "";
            }
            StringBuilder buffer = new StringBuilder();
            try 
            {
                for (int i = 0; i < str.Length; i++) 
                {
                    String temp = str.Substring(i,1);
                    if (Encoding.UTF8.GetBytes(temp).Length>1)
                    {
                        buffer.Append(HttpUtility.UrlEncode(temp, Encoding.GetEncoding(Constant.ENCODING_UTF8)));
                    } 
                    else 
                    {
                        buffer.Append(temp);
                    }
                }
                return buffer.ToString();
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }
        public static String urlCharactersEncoding(String str) 
        {
            if (StringUtil.isEmpty(str)) 
            {
                return "";
            }
            StringBuilder buffer = new StringBuilder();
            try 
            {
                for (int i = 0; i < str.Length; i++) 
                {
                    String temp = str.Substring(i,1);
                    if (' '.Equals(temp)) 
                    {
                        buffer.Append("%20");
                    } 
                    else if ('/'.Equals(temp) || '&'.Equals(temp)|| '='.Equals(temp)|| ':'.Equals(temp)) 
                    {
                        buffer.Append(temp);
                    } 
                    else 
                    {
                        buffer.Append(HttpUtility.UrlEncode(temp, Encoding.GetEncoding(Constant.ENCODING_UTF8)));
                    }
                }
                return buffer.ToString();
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }
    }
}
