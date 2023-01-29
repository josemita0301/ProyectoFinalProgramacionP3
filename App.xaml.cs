using ProyectoFinalProgramacion.Data;

namespace ProyectoFinalProgramacion;

public partial class App : Application
{
	public static BetterHomeDatabase BetterHomeRepo { get; set; }
	public App(BetterHomeDatabase repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

        BetterHomeRepo = repo;
    }
}
