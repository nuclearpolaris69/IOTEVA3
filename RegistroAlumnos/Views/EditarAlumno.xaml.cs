using Firebase.Database;
using Firebase.Database.Query;
using RegistroAlumnos.Models.Modelos;
namespace RegistroAlumnos.Views;

public partial class EditarAlumno : ContentPage
{

    FirebaseClient client = new FirebaseClient("https://aplicacionesmov-e2f6b-default-rtdb.firebaseio.com/");

    

    public EditarAlumno()
	{
		InitializeComponent();
	}

    private async void guardarButton_Clicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
		try
		{
            //validaciones
            if
            (
            string.IsNullOrWhiteSpace(nombreEntry.Text) ||
            string.IsNullOrWhiteSpace(correoEntry.Text) ||
            string.IsNullOrWhiteSpace(edadEntry.Text) ||
            CursoPicker.SelectedItem == null
            )
            {
                await DisplayAlert("Error", "Ninguno de los campos puede estar vacio", "OK");
                return;
            }
            if (!correoEntry.Text.Contains("@"))
            {
                await DisplayAlert("Error", "El correo debe contener un @", "OK");
                return;
            }
            if (!int.TryParse(edadEntry.Text, out int edad))
            {
                await DisplayAlert("Error", "La edad debe ser un numero", "OK");
                if (edad <= 0)
                {
                    await DisplayAlert("Error", "La edad minima es de 1 año", "OK");
                }
                return;
            }

            //se crea el nuevo objeto que reemplazara al antiguo alumno
            Alumno alumnoActualizado = new Alumno();

            //alumnoActualizado.Id = alumnoId;
            alumnoActualizado.Nombre = nombreEntry.Text;
            alumnoActualizado.Email = correoEntry.Text;
            alumnoActualizado.Edad = edad;
            alumnoActualizado.Activo = estadoSwitch.IsToggled;
            alumnoActualizado.Curso = new Curso { Nombre = CursoPicker.SelectedItem.ToString() };

            //cambiar en la base de datos
            //PutAsync reemplaza el objeto que se esta referenciando
           // await client.Child("Alumno").Child(alumnoId).PutAsync(alumnoActualizado);
            await DisplayAlert("Exito", "El alumno ha sido actualizado correctamente", "OK");

            //retornar
            await Navigation.PopAsync();


        } catch (Exception ex)
        {
            await DisplayAlert("Error", "error", "OK");
            Console.Write(ex);
        }
		
    }
}