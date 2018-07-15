using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Amb.Sdk
{
    public class Utils
    {
        public static string BuildQueryString(IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var keyValuePairs = parameters as KeyValuePair<string, object>[] ?? parameters.ToArray();
            if (!keyValuePairs.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder("?");

            var sep = string.Empty;
            foreach (var pair in keyValuePairs.Where(kvp => kvp.Value != null))
            {
                sb.AppendFormat("{0}{1}={2}", sep, WebUtility.UrlEncode(pair.Key),
                    WebUtility.UrlEncode(pair.Value.ToString()));
                sep = "&";
            }

            var result = sb.ToString();
            return result.Length == 1 ? "" : sb.ToString();
        }

    }

    public static class StringExtension
    {
        public static string ToCamelCase(this string s)
        {
            if (!string.IsNullOrEmpty(s) && s.Length > 1)
            {
                return char.ToLowerInvariant(s[0]) + s.Substring(1);
            }
            return s;
        }
    }
}
