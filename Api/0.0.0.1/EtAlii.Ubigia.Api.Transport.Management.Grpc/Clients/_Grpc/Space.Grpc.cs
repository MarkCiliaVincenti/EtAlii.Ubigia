// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Space.proto
// </auto-generated>
// Original file comments:
//
// Copyright 2018 Peter renken.
//
#pragma warning disable 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol {
  /// <summary>
  /// The Space Grpc service definition.
  /// </summary>
  public static partial class SpaceGrpcService
  {
    static readonly string __ServiceName = "EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceGrpcService";

    static readonly grpc::Marshaller<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest> __Marshaller_SpaceRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> __Marshaller_SpaceResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest, global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> __Method_Get = new grpc::Method<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest, global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Get",
        __Marshaller_SpaceRequest,
        __Marshaller_SpaceResponse);

    static readonly grpc::Method<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest, global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> __Method_Post = new grpc::Method<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest, global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Post",
        __Marshaller_SpaceRequest,
        __Marshaller_SpaceResponse);

    static readonly grpc::Method<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest, global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> __Method_Put = new grpc::Method<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest, global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Put",
        __Marshaller_SpaceRequest,
        __Marshaller_SpaceResponse);

    static readonly grpc::Method<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest, global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> __Method_Delete = new grpc::Method<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest, global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Delete",
        __Marshaller_SpaceRequest,
        __Marshaller_SpaceResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SpaceGrpcService</summary>
    public abstract partial class SpaceGrpcServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> Get(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> Post(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> Put(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> Delete(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for SpaceGrpcService</summary>
    public partial class SpaceGrpcServiceClient : grpc::ClientBase<SpaceGrpcServiceClient>
    {
      /// <summary>Creates a new client for SpaceGrpcService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public SpaceGrpcServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for SpaceGrpcService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public SpaceGrpcServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected SpaceGrpcServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected SpaceGrpcServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse Get(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Get(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse Get(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Get, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> GetAsync(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> GetAsync(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Get, null, options, request);
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse Post(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Post(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse Post(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Post, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> PostAsync(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PostAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> PostAsync(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Post, null, options, request);
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse Put(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Put(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse Put(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Put, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> PutAsync(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PutAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> PutAsync(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Put, null, options, request);
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse Delete(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Delete(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse Delete(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Delete, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> DeleteAsync(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceResponse> DeleteAsync(global::EtAlii.Ubigia.Api.Transport.Management.Grpc.WireProtocol.SpaceRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Delete, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override SpaceGrpcServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SpaceGrpcServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(SpaceGrpcServiceBase serviceImpl)
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
