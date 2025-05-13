using econradoS5B.Models;
using System.Diagnostics;

namespace econradoS5B.Views;

public partial class vPrincipal : ContentPage
{
    private Persona? persona;
	public vPrincipal()
	{
		InitializeComponent();
        ListarPersonas();
    }

    private void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        if (persona is null)
        {
            App.PersonaRepository.AddNewPersona(txtNombre.Text);
            lblStatus.Text = App.PersonaRepository.Message;
        } else
        {
            persona.Name = txtNombre.Text;
            App.PersonaRepository.EditarPersona(persona);
            lblStatus.Text = App.PersonaRepository.Message;
        }

        persona = null;
        ListarPersonas();
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        txtNombre.Text = "";
        ListarPersonas();
    }

    private void ListarPersonas()
    {
        lblStatus.Text = "";
        txtNombre.Text = "";
        List<Persona> personas = App.PersonaRepository.GetAllPersonas();
        listaPersona.ItemsSource = personas;
        txtNombre.Focus();
    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Persona personaEditar)
        {
            txtNombre.Text = personaEditar.Name;
            persona = personaEditar;
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Persona personaParaEliminar)
        {
            bool confirmacion = await DisplayAlert("Confirmar", $"¿Está seguro de eliminar a {personaParaEliminar.Name} (ID: {personaParaEliminar.Id})?", "Si", "No");

            if (confirmacion)
            {
                App.PersonaRepository.EliminarPersonaById(personaParaEliminar.Id);
                lblStatus.Text = App.PersonaRepository.Message;
                ListarPersonas();
            }
        }
    }
}