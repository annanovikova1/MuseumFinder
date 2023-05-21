using MuseumFinder.ViewModels;
namespace MuseumFinder.Views;

public partial class MuseumListPage : ContentPage
{
    private MuseumLisPageViewModel _viewMode;
    public MuseumListPage(MuseumLisPageViewModel viewModel)
	{
		InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetMuseumListCommand.Execute(null);

    }

}