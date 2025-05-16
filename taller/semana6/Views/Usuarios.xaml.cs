using econradoS6B.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

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
}