//using Google.Protobuf.WellKnownTypes;
//using Grpc.Core;

//namespace GrpcServer.Services
//{
//    public class MyStreamService:MyStream.MyStreamBase
//    {


//        public override async Task<MyStreamOperationResponse> MyStreamOperation(IAsyncStreamReader<MyStreamOperationRequest> requestStream, ServerCallContext context)
//        {
//        //    while (await requestStream.MoveNext())
//        //    {
//        //        MyStreamOperationRequest request = new MyStreamOperationRequest();
//        //        //if(request.StartRequest!=null)
//        //        Console.WriteLine(requestStream.Current.StartRequest);
//        //        //else
//        //        //Console.WriteLine(requestStream.Current.Chunck);
//        //    }

//            return new MyStreamOperationResponse { ResponseMessage = "MyStreamOperationResponse" };

//        }

//        //public override async Task<Empty> MyStreamOperation(IAsyncStreamReader<MyStreamOperationRequest> requestStream, ServerCallContext context)
//        //{
//        //    while (await requestStream.MoveNext())
//        //    {
//        //        MyStreamOperationRequest request = new MyStreamOperationRequest();
//        //        //if(request.StartRequest!=null)
//        //        Console.WriteLine(requestStream.Current.StartRequest);
//        //        //else
//        //        //Console.WriteLine(requestStream.Current.Chunck);
//        //    }

//        //    return null;
//        //}
//        //    public override async Task<Empty> MyStreamOperation(IAsyncStreamReader<MyStreamOperationRequest> requestStream, ServerCallContext context)
//        //    {
//        //        while (await requestStream.MoveNext())
//        //        {
//        //            MyStreamOperationRequest request = new MyStreamOperationRequest();
//        //            //if(request.StartRequest!=null)
//        //                Console.WriteLine(requestStream.Current.StartRequest);
//        //            //else
//        //            //Console.WriteLine(requestStream.Current.Chunck);
//        //        }

//        //        Console.WriteLine("Received: MyStreamOperationResponse");

//        //        return new Empty();

//        //    }
//    }
//}
