using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Biblioteca1;

namespace ProyectoCRUD
{

    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(idProducto);
            btnEliminar.Enabled = false;    // desactiva los botones "modificar" y "eliminar"
            btnModificar.Enabled = false;

        }

        List<Producto> listaProductos = new List<Producto>();       // lista de productos
        int idProducto = 1000;      // ID autoincremental que inicializa en 1000

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("No pueden haber campos vacíos", "Error en la carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiarError();
            }
            else
            {
                try
                {
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;


                    Producto nuevoProducto = new Producto(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), Convert.ToInt32(textBox5.Text), textBox6.Text);
                    listaProductos.Add(nuevoProducto);
                    idProducto++;

                    //MessageBox.Show("Hola", textBox3.Text);

                    dataGridView2.DataSource = null;    // limpia la planilla
                    dataGridView2.DataSource = listaProductos;      // vuelve a cargarla

                    MessageBox.Show("Se ha cargado un nuevo producto en la lista", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCamposProducto();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error en el formato admitido. Revise los datos cargados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {            
            var confimarAccion = MessageBox.Show("¿Desea finalizar el programa?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(confimarAccion == DialogResult.Yes)
            {
                Close();
            }
        }

        private void LimpiarCamposProducto()
        {
            textBox1.Text = Convert.ToString(idProducto);       // limpia los campos y enfoca en el textBox2
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox7.Text = "ingrese un ID";
            textBox7.ForeColor = Color.Gray;

            textBox2.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, punto decimal, teclas de control (por ejemplo, retroceso) y la tecla de suprimir.
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Cancelar la acción del evento si el carácter no es válido.
            }

            // Asegurarse de que solo haya un punto decimal en el cuadro de texto.
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }



        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, punto decimal, teclas de control (por ejemplo, retroceso) y la tecla de suprimir.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Cancelar la acción del evento si el carácter no es válido.
            }

            // Asegurarse de que solo haya un punto decimal en el cuadro de texto.
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada del carácter no válido
            }
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = MessageBox.Show("¿Está seguro que quiere eliminar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //Si el resultado es YES elimino. Si el resultado es NO no elimino.
                if (resultado == DialogResult.Yes)
                {
                    EliminarProducto(Convert.ToInt32(textBox7.Text));

                    dataGridView2.DataSource = null;    // limpia la planilla
                    dataGridView2.DataSource = listaProductos;

                    LimpiarCamposProducto();
                    textBox7.Text = null;

                    btnAgregarProducto.Enabled = true;
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Se canceló la eliminación del producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                MessageBox.Show("No se puede eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("No pueden haber campos vacíos", "Error en la carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {                                       
                    var confirmarAccion = MessageBox.Show("¿Está seguro que quiere modificar?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(confirmarAccion == DialogResult.Yes)
                    {
                        ModificarProducto(Convert.ToInt32(textBox7.Text));
                        MessageBox.Show("Se ha modificado los datos correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataGridView2.DataSource = null;    // limpia la planilla
                        dataGridView2.DataSource = listaProductos;
                        btnAgregarProducto.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la modificación del producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                   
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error en el formato admitido. Revise los datos cargados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idIngresado;

            try
            {
                idIngresado = Convert.ToInt32(textBox7.Text);

                if (idIngresado < 1000)
                {
                    MessageBox.Show("Valor de ID no admitido. Ingrese un número superior a 1000", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox7.Text = "";
                    textBox7.Focus();
                }
                else
                {
                    BuscarYMostrarProducto(idIngresado);
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Error al buscar por ID. Formato no admitido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Text = "ingrese un ID";
                textBox7.ForeColor = Color.Gray;
                textBox7.Focus();
            }

        }

        public void ModificarProducto(int id)
        {
            foreach (var producto in listaProductos)
            {
                if (producto.Id == id)
                {
                    producto.Descripcion = textBox2.Text;
                    producto.Precio = Convert.ToDouble(textBox3.Text);
                    producto.Costo = Convert.ToDouble(textBox4.Text);
                    producto.Stock = Convert.ToInt32(textBox5.Text);
                    producto.Proveedor = textBox6.Text;

                    break;
                }

            }
        }

        public void EliminarProducto(int id)
        {
            foreach (var producto in listaProductos)
            {
                if (producto.Id == id)
                {
                    listaProductos.Remove(producto);                                       
                    
                    break;
                }

            }
        }

        //Cargo los textbox para poder modificar los datos
        void BuscarYMostrarProducto(int id)
        {
            bool productoEncontrado = false;

            foreach (var producto in listaProductos)
            {
                if (producto.Id == id)
                {
                    btnAgregarProducto.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;

                    textBox1.Text = producto.Id.ToString();
                    textBox2.Text = producto.Descripcion;
                    textBox3.Text = producto.Precio.ToString();
                    textBox4.Text = producto.Costo.ToString();
                    textBox5.Text = producto.Stock.ToString();
                    textBox6.Text = producto.Proveedor.ToString();

                    productoEncontrado = true;
                    break;
                }
            }

            if (productoEncontrado == false)
            {
                MessageBox.Show("Producto no encontrado", "ID incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox7.Text = "";
                textBox7.Focus();
            }

        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "ingrese un ID")
            {
                textBox7.Text = "";
                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "ingrese un ID";
                textBox7.ForeColor = Color.Gray;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposProducto();
            btnAgregarProducto.Enabled = true;  // activa el boton agregar
            btnEliminar.Enabled = false;    // desactiva los botones "modificar" y "eliminar"
            btnModificar.Enabled = false;
        }

        private void limpiarError()
        {
            errorProvider1.SetError(textBox2, "");
            errorProvider1.SetError(textBox3, "");
            errorProvider1.SetError(textBox4, "");
            errorProvider1.SetError(textBox5, "");
            errorProvider1.SetError(textBox6, "");
            errorProvider1.SetError(textBox7, "");

        }
    }
}

/*          MODIFICACIONES PENDIENTES

    Marcar en rojo los textBoxs que se encuentren vacíos al momento de cargar o modificar un producto
    Corregir error en el precio y el costo. tiene que aceptar valores double
 
 */