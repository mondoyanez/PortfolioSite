namespace Portfolio.Models;
public class CongaLine
{
    private readonly List<char> _line = new();
    private readonly List<char> _allZombies = new() { 'R', 'Y', 'G', 'B', 'M', 'C' };

    public void Engine(char zombie)
    {
        if (_allZombies.Contains(Char.ToUpper(zombie)))
            _line.Insert(0, Char.ToUpper(zombie));
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
        return _line.Count;
    }

    public override string ToString()
    {
        return _line.Any() ? string.Join(", ", _line.ToArray()) : "No zombies in line";
    }
}