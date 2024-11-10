using ejumboS5.Modelos;

namespace ejumboS5;

public partial class App : Application
{
    public static PersonRepository personRepo { get; set; }

    public App(PersonRepository personRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();
        personRepo = personRepository;
    }
}

