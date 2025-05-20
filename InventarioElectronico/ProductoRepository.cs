using System.Collections.Generic;
using System.Data.SqlClient;

public class ProductoRepository
{
    private SqlConnection _connection = DatabaseConnection.GetInstance().GetConnection();

    public List<Producto> GetAll()
    {
        List<Producto> productos = new List<Producto>();
        using (SqlCommand cmd = new SqlCommand("SP_ObtenerProductos", _connection))
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productos.Add(new Producto
                {
                    ProductoID = (int)reader["ProductoID"],
                    Marca = reader["Marca"].ToString(),
                    Modelo = reader["Modelo"].ToString(),
                    Precio = (decimal)reader["Precio"],
                    CantidadInventario = (int)reader["CantidadInventario"]
                });
            }
            _connection.Close();
        }
        return productos;
    }

    public void Add(Producto producto)
    {
        using (SqlCommand cmd = new SqlCommand("INSERT INTO Productos (Marca, Modelo, Precio, CantidadInventario) VALUES (@Marca, @Modelo, @Precio, @Cantidad)", _connection))
        {
            cmd.Parameters.AddWithValue("@Marca", producto.Marca);
            cmd.Parameters.AddWithValue("@Modelo", producto.Modelo);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);
            cmd.Parameters.AddWithValue("@Cantidad", producto.CantidadInventario);
            _connection.Open();
            cmd.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
