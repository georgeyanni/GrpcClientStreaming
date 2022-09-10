using Google.Protobuf;
using Grpc.Core;
using System.Text;

namespace GrpcServer.Services
{
    public class MyStreamService:MyStream.MyStreamBase
    {
        public override async Task<MyStreamOperationResponse> MyStreamOperation(IAsyncStreamReader<MyStreamOperationRequest> requestStream, ServerCallContext context)
        {
            
            while (await requestStream.MoveNext())
            {
               
               if(requestStream.Current.StartRequest!=null)

                     Console.WriteLine("Received: " +requestStream.Current.StartRequest);
                else
                    Console.WriteLine("Received: " + Encoding.UTF8.GetString(requestStream.Current.ChunckMsg.Chunck.ToByteArray()));
      
               
            }
            Console.WriteLine("Responding : MyStreamOperationResponse");
            return new MyStreamOperationResponse { ResponseMessage = "MyStreamOperationResponse" };

        }
    }
}
