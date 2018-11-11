using System;
//using  Microsoft.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Console;

using System.Collections;
using System.Diagnostics;
using System.IO;
// using System.Security.Permissions;
// using System.Reflection;

namespace Any2pdf.Log
{
    public class  MyLogUtil
    {
        private static ILoggerFactory _factory = null;
        private static bool _filter(string s, LogLevel level){
            return level >= LogLevel.Warning ;
        }

        //shd only be called once when MyLoggerFactory is accessed for the first tme
        private static void ConfigureLogger(ILoggerFactory factory)
        {
            ConfigureLogger(factory, "mylog.txt");
        }
        private static void ConfigureLogger(ILoggerFactory factory, string fname)
        {
            Console.WriteLine("ConfigureLogger in MyLogUtil");
            IConfiguration configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
            int x= (int)(LogLevel.Information);
            if (Int32.TryParse(configuration["LOG_LEVEL"], out x))
            {
                Console.WriteLine("LOG_LEVEL from env va: " + x);
            } else
            {
                Console.WriteLine("LOG_LEVEL not defined in env var, use LogLevel.Information");
            }


            Func<string,LogLevel,bool> filter= (text, level) => level >= (LogLevel)x;
            //factory.AddConsole();
            factory.AddConsole(filter);

            //serilog file extension
            //factory.AddFile(@"c:\workspaces\mylogutil\myLog.txt",  minimumLevel: (LogLevel)x);
            // has to use windows path style ? nodejs-like path.resolve() ?

            factory.AddFile(fname, minimumLevel: (LogLevel)x,isJson:true); 
            //factory.AddProvider(new ConsoleLoggerProvider(filter , true));
            //factory.AddConsole((text, level) => level >= LogLevel.Information);

        }

        public static ILoggerFactory  MyLoggerFactory
        {
            get
            {
                if (_factory == null)
                {
                    _factory = new LoggerFactory();
                    ConfigureLogger(_factory);
                }
                return _factory;
            }
            set { _factory = value; }
        }
        //xxx public static ILogger CreateLogger() => _factory.CreateLogger();
        public static ILogger CreateLogger(string cat){ 
            return MyLoggerFactory.CreateLogger(cat);
        }
        public static ILogger CreateLogger(Type type){
            return MyLoggerFactory.CreateLogger(type.ToString());
        }

        public static ILogger CreateLogger(string cat, string fname){ 
            //non-static factory, just local to the static method
            ILoggerFactory factory = new LoggerFactory();
            ConfigureLogger(factory, fname);

            return factory.CreateLogger(cat);
        }

        //public static ILogger<T> CreateLogger<T>() => MyLoggerFactory.CreateLogger<T>();
        public static ILogger CreateLogger(ILoggerFactory factory, string cat) {
            _factory= factory;
            ConfigureLogger(_factory);
            return _factory.CreateLogger(cat);
        }
    }
}
