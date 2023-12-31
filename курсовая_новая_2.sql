USE [master]
GO
/****** Object:  Database [курсовая_новая_2]    Script Date: 16.10.2023 23:48:11 ******/
CREATE DATABASE [курсовая_новая_2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'курсовая_новая_2', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\курсовая_новая_2.mdf' , SIZE = 11264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'курсовая_новая_2_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\курсовая_новая_2_log.ldf' , SIZE = 4672KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [курсовая_новая_2] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [курсовая_новая_2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [курсовая_новая_2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET ARITHABORT OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [курсовая_новая_2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [курсовая_новая_2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [курсовая_новая_2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [курсовая_новая_2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [курсовая_новая_2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [курсовая_новая_2] SET  MULTI_USER 
GO
ALTER DATABASE [курсовая_новая_2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [курсовая_новая_2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [курсовая_новая_2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [курсовая_новая_2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [курсовая_новая_2]
GO
/****** Object:  StoredProcedure [dbo].[Для_проверки_время_день]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Для_проверки_время_день]
@time time,
@date_ned varchar(15)
AS
BEGIN
select График.День_недели,График.Время_начала,График.Время_окончания from Преподаватель,График
where График.ID_графика = Преподаватель.ID_графика and @time>График.Время_начала and @time<График.Время_окончания and График.День_недели = @date_ned
END

GO
/****** Object:  StoredProcedure [dbo].[Запись]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Запись]
@kurs varchar(15)
as
begin
select Курсы.ID_курсы from Курсы
where Курсы.Название_курса = @kurs
end
GO
/****** Object:  StoredProcedure [dbo].[Пакет]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Пакет]
@baza varchar(10),
@pluz varchar(15),
@but varchar(15)
as
begin
select Пакет_услуг.ID_пакета from Пакет_услуг where Пакет_услуг.Название_пакета=@baza or Пакет_услуг.Название_пакета=@pluz or Пакет_услуг.Название_пакета=@but
end
GO
/****** Object:  Table [dbo].[График]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[График](
	[ID_графика] [int] NOT NULL,
	[День_недели] [varchar](15) NOT NULL,
	[Время_начала] [time](7) NULL,
	[Время_окончания] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_графика] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Заказ]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Заказ](
	[ID_заказа] [int] NOT NULL,
	[ID_клиента] [int] NOT NULL,
	[ID_курсы] [int] NOT NULL,
	[ID_пакета] [int] NOT NULL,
	[Стоимость] [money] NULL,
	[Банк] [varchar](15) NULL,
	[Карта] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_заказа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Клиент]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Клиент](
	[ID_клиента] [int] NOT NULL,
	[ФИО] [varchar](15) NOT NULL,
	[Телефон] [varchar](11) NOT NULL,
	[Почта] [varchar](10) NOT NULL,
	[Адрес] [varchar](15) NOT NULL,
	[Логин] [varchar](10) NOT NULL,
	[Пароль] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_клиента] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Курсы]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Курсы](
	[ID_курсы] [int] NOT NULL,
	[ID_формата] [int] NOT NULL,
	[ID_преподавателя] [int] NOT NULL,
	[ID_программы] [int] NOT NULL,
	[Название_курса] [varchar](15) NOT NULL,
	[Средняя_з_п] [decimal](2, 0) NOT NULL,
	[Количество_специальностей] [int] NOT NULL,
	[Дата_начала] [date] NULL,
	[Дата_окончания] [date] NULL,
	[Количество_мест] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_курсы] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Отзывы]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Отзывы](
	[ID_отзывы] [int] NOT NULL,
	[ID_преподавателя] [int] NOT NULL,
	[Логин_пользователя] [varchar](8) NOT NULL,
	[Категория] [varchar](10) NOT NULL,
	[Описание] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_отзывы] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Пакет_услуг]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Пакет_услуг](
	[ID_пакета] [int] NOT NULL,
	[Название_пакета] [varchar](15) NOT NULL,
	[Скидка] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_пакета] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Преподаватель]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Преподаватель](
	[ID_преподавателя] [int] NOT NULL,
	[ID_формата] [int] NOT NULL,
	[ID_графика] [int] NOT NULL,
	[ФИО_преподавателя] [varchar](15) NOT NULL,
	[Стаж] [int] NOT NULL,
	[Предмет] [varchar](10) NOT NULL,
	[Телефон] [varchar](11) NOT NULL,
	[Количество_учеников] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_преподавателя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Программа]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Программа](
	[ID_программы] [int] NOT NULL,
	[Название_программы] [varchar](15) NOT NULL,
	[Количество_тем] [int] NOT NULL,
	[Описание] [varchar](20) NOT NULL,
	[Количество_практических_часов] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_программы] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Формат]    Script Date: 16.10.2023 23:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Формат](
	[ID_формата] [int] NOT NULL,
	[Название_формата] [varchar](15) NOT NULL,
	[Место_проведения] [varchar](10) NOT NULL,
	[День_недели] [varchar](15) NULL,
	[Время_начала] [time](7) NULL,
	[Время_окончания] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_формата] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD FOREIGN KEY([ID_клиента])
REFERENCES [dbo].[Клиент] ([ID_клиента])
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD FOREIGN KEY([ID_курсы])
REFERENCES [dbo].[Курсы] ([ID_курсы])
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD FOREIGN KEY([ID_пакета])
REFERENCES [dbo].[Пакет_услуг] ([ID_пакета])
GO
ALTER TABLE [dbo].[Курсы]  WITH CHECK ADD FOREIGN KEY([ID_преподавателя])
REFERENCES [dbo].[Преподаватель] ([ID_преподавателя])
GO
ALTER TABLE [dbo].[Курсы]  WITH CHECK ADD FOREIGN KEY([ID_программы])
REFERENCES [dbo].[Программа] ([ID_программы])
GO
ALTER TABLE [dbo].[Курсы]  WITH CHECK ADD FOREIGN KEY([ID_формата])
REFERENCES [dbo].[Формат] ([ID_формата])
GO
ALTER TABLE [dbo].[Отзывы]  WITH CHECK ADD FOREIGN KEY([ID_преподавателя])
REFERENCES [dbo].[Преподаватель] ([ID_преподавателя])
GO
ALTER TABLE [dbo].[Преподаватель]  WITH CHECK ADD FOREIGN KEY([ID_графика])
REFERENCES [dbo].[График] ([ID_графика])
GO
ALTER TABLE [dbo].[Преподаватель]  WITH CHECK ADD FOREIGN KEY([ID_формата])
REFERENCES [dbo].[Формат] ([ID_формата])
GO
USE [master]
GO
ALTER DATABASE [курсовая_новая_2] SET  READ_WRITE 
GO
