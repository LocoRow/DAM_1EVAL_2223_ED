namespace GestionBancaria
{
    public partial class Form1 : Form
    {
        private double saldo_jpt_1dam = 1000;  // Saldo inicial de la cuenta, 1000€

        public Form1()
        {
            InitializeComponent();
            txtSaldo.Text = saldo_jpt_1dam.ToString();
            txtCantidad.Text = "0";
        }

        private bool realizarReintegro(double cantidad)
        {
            if (cantidad > 0 && saldo_jpt_1dam >= cantidad)
            {
                saldo_jpt_1dam -= cantidad;
                return true;
            }
            return false;
        }

        private void realizarIngreso(double cantidad)
        {
            if (cantidad > 0)
                saldo_jpt_1dam += cantidad;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad_jpt_1dam = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número

            if (cantidad_jpt_1dam < 0)
            {
                MessageBox.Show("Cantidad no válidá, sólo se admiten cantidades positivas.");
            }

            else
            {
                if (rbReintegro.Checked)
                {
                    if (realizarReintegro(cantidad_jpt_1dam) == false)  // No se ha podido completar la operación, saldo insuficiente?
                        MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                }

                else
                    realizarIngreso(cantidad_jpt_1dam);
                txtSaldo.Text = saldo_jpt_1dam.ToString();
            }
            
        }
    }
}