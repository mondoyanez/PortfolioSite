namespace Portfolio.Models;
public class CongaLine
{
    private List<char> Line = new();

    public void Engine(char zombie)
    {
        Line.Insert(0, Char.ToUpper(zombie));
    }

    public void Caboose()
    {
        throw new NotImplementedException();
    }

    public void JumpInLine()
    {
        throw new NotImplementedException();
    }

    public void EveryOneOut()
    {
        throw new NotImplementedException();
    }

    public void YourDone()
    {
        throw new NotImplementedException();
    }

    public void Brains()
    {
        throw new NotImplementedException();
    }

    public void RainbowBrains()
    {
        throw new NotImplementedException();
    }

    public int CongaLineLength()
    {
        return Line.Count;
    }

    public override string ToString()
    {
        return Line.Any() ? string.Join(", ", Line.ToArray()) : "No zombies in line";
    }
}