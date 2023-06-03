namespace Portfolio.Utilities;
public class Converter
{
    public List<char> StringToListChar(string str)
    {
        string[] strArraySplitWS = str.Split(',');
        string[] strArrayModified = strArraySplitWS.Select(s => s.Trim()).ToArray();
        List<string> strListSplit = strArrayModified.ToList();
        IEnumerable<char> charIEnumerable = strListSplit.SelectMany(s => s);
        List<char> charList = charIEnumerable.ToList();
        return charList;
    }
}

