using MuseumFinder.ViewModels;

namespace MuseumFinder.Views;

public partial class AddUpdateMuseumDetail : ContentPage
{
	public AddUpdateMuseumDetail(AddUpdateMuseumDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}