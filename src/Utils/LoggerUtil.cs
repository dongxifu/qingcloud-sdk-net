using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using log4net;
using QingCloudSDK.constants;

namespace QingCloudSDK.utils
{
    class LoggerUtil
    {
        
         public static  ILog setLoggerHanlder(string loggerName)
         {
            ILog logger = LogManager.GetLogger(loggerName);
            if (Constant.LOGGER_LEVEL.Equals(Constant.LOGGER_ERROR)) 
            {
                logger.Error("Error");   
            } 
            else if (Constant.LOGGER_LEVEL.Equals(Constant.LOGGER_WARNNING)) 
            {
                logger.Warn("Warning");
            } 
            else if (Constant.LOGGER_LEVEL.Equals(Constant.LOGGER_INFO)) 
            {
                logger.Info("Info");
            }
            else if (Constant.LOGGER_LEVEL.Equals(Constant.LOGGER_DEBUG)) 
            {
                logger.Debug("Debug");
            }
            else if (Constant.LOGGER_LEVEL.Equals(Constant.LOGGER_FATAL)) 
            {
                logger.Fatal("Fatal");
            } 
            else 
            {
                logger.Warn("Warning");
            }
            return logger;
        }
    }
}
