using econradoS5B.Models;
using System.Diagnostics;

namespace econradoS5B.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.PersonaRepository.AddNewPersona(txtNombre.Text);
        lblStatus.Text = App.PersonaRepository.Message;
        txtNombre.Text = "";
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> personas = App.PersonaRepository.GetAllPersonas();
        listaPersona.ItemsSource = personas;
    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Prueba", sender, e);
    }
}