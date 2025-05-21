using econradoS6B.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace econradoS6B.Views;

public partial class Usuarios : ContentPage
{
	private const string URL_WS = "https://68267073397e48c913161ab0.mockapi.io/api/v1/usuario";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Usuario> usuarios;
	public Usuarios()
	{
		InitializeComponent();
		CargarUsuarios();
	}

	public async void CargarUsuarios()
	{
		var contenido = await cliente.GetStringAsync(URL_WS);
		List<Usuario> lista = JsonConvert.DeserializeObject<List<Usuario>>(contenido);
		usuarios = new ObservableCollection<Usuario>(lista);
		listUsuarios.ItemsSource = usuarios;
	}

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
		Debug.WriteLine("Eliminando");
		if (sender is Button button && button.BindingContext is Usuario usuarioAEliminar)
		{
			bool confirmacion = await DisplayAlert("Eliminar", $"¿Está seguro de eliminar al usuario {usuarioAEliminar.Nombre}?", "Si", "No");
            Debug.WriteLine("Eliminando"+confirmacion);
            if (!confirmacion)
			{
				return;
			}
            else
            {
				string urlEliminar = $"{URL_WS}/{usuarioAEliminar.uid}";
				var res = await cliente.DeleteAsync(urlEliminar);
				await DisplayAlert("Confirmación", "El usuario fue eliminado correctamente!", "Aceptar");
				CargarUsuarios();
            }
        }
    }
     private void btnAddUsuario_Clicked(object sender, EventArgs e)
 {
     Navigation.PushAsync(new NuevoUsuario());
 }

 private void listUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
 {
     var parametro = (Usuario)e.SelectedItem;
     Navigation.PushAsync(new NuevoUsuario(parametro));
 }
}
