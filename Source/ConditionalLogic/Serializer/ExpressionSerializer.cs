using System.Linq.Expressions;
using Serialize.Linq.Serializers;

namespace ConditionalLogic.Serializer;

public static class ExpSerializer
{
    private const string TypeMarker = "<#Type#>";
    private static readonly ExpressionSerializer Serializer = new(new JsonSerializer());

    public static string Serialize<T>(Expression exp)
    {
        var t = typeof(T);
        var fullName = t.FullName;

        var json = Serializer.SerializeText(exp);

        return json.Replace(fullName, TypeMarker);
    }

    public static Expression Deserialize<T>(string exp)
    {
        var t = typeof(T);

        var fixedJson = exp.Replace(TypeMarker, t.FullName);
        return Serializer.DeserializeText(fixedJson);
    }
}