//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: client_runtime.proto
// Note: requires additional types generated from: reef_service_protos.proto

using Org.Apache.Reef.Common.ProtoBuf.ReefServiceProto;

namespace Org.Apache.Reef.Common.ProtoBuf.ClienRuntimeProto{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"JobSubmissionProto")]
  public partial class JobSubmissionProto : global::ProtoBuf.IExtensible
  {
    public JobSubmissionProto() {}
    
    private string _identifier;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"identifier", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string identifier
    {
      get { return _identifier; }
      set { _identifier = value; }
    }
    private string _remote_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"remote_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string remote_id
    {
      get { return _remote_id; }
      set { _remote_id = value; }
    }
    private string _configuration;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"configuration", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string configuration
    {
      get { return _configuration; }
      set { _configuration = value; }
    }
    private string _user_name;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"user_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string user_name
    {
      get { return _user_name; }
      set { _user_name = value; }
    }
    private SIZE _driver_size = SIZE.SMALL;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"driver_size", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(SIZE.SMALL)]
    public SIZE driver_size
    {
      get { return _driver_size; }
      set { _driver_size = value; }
    }
    private int _driver_memory = default(int);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"driver_memory", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int driver_memory
    {
      get { return _driver_memory; }
      set { _driver_memory = value; }
    }
    private int _priority = default(int);
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"priority", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int priority
    {
      get { return _priority; }
      set { _priority = value; }
    }
    private string _queue = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"queue", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string queue
    {
      get { return _queue; }
      set { _queue = value; }
    }
    private readonly global::System.Collections.Generic.List<FileResourceProto> _global_file = new global::System.Collections.Generic.List<FileResourceProto>();
    [global::ProtoBuf.ProtoMember(11, Name=@"global_file", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<FileResourceProto> global_file
    {
      get { return _global_file; }
    }
  
    private readonly global::System.Collections.Generic.List<FileResourceProto> _local_File = new global::System.Collections.Generic.List<FileResourceProto>();
    [global::ProtoBuf.ProtoMember(12, Name=@"local_File", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<FileResourceProto> local_File
    {
      get { return _local_File; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"JobControlProto")]
  public partial class JobControlProto : global::ProtoBuf.IExtensible
  {
    public JobControlProto() {}
    
    private string _identifier;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"identifier", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string identifier
    {
      get { return _identifier; }
      set { _identifier = value; }
    }
    private Signal _signal = Signal.SIG_TERMINATE;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"signal", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(Signal.SIG_TERMINATE)]
    public Signal signal
    {
      get { return _signal; }
      set { _signal = value; }
    }
    private byte[] _message = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"message", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] message
    {
      get { return _message; }
      set { _message = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"Signal")]
    public enum Signal
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"SIG_TERMINATE", Value=1)]
      SIG_TERMINATE = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SIG_SUSPEND", Value=2)]
      SIG_SUSPEND = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SIG_RESUME", Value=3)]
      SIG_RESUME = 3
    }
  
}