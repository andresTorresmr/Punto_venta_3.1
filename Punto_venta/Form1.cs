using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace Punto_venta
{

    public partial class Form1 : Form
    {

        public Double huevo = 0;
        public Double limon = 0;
        public Double aguacate = 0;
        public Double manzana = 0;
        public Double platano = 0;
        public Double sandia = 0;
        public Double total = 0;

        public class ticket
        {
            public Double huevo { get; set; }
            public Double aguacate { get; set; }
            public Double limon { get; set; }
            public Double manzana { get; set; }
            public Double platano { get; set; }
            public Double sandia { get; set; }
            public Double total { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void txtHuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtAguacate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtLimon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtManzana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPlatano_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtSandia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ticket = new ticket();
            if (txtHuevo.Text.Length > 0)
            {
                huevo = Convert.ToDouble(txtHuevo.Text);
            }

            if (txtAguacate.Text.Length > 0)
            {
                aguacate = Convert.ToDouble(txtAguacate.Text);
            }

            if (txtManzana.Text.Length > 0)
            {
                manzana = Convert.ToDouble(txtManzana.Text);
            }

            if (txtPlatano.Text.Length > 0)
            {
                platano = Convert.ToDouble(txtPlatano.Text);
            }

            if (txtSandia.Text.Length > 0)
            {
                sandia = Convert.ToDouble(txtSandia.Text);
            }

            
            
            
            

            total = huevo + aguacate + limon + manzana + platano + sandia;
            
            ticket.huevo = huevo;
            ticket.aguacate = aguacate;
            ticket.limon = limon;
            ticket.manzana = manzana;
            ticket.platano = platano;
            ticket.sandia = sandia;

            ticket.total = total;
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var dirName = $@"{docPath}\Tickets\";
            int totalItems = 1;

            DateTime aDate = DateTime.Now;
            if (Directory.Exists(dirName))
            {

                totalItems = Directory.GetFiles(dirName, "*", SearchOption.TopDirectoryOnly).Length;
                totalItems += 1;
                string fileName = dirName + Convert.ToString(totalItems) + " " + " Ticket-" +  Convert.ToString(aDate.ToString("yyyy-MM-dd HH_m_ss")) + ".json";
                string json = JsonConvert.SerializeObject(ticket, Formatting.Indented);
                MessageBox.Show("Se ha guardado tu ticket en la carpeta");
                File.WriteAllText(fileName, json);
            }
            else
            {
                Directory.CreateDirectory(dirName);
                string fileName = dirName + Convert.ToString(totalItems) + " " + " Ticket-" + Convert.ToString(aDate.ToString("yyyy-MM-dd HH_m_ss")) + ".json";
                string json = JsonConvert.SerializeObject(ticket, Formatting.Indented);
                MessageBox.Show("Tu ticket se guardó exitosamente en el escritorio dentro de la carpeta Tickets");
                File.WriteAllText(fileName, json);
            }


            
            
        }
    }
}