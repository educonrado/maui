using System.Collections.ObjectModel;
using System.Diagnostics;
using econradoT3.Model;

namespace econradoT3.Views;

public partial class Contactos : ContentPage
{
    private static ObservableCollection<Contacto> contactos = new ObservableCollection<Contacto>();
    private TableView tableView;

    public Contactos()
    {
        InitializeComponent();
    }
    public Contactos(Contacto contacto)
    {
        InitializeComponent();
        contactos.Add(contacto);
        tableView = this.FindByName<TableView>("contactosTableView");
        PoblarTableView();
    }

    private void PoblarTableView()
    {
        var tablaSeccion = new TableSection("Listado");
        foreach (var contacto in contactos)
        {
            tablaSeccion.Add(new TextCell
            {
                Text = contacto.Nombre.ToUpper(),
                Detail = contacto.ToString()
            });
        }
        tableView.Root = new TableRoot { tablaSeccion };
    }
    

    private void btnNuevo_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Views.Registro());
    }

    private async void Btn_Exportar_Contactos_Clicked(object sender, EventArgs e)
    {
        try
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "contactos.txt");
            var lineas = contactos.Select(c => $"{c.Identificacion},{c.Nombre},{c.Apellido},{c.Fecha:yyyy-MM-dd},{c.Salario:F2},{c.Aportes}");
            await File.WriteAllLinesAsync(filePath, lineas);
            await DisplayAlert("Archivo", $"Contactos exportados a:\n {filePath}", "Aceptar");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo exportar: {ex.Message}", "Aceptar");
        }
    }
}