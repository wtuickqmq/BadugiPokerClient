//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: SubscribeRespProto.proto
namespace com.game.msg
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SubscribeResp")]
  public partial class SubscribeResp : global::ProtoBuf.IExtensible
  {
    public SubscribeResp() {}
    
    private int _subReqID;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"subReqID", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int subReqID
    {
      get { return _subReqID; }
      set { _subReqID = value; }
    }
    private string _respCode;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"respCode", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string respCode
    {
      get { return _respCode; }
      set { _respCode = value; }
    }
    private string _desc;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"desc", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string desc
    {
      get { return _desc; }
      set { _desc = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}