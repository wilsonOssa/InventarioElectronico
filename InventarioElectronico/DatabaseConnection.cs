using System.Data.SqlClient;

public sealed class DatabaseConnection
{
    private static DatabaseConnection _instance;
    private SqlConnection _connection;
    private static readonly string _connectionString = "Server=localhost;Database=InventarioElectronico;Integrated Security=True;";

    private DatabaseConnection()
    {
        _connection = new SqlConnection(_connectionString);
    }

    public static DatabaseConnection GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DatabaseConnection();
        }
        return _instance;
    }

    public SqlConnection GetConnection()
    {
        return _connection;
    }
}