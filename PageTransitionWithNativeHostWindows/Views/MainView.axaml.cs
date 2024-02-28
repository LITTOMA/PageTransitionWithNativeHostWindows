using Avalonia.Controls;

namespace PageTransitionWithNativeHostWindows.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        view.Content = new MyWinFormsControl();
    }
}
