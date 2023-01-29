using ProyectoFinalProgramacion.Data;
using ProyectoFinalProgramacion.Models;

namespace ProyectoFinalProgramacion;

public partial class App : Application
{
	public static BetterHomeDatabase BetterHomeRepo { get; set; }

	public static User loggedUser { get; set; }
	public App(BetterHomeDatabase repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

        BetterHomeRepo = repo;

		loggedUser = null;
    }
}
