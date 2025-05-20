using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioElectronico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        
            public interface IProductoRepository
        { 
            void Agregar(ProductoRepository producto);
            void Actualizar(ProductoRepository producto);
            void Eliminar(int productoID);
            ProductoRepository ObtenerPorID(int productoID);
            List<ProductoRepository> ObtenerTodos();
        
        }
    }
}
