using econradoT3.Model;

namespace econradoT3.Views;

public partial class Contactos : ContentPage
{

	private Contacto contacto;
	public Contactos(Contacto contacto)
	{
		InitializeComponent();
		this.contacto = contacto;
	}

    private void btnNuevo_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Views.Registro());
    }
}