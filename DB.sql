-- Tabla Pais
CREATE TABLE Pais (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla Region
CREATE TABLE Region (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    PaisId INT FOREIGN KEY REFERENCES Pais(Id)
);

-- Tabla Ciudad
CREATE TABLE Ciudad (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    RegionId INT FOREIGN KEY REFERENCES Region(Id)
);

-- Tabla TipoDocumento
CREATE TABLE TipoDocumento (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(100) NOT NULL
);

-- Tabla TipoTercero
CREATE TABLE TipoTercero (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(100) NOT NULL
);

-- Tabla Tercero
CREATE TABLE Tercero (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellidos NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    TipoDocId INT FOREIGN KEY REFERENCES TipoDocumento(Id),
    TipoTerceroId INT FOREIGN KEY REFERENCES TipoTercero(Id),
    CiudadId INT FOREIGN KEY REFERENCES Ciudad(Id)
);

-- Tabla Producto
CREATE TABLE Producto (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Stock INT NOT NULL,
    StockMin INT NOT NULL,
    StockMax INT NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NOT NULL,
    Barcode NVARCHAR(50) NOT NULL,
    Precio DECIMAL(18, 2) NOT NULL
);

-- Tabla Venta
CREATE TABLE Venta (
    FactId INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL,
    TerceroEmpId INT FOREIGN KEY REFERENCES Tercero(Id),
    TerceroCliId INT FOREIGN KEY REFERENCES Tercero(Id)
);

-- Tabla DetalleVenta
CREATE TABLE DetalleVenta (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FactId INT FOREIGN KEY REFERENCES Venta(FactId),
    ProductoId INT FOREIGN KEY REFERENCES Producto(Id),
    Cantidad INT NOT NULL,
    Valor DECIMAL(18, 2) NOT NULL
);