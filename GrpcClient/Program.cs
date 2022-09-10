using Google.Protobuf;
using Grpc.Net.Client;
using GrpcServer;
using System.Text;

namespace GrpcClient
{
    public class Program
    {
       
        public static async Task Main(string[] args)
        {
            
            await ClientStreamingDemo();
           

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

       
        private static async Task ClientStreamingDemo()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5043");
            var client = new MyStream.MyStreamClient(channel);
            var stream = client.MyStreamOperation();

            FileInfo fileInfo = new FileInfo(Path.Combine("test.txt"));


            MyStreamOperationRequest firstStreamOperationRequest = new MyStreamOperationRequest();
             StartRequest startRequest = new StartRequest();
            startRequest.BlockName = "foo";
            firstStreamOperationRequest.StartRequest = startRequest;
           
            await stream.RequestStream.WriteAsync(firstStreamOperationRequest);

            Console.WriteLine($"Sending: StartRequest, BlockName: { startRequest.BlockName}");
         
           

            using var fs = File.Open(Path.Combine("test.txt"), System.IO.FileMode.Open);
            int bytesRead;
            int fileChunkSize = 12 ;
            var buffer = new byte[fileChunkSize];
            while ((bytesRead = await fs.ReadAsync(buffer)) > 0)
            {
                MyStreamOperationRequest myStreamOperationRequest = new MyStreamOperationRequest();
                var chunck = new ChunckMsg
                {
                     
                    Chunck = ByteString.CopyFrom(buffer[0..bytesRead]),
                };
                myStreamOperationRequest.ChunckMsg = chunck;
                await stream.RequestStream.WriteAsync(myStreamOperationRequest);
                Console.WriteLine("Sending: "+ Encoding.UTF8.GetString(myStreamOperationRequest.ChunckMsg.Chunck.ToByteArray()));
            }

            await stream.RequestStream.CompleteAsync();
        
           
            var response = await stream.ResponseAsync;
            Console.WriteLine("Received: " + response.ResponseMessage);
            await channel.ShutdownAsync();
        }

   
    }
}
