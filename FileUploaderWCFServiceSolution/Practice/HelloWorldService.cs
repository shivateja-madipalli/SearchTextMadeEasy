using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWCFServices
{
    public class HelloWorldService : IHelloWorldService
    {
        public String GetMessages(String name)
        {
            return "Hello World from "+name+"!";
        }
    }
}
