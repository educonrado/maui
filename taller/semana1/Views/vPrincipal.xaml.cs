namespace econradoT1.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void BtnGuardar_Clicked(object sender, EventArgs e)
    {
		string identificacion = this.txtIdentificacion.Text;
		string apellidoPaterno = this.txtApellidoPaterno.Text;
		string apellidoMaterno = this.txtApellidoMaterno.Text;
		string nombres = this.txtNombres.Text;
		string telefono = this.txtTelefono.Text;
		string correo = this.txtCorreo.Text;
		string correoVerificar = this.txtCorreoVerificacion.Text;
        bool camposValidos = ValidarCamposObligatorios(this.txtIdentificacion, this.txtApellidoPaterno, this.txtApellidoMaterno, this.txtNombres, this.txtTelefono, this.txtCorreo);
        if (camposValidos)
        {
            if (correo == correoVerificar )
            {   
                DisplayAlert("Registro", "El usuario fue registrado correctamente.", "Aceptar");
                GenerarArchivoTxt(identificacion, apellidoPaterno, apellidoMaterno, nombres, telefono, correo);
                InicializarCampos();
            }
            else
            {
                DisplayAlert("Error", "El correo no coincide", "Aceptar");
            }
        }
        

    }

    private void GenerarArchivoTxt(params string[] parametros)
    {
        string ruta = Path.Combine(FileSystem.CacheDirectory, "estudiante.txt");
        string contenido = $"Datos del estudiante\n" +
            $"--------------------\n";
        foreach (string str in parametros)
        {
            contenido += str+"\n";
        }
        try
        {
            File.WriteAllText(ruta, contenido);
            DisplayAlert("Archivo", $"El archivo fue generado correctamente.\n" +
                $"Disponible en: `{ruta}`", "Aceptar");
        }
        catch (Exception)
        {

            Console.WriteLine("Error");
        }
      
    }

    private void InicializarCampos()
    {
        this.txtIdentificacion.Text = null; 
        this.txtApellidoPaterno.Text = null;
        this.txtApellidoMaterno.Text = null;
        this.txtNombres.Text = null;
        this.txtTelefono.Text = null;
        this.txtCorreo.Text = null;
        this.txtCorreoVerificacion.Text = null;
        this.txtIdentificacion.Focus();
    }

    private bool ValidarCamposObligatorios(params Entry[] parametros)
    {
        foreach (var parametro in parametros) {
            if (string.IsNullOrEmpty(parametro.Text))
            {
                DisplayAlert("Error", $"El campo `{parametro.Placeholder}` es obligatorio", "Aceptar");
                return false;
            }
        }
        return true;
    }
}