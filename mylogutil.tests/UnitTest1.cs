using System;
using Xunit;
using Any2pdf.Log;
using Microsoft.Extensions.Logging;

namespace mylogutil.tests
{
    public class UnitTest1
    {
        static ILogger _logger=MyLogUtil.CreateLogger("mylogutil.tests", "unitTest1.txt");
         [Fact]
        public void Test1()
        {
            ILogger logger= MyLogUtil.CreateLogger("test1");
            logger.LogInformation("Test1() on default log location mylog*.txt");

            _logger.LogInformation("Test1() on another log location unitTest1*.txt");

        }
       [Fact]
        public void Test2()
        {
            ILogger logger= MyLogUtil.CreateLogger("test2");
            logger.LogInformation("Test2() on default log location mylog*.txt");

            _logger.LogInformation("Test2() on another log location unitTest1*.txt");

        }
    }
}
