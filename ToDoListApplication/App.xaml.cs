using ToDoListApplication.Manager;

namespace ToDoListApplication;

public partial class App : Application
{
    public static ToDoListManager manager { get; set; }
    public App()
	{
		
		InitializeComponent();

		MainPage = new AppShell();
		manager = new ToDoListManager();
		
	}
}
