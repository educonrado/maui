using econradoT3.Model;

namespace econradoT3.Views;

public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();
	}

    private void btnRegistrar_Clicked(object sender, EventArgs e)
    {
		Contacto contacto = CrearContacto();


		Navigation.PushAsync(new Views.Contactos(contacto));
    }

    private Contacto CrearContacto()
    {
        bool contactoValido = ValidarDatos();
        if (contactoValido)
        {
            return new Contacto(txtIdentificacion.Text, txtNombres.Text, txtApellidos.Text, DateTime.Now, 100000);
        }
    }
}