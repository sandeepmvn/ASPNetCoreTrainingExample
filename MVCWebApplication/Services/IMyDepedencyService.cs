using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApplication.Services
{
    public interface IMyDepedencyService
    {
        void WriteMessage(string message);
    }


    public class MyDepedencyService : IMyDepedencyService
    {
        public MyDepedencyService()
        {
            Console.WriteLine(DateTime.Now);
        }
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }


    //public class MyDepedencyService1 : IMyDepedencyService
    //{
    //    public void WriteMessage(string message)
    //    {
    //        // use logger
    //    }
    //}

}
