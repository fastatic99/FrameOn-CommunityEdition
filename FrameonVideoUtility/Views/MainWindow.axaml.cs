using Avalonia.Controls;
using FrameonVideoUtility.ViewModels;

namespace FrameonVideoUtility.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}
