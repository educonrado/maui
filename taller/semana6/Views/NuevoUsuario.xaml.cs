using econradoS6B.Model;
using System.Diagnostics;
using System.Net;

namespace econradoS6B.Views;

public partial class NuevoUsuario : ContentPage
{
    private const string URL_WS = "https://68267073397e48c913161ab0.mockapi.io/api/v1/usuario";
    private Usuario usuario;

    public NuevoUsuario()
	{
		InitializeComponent();
	}

    public NuevoUsuario(Usuario usuario)
    {
        this.usuario = usuario;
		
		InitializeComponent();
        txtNombre.Text = usuario.Nombre;
        txtApellido.Text = usuario.Apellido;
        txtEdad.Text = usuario.Edad.ToString();
        Debug.WriteLine(usuario.uid);
    }

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
			parametros.Add("apellido", txtApellido.Text);
			parametros.Add("edad", txtEdad.Text);
			if (string.IsNullOrEmpty(this.usuario?.uid.ToString()))
			{
				cliente.UploadValues(URL_WS, "POST", parametros);
				Navigation.PushAsync(new Usuarios());
			} else
			{
				cliente.UploadValues($"{URL_WS}/{this.usuario.uid}", "PATCH", parametros);
                Navigation.PushAsync(new Usuarios());
            }
			
		}
		catch (Exception ex)
		{
			DisplayAlert("Error", "No se pudo guardar/actualizar el usuario. ", "Aceptar");
		}
    }
}