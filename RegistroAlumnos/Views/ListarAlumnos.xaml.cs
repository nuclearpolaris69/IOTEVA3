using Firebase.Database;
using RegistroAlumnos.Models.Modelos;
using System.Collections.ObjectModel;

namespace RegistroAlumnos.Views;

public partial class ListarAlumnos : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://aplicacionesmov-e2f6b-default-rtdb.firebaseio.com/");

    public ObservableCollection<Alumno> ListaAlumnos { get; set; } = new ObservableCollection<Alumno>();
    public ListarAlumnos()
	{
		InitializeComponent();
        CargarAlumnos();
        BindingContext = this;
	}

    private void CargarAlumnos()
    {
        client.Child("Alumnos").AsObservable<Alumno>().Subscribe((alumno) =>
        {
            if (alumno != null)
            {
                if (alumno.Object.Activo)
                {
                    ListaAlumnos.Add(alumno.Object);
                }
            }

        });
    }

    private void filtroSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void filtroCursosBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private async void NuevoAlumnoBoton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearAlumno());
    }

    private async void VerAlumnosBoton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListarCursos());
    }

    
}