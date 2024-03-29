﻿USE [master]
GO
/****** Object:  Database [hotel_Sistema]    Script Date: 07/03/2024 06:22:39 p. m. ******/
CREATE DATABASE [hotel_Sistema]
GO
USE [hotel_Sistema]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[IdFacturas] [int] IDENTITY(1,1) NOT NULL,
	[IdReserva] [int] NOT NULL,
	[CodigoReserva] [varchar](100) NOT NULL,
	[CantidadPersonas] [int] NOT NULL,
	[PrecioTotal] [float] NOT NULL,
	[FechaFactura] [datetime] NOT NULL,
	[Detalle] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFacturas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habitaciones]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitaciones](
	[IdHabitacion] [int] IDENTITY(1,1) NOT NULL,
	[NumeroHabitacion] [int] NOT NULL,
	[Disponible] [bit] NOT NULL,
	[NumeroPiso] [int] NULL,
	[IdTipoHabitacion] [int] NOT NULL,
	[TipoHabitacion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[CodigoReserva] [varchar](100) NOT NULL,
	[NombreCliente] [varchar](100) NOT NULL,
	[IdHabitacion] [int] NOT NULL,
	[FechaEntrada] [datetime] NOT NULL,
	[FechaSalida] [datetime] NOT NULL,
	[EstadoReservacion] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_rol] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoHabitacion]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoHabitacion](
	[IDTipoHabitacion] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTipoHabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](100) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Celular] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdRol] [int] NOT NULL,
	[password] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Habitaciones] ON 

INSERT [dbo].[Habitaciones] ([IdHabitacion], [NumeroHabitacion], [Disponible], [NumeroPiso], [IdTipoHabitacion], [TipoHabitacion]) VALUES (2, 1, 0, 1, 1, N'Pequeña')
INSERT [dbo].[Habitaciones] ([IdHabitacion], [NumeroHabitacion], [Disponible], [NumeroPiso], [IdTipoHabitacion], [TipoHabitacion]) VALUES (3, 5, 1, 2, 1, N'Pequeña')
INSERT [dbo].[Habitaciones] ([IdHabitacion], [NumeroHabitacion], [Disponible], [NumeroPiso], [IdTipoHabitacion], [TipoHabitacion]) VALUES (4, 2, 1, 1, 1, N'Pequeña')
INSERT [dbo].[Habitaciones] ([IdHabitacion], [NumeroHabitacion], [Disponible], [NumeroPiso], [IdTipoHabitacion], [TipoHabitacion]) VALUES (5, 3, 1, 2, 1, N'Pequeña')
INSERT [dbo].[Habitaciones] ([IdHabitacion], [NumeroHabitacion], [Disponible], [NumeroPiso], [IdTipoHabitacion], [TipoHabitacion]) VALUES (6, 4, 1, 1, 2, N'Mediana')
INSERT [dbo].[Habitaciones] ([IdHabitacion], [NumeroHabitacion], [Disponible], [NumeroPiso], [IdTipoHabitacion], [TipoHabitacion]) VALUES (8, 6, 0, 2, 3, N'Grande')
SET IDENTITY_INSERT [dbo].[Habitaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([IdRol], [Nombre_rol]) VALUES (1, N'Administrador')
INSERT [dbo].[Roles] ([IdRol], [Nombre_rol]) VALUES (2, N' Recepcionista')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoHabitacion] ON 

