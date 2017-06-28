using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QingCloudSDK.constants
{
    class Constant
    {
        public static string SDK_VERSION = "1.0.0";
        public static string FINNAL_URL = "FINNAL_URL";
        public static string CLOUD_NAME = "qingcloud-sdk-net";
        public static string QC_CODE_FIELD_NAME = "statue_code";
        public static string QC_MESSAGE_FIELD_NAME = "message";

        public static string PARAM_TYPE_QUERY = "query";
        public static string PARAM_TYPE_BODY = "body";
        public static string PARAM_TYPE_HEADER = "header";

        public static string PARAM_TYPE_BODYINPUTSTREAM = "BodyInputStream";
        public static string PARAM_TYPE_BODYINPUTSTRING = "BodyInput";
        public static string PARAM_TYPE_BODYINPUTFILESTREAM = "BodyInputFileStream";

        public static string PARAM_KEY_REQUEST_PATH = "RequestURI";
        public static string PARAM_KEY_REQUEST_METHOD = "RequestMethod";
        public static string PARAM_KEY_REQUEST_ZONE = "RequestZone";
        public static string PARAM_KEY_REQUEST_APINAME = "APIName";

        public static string PARAM_KEY_CONTENT_LENGTH = "Content-Length";
        public static string PARAM_KEY_CONTENT_MD5 = "Content-MD5";
        public static string PARAM_KEY_USER_AGENT = "User-Agent";
        public static string PARAM_KEY_PART_NUMBER = "part_number";

        
        public static string OBJECT_NAME_REPLACE = "<object-key>";

        public static string CONTENT_TYPE_TEXT = "application/json";

        public static string ENCODING_UTF8 = "UTF-8";

        public static string CONFIG_CONTEXT_KEY = "Config";

        public static string SDK_TYPE_IAAS = "qingcloud_iaas";

        public static string CLOUD_DEFAULT_ZONE = "pek3a";

        public static string HEADER_PARAM_KEY_DATE = "time_stamp";

        public static string HEADER_PARAM_KEY_EXPIRES = "Expires";

        public static string HEADER_PARAM_KEY_CONTENTTYPE = "Content-Type";

        public static int REQUEST_ERROR_CODE = 10000;

        public static string LOGGER_LEVEL = "error";

        public static string LOGGER_ERROR = "error";
        public static string LOGGER_WARNNING = "warn";
        public static string LOGGER_INFO = "info";
        public static string LOGGER_DEBUG = "debug";
        public static string LOGGER_FATAL = "fatal";
    

        public static int HTTPCLIENT_CONNECTION_TIME_OUT = 60; // Seconds
        public static int HTTPCLIENT_READ_TIME_OUT = 100; // Seconds
        public static int HTTPCLIENT_WRITE_TIME_OUT = 100; // Seconds
    }
}
