using MuseumFinder.Views;
//using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace MuseumFinder;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddUpdateMuseumDetail), typeof(AddUpdateMuseumDetail));
	}
}
