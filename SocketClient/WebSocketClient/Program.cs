using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketClient
{
    class Program
    {

        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");

            new test().WebSocket();

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

    }

    public class test
    {

        readonly ClientWebSocket _webSocket = new ClientWebSocket();
        readonly CancellationToken _cancellation = new CancellationToken();
        public async void WebSocket()
        {
            try
            {

                //建立连接
                var url = "ws://localhost:8080/ws";

                var url1 = "ws://localhost:60365/ws";

                await _webSocket.ConnectAsync(new Uri(url), _cancellation);

                var bsend = new byte[1024];


                var messageBytes = System.Text.Encoding.UTF8.GetBytes("123123");

                await _webSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Binary, true, _cancellation); //发送数据

                while (true)
                {
                    var result = new byte[1024 *4];

                    await _webSocket.ReceiveAsync(new ArraySegment<byte>(result), new CancellationToken());//接受数据

                    //var lastbyte = ByteCut(result, 0x00);

                    var str = Encoding.UTF8.GetString(result, 0, result.Length);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