INSERT [dbo].[TipoHabitacion] ([IDTipoHabitacion], [Tipo]) VALUES (1, N'Pequeña')
INSERT [dbo].[TipoHabitacion] ([IDTipoHabitacion], [Tipo]) VALUES (2, N'Mediana')
INSERT [dbo].[TipoHabitacion] ([IDTipoHabitacion], [Tipo]) VALUES (3, N'Grande')
SET IDENTITY_INSERT [dbo].[TipoHabitacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [NombreUsuario], [Nombre], [Apellido], [Celular], [Activo], [IdRol], [password]) VALUES (2, N'admin', N'Carlos', N'Arias', 88888888, 1, 1, N'1234')
INSERT [dbo].[Usuarios] ([IdUsuario], [NombreUsuario], [Nombre], [Apellido], [Celular], [Activo], [IdRol], [password]) VALUES (3, N'mau', N'Mauricio', N'Arias', 88188865, 1, 2, N'12345')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Reservas] FOREIGN KEY([IdReserva])
REFERENCES [dbo].[Reservas] ([IdReserva])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Reservas]
GO
ALTER TABLE [dbo].[Habitaciones]  WITH CHECK ADD  CONSTRAINT [FK_Habitaciones_TipoHabitacion] FOREIGN KEY([IdTipoHabitacion])
REFERENCES [dbo].[TipoHabitacion] ([IDTipoHabitacion])
GO
ALTER TABLE [dbo].[Habitaciones] CHECK CONSTRAINT [FK_Habitaciones_TipoHabitacion]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Habitaciones] FOREIGN KEY([IdHabitacion])
REFERENCES [dbo].[Habitaciones] ([IdHabitacion])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Habitaciones]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  StoredProcedure [dbo].[SP_FacturaEliminar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FacturaEliminar]
    @IdFactura INT
AS
BEGIN
    DELETE FROM Facturas
    WHERE IdFacturas = @IdFactura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FacturaLista]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FacturaLista]
AS
BEGIN
    SELECT IdFacturas, IdReserva, CodigoReserva, CantidadPersonas, PrecioTotal, FechaFactura,detalle
    FROM Facturas
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FacturaModificar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FacturaModificar]
    @IdFactura INT,
    @IdReserva INT,
    @CodigoReserva VARCHAR(100),
    @CantidadPersonas INT,
    @PrecioTotal FLOAT,
    @FechaFactura DATETIME,
	@Detalle   varchar(250)
AS
BEGIN
    UPDATE Facturas
    SET IdReserva = @IdReserva,
        CodigoReserva = @CodigoReserva,
        CantidadPersonas = @CantidadPersonas,
        PrecioTotal = @PrecioTotal,
        FechaFactura = @FechaFactura,
		detalle = @Detalle
    WHERE IdFacturas = @IdFactura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FacturaNueva]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FacturaNueva]
    @IdReserva INT,
    @CodigoReserva VARCHAR(100),
    @CantidadPersonas INT,
    @PrecioTotal FLOAT,
    @FechaFactura DATETIME,
	@Detalle   varchar(250)
AS
BEGIN
    INSERT INTO Facturas (IdReserva, CodigoReserva, CantidadPersonas, PrecioTotal, FechaFactura, detalle)
    VALUES (@IdReserva, @CodigoReserva, @CantidadPersonas, @PrecioTotal, @FechaFactura,@Detalle)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FacturasGetByID]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FacturasGetByID]
    @IdFactura INT
AS
BEGIN
    SELECT IdFacturas, IdReserva, CodigoReserva, CantidadPersonas, PrecioTotal, FechaFactura,detalle
    FROM Facturas
    WHERE IdFacturas = @IdFactura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_HabitacionEliminar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_HabitacionEliminar]
    @IdHabitacion int
AS
BEGIN
    DELETE FROM Habitaciones
    WHERE IdHabitacion = @IdHabitacion
