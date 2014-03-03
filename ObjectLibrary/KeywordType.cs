using System;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class KeywordType : BaseObject
    {
        [DataMember(Order = 100)]
        public string DataTypeString {
            get { return DataType.ToString(); }
            set { DataType = Type.GetType(value); }
        }
      
        [DataMember(Order = 101)]
        public string DefaultValue { get; set; }

        private Type DataType { get; set; }

        public KeywordType(long id, string name, Type dataType, string defaultValue)
        {
            ID = id;
            Name = name;
            DataType = dataType;
            DefaultValue = defaultValue;
        }
    }
}
