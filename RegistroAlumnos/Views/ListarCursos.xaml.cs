using Firebase.Database;
using RegistroAlumnos.Models.Modelos;
using System.Collections.ObjectModel;

namespace RegistroAlumnos.Views;

public partial class ListarCursos : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://aplicacionesmov-e2f6b-default-rtdb.firebaseio.com/");
    public ObservableCollection<Curso> ListaCursos { get; set; } = new ObservableCollection<Curso>();

	public ListarCursos()
	{
		InitializeComponent();
        BindingContext = this;
        CargarLista();
	}

    private void CargarLista()
    {
        client.Child("Cursos").AsObservable<Curso>().Subscribe((curso) =>
        {
            if (curso != null)
            {
                ListaCursos.Add(curso.Object);
            }
        });
    }

    private void filtroSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void NuevoCursoBoton_Clicked(object sender, EventArgs e)
    {

    }

    
}