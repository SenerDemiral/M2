// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: protos/lookup.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Rest {
  public static partial class LookupService
  {
    static readonly string __ServiceName = "rest.LookupService";

    static readonly grpc::Marshaller<global::Rest.LookupProxy> __Marshaller_rest_LookupProxy = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rest.LookupProxy.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Rest.BbLookupProxy> __Marshaller_rest_BbLookupProxy = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rest.BbLookupProxy.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Rest.KftLookupProxy> __Marshaller_rest_KftLookupProxy = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rest.KftLookupProxy.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Rest.NntLookupProxy> __Marshaller_rest_NntLookupProxy = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rest.NntLookupProxy.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Rest.AhpLookupProxy> __Marshaller_rest_AhpLookupProxy = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Rest.AhpLookupProxy.Parser.ParseFrom);

    static readonly grpc::Method<global::Rest.LookupProxy, global::Rest.BbLookupProxy> __Method_BbL = new grpc::Method<global::Rest.LookupProxy, global::Rest.BbLookupProxy>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "BbL",
        __Marshaller_rest_LookupProxy,
        __Marshaller_rest_BbLookupProxy);

    static readonly grpc::Method<global::Rest.LookupProxy, global::Rest.KftLookupProxy> __Method_KftL = new grpc::Method<global::Rest.LookupProxy, global::Rest.KftLookupProxy>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "KftL",
        __Marshaller_rest_LookupProxy,
        __Marshaller_rest_KftLookupProxy);

    static readonly grpc::Method<global::Rest.LookupProxy, global::Rest.NntLookupProxy> __Method_NntL = new grpc::Method<global::Rest.LookupProxy, global::Rest.NntLookupProxy>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "NntL",
        __Marshaller_rest_LookupProxy,
        __Marshaller_rest_NntLookupProxy);

    static readonly grpc::Method<global::Rest.LookupProxy, global::Rest.AhpLookupProxy> __Method_AhpL = new grpc::Method<global::Rest.LookupProxy, global::Rest.AhpLookupProxy>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "AhpL",
        __Marshaller_rest_LookupProxy,
        __Marshaller_rest_AhpLookupProxy);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Rest.LookupReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of LookupService</summary>
    public abstract partial class LookupServiceBase
    {
      public virtual global::System.Threading.Tasks.Task BbL(global::Rest.LookupProxy request, grpc::IServerStreamWriter<global::Rest.BbLookupProxy> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task KftL(global::Rest.LookupProxy request, grpc::IServerStreamWriter<global::Rest.KftLookupProxy> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task NntL(global::Rest.LookupProxy request, grpc::IServerStreamWriter<global::Rest.NntLookupProxy> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task AhpL(global::Rest.LookupProxy request, grpc::IServerStreamWriter<global::Rest.AhpLookupProxy> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for LookupService</summary>
    public partial class LookupServiceClient : grpc::ClientBase<LookupServiceClient>
    {
      /// <summary>Creates a new client for LookupService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public LookupServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for LookupService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public LookupServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected LookupServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected LookupServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::Rest.BbLookupProxy> BbL(global::Rest.LookupProxy request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return BbL(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Rest.BbLookupProxy> BbL(global::Rest.LookupProxy request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_BbL, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::Rest.KftLookupProxy> KftL(global::Rest.LookupProxy request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return KftL(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Rest.KftLookupProxy> KftL(global::Rest.LookupProxy request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_KftL, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::Rest.NntLookupProxy> NntL(global::Rest.LookupProxy request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return NntL(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Rest.NntLookupProxy> NntL(global::Rest.LookupProxy request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_NntL, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::Rest.AhpLookupProxy> AhpL(global::Rest.LookupProxy request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AhpL(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Rest.AhpLookupProxy> AhpL(global::Rest.LookupProxy request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_AhpL, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override LookupServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new LookupServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(LookupServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_BbL, serviceImpl.BbL)
          .AddMethod(__Method_KftL, serviceImpl.KftL)
          .AddMethod(__Method_NntL, serviceImpl.NntL)
          .AddMethod(__Method_AhpL, serviceImpl.AhpL).Build();
    }

  }
}
#endregion
