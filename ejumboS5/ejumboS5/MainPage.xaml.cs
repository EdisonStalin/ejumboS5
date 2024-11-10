using ejumboS5.Modelos;
namespace ejumboS5;

public partial class MainPage : ContentPage
{
    // int count = 0;

    public MainPage()
	{
		InitializeComponent();
	}

	private void btnAgregar_Clicked(object sender, EventArgs e)
	{
		statusMessage.Text = "";

        App.personRepo.AddNewPerson(txtNombre.Text);
        statusMessage.Text = App.personRepo.StatusMessage;

    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        List<Persona> people = App.personRepo.GetAllPeople();
        ListaPersona.ItemsSource = people;

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        try
        {
            // Verifica que los campos de texto de ID y nombre estén completos
            if (int.TryParse(txtId.Text, out int id))
            {
                App.personRepo.UpdatePerson(id, txtNombre.Text);
                statusMessage.Text = App.personRepo.StatusMessage;
            }
            else
            {
                statusMessage.Text = "Por favor, ingrese un ID válido.";
            }
        }
        catch (Exception ex)
        {
            statusMessage.Text = $"Error al actualizar: {ex.Message}";
        }

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        try
        {
            // Verifica que el campo de texto de ID esté completo
            if (int.TryParse(txtId.Text, out int id))
            {
                App.personRepo.DeletePerson(id);
                statusMessage.Text = App.personRepo.StatusMessage;
            }
            else
            {
                statusMessage.Text = "Por favor, ingrese un ID válido.";
            }
        }
        catch (Exception ex)
        {
            statusMessage.Text = $"Error al eliminar: {ex.Message}";
        }
    }



}


