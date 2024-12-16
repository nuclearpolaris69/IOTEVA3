using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Graphics.Text;
using RegistroAlumnos.Models.Modelos;

namespace RegistroAlumnos.Views;

public partial class CrearAlumno : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://aplicacionesmov-e2f6b-default-rtdb.firebaseio.com/");
    public List<Curso> Cursos { get; set; }
    public CrearAlumno()
    {
        InitializeComponent();
        ListarCursos();
        BindingContext = this;
    }

    private void ListarCursos()
    {
        var cursos = client.Child("Cursos").OnceAsync<Curso>();
        Cursos= cursos.Result.Select((x) => x.Object).ToList();
    }

    private async void guardarButton_Clicked(object sender, EventArgs e)
    {
        Curso curso = CursoPicker.SelectedItem as Curso;

        var alumno = new Alumno
        {
            Nombre = nombreEntry.Text,
            Email = correoEntry.Text,
            Edad = int.Parse(edadEntry.Text),
            Curso = curso,
            Activo = true
        };

        try
        {
            await client.Child("Alumnos").PostAsync(alumno);
            await DisplayAlert("Exito", $"El alumno {alumno.Nombre} fue guardado correctamente", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

   
}
    