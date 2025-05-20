CREATE DATABASE InventarioElectronico;
GO

USE InventarioElectronico;
GO

CREATE TABLE Productos (
    ProductoID INT PRIMARY KEY IDENTITY(1,1),
    Marca VARCHAR(50) NOT NULL,
    Modelo VARCHAR(50) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    CantidadInventario INT NOT NULL
);

CREATE TABLE Proveedores (
    ProveedorID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Contacto VARCHAR(100) NOT NULL,
    ProductoID INT NOT NULL,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

CREATE TABLE MovimientosInventario (
    MovimientoID INT PRIMARY KEY IDENTITY(1,1),
    ProductoID INT NOT NULL,
    FechaMovimiento DATE DEFAULT GETDATE(),
    TipoMovimiento VARCHAR(10) CHECK (TipoMovimiento IN ('Entrada', 'Salida')),
    Cantidad INT NOT NULL,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

CREATE TABLE Ventas (
    VentaID INT PRIMARY KEY IDENTITY(1,1),
    ProductoID INT NOT NULL,
    FechaVenta DATE DEFAULT GETDATE(),
    Cantidad INT NOT NULL,
    PrecioVenta DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

CREATE TABLE Alertas (
    AlertaID INT PRIMARY KEY IDENTITY(1,1),
    ProductoID INT NOT NULL,
    Mensaje VARCHAR(200) NOT NULL,
    FechaAlerta DATE DEFAULT GETDATE(),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

-- SP_RegistrarMovimiento
CREATE PROCEDURE SP_RegistrarMovimiento
    @ProductoID INT,
    @TipoMovimiento VARCHAR(10),
    @Cantidad INT
AS
BEGIN
    INSERT INTO MovimientosInventario (ProductoID, TipoMovimiento, Cantidad)
    VALUES (@ProductoID, @TipoMovimiento, @Cantidad);

    IF @TipoMovimiento = 'Entrada'
        UPDATE Productos SET CantidadInventario += @Cantidad WHERE ProductoID = @ProductoID;
    ELSE
        UPDATE Productos SET CantidadInventario -= @Cantidad WHERE ProductoID = @ProductoID;
END;
GO