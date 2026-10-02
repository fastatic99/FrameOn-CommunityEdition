using FrameonVideoUtility.ViewModels;

namespace FrameonVideoUtility.Service;

/// <summary>
/// Example application boundary. Replace this interface and its sample
/// implementation with contracts for the features in your own application.
/// </summary>
public interface IWorkspaceCatalog
{
    IReadOnlyList<WorkspaceCard> GetWorkspaces();
}
