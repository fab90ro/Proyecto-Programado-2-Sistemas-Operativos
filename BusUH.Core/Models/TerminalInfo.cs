namespace BusUH.Core.Models;

public sealed class TerminalInfo
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public override string ToString() => $"{Code} - {Name}";
}
