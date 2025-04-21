using System.Diagnostics;

namespace calificaciones.Views;

public partial class Notas : ContentPage
{
    readonly double factor_seguimiento = 0.3;
    readonly double factor_examen = 0.2;
    public Notas()
    {
        InitializeComponent();
    }
    private void Btn_Calcular_Clicked(object sender, EventArgs e)
    {

        bool estudiante = Validar_Estudiante(PCK_ESTUDIANTE);
        if (estudiante)
        {
            bool validado = Validar_Campos(Txt_Seguimiento1, Txt_Seguimiento2, Txt_Examen1, Txt_Examen2);
            if (validado)
            {
                double seg_1 = Int32.Parse(Txt_Seguimiento1.Text);
                double seg_2 = Int32.Parse(Txt_Seguimiento2.Text);
                double examen_1 = Int32.Parse(Txt_Examen1.Text);
                double examen_2 = Int32.Parse(Txt_Examen2.Text);
                double nota_1 = Calcular_Nota_Parcial(seg_1, examen_1);
                double nota_2 = Calcular_Nota_Parcial(seg_2, examen_2);

                if (nota_1 != -1 && nota_2 != -1)
                {
                   Calcular_Observacion(nota_1, nota_2);
                    Debug.WriteLine("--->" + nota_1 + nota_2); 
                }
                

            }
        }

    }

    private void Calcular_Observacion(double nota_1, double nota_2)
    {
        double nota_final = nota_1 + nota_2;
        string resultado = Verificar_Estado(nota_final);
        Mostrar_Alerta("Calificaciones", $"Nombre: \t\t{PCK_ESTUDIANTE.SelectedItem.ToString()}\n" +
            $"Fecha: \t\t{Dp_Fecha.Date}\n" +
            $"Nota parcial 1: \t{nota_1}\n" +
            $"Nota parcial 2: \t{nota_2}\n" +
            $"Nota final: \t{nota_final}\n" +
            $"Estado: \t\t{resultado}");

    }

    private string Verificar_Estado(double nota_final)
    {
        switch (nota_final)
        {
            case > 7.0:
                return "Aprobado";
            case > 5.0:
                return "Complementario";
            case > 0.1:
                return "Reprobado";
            default:
                return "";
        }
    }

    private double Calcular_Nota_Parcial(double seg, double examen)
    {
        if (seg > 10 || examen > 10 || seg < 0 || examen < 0)
        {
            Mostrar_Alerta("Error", "Las calificaciones deben estar comprendidas entre 0-10");
            return -1;
        }
        else
        {
            return seg * factor_seguimiento + examen * factor_examen;
        }
    }

    private bool Validar_Estudiante(Picker lista)
    {
        if (lista.SelectedIndex == -1)
        {
            Mostrar_Alerta("Estudiante", "Seleccione un estudiante antes de continuar");
            return false;
        }
        return true;

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

    private void Mostrar_Alerta(string titulo, string mensaje, string boton = "Aceptar")
    {
        DisplayAlert(titulo, mensaje, boton);
    }
}