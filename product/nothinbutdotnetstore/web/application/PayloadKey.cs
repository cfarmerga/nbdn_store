using System;
using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.application
{
    public class PayloadKey<ValueType>
    {
        string key_name;

        public PayloadKey(string key_name)
        {
            this.key_name = key_name;
        }

        public static implicit operator string(PayloadKey<ValueType> key)
        {
            return key.ToString();
        }

        public override string ToString()
        {
            return key_name;
        }

        public ValueType map_from(NameValueCollection payload)
        {
            return (ValueType) Convert.ChangeType(payload[key_name], typeof(ValueType));
        }
    }
}