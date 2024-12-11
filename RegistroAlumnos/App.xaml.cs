using Firebase.Database;
using RegistroAlumnos.Models.Modelos;
using System.Collections.ObjectModel;

namespace RegistroAlumnos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ListarAlumnos());
        }

        public static ObservableCollection<Curso>? Cursos { get; private set; }

        public async void GetCursos()
        {
            FirebaseClient client = new FirebaseClient("https://aplicacionesmov-e2f6b-default-rtdb.firebaseio.com/");
            var coleccionCursos = new ObservableCollection<Curso>();
            var cursos = await client.Child("Cursos").OnceAsync<Curso>();

            foreach (var curso in cursos)
            {
                coleccionCursos.Add(new Curso { Nombre = curso.Object.Nombre });
            }

        }
    }
}
