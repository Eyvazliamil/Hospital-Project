using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Logs
{
    public class LogHistory
    { 
        public static void saveLogInfos(string msg)
        { 
            var logProcess = Path.Combine(AppContext.BaseDirectory, "logs", "process.log");
            Directory.CreateDirectory(Path.GetDirectoryName(logProcess)!);

            using var log = new LoggerConfiguration() 
     .WriteTo.File(
         logProcess,
         rollingInterval: RollingInterval.Day,
         retainedFileCountLimit: 30,
         shared: true,
         outputTemplate:
             "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] " +
             "[{Level:u3}] " +
             "[Env:{EnvironmentName}] " +
             "[Thread:{ThreadId}] " +
             "[{SourceContext}] " +
             "{Message:lj}{NewLine}{Exception}")
     .CreateLogger();
             

            log.Information(msg);

        }

        public static void saveLogErrors(string msg)
        { 
            var logProcess = Path.Combine(AppContext.BaseDirectory, "logs", "process.log");
            Directory.CreateDirectory(Path.GetDirectoryName(logProcess)!);

            using var log = new LoggerConfiguration() 
    .WriteTo.File(
        logProcess,
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 30,
        shared: true,
        outputTemplate:
            "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] " +
            "[{Level:u3}] " +
            "[Env:{EnvironmentName}] " +
            "[Thread:{ThreadId}] " +
            "[{SourceContext}] " +
            "{Message:lj}{NewLine}{Exception}")
    .CreateLogger();

            log.Error(msg);

        }
    }
}
