using System;
using Windows.Data.Json;

namespace ParseJSON.Utility
{
    internal static class JsonObjectExtensions
    {
        public static bool? GetBooleanValue(this JsonObject jsonObject, string key)
        {
            IJsonValue value;
            bool? returnValue = null;

            if (jsonObject.ContainsKey(key))
            {
                if (jsonObject.TryGetValue(key, out value))
                {
                    if (value.ValueType == JsonValueType.String)
                    {
                        string v = jsonObject.GetNamedString(key).ToLower();
                        if (v == "1" || v == "true")
                        {
                            returnValue = true;
                        }
                        else if (v == "0" || v == "false")
                        {
                            returnValue = false;
                        }
                    }
                    else if (value.ValueType == JsonValueType.Number)
                    {
                        int v = Convert.ToInt32(jsonObject.GetNamedNumber(key));
                        if (v == 1)
                        {
                            returnValue = true;
                        }
                        else if (v == 0)
                        {
                            returnValue = false;
                        }
                    }
                    else if (value.ValueType == JsonValueType.Boolean)
                    {
                        returnValue = value.GetBoolean();
                    }
                }
            }

            return returnValue;
        }

        public static double? GetDoubleValue(this JsonObject jsonObject, string key)
        {
            IJsonValue value;
            double? returnValue = null;
            double parsedValue;

            if (jsonObject.ContainsKey(key))
            {
                if (jsonObject.TryGetValue(key, out value))
                {
                    if (value.ValueType == JsonValueType.String)
                    {
                        if (double.TryParse(jsonObject.GetNamedString(key), out parsedValue))
                        {
                            returnValue = parsedValue;
                        }
                    }
                    else if (value.ValueType == JsonValueType.Number)
                    {
                        returnValue = jsonObject.GetNamedNumber(key);
                    }
                }
            }

            return returnValue;
        }

        public static int? GetIntegerValue(this JsonObject jsonObject, string key)
        {
            double? value = jsonObject.GetDoubleValue(key);
            int? returnValue = null;

            if (value.HasValue)
            {
                returnValue = Convert.ToInt32(value.Value);
            }

            return returnValue;
        }

        public static string GetStringValue(this JsonObject jsonObject, string key)
        {
            IJsonValue value;
            string returnValue = string.Empty;

            if (jsonObject.ContainsKey(key))
            {
                if (jsonObject.TryGetValue(key, out value))
                {
                    if (value.ValueType == JsonValueType.String)
                    {
                        returnValue = jsonObject.GetNamedString(key);
                    }
                    else if (value.ValueType == JsonValueType.Number)
                    {
                        returnValue = jsonObject.GetNamedNumber(key).ToString();
                    }
                    else if (value.ValueType == JsonValueType.Boolean)
                    {
                        returnValue = jsonObject.GetNamedBoolean(key).ToString();
                    }
                }
            }

            return returnValue;
        }
    }
}
