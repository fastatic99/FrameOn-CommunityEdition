using System.ComponentModel;
using System.Runtime.CompilerServices;
using FrameonVideoUtility.Service;

namespace FrameonVideoUtility.ViewModels;

public sealed class MainWindowViewModel : INotifyPropertyChanged
{
    private WorkspaceCard? _selectedWorkspace;

    public MainWindowViewModel()
        : this(new SampleWorkspaceCatalog())
    {
    }

    public MainWindowViewModel(IWorkspaceCatalog catalog)
    {
        ArgumentNullException.ThrowIfNull(catalog);

        Workspaces = catalog.GetWorkspaces();
        SelectedWorkspace = Workspaces.FirstOrDefault();
    }

    public IReadOnlyList<WorkspaceCard> Workspaces { get; }

    public string ProductName => "FrameOn";

    public string ProductSubtitle => "Community Edition";

    public WorkspaceCard? SelectedWorkspace
    {
        get => _selectedWorkspace;
        set
        {
            if (Equals(_selectedWorkspace, value))
            {
                return;
            }

            _selectedWorkspace = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
