using System.Text;

namespace HeapStack.WorkerService.Services;
public class StringService
{
    public string BuildStringBadly(string value)
    {
        for (var i = 0; i < 50; i++)
        {
            value += " " + "test";
        }

        return value;
    }

    public string BuildStringBetter(string value)
    {
        var sb = new StringBuilder(value);

        for (var i = 0; i < 50; i++)
        {
            sb.Append(" ");
            sb.Append("test");
        }

        return sb.ToString();
    }

    public string BuildStringBetterWithChar(string value)
    {
        var sb = new StringBuilder(value);

        for (var i = 0; i < 50; i++)
        {
            sb.Append(' ');
            sb.Append("test");
        }

        return sb.ToString();
    }

    public (string first, string last) NameTransformSubstring(string name)
    {
        var commaPosition = name.IndexOf(',');
        var lastName = name[..commaPosition];
        var firstName = name[(commaPosition + 2)..];

        return (firstName, lastName);
    }

    public (string first, string last) NameTransformSplit(string name)
    {
        var nameArray = name.Split(',');

        return (nameArray[1].Trim(), nameArray[0].Trim());
    }

    public (string first, string last) NameTransformSpan(string name)
    {
        var nameSpan = name.AsSpan();

        var commaPosition = name.IndexOf(',');
        var lastName = nameSpan[..commaPosition].ToString();
        var firstName = nameSpan[commaPosition + 2].ToString();

        return (firstName, lastName);
    }
}
