namespace FrameonVideoUtility.ViewModels;

public sealed record WorkspaceCard(
    string Title,
    string Subtitle,
    string Description,
    string ImplementationHint,
    string Glyph = "◆",
    string ActionTitle = "Start sample workflow");
