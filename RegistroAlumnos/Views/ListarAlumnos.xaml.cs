namespace RegistroAlumnos.Views;

public partial class ListarAlumnos : ContentPage
{
	public ListarAlumnos()
	{
		InitializeComponent();
	}

    private void filtroSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private async void NuevoAlumnoBoton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearAlumno());
    }
}