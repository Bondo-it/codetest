using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace codetest.Utilities
{
    public static class ToStringUtil
    {
        public static string ObjToString(this object obj)
        {
            if (obj == null) return string.Empty;
            if (obj is IList &&
                obj.GetType().IsGenericType &&
                obj.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
            {
                var list = (List<object>)obj;
                var sb = new StringBuilder();
                list.ForEach(x => sb.Append($"\t\t{x.ObjToString()}\n"));
                return sb.ToString();
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(obj.GetType());
            stringBuilder.Append("\n");
            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                stringBuilder.Append($"\t{propertyInfo.Name}: {propertyInfo.GetValue(obj, null)}\n");
                switch (propertyInfo.Name)
                {
                    case "Candidate":
                        stringBuilder.Append($"\t\t{propertyInfo.GetValue(obj, null)?.ObjToString()}\n");
                        break;
                    case "Company":
                        stringBuilder.Append($"\t\t{propertyInfo.GetValue(obj, null)?.ObjToString()}\n");
                        break;
                    case "Skills":
                        stringBuilder.Append($"\t\t{((object)propertyInfo.GetValue(obj, null))?.ObjToString()}\n");
                        break;
                    case "Industries":
                        stringBuilder.Append($"\t\t{propertyInfo.GetValue(obj, null)?.ObjToString()}\n");
                        break;
                    default:
                        break;
                }
            }

            return stringBuilder.ToString();
        }

    }
}