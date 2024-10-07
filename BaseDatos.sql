CREATE DATABASE AccountingDb;
CREATE SCHEMA dbo;
CREATE TABLE AccountingDb.dbo.Cuentas (
	NumeroCuenta nvarchar(450) NOT NULL,
	TipoCuenta int NOT NULL,
	SaldoInicial decimal(18,2) NOT NULL,
	Estado bit NOT NULL,
	ClienteId int DEFAULT 0 NOT NULL,
	CONSTRAINT PK_Cuentas PRIMARY KEY (NumeroCuenta)
);

CREATE TABLE AccountingDb.dbo.Movimientos (
	MovimientoId int IDENTITY(1,1) NOT NULL,
	Fecha datetime2 NOT NULL,
	TipoMovimiento int NOT NULL,
	Valor decimal(18,2) NOT NULL,
	Saldo decimal(18,2) NOT NULL,
	NumeroCuenta nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	CONSTRAINT PK_Movimientos PRIMARY KEY (MovimientoId)
);
 CREATE NONCLUSTERED INDEX IX_Movimientos_NumeroCuenta ON dbo.Movimientos (  NumeroCuenta ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- AccountingDb.dbo.Movimientos foreign keys

ALTER TABLE AccountingDb.dbo.Movimientos ADD CONSTRAINT FK_Movimientos_Cuentas_NumeroCuenta FOREIGN KEY (NumeroCuenta) REFERENCES AccountingDb.dbo.Cuentas(NumeroCuenta) ON DELETE CASCADE;

CREATE DATABASE PersonDb;
CREATE SCHEMA dbo;
CREATE TABLE PersonDb.dbo.Clientes (
	Id int IDENTITY(1,1) NOT NULL,
	ClienteId int NOT NULL,
	Contraseña nvarchar(MAX) NOT NULL,
	Estado bit NOT NULL,
	Nombre nvarchar(MAX) NOT NULL,
	Genero int NOT NULL,
	Edad int NOT NULL,
	Identificacion nvarchar(MAX) NOT NULL,
	Direccion nvarchar(MAX) NOT NULL,
	Telefono nvarchar(MAX) NOT NULL,
	CONSTRAINT PK_Clientes PRIMARY KEY (Id)
);