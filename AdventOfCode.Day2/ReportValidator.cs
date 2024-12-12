namespace AdventOfCode.Day2;

public class ReportValidator
{
    public ReportValidator(bool firstLevelErrorSafe)
    {
        FirstLevelErrorSafe = firstLevelErrorSafe;
    }

    private bool FirstLevelErrorSafe { get; set; }
    
}