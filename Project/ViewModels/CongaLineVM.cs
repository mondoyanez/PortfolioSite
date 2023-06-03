using Portfolio.Models;

namespace Portfolio.ViewModels;
public class CongaLineVM
{
    public CongaLineVM()
    {
        CongaLine = new CongaLine();
    }

    public CongaLineVM(CongaLine congaLine)
    {
        CongaLine = congaLine;
    }

    public CongaLine CongaLine { get; set; }
}