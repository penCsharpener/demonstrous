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
}
