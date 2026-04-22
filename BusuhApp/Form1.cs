namespace BusuhApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnViajes_Click(object sender, EventArgs e)
    {
        using FrmMantenimientoViajes frm = new();
        frm.ShowDialog(this);
    }

    private void btnSocket_Click(object sender, EventArgs e)
    {
        using FrmSocketServidor frm = new();
        frm.ShowDialog(this);
    }
}
