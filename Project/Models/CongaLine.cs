namespace Portfolio.Models;
public class CongaLine
{
    private readonly List<char> _line;
    private readonly List<char> _allZombies = new() { 'R', 'Y', 'G', 'B', 'M', 'C' };

    public CongaLine()
    {
        _line = new List<char>();
    }

    public CongaLine(List<char> line)
    {
        _line = line;
    }

    public void Engine(char zombie)
    {
        if (_allZombies.Contains(Char.ToUpper(zombie)))
            _line.Insert(0, Char.ToUpper(zombie));
    }

    public void Caboose(char zombie)
    {
        if (_allZombies.Contains(Char.ToUpper(zombie)))
            _line.Add(Char.ToUpper(zombie));
    }

    public void JumpInLine(int position, char zombie)
    {
        if (position - 1 >= _line.Count + 1 || position <= 0) return;
        if (_allZombies.Contains(Char.ToUpper(zombie)))
            _line.Insert(position - 1, Char.ToUpper(zombie));
    }

    public void EveryOneOut(char zombie)
    {
        _line.RemoveAll(z => z == Char.ToUpper(zombie));
    }

    public void YourDone(char zombie)
    {
        _line.Remove(Char.ToUpper(zombie));
    }

    public void Brains()
    {
        Random r = new();
        int randomIndex = r.Next(0, _allZombies.Count);
        char zombieChosen = _allZombies[randomIndex];

        Engine(zombieChosen);
        Caboose(zombieChosen);
    }

    public void RainbowBrains()
    {
        Random r = new();
        List<char> zombiesShuffled = _allZombies.OrderBy(_ => r.Next()).ToList();

        foreach (var zombie in zombiesShuffled)
            Caboose(zombie);
    }

    public void TimesUp()
    {
        if (!_line.Any())
            throw new Exception("Conga Line is Empty");

        _line.RemoveAt(CongaLineLength() - 1);
        _line.RemoveAt(0);
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