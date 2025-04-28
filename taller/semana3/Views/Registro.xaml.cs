using System.Diagnostics;
using econradoT3.Model;

namespace econradoT3.Views;

public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();
        LimpiarEntries(txtNombres, txtApellidos, txtIdentificacion, txtCorreo, txtSalario);
	}


    private void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        
        if (Validar_Tipo_Identicacion(pckTipoIdentificacion, txtIdentificacion))
        {
            if (Validar_Identifacion(pckTipoIdentificacion.SelectedItem.ToString(), txtIdentificacion.Text))
            {
                if (Validar_Campos(txtNombres, txtCorreo, txtSalario))
                { 
                    Mostrar_Alerta("Registro", "El contacto se registro correctamente.");
                    Navigation.PushAsync(new Views.Contactos(Crear_Contacto()));
                }
               
            }
            else
            {
                Mostrar_Alerta("Error", "La identificación ingresada es incorrecta.");
            }
            
        }
        
    }

    private bool Validar_Campos(params Entry[] parametros)
    {
        foreach (var item in parametros)
        {
            if (item == null || string.IsNullOrEmpty(item.Text))
            {
                Mostrar_Alerta("Campos incompletos", $"Ingrese información válida para {item?.Placeholder}");
                return false;
            }
        }
        return true;
    }

    private bool Validar_Identifacion(string? tipo, string identificacion)
    {
        switch (tipo)
        {
            case "CI":
                if (identificacion.Length == 10 && identificacion.All(char.IsDigit))
                {
                    return true;
                }
                break;
            case "RUC":
                if (identificacion.Length == 13 && identificacion.All(char.IsDigit))
                {
                    return true;
                }
                break;
            case "Pasaporte":
                if (!string.IsNullOrEmpty(identificacion))
                {
                    return true;
                }
                break;
            default: return false;
        }

        return false;

    }

    private bool Validar_Tipo_Identicacion(Picker lista, Entry txtIdentificacion)
    {
        if (lista.SelectedIndex == -1 || string.IsNullOrEmpty(txtIdentificacion.Text))
        {
            Mostrar_Alerta("Error", "Seleccione un tipo de documento e ingrese la identificación");
            return false;
        }
        return true;

    }

    private Contacto Crear_Contacto()
    {
        return new Contacto(txtIdentificacion.Text, txtNombres.Text, txtApellidos.Text, DateTime.Now, double.Parse(txtSalario.Text), Calcular_Aporte_Iess(double.Parse(txtSalario.Text)));
    }

    private void LimpiarEntries(params Entry[] entries)
    {
        foreach (var item in entries)
        {
            item.Text = "";
        }

        pckTipoIdentificacion.SelectedIndex = -1;
        dpckFecha.Date = DateTime.Now;
    }

    private string Calcular_Aporte_Iess(double salario)
    {
        return string.Format("${0:F2}", salario * 0.0945);
    }

    private void Mostrar_Alerta(string titulo, string mensaje, string boton = "Aceptar")
    {
        DisplayAlert(titulo, mensaje, boton);
    }
}