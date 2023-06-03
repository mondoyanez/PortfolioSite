namespace Portfolio.Utilities;
public class Converter
{
    public List<char> StringToListChar(string str)
    {
        return str.Split(',')
            .Select(s => s.Trim()).ToList()
            .SelectMany(s => s).ToList();
    }
}

