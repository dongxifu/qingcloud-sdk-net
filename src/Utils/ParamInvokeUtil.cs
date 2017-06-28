using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using QingCloudSDK.Attribute;
using QingCloudSDK.constants;
using QingCloudSDK.exception;
using QingCloudSDK.model;
using QingCloudSDK.request;
using System.Web;

namespace QingCloudSDK.utils
{
    class ParamInvokeUtil
    {
        private static void setParameterToDictionary(MethodInfo m, object source, Dictionary<object,object> retParametersDictionary, string paramKey)
        {
            object[] invokeParams = null;
            object objValue = m.Invoke(source, invokeParams);
            if (objValue != null) 
            {
                Type Ts = objValue.GetType();
                if (Ts.Equals(typeof(int))
                    || Ts.Equals(typeof(double))
                    || Ts.Equals(typeof(Boolean))
                    || Ts.Equals(typeof(bool))
                    || Ts.Equals(typeof(long))
                    || Ts.Equals(typeof(float)))
                {
                    retParametersDictionary.Add(paramKey.ToString().ToLower(), objValue.ToString());
                }
                else if(Ts.Equals(typeof(String[])))
                {
                    for(int i=0;i<((String[])objValue).Length;i++)
                    {
                        retParametersDictionary.Add(paramKey.ToString().ToLower()+"."+(i+1).ToString(), StringUtil.chineseCharactersEncoding(((String[])objValue)[i] + ""));
                    }
                }
                else if(Ts.Equals(typeof(string)) || Ts.Equals(typeof(string)))
                {
                    retParametersDictionary.Add(paramKey.ToString().ToLower(), StringUtil.chineseCharactersEncoding(objValue + ""));
                }
                else 
                {
                    retParametersDictionary.Add(paramKey.ToString().ToLower(), objValue);
                }
            }
        }
        private static void initParameterDictionary(Type objClass, object source, Dictionary<object,object> retParametersDictionary, string paramType)
        {
            try
            {
                FieldInfo[] declaredField = objClass.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                int i=0;
                for (i=0;i<declaredField.Length;i++) 
                {
                    FieldInfo field=declaredField[i];
                    string methodName = "get" + field.Name.Substring(0,1).ToUpper()+field.Name.Substring(1);
                    string fieldName = field.Name;
                    MethodInfo[] methods = objClass.GetMethods();
                    int k=0;
                    for (k=0;k<methods.Length;k++) 
                    {
                        MethodInfo m=methods[k];
                        if (m.Name.Equals(methodName,StringComparison.CurrentCultureIgnoreCase)) 
                        {
                            ParamAttribute attribute = (ParamAttribute)ParamAttribute.GetCustomAttribute(m,typeof(ParamAttribute));
                            if (attribute == null) 
                            {
                                continue;
                            }
                            if (!"".Equals(attribute.paramName)) 
                            {
                                fieldName = attribute.paramName;
                            }
                            if (paramType.Equals(attribute.paramType)) 
                            {
                                setParameterToDictionary(m, source, retParametersDictionary, fieldName);
                            } 
                            else if (paramType.Equals(attribute.paramType)) 
                            {
                                setParameterToDictionary(m, source, retParametersDictionary, fieldName);
                            } 
                            else if (paramType.Equals(attribute.paramType)) 
                            {
                                setParameterToDictionary(m, source, retParametersDictionary, fieldName);
                            } 
                            else if ("".Equals(paramType)) 
                            {
                                setParameterToDictionary(m, source, retParametersDictionary, fieldName);
                            }
                        }
                    }
                }
             }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static Dictionary<object,object> getRequestParams(object model, string paramType) 
        {
            Dictionary<object,object> retParametersDictionary = new Dictionary<object,object>();
            if (model != null) 
            {
                try 
                {
                    Type tmpType = model.GetType();
                    while (tmpType != typeof(Object))
                    {
                        initParameterDictionary(tmpType, model, retParametersDictionary, paramType);
                        tmpType = tmpType.BaseType;
                    }
                } 
                catch (Exception e) 
                {
                    throw new Exception(e.Message);
                } 
            }
            if (Constant.PARAM_TYPE_HEADER.Equals(paramType)) 
            {
                if (!retParametersDictionary.ContainsKey(Constant.HEADER_PARAM_KEY_DATE)) 
                {
                    retParametersDictionary.Add(Constant.HEADER_PARAM_KEY_DATE,SignatureUtil.formatGmtDate(DateTime.Now));
                }
            /*if(!retParametersMap.containsKey(SDKConstant.HEADER_PARAM_KEY_CONTENTTYPE)){
                retParametersMap.put(SDKConstant.HEADER_PARAM_KEY_CONTENTTYPE, SDKConstant.CONTENT_TYPE_TEXT);
            }*/
            }
            return retParametersDictionary;
        }
    

        public static string capitalize(string word) 
        {
            return word.Substring(0, 1).ToUpper() + word.Substring(1);
        }

        public static object getOutputModel(Type TypeName)
        {
            try 
            {
                return Activator.CreateInstance(TypeName);
            }
            catch (Exception e) 
            {
                throw new QCException(e.Message);
            }
        }

        public static Dictionary<object,object> serializeParams(Dictionary<object,object> parameters) 
        {
            Dictionary<object,object> result = new Dictionary<object,object>();
            Dictionary<object,object>.Enumerator en=parameters.GetEnumerator();
            int i;
            for(i=0;i<parameters.Count;i++) 
            {
                en.MoveNext();
                string key = en.Current.Key.ToString();
                object value = (object) en.Current.Value;
                if (value is List<object>) 
                {
                    for(int k = 0, cnt = ((List<object>) value).Count; k < cnt; k++) 
                    {
                        object v2 = ((List<object>) value)[i];
                        if (v2 is Dictionary<object,object>) 
                        {
                           
                            int m=0;
                            Dictionary<object,object>.Enumerator en2 = ((Dictionary<object,object>)v2).GetEnumerator();
                            for (m=0;m<((Dictionary<object,object>)v2).Count;m++) 
                            {
                                object key2=en2.Current.Key;
                                result.Add(key + "." +(i + 1).ToString() + "." + key2,((Dictionary<object,object>)v2)[key2]);
                            }
                        } 
                        else 
                        {
                            result.Add(key + "." + (i+1).ToString(), v2);
                        }
                    }
                } 
                else if (value is int
                    || value is long
                    || value is float
                    || value is double
                    || value is Boolean
                    || value is bool) 
                {
                    result.Add(key,value.ToString());
                } 
                else 
                {
                    result.Add(key, value);
                }
            }
            return result;
        }

        public static OutputModel getOutputModel(ResponseCallBack o)
        {
            Type[] typeClass = o.GetType().GetInterfaces();

            try 
            {
                if (typeClass[0] is Type) 
                {
                    Type actualType = (Type)typeClass[0].GetType().GetGenericTypeDefinition().GetGenericArguments().First();
                    return (OutputModel) Activator.CreateInstance(actualType);
                } 
                else 
                {
                    return (OutputModel)Activator.CreateInstance(typeof(OutputModel));
                }
            } 
            catch (Exception e) 
            {
                throw new QCException(e.Message);
            } 
        
        }
    }
}
