// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: protos/rest.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Rest {

  /// <summary>Holder for reflection information generated from protos/rest.proto</summary>
  public static partial class RestReflection {

    #region Descriptor
    /// <summary>File descriptor for protos/rest.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RestReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFwcm90b3MvcmVzdC5wcm90bxIEcmVzdCIZCghRcnlQcm94eRINCgVxdWVy",
            "eRgBIAEoCSKQAQoJVGJsYVByb3h5EhEKCXJvd19zdGF0ZRgBIAEoCRIPCgdy",
            "b3dfZXJyGAIgASgJEg4KBnJvd19waxgDIAEoBBIOCgZmbGRTdHIYBCABKAkS",
            "DgoGZmxkSW50GAUgASgFEg4KBmZsZERibBgGIAEoARIOCgZmbGREY20YByAB",
            "KAESDwoHZmxkRGF0ZRgIIAEoAyJzCghBSFBwcm94eRIRCglyb3dfc3RhdGUY",
            "ASABKAkSDwoHcm93X2VychgCIAEoCRIOCgZyb3dfcGsYAyABKAQSDAoET2Jq",
            "UBgEIAEoBBIKCgJObxgFIAEoCRIKCgJBZBgGIAEoCRINCgVIc3BObxgHIAEo",
            "CTLIAQoFQ1JVRHMSLwoIVGJsYUZpbGwSDi5yZXN0LlFyeVByb3h5Gg8ucmVz",
            "dC5UYmxhUHJveHkiADABEjAKClRibGFVcGRhdGUSDy5yZXN0LlRibGFQcm94",
            "eRoPLnJlc3QuVGJsYVByb3h5IgASLQoHQUhQZmlsbBIOLnJlc3QuUXJ5UHJv",
            "eHkaDi5yZXN0LkFIUHByb3h5IgAwARItCglBSFB1cGRhdGUSDi5yZXN0LkFI",
            "UHByb3h5Gg4ucmVzdC5BSFBwcm94eSIAYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Rest.QryProxy), global::Rest.QryProxy.Parser, new[]{ "Query" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Rest.TblaProxy), global::Rest.TblaProxy.Parser, new[]{ "RowState", "RowErr", "RowPk", "FldStr", "FldInt", "FldDbl", "FldDcm", "FldDate" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Rest.AHPproxy), global::Rest.AHPproxy.Parser, new[]{ "RowState", "RowErr", "RowPk", "ObjP", "No", "Ad", "HspNo" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class QryProxy : pb::IMessage<QryProxy> {
    private static readonly pb::MessageParser<QryProxy> _parser = new pb::MessageParser<QryProxy>(() => new QryProxy());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<QryProxy> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Rest.RestReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QryProxy() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QryProxy(QryProxy other) : this() {
      query_ = other.query_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public QryProxy Clone() {
      return new QryProxy(this);
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
      return Equals(other as QryProxy);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(QryProxy other) {
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
    public void MergeFrom(QryProxy other) {
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

  public sealed partial class TblaProxy : pb::IMessage<TblaProxy> {
    private static readonly pb::MessageParser<TblaProxy> _parser = new pb::MessageParser<TblaProxy>(() => new TblaProxy());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TblaProxy> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Rest.RestReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TblaProxy() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TblaProxy(TblaProxy other) : this() {
      rowState_ = other.rowState_;
      rowErr_ = other.rowErr_;
      rowPk_ = other.rowPk_;
      fldStr_ = other.fldStr_;
      fldInt_ = other.fldInt_;
      fldDbl_ = other.fldDbl_;
      fldDcm_ = other.fldDcm_;
      fldDate_ = other.fldDate_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TblaProxy Clone() {
      return new TblaProxy(this);
    }

    /// <summary>Field number for the "row_state" field.</summary>
    public const int RowStateFieldNumber = 1;
    private string rowState_ = "";
    /// <summary>
    /// Inserted/Modified/Deleted/Unchanged
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string RowState {
      get { return rowState_; }
      set {
        rowState_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "row_err" field.</summary>
    public const int RowErrFieldNumber = 2;
    private string rowErr_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string RowErr {
      get { return rowErr_; }
      set {
        rowErr_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "row_pk" field.</summary>
    public const int RowPkFieldNumber = 3;
    private ulong rowPk_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong RowPk {
      get { return rowPk_; }
      set {
        rowPk_ = value;
      }
    }

    /// <summary>Field number for the "fldStr" field.</summary>
    public const int FldStrFieldNumber = 4;
    private string fldStr_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FldStr {
      get { return fldStr_; }
      set {
        fldStr_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "fldInt" field.</summary>
    public const int FldIntFieldNumber = 5;
    private int fldInt_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int FldInt {
      get { return fldInt_; }
      set {
        fldInt_ = value;
      }
    }

    /// <summary>Field number for the "fldDbl" field.</summary>
    public const int FldDblFieldNumber = 6;
    private double fldDbl_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double FldDbl {
      get { return fldDbl_; }
      set {
        fldDbl_ = value;
      }
    }

    /// <summary>Field number for the "fldDcm" field.</summary>
    public const int FldDcmFieldNumber = 7;
    private double fldDcm_;
    /// <summary>
    /// String olabilir
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double FldDcm {
      get { return fldDcm_; }
      set {
        fldDcm_ = value;
      }
    }

    /// <summary>Field number for the "fldDate" field.</summary>
    public const int FldDateFieldNumber = 8;
    private long fldDate_;
    /// <summary>
    /// DateTime.Ticks olarak UInt64 de tut. new DateTime(fldDate) => DateTime 
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long FldDate {
      get { return fldDate_; }
      set {
        fldDate_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TblaProxy);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TblaProxy other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (RowState != other.RowState) return false;
      if (RowErr != other.RowErr) return false;
      if (RowPk != other.RowPk) return false;
      if (FldStr != other.FldStr) return false;
      if (FldInt != other.FldInt) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FldDbl, other.FldDbl)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FldDcm, other.FldDcm)) return false;
      if (FldDate != other.FldDate) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (RowState.Length != 0) hash ^= RowState.GetHashCode();
      if (RowErr.Length != 0) hash ^= RowErr.GetHashCode();
      if (RowPk != 0UL) hash ^= RowPk.GetHashCode();
      if (FldStr.Length != 0) hash ^= FldStr.GetHashCode();
      if (FldInt != 0) hash ^= FldInt.GetHashCode();
      if (FldDbl != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FldDbl);
      if (FldDcm != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FldDcm);
      if (FldDate != 0L) hash ^= FldDate.GetHashCode();
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
      if (RowState.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(RowState);
      }
      if (RowErr.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(RowErr);
      }
      if (RowPk != 0UL) {
        output.WriteRawTag(24);
        output.WriteUInt64(RowPk);
      }
      if (FldStr.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(FldStr);
      }
      if (FldInt != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(FldInt);
      }
      if (FldDbl != 0D) {
        output.WriteRawTag(49);
        output.WriteDouble(FldDbl);
      }
      if (FldDcm != 0D) {
        output.WriteRawTag(57);
        output.WriteDouble(FldDcm);
      }
      if (FldDate != 0L) {
        output.WriteRawTag(64);
        output.WriteInt64(FldDate);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (RowState.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(RowState);
      }
      if (RowErr.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(RowErr);
      }
      if (RowPk != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(RowPk);
      }
      if (FldStr.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FldStr);
      }
      if (FldInt != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(FldInt);
      }
      if (FldDbl != 0D) {
        size += 1 + 8;
      }
      if (FldDcm != 0D) {
        size += 1 + 8;
      }
      if (FldDate != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(FldDate);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TblaProxy other) {
      if (other == null) {
        return;
      }
      if (other.RowState.Length != 0) {
        RowState = other.RowState;
      }
      if (other.RowErr.Length != 0) {
        RowErr = other.RowErr;
      }
      if (other.RowPk != 0UL) {
        RowPk = other.RowPk;
      }
      if (other.FldStr.Length != 0) {
        FldStr = other.FldStr;
      }
      if (other.FldInt != 0) {
        FldInt = other.FldInt;
      }
      if (other.FldDbl != 0D) {
        FldDbl = other.FldDbl;
      }
      if (other.FldDcm != 0D) {
        FldDcm = other.FldDcm;
      }
      if (other.FldDate != 0L) {
        FldDate = other.FldDate;
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
            RowState = input.ReadString();
            break;
          }
          case 18: {
            RowErr = input.ReadString();
            break;
          }
          case 24: {
            RowPk = input.ReadUInt64();
            break;
          }
          case 34: {
            FldStr = input.ReadString();
            break;
          }
          case 40: {
            FldInt = input.ReadInt32();
            break;
          }
          case 49: {
            FldDbl = input.ReadDouble();
            break;
          }
          case 57: {
            FldDcm = input.ReadDouble();
            break;
          }
          case 64: {
            FldDate = input.ReadInt64();
            break;
          }
        }
      }
    }

  }

  public sealed partial class AHPproxy : pb::IMessage<AHPproxy> {
    private static readonly pb::MessageParser<AHPproxy> _parser = new pb::MessageParser<AHPproxy>(() => new AHPproxy());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<AHPproxy> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Rest.RestReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AHPproxy() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AHPproxy(AHPproxy other) : this() {
      rowState_ = other.rowState_;
      rowErr_ = other.rowErr_;
      rowPk_ = other.rowPk_;
      objP_ = other.objP_;
      no_ = other.no_;
      ad_ = other.ad_;
      hspNo_ = other.hspNo_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public AHPproxy Clone() {
      return new AHPproxy(this);
    }

    /// <summary>Field number for the "row_state" field.</summary>
    public const int RowStateFieldNumber = 1;
    private string rowState_ = "";
    /// <summary>
    /// Inserted/Modified/Deleted/Unchanged
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string RowState {
      get { return rowState_; }
      set {
        rowState_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "row_err" field.</summary>
    public const int RowErrFieldNumber = 2;
    private string rowErr_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string RowErr {
      get { return rowErr_; }
      set {
        rowErr_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "row_pk" field.</summary>
    public const int RowPkFieldNumber = 3;
    private ulong rowPk_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong RowPk {
      get { return rowPk_; }
      set {
        rowPk_ = value;
      }
    }

    /// <summary>Field number for the "ObjP" field.</summary>
    public const int ObjPFieldNumber = 4;
    private ulong objP_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong ObjP {
      get { return objP_; }
      set {
        objP_ = value;
      }
    }

    /// <summary>Field number for the "No" field.</summary>
    public const int NoFieldNumber = 5;
    private string no_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string No {
      get { return no_; }
      set {
        no_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Ad" field.</summary>
    public const int AdFieldNumber = 6;
    private string ad_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Ad {
      get { return ad_; }
      set {
        ad_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "HspNo" field.</summary>
    public const int HspNoFieldNumber = 7;
    private string hspNo_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string HspNo {
      get { return hspNo_; }
      set {
        hspNo_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as AHPproxy);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(AHPproxy other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (RowState != other.RowState) return false;
      if (RowErr != other.RowErr) return false;
      if (RowPk != other.RowPk) return false;
      if (ObjP != other.ObjP) return false;
      if (No != other.No) return false;
      if (Ad != other.Ad) return false;
      if (HspNo != other.HspNo) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (RowState.Length != 0) hash ^= RowState.GetHashCode();
      if (RowErr.Length != 0) hash ^= RowErr.GetHashCode();
      if (RowPk != 0UL) hash ^= RowPk.GetHashCode();
      if (ObjP != 0UL) hash ^= ObjP.GetHashCode();
      if (No.Length != 0) hash ^= No.GetHashCode();
      if (Ad.Length != 0) hash ^= Ad.GetHashCode();
      if (HspNo.Length != 0) hash ^= HspNo.GetHashCode();
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
      if (RowState.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(RowState);
      }
      if (RowErr.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(RowErr);
      }
      if (RowPk != 0UL) {
        output.WriteRawTag(24);
        output.WriteUInt64(RowPk);
      }
      if (ObjP != 0UL) {
        output.WriteRawTag(32);
        output.WriteUInt64(ObjP);
      }
      if (No.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(No);
      }
      if (Ad.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Ad);
      }
      if (HspNo.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(HspNo);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (RowState.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(RowState);
      }
      if (RowErr.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(RowErr);
      }
      if (RowPk != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(RowPk);
      }
      if (ObjP != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(ObjP);
      }
      if (No.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(No);
      }
      if (Ad.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Ad);
      }
      if (HspNo.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(HspNo);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(AHPproxy other) {
      if (other == null) {
        return;
      }
      if (other.RowState.Length != 0) {
        RowState = other.RowState;
      }
      if (other.RowErr.Length != 0) {
        RowErr = other.RowErr;
      }
      if (other.RowPk != 0UL) {
        RowPk = other.RowPk;
      }
      if (other.ObjP != 0UL) {
        ObjP = other.ObjP;
      }
      if (other.No.Length != 0) {
        No = other.No;
      }
      if (other.Ad.Length != 0) {
        Ad = other.Ad;
      }
      if (other.HspNo.Length != 0) {
        HspNo = other.HspNo;
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
            RowState = input.ReadString();
            break;
          }
          case 18: {
            RowErr = input.ReadString();
            break;
          }
          case 24: {
            RowPk = input.ReadUInt64();
            break;
          }
          case 32: {
            ObjP = input.ReadUInt64();
            break;
          }
          case 42: {
            No = input.ReadString();
            break;
          }
          case 50: {
            Ad = input.ReadString();
            break;
          }
          case 58: {
            HspNo = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
