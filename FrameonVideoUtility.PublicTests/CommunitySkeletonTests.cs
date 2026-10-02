using FrameonVideoUtility.Service;
using FrameonVideoUtility.ViewModels;
using Xunit;

namespace FrameonVideoUtility.PublicTests;

public sealed class CommunitySkeletonTests
{
    [Fact]
    public void SampleCatalogProvidesLocalMediaViewsWithoutDownloadOrProductionLogic()
    {
        var workspaces = new SampleWorkspaceCatalog().GetWorkspaces();

        Assert.Equal(
            ["Audio Converter", "Video Converter"],
            workspaces.Select(workspace => workspace.Title));
        Assert.All(workspaces, workspace => Assert.False(string.IsNullOrWhiteSpace(workspace.Title)));
        Assert.DoesNotContain(workspaces, workspace =>
            workspace.Title.Contains("Download", StringComparison.OrdinalIgnoreCase) ||
            workspace.Description.Contains("FFmpeg", StringComparison.OrdinalIgnoreCase) ||
            workspace.Description.Contains("yt-dlp", StringComparison.OrdinalIgnoreCase));
        Assert.All(workspaces, workspace =>
            Assert.Contains("presentation-only", workspace.Description, StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void ViewModelSelectsTheFirstWorkspaceAndRaisesSelectionChanges()
    {
        var first = new WorkspaceCard("First", "One", "Description", "Hint");
        var second = new WorkspaceCard("Second", "Two", "Description", "Hint");
        var viewModel = new MainWindowViewModel(new TestCatalog(first, second));
        string? changedProperty = null;
        viewModel.PropertyChanged += (_, args) => changedProperty = args.PropertyName;

        Assert.Equal(first, viewModel.SelectedWorkspace);

        viewModel.SelectedWorkspace = second;

        Assert.Equal(second, viewModel.SelectedWorkspace);
        Assert.Equal(nameof(MainWindowViewModel.SelectedWorkspace), changedProperty);
    }

    private sealed class TestCatalog(params WorkspaceCard[] workspaces) : IWorkspaceCatalog
    {
        public IReadOnlyList<WorkspaceCard> GetWorkspaces() => workspaces;
    }
}
