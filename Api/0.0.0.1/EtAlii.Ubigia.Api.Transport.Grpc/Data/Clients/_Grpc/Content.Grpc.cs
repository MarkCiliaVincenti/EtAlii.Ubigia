// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Content.proto
// </auto-generated>
// Original file comments:
//
// Copyright 2018 Peter renken.
//
#pragma warning disable 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol {
  /// <summary>
  /// The Content Grpc service definition.
  /// </summary>
  public static partial class ContentGrpcService
  {
    static readonly string __ServiceName = "EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentGrpcService";

    static readonly grpc::Marshaller<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest> __Marshaller_ContentRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> __Marshaller_ContentResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest, global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> __Method_Get = new grpc::Method<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest, global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Get",
        __Marshaller_ContentRequest,
        __Marshaller_ContentResponse);

    static readonly grpc::Method<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest, global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> __Method_Post = new grpc::Method<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest, global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Post",
        __Marshaller_ContentRequest,
        __Marshaller_ContentResponse);

    static readonly grpc::Method<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest, global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> __Method_Put = new grpc::Method<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest, global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Put",
        __Marshaller_ContentRequest,
        __Marshaller_ContentResponse);

    static readonly grpc::Method<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest, global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> __Method_Delete = new grpc::Method<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest, global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Delete",
        __Marshaller_ContentRequest,
        __Marshaller_ContentResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ContentGrpcService</summary>
    public abstract partial class ContentGrpcServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> Get(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> Post(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> Put(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> Delete(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for ContentGrpcService</summary>
    public partial class ContentGrpcServiceClient : grpc::ClientBase<ContentGrpcServiceClient>
    {
      /// <summary>Creates a new client for ContentGrpcService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ContentGrpcServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ContentGrpcService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ContentGrpcServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ContentGrpcServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ContentGrpcServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse Get(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Get(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse Get(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Get, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> GetAsync(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> GetAsync(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Get, null, options, request);
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse Post(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Post(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse Post(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Post, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> PostAsync(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PostAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> PostAsync(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Post, null, options, request);
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse Put(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Put(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse Put(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Put, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> PutAsync(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PutAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> PutAsync(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Put, null, options, request);
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse Delete(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Delete(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse Delete(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Delete, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> DeleteAsync(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentResponse> DeleteAsync(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ContentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Delete, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ContentGrpcServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ContentGrpcServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ContentGrpcServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Get, serviceImpl.Get)
          .AddMethod(__Method_Post, serviceImpl.Post)
          .AddMethod(__Method_Put, serviceImpl.Put)
          .AddMethod(__Method_Delete, serviceImpl.Delete).Build();
    }

  }
}
#endregion
