// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: Root.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EtAlii.Ubigia.Api.Transport.Grpc {

  /// <summary>Holder for reflection information generated from Root.proto</summary>
  public static partial class RootReflection {

    #region Descriptor
    /// <summary>File descriptor for Root.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RootReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgpSb290LnByb3RvEiBFdEFsaWkuVWJpZ2lhLkFwaS5UcmFuc3BvcnQuR3Jw",
            "YxoMX01vZGVsLnByb3RvIkEKC1Jvb3RSZXF1ZXN0EjIKAklkGAEgASgLMiYu",
            "RXRBbGlpLlViaWdpYS5BcGkuVHJhbnNwb3J0LkdycGMuR3VpZCJECgxSb290",
            "UmVzcG9uc2USNAoEUm9vdBgBIAEoCzImLkV0QWxpaS5VYmlnaWEuQXBpLlRy",
            "YW5zcG9ydC5HcnBjLlJvb3QytQMKD1Jvb3RHcnBjU2VydmljZRJmCgNHZXQS",
            "LS5FdEFsaWkuVWJpZ2lhLkFwaS5UcmFuc3BvcnQuR3JwYy5Sb290UmVxdWVz",
            "dBouLkV0QWxpaS5VYmlnaWEuQXBpLlRyYW5zcG9ydC5HcnBjLlJvb3RSZXNw",
            "b25zZSIAEmcKBFBvc3QSLS5FdEFsaWkuVWJpZ2lhLkFwaS5UcmFuc3BvcnQu",
            "R3JwYy5Sb290UmVxdWVzdBouLkV0QWxpaS5VYmlnaWEuQXBpLlRyYW5zcG9y",
            "dC5HcnBjLlJvb3RSZXNwb25zZSIAEmYKA1B1dBItLkV0QWxpaS5VYmlnaWEu",
            "QXBpLlRyYW5zcG9ydC5HcnBjLlJvb3RSZXF1ZXN0Gi4uRXRBbGlpLlViaWdp",
            "YS5BcGkuVHJhbnNwb3J0LkdycGMuUm9vdFJlc3BvbnNlIgASaQoGRGVsZXRl",
            "Ei0uRXRBbGlpLlViaWdpYS5BcGkuVHJhbnNwb3J0LkdycGMuUm9vdFJlcXVl",
            "c3QaLi5FdEFsaWkuVWJpZ2lhLkFwaS5UcmFuc3BvcnQuR3JwYy5Sb290UmVz",
            "cG9uc2UiAEJYCiBFdEFsaWkuVWJpZ2lhLkFwaS5UcmFuc3BvcnQuR3JwY0IG",
            "VWJpZ2lhUAGiAgZVYmlnaWGqAiBFdEFsaWkuVWJpZ2lhLkFwaS5UcmFuc3Bv",
            "cnQuR3JwY2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::EtAlii.Ubigia.Api.Transport.Grpc.ModelReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EtAlii.Ubigia.Api.Transport.Grpc.RootRequest), global::EtAlii.Ubigia.Api.Transport.Grpc.RootRequest.Parser, new[]{ "Id" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::EtAlii.Ubigia.Api.Transport.Grpc.RootResponse), global::EtAlii.Ubigia.Api.Transport.Grpc.RootResponse.Parser, new[]{ "Root" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class RootRequest : pb::IMessage<RootRequest> {
    private static readonly pb::MessageParser<RootRequest> _parser = new pb::MessageParser<RootRequest>(() => new RootRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RootRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EtAlii.Ubigia.Api.Transport.Grpc.RootReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RootRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RootRequest(RootRequest other) : this() {
      Id = other.id_ != null ? other.Id.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RootRequest Clone() {
      return new RootRequest(this);
    }

    /// <summary>Field number for the "Id" field.</summary>
    public const int IdFieldNumber = 1;
    private global::EtAlii.Ubigia.Api.Transport.Grpc.Guid id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::EtAlii.Ubigia.Api.Transport.Grpc.Guid Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RootRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RootRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Id, other.Id)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (id_ != null) hash ^= Id.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (id_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Id);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (id_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Id);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RootRequest other) {
      if (other == null) {
        return;
      }
      if (other.id_ != null) {
        if (id_ == null) {
          id_ = new global::EtAlii.Ubigia.Api.Transport.Grpc.Guid();
        }
        Id.MergeFrom(other.Id);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            if (id_ == null) {
              id_ = new global::EtAlii.Ubigia.Api.Transport.Grpc.Guid();
            }
            input.ReadMessage(id_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class RootResponse : pb::IMessage<RootResponse> {
    private static readonly pb::MessageParser<RootResponse> _parser = new pb::MessageParser<RootResponse>(() => new RootResponse());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RootResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EtAlii.Ubigia.Api.Transport.Grpc.RootReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RootResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RootResponse(RootResponse other) : this() {
      Root = other.root_ != null ? other.Root.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RootResponse Clone() {
      return new RootResponse(this);
    }

    /// <summary>Field number for the "Root" field.</summary>
    public const int RootFieldNumber = 1;
    private global::EtAlii.Ubigia.Api.Transport.Grpc.Root root_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::EtAlii.Ubigia.Api.Transport.Grpc.Root Root {
      get { return root_; }
      set {
        root_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RootResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RootResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Root, other.Root)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (root_ != null) hash ^= Root.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (root_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Root);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (root_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Root);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RootResponse other) {
      if (other == null) {
        return;
      }
      if (other.root_ != null) {
        if (root_ == null) {
          root_ = new global::EtAlii.Ubigia.Api.Transport.Grpc.Root();
        }
        Root.MergeFrom(other.Root);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            if (root_ == null) {
              root_ = new global::EtAlii.Ubigia.Api.Transport.Grpc.Root();
            }
            input.ReadMessage(root_);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
