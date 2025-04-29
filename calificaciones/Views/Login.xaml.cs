namespace calificaciones.Views;

public partial class Login : ContentPage
    
{
    private Dictionary<string, string> USUARIOS = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    public Login()
	{
		InitializeComponent();
        Inicializar_Cuentas();
        LimpiarCampos();
	}

    private void Inicializar_Cuentas()
    {
        USUARIOS.Add("Carlos", "carlos123");
        USUARIOS.Add("Ana", "ana123");
        USUARIOS.Add("Jose", "jose123");
    }

    private void BtnIniciar_Clicked(object sender, EventArgs e)
    {
		bool campos = Validar_Campos(TxtUsuario, TxtPassword);
        if (campos && USUARIOS.ContainsKey(TxtUsuario.Text) && USUARIOS[TxtUsuario.Text] == TxtPassword.Text)
        {
            Navigation.PushAsync(new Views.Notas(TxtUsuario.Text));
        }
        else
        {
            DisplayAlert("Error", "Clave incorrecta.", "Aceptar");
            LimpiarCampos();
        }
    }

    private void LimpiarCampos()
    {
        TxtUsuario.Text = "";
        TxtPassword.Text = "";
        TxtUsuario.Focus();
    }

    private bool Validar_Campos(params Entry[] parametros)
    {
        foreach (var item in parametros)
        {
            if (item == null || string.IsNullOrEmpty(item.Text))
            {
                DisplayAlert("Error", "Ingrese usuario y password", "Aceptar");
                return false;
            }

            
        }
        return true;
    }
}