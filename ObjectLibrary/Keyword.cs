using System;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class Keyword
    {
        [DataMember(Order = 100)]
        public bool IsBlank { get; set; }
        [DataMember(Order = 101)]
        public int KeywordTypeId { get; set; }
        [DataMember(Order = 102)]
        public Type DataType { get; set; }

        [DataMember(Order = 103)]
        public string StringValue { get; set; }
        [DataMember(Order = 104)]
        public DateTime DateTimeValue { get; set; }
        [DataMember(Order = 105)]
        public int IntValue { get; set; }
        [DataMember(Order = 106)]
        public long LongValue { get; set; }
        [DataMember(Order = 107)]
        public double DoubleValue { get; set; }
        [DataMember(Order = 108)]
        public decimal DecimalValue { get; set; }
        [DataMember(Order = 109)]
        public Object Value { get; set; }

        public Keyword(string value)
        {
            DataType = typeof(String);
            StringValue = value;
            Value = value;
        }

        public Keyword(DateTime value)
        {
            DataType = typeof(DateTime);
            DateTimeValue = value;
            Value = value;
        }

        public Keyword(int value)
        {
            DataType = typeof(int);
            IntValue = value;
            Value = value;
        }

        public Keyword(long value)
        {
            DataType = typeof(long);
            LongValue = value;
            Value = value;
        }

        public Keyword(double value)
        {
            DataType = typeof(double);
            DoubleValue = value;
            Value = value;
        }

        public Keyword(decimal value)
        {
            DataType = typeof(decimal);
            DecimalValue = value;
            Value = value;
        }
    }
}
