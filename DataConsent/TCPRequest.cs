using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsent
{
    class TCPRequest
    {

        public static void test()
        {

            using (var server = new ResponseSocket("tcp://127.0.0.1:11000"))
            using (var client = new RequestSocket("tcp://127.0.0.1:11000"))
            {

                var message = new NetMQ.NetMQMessage();
                message.Append("IAmFrame0");
                message.Append("IAmFrame1");               
                client.SendMultipartMessage(message);

                //await Task.Run(() => test());
            }

        }
    }
}
