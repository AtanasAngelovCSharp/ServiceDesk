namespace ServiceDesk.ViewModels.Home;

public class HomeIndexViewModel
{
    public int NewCount { get; set; }
    public int InProgressCount { get; set; }
    public int WaitingForPartsCount { get; set; }
    public int CompletedCount { get; set; }
}