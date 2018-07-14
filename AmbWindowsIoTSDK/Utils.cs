using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AmbWindowsIoTSDK.Model;

namespace AmbWindowsIoTSDK
{
    public class Utils
    {
        public static string BuildQueryString(IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var keyValuePairs = parameters as KeyValuePair<string, object>[] ?? parameters.ToArray();
            if (!keyValuePairs.Any())
                return string.Empty;

            var builder = new StringBuilder("?");

            var sep = string.Empty;
            foreach (var pair in keyValuePairs.Where(kvp => kvp.Value != null))
            {
                builder.AppendFormat("{0}{1}={2}", sep, WebUtility.UrlEncode(pair.Key),
                    WebUtility.UrlEncode(pair.Value.ToString()));
                sep = "&";
            }

            return builder.ToString();
        }

    }

    public static class StringExtension
    {
        public static string ToCamelCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return Char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }
    }
}
