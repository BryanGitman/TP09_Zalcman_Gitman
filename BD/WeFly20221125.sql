USE [master]
GO
/****** Object:  Database [WeFly]    Script Date: 25/11/2022 11:53:32 ******/
CREATE DATABASE [WeFly]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WeFly', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WeFly.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WeFly_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\WeFly_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WeFly] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WeFly].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WeFly] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WeFly] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WeFly] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WeFly] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WeFly] SET ARITHABORT OFF 
GO
ALTER DATABASE [WeFly] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WeFly] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WeFly] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WeFly] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WeFly] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WeFly] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WeFly] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WeFly] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WeFly] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WeFly] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WeFly] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WeFly] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WeFly] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WeFly] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WeFly] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WeFly] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WeFly] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WeFly] SET RECOVERY FULL 
GO
ALTER DATABASE [WeFly] SET  MULTI_USER 
GO
ALTER DATABASE [WeFly] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WeFly] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WeFly] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WeFly] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WeFly] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'WeFly', N'ON'
GO
ALTER DATABASE [WeFly] SET QUERY_STORE = OFF
GO
USE [WeFly]
GO
/****** Object:  User [alumno]    Script Date: 25/11/2022 11:53:32 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Comentario]    Script Date: 25/11/2022 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDPublicacion] [int] NOT NULL,
	[Contenido] [varchar](100) NOT NULL,
	[FechaComentario] [datetime] NOT NULL,
 CONSTRAINT [PK_Comentario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destino]    Script Date: 25/11/2022 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destino](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FotoPais] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Destino] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Likes]    Script Date: 25/11/2022 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Likes](
	[IDUsuario] [int] NOT NULL,
	[IDPublicacion] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Like] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publicacion]    Script Date: 25/11/2022 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publicacion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDDestino] [int] NOT NULL,
	[Estrellas] [int] NOT NULL,
	[Opinion] [varchar](300) NULL,
	[Foto1] [varchar](50) NULL,
	[Foto2] [varchar](50) NULL,
	[Foto3] [varchar](50) NULL,
	[FechaPublicacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Publicacion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/11/2022 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](20) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[Pais] [varchar](50) NOT NULL,
	[FotoPerfil] [varchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comentario] ON 

INSERT [dbo].[Comentario] ([ID], [IDUsuario], [IDPublicacion], [Contenido], [FechaComentario]) VALUES (1, 5, 1, N'Que bonito debe de ser el caribe. A mi me queda un poco lejos :(', CAST(N'2022-02-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Comentario] ([ID], [IDUsuario], [IDPublicacion], [Contenido], [FechaComentario]) VALUES (2, 2, 2, N'Uh mal ahi, perdón pero altos muertos esos', CAST(N'2022-04-17T00:00:00.000' AS DateTime))
INSERT [dbo].[Comentario] ([ID], [IDUsuario], [IDPublicacion], [Contenido], [FechaComentario]) VALUES (3, 3, 2, N'Estas loco, parse. ¿Ir hasta allí solo para ver un partido?', CAST(N'2022-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Comentario] ([ID], [IDUsuario], [IDPublicacion], [Contenido], [FechaComentario]) VALUES (4, 4, 3, N'Qué envidia', CAST(N'2022-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Comentario] ([ID], [IDUsuario], [IDPublicacion], [Contenido], [FechaComentario]) VALUES (5, 2, 7, N'Aguante Argentina papá', CAST(N'2022-03-01T13:00:00.000' AS DateTime))
INSERT [dbo].[Comentario] ([ID], [IDUsuario], [IDPublicacion], [Contenido], [FechaComentario]) VALUES (7, 4, 7, N'Y si, bro. En Argentina tenemos este tipo de joyitas', CAST(N'2022-03-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Comentario] ([ID], [IDUsuario], [IDPublicacion], [Contenido], [FechaComentario]) VALUES (8, 8, 7, N'¡Hermoso lugar! Fuimos con mis hijos en año pasado', CAST(N'2022-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Comentario] ([ID], [IDUsuario], [IDPublicacion], [Contenido], [FechaComentario]) VALUES (13, 9, 17, N'Ole! Yo prefiero Madrid pero nuestro país entero es bellísimo', CAST(N'2022-11-25T14:38:28.987' AS DateTime))
SET IDENTITY_INSERT [dbo].[Comentario] OFF
GO
SET IDENTITY_INSERT [dbo].[Destino] ON 

INSERT [dbo].[Destino] ([ID], [Nombre], [FotoPais]) VALUES (1, N'Rio de Janeiro', N'brasil.png')
INSERT [dbo].[Destino] ([ID], [Nombre], [FotoPais]) VALUES (3, N'Cancún', N'mexico.png')
INSERT [dbo].[Destino] ([ID], [Nombre], [FotoPais]) VALUES (4, N'Iguazú', N'argentina.png')
INSERT [dbo].[Destino] ([ID], [Nombre], [FotoPais]) VALUES (5, N'París', N'francia.png')
INSERT [dbo].[Destino] ([ID], [Nombre], [FotoPais]) VALUES (6, N'Nueva York', N'eeuu.png')
INSERT [dbo].[Destino] ([ID], [Nombre], [FotoPais]) VALUES (7, N'Ushuaia', N'argentina.png')
INSERT [dbo].[Destino] ([ID], [Nombre], [FotoPais]) VALUES (8, N'Berlín', N'alemania.png')
INSERT [dbo].[Destino] ([ID], [Nombre], [FotoPais]) VALUES (9, N'Barcelona', N'españa.png')
INSERT [dbo].[Destino] ([ID], [Nombre], [FotoPais]) VALUES (10, N'Grecia', N'grecia.png')
INSERT [dbo].[Destino] ([ID], [Nombre], [FotoPais]) VALUES (11, N'Roma', N'italia.png')
SET IDENTITY_INSERT [dbo].[Destino] OFF
GO
SET IDENTITY_INSERT [dbo].[Likes] ON 

INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (1, 5, 1)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (2, 5, 2)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (3, 5, 3)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (4, 5, 4)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (5, 5, 5)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (6, 5, 6)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (7, 5, 7)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (8, 5, 8)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (10, 5, 9)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (7, 1, 10)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (10, 1, 11)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (1, 1, 12)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (1, 2, 13)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (2, 2, 14)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (3, 2, 15)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (1, 3, 17)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (2, 3, 18)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (3, 3, 19)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (4, 3, 20)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (5, 3, 21)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (8, 3, 22)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (4, 7, 23)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (2, 7, 24)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (8, 7, 25)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (6, 6, 26)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (7, 6, 27)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (9, 6, 28)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (10, 6, 29)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (5, 1, 43)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (5, 17, 44)
INSERT [dbo].[Likes] ([IDUsuario], [IDPublicacion], [ID]) VALUES (9, 17, 45)
SET IDENTITY_INSERT [dbo].[Likes] OFF
GO
SET IDENTITY_INSERT [dbo].[Publicacion] ON 

INSERT [dbo].[Publicacion] ([ID], [IDUsuario], [IDDestino], [Estrellas], [Opinion], [Foto1], [Foto2], [Foto3], [FechaPublicacion]) VALUES (1, 8, 3, 5, N'Playas hermosas, el mar limpio y con la temperatura ideal. El lugar perfecto para relajarse. De mis mejores vacaciones sin duda.', N'post1f1.jpg', NULL, NULL, CAST(N'2022-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Publicacion] ([ID], [IDUsuario], [IDDestino], [Estrellas], [Opinion], [Foto1], [Foto2], [Foto3], [FechaPublicacion]) VALUES (2, 4, 1, 3, N'Muy lindo el estadio pero la bajó mucho que no gane Flamengo loco. La pasé re piola igual.', N'post2f1.jpg', NULL, NULL, CAST(N'2022-04-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Publicacion] ([ID], [IDUsuario], [IDDestino], [Estrellas], [Opinion], [Foto1], [Foto2], [Foto3], [FechaPublicacion]) VALUES (3, 6, 6, 4, N'Una experiencia increíble, viaje inolvidable. Demasiada gente en todos lados que dificultaba las excursiones pero todo hermoso.', N'post3f1.jpg', N'post3f2.jpg', NULL, CAST(N'2022-01-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Publicacion] ([ID], [IDUsuario], [IDDestino], [Estrellas], [Opinion], [Foto1], [Foto2], [Foto3], [FechaPublicacion]) VALUES (5, 9, 5, 5, N'Sans mots...', N'post5f1.jpg', N'post5f2.jpg', N'post5f3.jpg', CAST(N'2022-08-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Publicacion] ([ID], [IDUsuario], [IDDestino], [Estrellas], [Opinion], [Foto1], [Foto2], [Foto3], [FechaPublicacion]) VALUES (6, 1, 1, 4, N'Viaje a Brasil parte 2: Rio de Janeiro. Playas geniales y muy buenas excursiones.', N'post6f1.jpg', N'post6f2.jpg', NULL, CAST(N'2022-03-01T10:30:00.000' AS DateTime))
INSERT [dbo].[Publicacion] ([ID], [IDUsuario], [IDDestino], [Estrellas], [Opinion], [Foto1], [Foto2], [Foto3], [FechaPublicacion]) VALUES (7, 1, 4, 5, N'Viaje a Brasil parte 1: Iguazú. Las vistas de las cataratas son de otro mundo, muy bien asignadas como una de las 7 maravillas.', N'post7f1.jpg', NULL, NULL, CAST(N'2022-03-01T10:20:00.000' AS DateTime))
INSERT [dbo].[Publicacion] ([ID], [IDUsuario], [IDDestino], [Estrellas], [Opinion], [Foto1], [Foto2], [Foto3], [FechaPublicacion]) VALUES (17, 5, 9, 5, N'¡Qué hermosa mi ciudad! Vale la pena ponerse de vez en cuando en modo turista.', N'post17f1.jpg', NULL, NULL, CAST(N'2022-11-25T11:34:04.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Publicacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([ID], [NombreUsuario], [Contraseña], [Pais], [FotoPerfil]) VALUES (1, N'carlos.gutierrez', N'jmSDJWrC', N'Chile', N'selfie1.jpg')
INSERT [dbo].[Usuario] ([ID], [NombreUsuario], [Contraseña], [Pais], [FotoPerfil]) VALUES (2, N'martin_rodriguezz', N'eu04Ua3a', N'Argentina', N'selfie2.jpg')
INSERT [dbo].[Usuario] ([ID], [NombreUsuario], [Contraseña], [Pais], [FotoPerfil]) VALUES (3, N'ferhernandez_', N'QBXtsQmE', N'Colombia', N'selfie3.jpg')
INSERT [dbo].[Usuario] ([ID], [NombreUsuario], [Contraseña], [Pais], [FotoPerfil]) VALUES (4, N'kevo.castillo', N'adAxuFN4', N'Argentina', N'selfie4.jpg')
INSERT [dbo].[Usuario] ([ID], [NombreUsuario], [Contraseña], [Pais], [FotoPerfil]) VALUES (5, N'maxicalderon', N'gñY3ñfm1', N'España', N'selfie5.jpg')
INSERT [dbo].[Usuario] ([ID], [NombreUsuario], [Contraseña], [Pais], [FotoPerfil]) VALUES (6, N'marina_carrizo', N'Apc5OWG6', N'Panamá', N'selfie6.jpg')
INSERT [dbo].[Usuario] ([ID], [NombreUsuario], [Contraseña], [Pais], [FotoPerfil]) VALUES (7, N'nicole.guzman', N'y8ITaL7v', N'Cuba', N'selfie7.jpg')
INSERT [dbo].[Usuario] ([ID], [NombreUsuario], [Contraseña], [Pais], [FotoPerfil]) VALUES (8, N'paulaschmukler', N'l2WEX63I', N'Argentina', N'selfie8.jpg')
INSERT [dbo].[Usuario] ([ID], [NombreUsuario], [Contraseña], [Pais], [FotoPerfil]) VALUES (9, N'gise_reyes', N'quKe15Lx', N'España', N'selfie9.jpg')
INSERT [dbo].[Usuario] ([ID], [NombreUsuario], [Contraseña], [Pais], [FotoPerfil]) VALUES (10, N'tamara.galindo', N'6J4oSNVP', N'Venezuela', N'selfie10.jpg')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Publicacion] FOREIGN KEY([IDPublicacion])
REFERENCES [dbo].[Publicacion] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [FK_Comentario_Publicacion]
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Usuario] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [FK_Comentario_Usuario]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Like_Publicacion] FOREIGN KEY([IDPublicacion])
REFERENCES [dbo].[Publicacion] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Like_Publicacion]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Like_Usuario] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Like_Usuario]
GO
ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Destino] FOREIGN KEY([IDDestino])
REFERENCES [dbo].[Destino] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Destino]
GO
ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Usuario] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Usuario]
GO
USE [master]
GO
ALTER DATABASE [WeFly] SET  READ_WRITE 
GO
