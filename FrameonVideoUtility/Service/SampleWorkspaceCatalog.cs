using FrameonVideoUtility.ViewModels;

namespace FrameonVideoUtility.Service;

/// <summary>
/// Static demonstration data only. It deliberately performs no network,
/// filesystem, media-tool, update, telemetry, or authentication work.
/// </summary>
public sealed class SampleWorkspaceCatalog : IWorkspaceCatalog
{
    public IReadOnlyList<WorkspaceCard> GetWorkspaces() =>
    [
        new(
            "Audio Converter",
            "Local audio workspace",
            "A presentation-only audio conversion workspace modeled after the classic FrameOn layout.",
            "Add your own file picker, validation, processing, cancellation, and output-conflict handling.",
            "♪",
            "Convert Audio"),
        new(
            "Video Converter",
            "Local video workspace",
            "A presentation-only video conversion workspace with generic starter controls.",
            "Implement your own inspection and processing behind interfaces owned by your application.",
            "▶",
            "Convert Video")
    ];
}
