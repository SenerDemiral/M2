// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: protos/lookup.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Rest {

  /// <summary>Holder for reflection information generated from protos/lookup.proto</summary>
  public static partial class LookupReflection {

    #region Descriptor
    /// <summary>File descriptor for protos/lookup.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static LookupReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNwcm90b3MvbG9va3VwLnByb3RvEgRyZXN0IhwKC0xvb2t1cFByb3h5Eg0K",
            "BXF1ZXJ5GAEgASgJIlIKDUJiTG9va3VwUHJveHkSDgoGUm93S2V5GAEgASgE",
            "EgsKA1R5cBgCIAEoCRIKCgJLZBgDIAEoCRIKCgJBZBgEIAEoCRIMCgRJbmZv",
            "GAUgASgJIkYKDktmdExvb2t1cFByb3h5Eg4KBlJvd0tleRgBIAEoBBIKCgJL",
            "ZBgCIAEoCRIKCgJBZBgDIAEoCRIMCgRJbmZvGAQgASgJIkYKDk5udExvb2t1",
            "cFByb3h5Eg4KBlJvd0tleRgBIAEoBBIKCgJLZBgCIAEoCRIKCgJBZBgDIAEo",
            "CRIMCgRJbmZvGAQgASgJIkYKDkFocExvb2t1cFByb3h5Eg4KBlJvd0tleRgB",
            "IAEoBBIKCgJLZBgCIAEoCRIKCgJBZBgDIAEoCRIMCgRJbmZvGAQgASgJMuEB",
            "Cg1Mb29rdXBTZXJ2aWNlEjEKA0JiTBIRLnJlc3QuTG9va3VwUHJveHkaEy5y",
            "ZXN0LkJiTG9va3VwUHJveHkiADABEjMKBEtmdEwSES5yZXN0Lkxvb2t1cFBy",
            "b3h5GhQucmVzdC5LZnRMb29rdXBQcm94eSIAMAESMwoETm50TBIRLnJlc3Qu",
            "TG9va3VwUHJveHkaFC5yZXN0Lk5udExvb2t1cFByb3h5IgAwARIzCgRBaHBM",
            "EhEucmVzdC5Mb29rdXBQcm94eRoULnJlc3QuQWhwTG9va3VwUHJveHkiADAB",
            "YgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Rest.LookupProxy), global::Rest.LookupProxy.Parser, new[]{ "Query" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Rest.BbLookupProxy), global::Rest.BbLookupProxy.Parser, new[]{ "RowKey", "Typ", "Kd", "Ad", "Info" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Rest.KftLookupProxy), global::Rest.KftLookupProxy.Parser, new[]{ "RowKey", "Kd", "Ad", "Info" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Rest.NntLookupProxy), global::Rest.NntLookupProxy.Parser, new[]{ "RowKey", "Kd", "Ad", "Info" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Rest.AhpLookupProxy), global::Rest.AhpLookupProxy.Parser, new[]{ "RowKey", "Kd", "Ad", "Info" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class LookupProxy : pb::IMessage<LookupProxy> {
    private static readonly pb::MessageParser<LookupProxy> _parser = new pb::MessageParser<LookupProxy>(() => new LookupProxy());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LookupProxy> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Rest.LookupReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LookupProxy() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LookupProxy(LookupProxy other) : this() {
      query_ = other.query_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LookupProxy Clone() {
      return new LookupProxy(this);
    }

    /// <summary>Field number for the "query" field.</summary>
    public const int QueryFieldNumber = 1;
    private string query_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Query {
      get { return query_; }
      set {
        query_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LookupProxy);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LookupProxy other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Query != other.Query) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Query.Length != 0) hash ^= Query.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Query.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Query);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Query.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Query);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LookupProxy other) {
      if (other == null) {
        return;
      }
      if (other.Query.Length != 0) {
        Query = other.Query;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Query = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class BbLookupProxy : pb::IMessage<BbLookupProxy> {
    private static readonly pb::MessageParser<BbLookupProxy> _parser = new pb::MessageParser<BbLookupProxy>(() => new BbLookupProxy());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BbLookupProxy> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Rest.LookupReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BbLookupProxy() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BbLookupProxy(BbLookupProxy other) : this() {
      rowKey_ = other.rowKey_;
      typ_ = other.typ_;
      kd_ = other.kd_;
      ad_ = other.ad_;
      info_ = other.info_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BbLookupProxy Clone() {
      return new BbLookupProxy(this);
    }

    /// <summary>Field number for the "RowKey" field.</summary>
    public const int RowKeyFieldNumber = 1;
    private ulong rowKey_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong RowKey {
      get { return rowKey_; }
      set {
        rowKey_ = value;
      }
    }

    /// <summary>Field number for the "Typ" field.</summary>
    public const int TypFieldNumber = 2;
    private string typ_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Typ {
      get { return typ_; }
      set {
        typ_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Kd" field.</summary>
    public const int KdFieldNumber = 3;
    private string kd_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Kd {
      get { return kd_; }
      set {
        kd_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Ad" field.</summary>
    public const int AdFieldNumber = 4;
    private string ad_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Ad {
      get { return ad_; }
      set {
        ad_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Info" field.</summary>
    public const int InfoFieldNumber = 5;
    private string info_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Info {
      get { return info_; }
      set {
        info_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as BbLookupProxy);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(BbLookupProxy other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (RowKey != other.RowKey) return false;
      if (Typ != other.Typ) return false;
      if (Kd != other.Kd) return false;
      if (Ad != other.Ad) return false;
      if (Info != other.Info) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (RowKey != 0UL) hash ^= RowKey.GetHashCode();
      if (Typ.Length != 0) hash ^= Typ.GetHashCode();
      if (Kd.Length != 0) hash ^= Kd.GetHashCode();
      if (Ad.Length != 0) hash ^= Ad.GetHashCode();
      if (Info.Length != 0) hash ^= Info.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (RowKey != 0UL) {
        output.WriteRawTag(8);
        output.WriteUInt64(RowKey);
      }
      if (Typ.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Typ);
      }
      if (Kd.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Kd);
      }
      if (Ad.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Ad);
      }
      if (Info.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Info);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (RowKey != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(RowKey);
      }
      if (Typ.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Typ);
      }
      if (Kd.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Kd);
      }
      if (Ad.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Ad);
      }
      if (Info.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Info);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(BbLookupProxy other) {
      if (other == null) {
        return;
      }
      if (other.RowKey != 0UL) {
        RowKey = other.RowKey;
      }
      if (other.Typ.Length != 0) {
        Typ = other.Typ;
      }
      if (other.Kd.Length != 0) {
        Kd = other.Kd;
      }
      if (other.Ad.Length != 0) {
        Ad = other.Ad;
      }
      if (other.Info.Length != 0) {
        Info = other.Info;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            RowKey = input.ReadUInt64();
            break;
          }
          case 18: {
            Typ = input.ReadString();
            break;
          }
          case 26: {
            Kd = input.ReadString();
            break;
          }
          case 34: {
            Ad = input.ReadString();
            break;
          }
          case 42: {
            Info = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class KftLookupProxy : pb::IMessage<KftLookupProxy> {
    private static readonly pb::MessageParser<KftLookupProxy> _parser = new pb::MessageParser<KftLookupProxy>(() => new KftLookupProxy());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<KftLookupProxy> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Rest.LookupReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public KftLookupProxy() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public KftLookupProxy(KftLookupProxy other) : this() {
      rowKey_ = other.rowKey_;
      kd_ = other.kd_;
      ad_ = other.ad_;
      info_ = other.info_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public KftLookupProxy Clone() {
      return new KftLookupProxy(this);
    }

    /// <summary>Field number for the "RowKey" field.</summary>
    public const int RowKeyFieldNumber = 1;
    private ulong rowKey_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong RowKey {
      get { return rowKey_; }
      set {
        rowKey_ = value;
      }
    }

    /// <summary>Field number for the "Kd" field.</summary>
    public const int KdFieldNumber = 2;
    private string kd_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Kd {
      get { return kd_; }
      set {
        kd_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Ad" field.</summary>
    public const int AdFieldNumber = 3;
    private string ad_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Ad {
      get { return ad_; }
      set {
        ad_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Info" field.</summary>
    public const int InfoFieldNumber = 4;
    private string info_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Info {
      get { return info_; }
      set {
        info_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as KftLookupProxy);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(KftLookupProxy other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (RowKey != other.RowKey) return false;
      if (Kd != other.Kd) return false;
      if (Ad != other.Ad) return false;
      if (Info != other.Info) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (RowKey != 0UL) hash ^= RowKey.GetHashCode();
      if (Kd.Length != 0) hash ^= Kd.GetHashCode();
      if (Ad.Length != 0) hash ^= Ad.GetHashCode();
      if (Info.Length != 0) hash ^= Info.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (RowKey != 0UL) {
        output.WriteRawTag(8);
        output.WriteUInt64(RowKey);
      }
      if (Kd.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Kd);
      }
      if (Ad.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Ad);
      }
      if (Info.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Info);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (RowKey != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(RowKey);
      }
      if (Kd.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Kd);
      }
      if (Ad.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Ad);
      }
      if (Info.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Info);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(KftLookupProxy other) {
      if (other == null) {
        return;
      }
      if (other.RowKey != 0UL) {
        RowKey = other.RowKey;
      }
      if (other.Kd.Length != 0) {
        Kd = other.Kd;
      }
      if (other.Ad.Length != 0) {
        Ad = other.Ad;
      }
      if (other.Info.Length != 0) {
        Info = other.Info;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            RowKey = input.ReadUInt64();
            break;
          }
          case 18: {
            Kd = input.ReadString();
            break;
          }
          case 26: {
            Ad = input.ReadString();
            break;
          }
          case 34: {
            Info = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class NntLookupProxy : pb::IMessage<NntLookupProxy> {
    private static readonly pb::MessageParser<NntLookupProxy> _parser = new pb::MessageParser<NntLookupProxy>(() => new NntLookupProxy());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NntLookupProxy> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Rest.LookupReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NntLookupProxy() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NntLookupProxy(NntLookupProxy other) : this() {
      rowKey_ = other.rowKey_;
      kd_ = other.kd_;
      ad_ = other.ad_;
      info_ = other.info_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NntLookupProxy Clone() {
      return new NntLookupProxy(this);
    }

    /// <summary>Field number for the "RowKey" field.</summary>
    public const int RowKeyFieldNumber = 1;
    private ulong rowKey_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong RowKey {
      get { return rowKey_; }
      set {
        rowKey_ = value;
      }
    }

    /// <summary>Field number for the "Kd" field.</summary>
    public const int KdFieldNumber = 2;
    private string kd_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Kd {
      get { return kd_; }
      set {
        kd_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Ad" field.</summary>
    public const int AdFieldNumber = 3;
    private string ad_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Ad {
      get { return ad_; }
      set {
        ad_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Info" field.</summary>
    public const int InfoFieldNumber = 4;
    private string info_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Info {
      get { return info_; }
      set {
        info_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NntLookupProxy);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NntLookupProxy other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (RowKey != other.RowKey) return false;
      if (Kd != other.Kd) return false;
      if (Ad != other.Ad) return false;
      if (Info != other.Info) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (RowKey != 0UL) hash ^= RowKey.GetHashCode();
      if (Kd.Length != 0) hash ^= Kd.GetHashCode();
      if (Ad.Length != 0) hash ^= Ad.GetHashCode();
      if (Info.Length != 0) hash ^= Info.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (RowKey != 0UL) {
        output.WriteRawTag(8);
        output.WriteUInt64(RowKey);
      }
      if (Kd.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Kd);
      }
      if (Ad.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Ad);
      }
      if (Info.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Info);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (RowKey != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(RowKey);
      }
      if (Kd.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Kd);
      }
      if (Ad.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Ad);
      }
      if (Info.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Info);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NntLookupProxy other) {
      if (other == null) {
        return;
      }
      if (other.RowKey != 0UL) {
        RowKey = other.RowKey;
      }
      if (other.Kd.Length != 0) {
        Kd = other.Kd;
      }
      if (other.Ad.Length != 0) {
        Ad = other.Ad;
      }
      if (other.Info.Length != 0) {
        Info = other.Info;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            RowKey = input.ReadUInt64();
            break;
          }
          case 18: {
            Kd = input.ReadString();
            break;
          }
          case 26: {
            Ad = input.ReadString();
            break;
          }
          case 34: {
            Info = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class AhpLookupProxy : pb::IMessage<AhpLookupProxy> {
    private static readonly pb::MessageParser<AhpLookupProxy> _parser = new pb::MessageParser<AhpLookupProxy>(() => new AhpLookupProxy());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AhpLookupProxy> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Rest.LookupReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AhpLookupProxy() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AhpLookupProxy(AhpLookupProxy other) : this() {
      rowKey_ = other.rowKey_;
      kd_ = other.kd_;
      ad_ = other.ad_;
      info_ = other.info_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AhpLookupProxy Clone() {
      return new AhpLookupProxy(this);
    }

    /// <summary>Field number for the "RowKey" field.</summary>
    public const int RowKeyFieldNumber = 1;
    private ulong rowKey_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong RowKey {
      get { return rowKey_; }
      set {
        rowKey_ = value;
      }
    }

    /// <summary>Field number for the "Kd" field.</summary>
    public const int KdFieldNumber = 2;
    private string kd_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Kd {
      get { return kd_; }
      set {
        kd_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Ad" field.</summary>
    public const int AdFieldNumber = 3;
    private string ad_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Ad {
      get { return ad_; }
      set {
        ad_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Info" field.</summary>
    public const int InfoFieldNumber = 4;
    private string info_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Info {
      get { return info_; }
      set {
        info_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AhpLookupProxy);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AhpLookupProxy other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (RowKey != other.RowKey) return false;
      if (Kd != other.Kd) return false;
      if (Ad != other.Ad) return false;
      if (Info != other.Info) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (RowKey != 0UL) hash ^= RowKey.GetHashCode();
      if (Kd.Length != 0) hash ^= Kd.GetHashCode();
      if (Ad.Length != 0) hash ^= Ad.GetHashCode();
      if (Info.Length != 0) hash ^= Info.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (RowKey != 0UL) {
        output.WriteRawTag(8);
        output.WriteUInt64(RowKey);
      }
      if (Kd.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Kd);
      }
      if (Ad.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Ad);
      }
      if (Info.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Info);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (RowKey != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(RowKey);
      }
      if (Kd.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Kd);
      }
      if (Ad.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Ad);
      }
      if (Info.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Info);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AhpLookupProxy other) {
      if (other == null) {
        return;
      }
      if (other.RowKey != 0UL) {
        RowKey = other.RowKey;
      }
      if (other.Kd.Length != 0) {
        Kd = other.Kd;
      }
      if (other.Ad.Length != 0) {
        Ad = other.Ad;
      }
      if (other.Info.Length != 0) {
        Info = other.Info;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            RowKey = input.ReadUInt64();
            break;
          }
          case 18: {
            Kd = input.ReadString();
            break;
          }
          case 26: {
            Ad = input.ReadString();
            break;
          }
          case 34: {
            Info = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
