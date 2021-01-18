CREATE DATABASE [QUANLYVDV] COLLATE SQL_Latin1_General_CP1_CI_AS
GO
RAISERROR(N'Create Table [dbo].[Bomon]', 0, 1) WITH NOWAIT;
GO
CREATE TABLE [dbo].[Bomon] (
    [MaBM]  NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [TenBM] CHAR (50)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_Bomon_1] PRIMARY KEY CLUSTERED ([MaBM]) WITH (IGNORE_DUP_KEY = OFF, ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF)
)
GO
RAISERROR(N'Create Table [dbo].[DienKinh]', 0, 1) WITH NOWAIT;
GO
CREATE TABLE [dbo].[DienKinh] (
    [MaVDV_dk]         NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [TenVDV_dk]        CHAR (50)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [gioitinh]         NCHAR (10)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [MaBM_dk]          NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [chieucao]         FLOAT         NULL,
    [cannang]          FLOAT         NULL,
    [Tttnhat_dk_100m]  FLOAT         NULL,
    [Tttnhat_dk_200m]  FLOAT         NULL,
    [Tttnhat_dk_500m]  FLOAT         NULL,
    [Tttnhat_dk_1000m] FLOAT         NULL,
    [ttsk]             NCHAR (20)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_DienKinh] PRIMARY KEY CLUSTERED ([MaVDV_dk]) WITH (IGNORE_DUP_KEY = OFF, ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF)
)
GO
RAISERROR(N'Create Table [dbo].[BongDa]', 0, 1) WITH NOWAIT;
GO
CREATE TABLE [dbo].[BongDa] (
    [MaVDV_bd]  NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [TenVDV_bd] CHAR (50)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [gioitinh]  NCHAR (10)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [MaBM_bd]   NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Vị trí]    CHAR (50)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [chieucao]  FLOAT         NULL,
    [cannang]   FLOAT         NULL,
    [ttsk]      NCHAR (50)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_BongDa] PRIMARY KEY CLUSTERED ([MaVDV_bd]) WITH (IGNORE_DUP_KEY = OFF, ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF)
)
GO
RAISERROR(N'Create Table [dbo].[Nhayxa]', 0, 1) WITH NOWAIT;
GO
CREATE TABLE [dbo].[Nhayxa] (
    [MaVDV_nx]    NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [TenVDV_nx]   CHAR (50)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [gioitinh]    NCHAR (10)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [MaBM_nx]     NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [cannang_nx]  FLOAT         NULL,
    [chieucao_nx] FLOAT         NULL,
    [Tttnhat_nx]  FLOAT         NULL,
    [ttsk]        NCHAR (20)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_Nhayxa] PRIMARY KEY CLUSTERED ([MaVDV_nx]) WITH (IGNORE_DUP_KEY = OFF, ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF)
)
GO
RAISERROR(N'Create Table [dbo].[NhayCao]', 0, 1) WITH NOWAIT;
GO
CREATE TABLE [dbo].[NhayCao] (
    [MaVDV_nc]    NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Ten_VDV_nc]  CHAR (50)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [gioitinh]    NCHAR (10)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [MaBM_nc]     NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [chieucao_nc] FLOAT         NULL,
    [cannang_nc]  FLOAT         NULL,
    [Tttnhat_nc]  FLOAT         NULL,
    [ttsk]        NCHAR (20)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_NhayCao] PRIMARY KEY CLUSTERED ([MaVDV_nc]) WITH (IGNORE_DUP_KEY = OFF, ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF)
)
GO
RAISERROR(N'Create Table [dbo].[VDV]', 0, 1) WITH NOWAIT;
GO
CREATE TABLE [dbo].[VDV] (
    [MaVDV]   NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [TenVDV]  CHAR (50)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [MaBoMon] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [NamSinh] DATE          NULL,
    [BoMon]   CHAR (50)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [FK_VDV_Bomon] FOREIGN KEY ([MaBoMon]) REFERENCES [dbo].[Bomon] ([MaBM]) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT [PK_VDV] PRIMARY KEY CLUSTERED ([MaVDV]) WITH (IGNORE_DUP_KEY = OFF, ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF)
)
GO
RAISERROR(N'Create Table [dbo].[TaiKhoan]', 0, 1) WITH NOWAIT;
GO
CREATE TABLE [dbo].[TaiKhoan] (
    [name] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [pass] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [type] INT           NULL
)
GO
RAISERROR(N'Create Table [dbo].[Boi]', 0, 1) WITH NOWAIT;
GO
CREATE TABLE [dbo].[Boi] (
    [MaVDV_boi]        NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [TenVDV_boi]       CHAR (50)     COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [gioitinh]         NCHAR (10)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [MaBM_boi]         NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [cannang_boi]      FLOAT         NULL,
    [chieucao_boi]     FLOAT         NULL,
    [Tttnhat_boi_100m] FLOAT         NULL,
    [Tttnhat_boi_200m] FLOAT         NULL,
    [Tttnhat_boi_500m] FLOAT         NULL,
    [ttsk]             NCHAR (50)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_Boi] PRIMARY KEY CLUSTERED ([MaVDV_boi]) WITH (IGNORE_DUP_KEY = OFF, ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF)
)
GO
