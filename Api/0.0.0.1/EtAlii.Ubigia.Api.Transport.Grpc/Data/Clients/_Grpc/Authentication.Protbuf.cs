// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: Authentication.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol {

  /// <summary>Holder for reflection information generated from Authentication.proto</summary>
  public static partial class AuthenticationReflection {

    #region Descriptor
    /// <summary>File descriptor for Authentication.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AuthenticationReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChRBdXRoZW50aWNhdGlvbi5wcm90bxItRXRBbGlpLlViaWdpYS5BcGkuVHJh",
            "bnNwb3J0LkdycGMuV2lyZVByb3RvY29sGgxfTW9kZWwucHJvdG8iVgoVQXV0",
            "aGVudGljYXRpb25SZXF1ZXN0EhMKC0FjY291bnROYW1lGAEgASgJEhAKCFBh",
            "c3N3b3JkGAIgASgJEhYKDmhvc3RJZGVudGlmaWVyGAMgASgJIn4KFkF1dGhl",
            "bnRpY2F0aW9uUmVzcG9uc2USGwoTQXV0aGVudGljYXRpb25Ub2tlbhgBIAEo",
            "CRJHCgdBY2NvdW50GAIgASgLMjYuRXRBbGlpLlViaWdpYS5BcGkuVHJhbnNw",
            "b3J0LkdycGMuV2lyZVByb3RvY29sLkFjY291bnQiOQoaQXV0aGVudGljYXRp",
            "b25Ub2tlblJlcXVlc3QSGwoTQXV0aGVudGljYXRpb25Ub2tlbhgBIAEoCSJm",
            "ChtBdXRoZW50aWNhdGlvblRva2VuUmVzcG9uc2USRwoHQWNjb3VudBgBIAEo",
            "CzI2LkV0QWxpaS5VYmlnaWEuQXBpLlRyYW5zcG9ydC5HcnBjLldpcmVQcm90",
            "b2NvbC5BY2NvdW50IhUKE0xvY2FsU3RvcmFnZVJlcXVlc3QiKwoUTG9jYWxT",
            "dG9yYWdlUmVzcG9uc2USEwoLU3RvcmFnZU5hbWUYASABKAkyugUKGUF1dGhl",
            "bnRpY2F0aW9uR3JwY1NlcnZpY2USnQEKDEF1dGhlbnRpY2F0ZRJELkV0QWxp",
            "aS5VYmlnaWEuQXBpLlRyYW5zcG9ydC5HcnBjLldpcmVQcm90b2NvbC5BdXRo",
            "ZW50aWNhdGlvblJlcXVlc3QaRS5FdEFsaWkuVWJpZ2lhLkFwaS5UcmFuc3Bv",
            "cnQuR3JwYy5XaXJlUHJvdG9jb2wuQXV0aGVudGljYXRpb25SZXNwb25zZSIA",
            "Ep8BCg5BdXRoZW50aWNhdGVBcxJELkV0QWxpaS5VYmlnaWEuQXBpLlRyYW5z",
            "cG9ydC5HcnBjLldpcmVQcm90b2NvbC5BdXRoZW50aWNhdGlvblJlcXVlc3Qa",
            "RS5FdEFsaWkuVWJpZ2lhLkFwaS5UcmFuc3BvcnQuR3JwYy5XaXJlUHJvdG9j",
            "b2wuQXV0aGVudGljYXRpb25SZXNwb25zZSIAErsBCiBHZXRBY2NvdW50Rm9y",
            "QXV0aGVudGljYXRpb25Ub2tlbhJJLkV0QWxpaS5VYmlnaWEuQXBpLlRyYW5z",
            "cG9ydC5HcnBjLldpcmVQcm90b2NvbC5BdXRoZW50aWNhdGlvblRva2VuUmVx",
            "dWVzdBpKLkV0QWxpaS5VYmlnaWEuQXBpLlRyYW5zcG9ydC5HcnBjLldpcmVQ",
            "cm90b2NvbC5BdXRoZW50aWNhdGlvblRva2VuUmVzcG9uc2UiABKcAQoPR2V0",
            "TG9jYWxTdG9yYWdlEkIuRXRBbGlpLlViaWdpYS5BcGkuVHJhbnNwb3J0Lkdy",
            "cGMuV2lyZVByb3RvY29sLkxvY2FsU3RvcmFnZVJlcXVlc3QaQy5FdEFsaWku",
            "VWJpZ2lhLkFwaS5UcmFuc3BvcnQuR3JwYy5XaXJlUHJvdG9jb2wuTG9jYWxT",
            "dG9yYWdlUmVzcG9uc2UiAEJyCi1FdEFsaWkuVWJpZ2lhLkFwaS5UcmFuc3Bv",
            "cnQuR3JwYy5XaXJlUHJvdG9jb2xCBlViaWdpYVABogIGVWJpZ2lhqgItRXRB",
            "bGlpLlViaWdpYS5BcGkuVHJhbnNwb3J0LkdycGMuV2lyZVByb3RvY29sYgZw",
            "cm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.ModelReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationRequest), global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationRequest.Parser, new[]{ "AccountName", "Password", "HostIdentifier" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationResponse), global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationResponse.Parser, new[]{ "AuthenticationToken", "Account" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationTokenRequest), global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationTokenRequest.Parser, new[]{ "AuthenticationToken" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationTokenResponse), global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationTokenResponse.Parser, new[]{ "Account" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.LocalStorageRequest), global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.LocalStorageRequest.Parser, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.LocalStorageResponse), global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.LocalStorageResponse.Parser, new[]{ "StorageName" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class AuthenticationRequest : pb::IMessage<AuthenticationRequest> {
    private static readonly pb::MessageParser<AuthenticationRequest> _parser = new pb::MessageParser<AuthenticationRequest>(() => new AuthenticationRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AuthenticationRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationRequest(AuthenticationRequest other) : this() {
      accountName_ = other.accountName_;
      password_ = other.password_;
      hostIdentifier_ = other.hostIdentifier_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationRequest Clone() {
      return new AuthenticationRequest(this);
    }

    /// <summary>Field number for the "AccountName" field.</summary>
    public const int AccountNameFieldNumber = 1;
    private string accountName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string AccountName {
      get { return accountName_; }
      set {
        accountName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Password" field.</summary>
    public const int PasswordFieldNumber = 2;
    private string password_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Password {
      get { return password_; }
      set {
        password_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "hostIdentifier" field.</summary>
    public const int HostIdentifierFieldNumber = 3;
    private string hostIdentifier_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string HostIdentifier {
      get { return hostIdentifier_; }
      set {
        hostIdentifier_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AuthenticationRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AuthenticationRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AccountName != other.AccountName) return false;
      if (Password != other.Password) return false;
      if (HostIdentifier != other.HostIdentifier) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (AccountName.Length != 0) hash ^= AccountName.GetHashCode();
      if (Password.Length != 0) hash ^= Password.GetHashCode();
      if (HostIdentifier.Length != 0) hash ^= HostIdentifier.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (AccountName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(AccountName);
      }
      if (Password.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Password);
      }
      if (HostIdentifier.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(HostIdentifier);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (AccountName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AccountName);
      }
      if (Password.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Password);
      }
      if (HostIdentifier.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(HostIdentifier);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AuthenticationRequest other) {
      if (other == null) {
        return;
      }
      if (other.AccountName.Length != 0) {
        AccountName = other.AccountName;
      }
      if (other.Password.Length != 0) {
        Password = other.Password;
      }
      if (other.HostIdentifier.Length != 0) {
        HostIdentifier = other.HostIdentifier;
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
            AccountName = input.ReadString();
            break;
          }
          case 18: {
            Password = input.ReadString();
            break;
          }
          case 26: {
            HostIdentifier = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class AuthenticationResponse : pb::IMessage<AuthenticationResponse> {
    private static readonly pb::MessageParser<AuthenticationResponse> _parser = new pb::MessageParser<AuthenticationResponse>(() => new AuthenticationResponse());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AuthenticationResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationResponse(AuthenticationResponse other) : this() {
      authenticationToken_ = other.authenticationToken_;
      Account = other.account_ != null ? other.Account.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationResponse Clone() {
      return new AuthenticationResponse(this);
    }

    /// <summary>Field number for the "AuthenticationToken" field.</summary>
    public const int AuthenticationTokenFieldNumber = 1;
    private string authenticationToken_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string AuthenticationToken {
      get { return authenticationToken_; }
      set {
        authenticationToken_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Account" field.</summary>
    public const int AccountFieldNumber = 2;
    private global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.Account account_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.Account Account {
      get { return account_; }
      set {
        account_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AuthenticationResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AuthenticationResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AuthenticationToken != other.AuthenticationToken) return false;
      if (!object.Equals(Account, other.Account)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (AuthenticationToken.Length != 0) hash ^= AuthenticationToken.GetHashCode();
      if (account_ != null) hash ^= Account.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (AuthenticationToken.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(AuthenticationToken);
      }
      if (account_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Account);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (AuthenticationToken.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AuthenticationToken);
      }
      if (account_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Account);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AuthenticationResponse other) {
      if (other == null) {
        return;
      }
      if (other.AuthenticationToken.Length != 0) {
        AuthenticationToken = other.AuthenticationToken;
      }
      if (other.account_ != null) {
        if (account_ == null) {
          account_ = new global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.Account();
        }
        Account.MergeFrom(other.Account);
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
            AuthenticationToken = input.ReadString();
            break;
          }
          case 18: {
            if (account_ == null) {
              account_ = new global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.Account();
            }
            input.ReadMessage(account_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class AuthenticationTokenRequest : pb::IMessage<AuthenticationTokenRequest> {
    private static readonly pb::MessageParser<AuthenticationTokenRequest> _parser = new pb::MessageParser<AuthenticationTokenRequest>(() => new AuthenticationTokenRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AuthenticationTokenRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationTokenRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationTokenRequest(AuthenticationTokenRequest other) : this() {
      authenticationToken_ = other.authenticationToken_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationTokenRequest Clone() {
      return new AuthenticationTokenRequest(this);
    }

    /// <summary>Field number for the "AuthenticationToken" field.</summary>
    public const int AuthenticationTokenFieldNumber = 1;
    private string authenticationToken_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string AuthenticationToken {
      get { return authenticationToken_; }
      set {
        authenticationToken_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AuthenticationTokenRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AuthenticationTokenRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AuthenticationToken != other.AuthenticationToken) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (AuthenticationToken.Length != 0) hash ^= AuthenticationToken.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (AuthenticationToken.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(AuthenticationToken);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (AuthenticationToken.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AuthenticationToken);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AuthenticationTokenRequest other) {
      if (other == null) {
        return;
      }
      if (other.AuthenticationToken.Length != 0) {
        AuthenticationToken = other.AuthenticationToken;
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
            AuthenticationToken = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class AuthenticationTokenResponse : pb::IMessage<AuthenticationTokenResponse> {
    private static readonly pb::MessageParser<AuthenticationTokenResponse> _parser = new pb::MessageParser<AuthenticationTokenResponse>(() => new AuthenticationTokenResponse());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AuthenticationTokenResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationTokenResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationTokenResponse(AuthenticationTokenResponse other) : this() {
      Account = other.account_ != null ? other.Account.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AuthenticationTokenResponse Clone() {
      return new AuthenticationTokenResponse(this);
    }

    /// <summary>Field number for the "Account" field.</summary>
    public const int AccountFieldNumber = 1;
    private global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.Account account_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.Account Account {
      get { return account_; }
      set {
        account_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AuthenticationTokenResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AuthenticationTokenResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Account, other.Account)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (account_ != null) hash ^= Account.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (account_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Account);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (account_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Account);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AuthenticationTokenResponse other) {
      if (other == null) {
        return;
      }
      if (other.account_ != null) {
        if (account_ == null) {
          account_ = new global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.Account();
        }
        Account.MergeFrom(other.Account);
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
            if (account_ == null) {
              account_ = new global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.Account();
            }
            input.ReadMessage(account_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class LocalStorageRequest : pb::IMessage<LocalStorageRequest> {
    private static readonly pb::MessageParser<LocalStorageRequest> _parser = new pb::MessageParser<LocalStorageRequest>(() => new LocalStorageRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LocalStorageRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LocalStorageRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LocalStorageRequest(LocalStorageRequest other) : this() {
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LocalStorageRequest Clone() {
      return new LocalStorageRequest(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LocalStorageRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LocalStorageRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LocalStorageRequest other) {
      if (other == null) {
        return;
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
        }
      }
    }

  }

  public sealed partial class LocalStorageResponse : pb::IMessage<LocalStorageResponse> {
    private static readonly pb::MessageParser<LocalStorageResponse> _parser = new pb::MessageParser<LocalStorageResponse>(() => new LocalStorageResponse());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LocalStorageResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EtAlii.Ubigia.Api.Transport.Grpc.WireProtocol.AuthenticationReflection.Descriptor.MessageTypes[5]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LocalStorageResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LocalStorageResponse(LocalStorageResponse other) : this() {
      storageName_ = other.storageName_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LocalStorageResponse Clone() {
      return new LocalStorageResponse(this);
    }

    /// <summary>Field number for the "StorageName" field.</summary>
    public const int StorageNameFieldNumber = 1;
    private string storageName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string StorageName {
      get { return storageName_; }
      set {
        storageName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LocalStorageResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LocalStorageResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (StorageName != other.StorageName) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (StorageName.Length != 0) hash ^= StorageName.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (StorageName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(StorageName);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (StorageName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(StorageName);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LocalStorageResponse other) {
      if (other == null) {
        return;
      }
      if (other.StorageName.Length != 0) {
        StorageName = other.StorageName;
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
            StorageName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