END
GO
/****** Object:  StoredProcedure [dbo].[SP_HabitacionGetByID]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_HabitacionGetByID]
    @IdHabitacion int
AS
BEGIN
    SELECT *
    FROM Habitaciones
    WHERE IdHabitacion = @IdHabitacion
END
GO
/****** Object:  StoredProcedure [dbo].[SP_HabitacionLista]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_HabitacionLista]
AS
BEGIN
    SELECT *
    FROM Habitaciones
END
GO
/****** Object:  StoredProcedure [dbo].[SP_HabitacionListaLibres]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_HabitacionListaLibres]
(
  @FechaEntrada DATETIME,
  @FechaSalida DATETIME
)
as
begin
SELECT h.IdHabitacion, h.NumeroHabitacion, h.Disponible, h.NumeroPiso, h.IdTipoHabitacion,h.TipoHabitacion
FROM Habitaciones h
WHERE NOT EXISTS (
    SELECT 1
    FROM Reservas r
    WHERE r.IdHabitacion = h.IdHabitacion
    AND (
        @FechaEntrada BETWEEN r.FechaEntrada AND r.FechaSalida
        OR @FechaSalida BETWEEN r.FechaEntrada AND r.FechaSalida
        OR (r.FechaEntrada BETWEEN @FechaEntrada AND @FechaSalida 
		AND r.FechaSalida BETWEEN @FechaEntrada AND @FechaSalida)
    )
	and r.EstadoReservacion = 1
)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_HabitacionModificar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_HabitacionModificar]
    @IdHabitacion int,
    @NumeroHabitacion int,
    @Disponible bit,
    @NumeroPiso int,
    @IdTipoHabitacion int,
	@TipoHabitacion varchar(50)
AS
BEGIN
    UPDATE Habitaciones
    SET NumeroHabitacion = @NumeroHabitacion,
        Disponible = @Disponible,
        NumeroPiso = @NumeroPiso,
        IdTipoHabitacion = @IdTipoHabitacion,
		TipoHabitacion = @TipoHabitacion
    WHERE IdHabitacion = @IdHabitacion
END
GO
/****** Object:  StoredProcedure [dbo].[SP_HabitacionNueva]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_HabitacionNueva]
    @NumeroHabitacion int,
    @Disponible bit,
    @NumeroPiso int,
    @IdTipoHabitacion int,
	@TipoHabitacion varchar(50)
AS
BEGIN
    INSERT INTO Habitaciones (NumeroHabitacion, Disponible, NumeroPiso, IdTipoHabitacion, TipoHabitacion)
    VALUES (@NumeroHabitacion, @Disponible, @NumeroPiso, @IdTipoHabitacion,@TipoHabitacion)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ReservaEliminar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ReservaEliminar]
    @IdReserva INT
AS
BEGIN
    DELETE FROM Reservas
    WHERE IdReserva = @IdReserva
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_ReservaGetByCodigo]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Sp_ReservaGetByCodigo]
    @CodigoReserva varchar(15)
AS
BEGIN
    SELECT * FROM Reservas
    WHERE CodigoReserva = @CodigoReserva
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_ReservaGetById]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_ReservaGetById]
    @IdReserva INT
AS
BEGIN
    SELECT * FROM Reservas
    WHERE IdReserva = @IdReserva
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ReservaLista]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ReservaLista]
AS
BEGIN
    SELECT * FROM Reservas
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ReservaModificar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ReservaModificar]
    @IdReserva INT,
    @CodigoReserva VARCHAR(100),
    @NombreCliente VARCHAR(100),
    @IdHabitacion INT,
    @FechaEntrada DATETIME,
    @FechaSalida DATETIME,
    @EstadoReservacion BIT
AS
BEGIN
    UPDATE Reservas
    SET CodigoReserva = @CodigoReserva,
        NombreCliente = @NombreCliente,
        IdHabitacion = @IdHabitacion,
        FechaEntrada = @FechaEntrada,
        FechaSalida = @FechaSalida,
        EstadoReservacion = @EstadoReservacion
    WHERE IdReserva = @IdReserva
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ReservaNueva]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ReservaNueva]
    @CodigoReserva VARCHAR(100),
    @NombreCliente VARCHAR(100),
    @IdHabitacion INT,
    @FechaEntrada DATETIME,
    @FechaSalida DATETIME,
    @EstadoReservacion BIT
AS
BEGIN
    INSERT INTO Reservas(CodigoReserva, NombreCliente, IdHabitacion, FechaEntrada, FechaSalida, EstadoReservacion)
    VALUES (@CodigoReserva, @NombreCliente, @IdHabitacion, @FechaEntrada, @FechaSalida, @EstadoReservacion)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RoleEliminar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RoleEliminar]
    @IdRol INT
AS
BEGIN
    DELETE FROM Roles
    WHERE IdRol = @IdRol
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RoleLista]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RoleLista]
AS
BEGIN
    SELECT IdRol, Nombre_rol
    FROM Roles
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RoleNuevo]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RoleNuevo]
    @NombreRol VARCHAR(100)
AS
BEGIN
    INSERT INTO Roles (Nombre_rol)
    VALUES (@NombreRol)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RolesGetByID]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RolesGetByID]
    @IdRol INT
AS
BEGIN
    SELECT IdRol, Nombre_rol
    FROM Roles
    WHERE IdRol = @IdRol
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RolesModificar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RolesModificar]
    @IdRol INT,
    @NombreRol VARCHAR(100)
AS
BEGIN
    UPDATE Roles
    SET Nombre_rol = @NombreRol
    WHERE IdRol = @IdRol
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TipoHabitacionEliminar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_TipoHabitacionEliminar]
    @IDTipoHabitacion INT
AS
BEGIN
    DELETE FROM TipoHabitacion
    WHERE IDTipoHabitacion = @IDTipoHabitacion
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TipoHabitacionGetByID]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_TipoHabitacionGetByID]
    @IDTipoHabitacion INT
AS
BEGIN
    SELECT IDTipoHabitacion, Tipo
    FROM TipoHabitacion
    WHERE IDTipoHabitacion = @IDTipoHabitacion
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TipoHabitacionLista]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_TipoHabitacionLista]
AS
BEGIN
    SELECT IDTipoHabitacion, Tipo
    FROM TipoHabitacion
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TipoHabitacionModificar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_TipoHabitacionModificar]
    @IDTipoHabitacion INT,
    @Tipo VARCHAR(100)
AS
BEGIN
    UPDATE TipoHabitacion
    SET Tipo = @Tipo
    WHERE IDTipoHabitacion = @IDTipoHabitacion
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TipoHabitacionNueva]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_TipoHabitacionNueva]
    @Tipo VARCHAR(100)
AS
BEGIN
    INSERT INTO TipoHabitacion (Tipo)
    VALUES (@Tipo)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UsuarioEliminar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_UsuarioEliminar]
(
    @IdUsuario int
)
as
begin
  delete Usuarios where IdUsuario = @IdUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[SP_UsuarioLista]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_UsuarioLista]
as
begin
  select * from Usuarios
end
GO
/****** Object:  StoredProcedure [dbo].[SP_UsuarioModificar]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SP_UsuarioModificar]
(
		   @IdUsuario int,
		   @NombreUsuario	varchar(100),
           @Nombre			varchar(100),
           @Apellido		varchar(100),
           @Celular		int,
           @Activo			bit,
           @IdRol			int,
           @password		varchar(50)
)
as
begin
UPDATE Usuarios set NombreUsuario=@NombreUsuario
           ,Nombre=@Nombre
           ,Apellido=@Apellido
           ,Celular=@Celular
           ,Activo=@Activo
           ,IdRol=@IdRol
           ,password = @password
     WHERE IdUsuario = @IdUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[SP_UsuarioNuevo]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_UsuarioNuevo]
(
		   @NombreUsuario	varchar(100),
           @Nombre			varchar(100),
           @Apellido		varchar(100),
           @Celular		int,
           @Activo			bit,
           @IdRol			int,
           @password		varchar(50)
)
as
begin
INSERT INTO [dbo].[Usuarios]
           ([NombreUsuario]
           ,[Nombre]
           ,[Apellido]
           ,[Celular]
           ,[Activo]
           ,[IdRol]
           ,[password])
     VALUES
           (@NombreUsuario
           ,@Nombre
           ,@Apellido
           ,@Celular
           ,@Activo	
           ,@IdRol
           ,@password)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_UsuarioValido]    Script Date: 07/03/2024 06:22:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_UsuarioValido]
(
  @NombreUsuario varchar(50),
  @Password		 varchar(50)
)
as
begin
    
	select * from Usuarios where NombreUsuario =@NombreUsuario and password= @Password 

end
GO
USE [master]
GO
ALTER DATABASE [hotel_Sistema] SET  READ_WRITE 
GO
