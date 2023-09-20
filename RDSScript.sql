USE [master]
GO
/****** Object:  Database [GadgetsOnlineDB]    Script Date: 9/15/2023 4:49:56 PM ******/
CREATE DATABASE [GadgetsOnlineDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GadgetsOnlineDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GadgetsOnlineDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GadgetsOnlineDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GadgetsOnlineDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GadgetsOnlineDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GadgetsOnlineDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GadgetsOnlineDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GadgetsOnlineDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GadgetsOnlineDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GadgetsOnlineDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GadgetsOnlineDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GadgetsOnlineDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GadgetsOnlineDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GadgetsOnlineDB] SET  MULTI_USER 
GO
ALTER DATABASE [GadgetsOnlineDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GadgetsOnlineDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GadgetsOnlineDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GadgetsOnlineDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GadgetsOnlineDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GadgetsOnlineDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GadgetsOnlineDB] SET QUERY_STORE = OFF
GO
USE [GadgetsOnlineDB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 9/15/2023 4:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 9/15/2023 4:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[RecordId] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [nvarchar](max) NULL,
	[Count] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Carts] PRIMARY KEY CLUSTERED 
(
	[RecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/15/2023 4:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 9/15/2023 4:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/15/2023 4:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[Username] [nvarchar](max) NULL,
	[FirstName] [nvarchar](160) NOT NULL,
	[LastName] [nvarchar](160) NOT NULL,
	[Address] [nvarchar](70) NOT NULL,
	[City] [nvarchar](40) NOT NULL,
	[State] [nvarchar](40) NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
	[Country] [nvarchar](40) NOT NULL,
	[Phone] [nvarchar](24) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/15/2023 4:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ProductArtUrl] [nvarchar](1024) NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202111210255284_InitialDB-setup', N'GadgetsOnline.Migrations.Configuration', 0x1F8B0800000000000400DD5CDD4E24B915BE8F947728D55512B13430B3D90D6A76459A6185320C846656B943A6CA34A554B93AB61BD11BE5C9729147CA2BC4F5EFFFB2ABAA1B361A69042EFBF3F1F1F9B37D0EFFFDF77FE63FBE6669F00231497274161E1F1E850144511E276875166EE8D337DF873FFEF0DBDFCC3FC5D96BF073D3EF43D18F8D44E42C7CA6747D3A9B91E81966801C66498473923FD1C328CF6620CE672747477F9A1D1FCF208308195610CCEF368826192C7F61BF2E7214C135DD80F43A8F614AEA76F66559A2065F4006C91A44F02CFC09C42B48C90D4A13040FABFE61709E2680D1B284E953180084720A28A3F4F42B814B8A73B45AAE590348EFB76BC8FA3D8194C07A05A75D77D7C51C9D148B9975031BA86843689E79021E7FA8B93393870FE271D8728FF1EF13E333DD16AB2E7978162E00A661204F74BA4871D149CFDEC362D041207C3A688581C94CF1EF20586C52BAC1F00CC10DC5203D086E378F6912FD056EEFF3BF4374863669CA13C7C863DF8406D6748BF335C4747B079F6A92EF6094E3F82A0E8399387A260F6F072B23ABC55D21FAE1240CBE3042C0630A5B39E018B1A439863F410431A030BE059442CCB6F12A862527151AA4190B4E75F331D1637A1406D7E0F533442BFA7C16B21FC3E032798571D352D3F015254CEDD8208A37B06F9ADBE4975F40FFBA7A68CD99168E83B8604C5A6058B0AA012A9AEE996EF7637D012FC9AAE4BABC3A9CC79B88917607D3F23B794ED6957297A2F8D076B8C4797697A735E39BF68765BEC1119BF03ED77CBC079889B148CD7CD6298A557DDA993D35A81EF7764A541330448BB8A1FB53230A5739DE8E15F1E27F8B329E7CFBAD93327ACE7A8B93A89DF602464906D230B8C5ECA7DACD7E1F06CB081480FE6BAAB7E31CD3AF38B52CEEF8E8E4E310536354CB66530C7A597D6CD48C88CA297D6C95B0D350B947A3C3AED4DDE018E20B484152C4031A0AB90E3A03A2F9AC50A9EBA3A3D3D99C742CF5F6C8D5C0B73328BC8AFA5A1477F59ECEA4F4988269FCF20524114ED655EC36F55C7DFE522FF69E8AA9BA4E93EA0E12784E83BC659E1BFB7662CF113144F2A5E1FB12FE72DAB1CED4390EB0C3FC75036A9AC7A03055A113FB59BB6B31FB9407D1F5482E45F8AAF72862175FC7678B9607F83CD900D8FCE27013304CF9DF58ED072BFCDE55BD3884F91FC86415236CE27D78CDCB0413DAE39F8FFF78B48B50FD3378AB99CFE31843422C137FB79379179CE9D54CFA7127932E2927907B9BF5362714A40B06603D26ED84CBC5DD0ADE3FA36F9F73643DF1BA1D093D67FD9495F1DC6833E139ED3D3399E9BEFC7FEFD1D2270CD03A597DA4E0E263CF09C9A3A4A44A3A617551BFB8D64F280E7A8F00D576F28708B6ABCCC1266BE65219198CC1A1EC3A6FD0054C2185C179545D802F008940AC729B2D2576A7A98D9B3A9ADA784624E90FCA4CCC8B435C38CFC21620C2E2820451D5E527284AD620ED638B34D0F36C5C2CBC9D4AFE7201D710156EBE8F0DE36968A79236A58F57F319276B7611D4288569BF6D1AD26D781D38EE45026DA1BB4451739ADD89189A39E3220386A8D54B08CD9C1849C1BE44503AFE5877DC74161AB8E57674779B36A9900F97433DFD2E62607C7DF01745FD168D26620FD2283C5D995D9FEE1D8BF7C4D8C1E519F0DC25EEE8F0F0588E3D0C0BAD4212C61CB62FECD05A2F5638A8975D124834A77E76C8AC0FFEA48E02E59514E84B483926329C2E0E12F8A2B0411CDC5D812AE35B3EF440D46EB55C8C8688264CEA41114345054730322E5046106538B789CAA2F83B62AE9FF12259562297A0B2255F64A5A2902EC12087D5112EDB3F71C10ECCD005F32A37FAA21BD7F8865B43B393165E58C21219A8A57D1A86C89788068ED89CADB3BB755C8AB383DD8D9C8899083A7D3199FB7E832F680956C9ED37F1E3D6DC1C345BABDE7E9BCFAA94ACBA613E33E46ECDAFC17A9DA01597CB55B704CB2A916BF1CDD23FBF29AB306611D1A439B5D4B633D11C831594BE16B733312C2F1D2F00058FA0B80B58C499D24DEFC30CE6B899937753EA9E3536BAE95DFCAC71987CE29526B6A9475FB2C5654578545E194B32A30E0B8A743A90026CCC925AE4E92643F6AC2B1B5293FDC4E3346DEE286D72130FD3367A5053E53709C4544DEE184282138F247C50F1E633698F9480539105256E1705CB49EC2CAED953F20C86CB41F88C238DFBDDC5E5C28E9BC375CB9E73B71EA2149A6F43CC68D5CB008F53B578C872F54429AE2B519FF71CF8D324FC6878D47C7A3772C8857613D8C03AA81E62074D437F2DF223249408F687FFF06EF6BD271EF6DC79FE18E4BFF9D6D1267E4BF9193CC7AD991FBD985A344FBF38A19DEC923078A8AED51D894BC4E0A1B8E6F7259D53C9E55089F494C509E486CB0850E5B96CF6D8ED362740D8ECB6D51D897BF4E7A1B86677ACEE159F87EA5ADD91DA57791EA86DF4884314DD5A78EA55FD64CE43D44D1E16837B00174C06D7EE194F6379594DA30755D51BB54050D5E48E51BF38F31875933B46FD7CCC63D44DFBB758E2495C3D4B76170D0E27C6AEB3CBC1B0B849D09CE3FAAFF90738A9078BB32A9F2A1A344F1A8DAF00931C78AD942D721427E52DFF1529320CDAEC02AFE5CB7731AA9028573272975644DBAB19E90A665E5F87F4D7D829F723559722B7227F49E2E26E64B9251466874587C3E53FD2459AC0E264DD74B80628798284565977E1C9D1F18954A4F77E0AE66684C4A9E63A49AE9A13376CCFA56B096AD4D9961AE89BA52454ABA11780A367807F9781D7DFF358032AD24A72C7D4A30D01D054A3C5EC173A24F951A3B11C61CA33D6158AE1EB59F8CF72F46970F5B70705E0202823AED3E028F8979DBBDED5680324D36289BCEBC176249B728D882BE7BB9126967BD78E35AAA1568F8D290D8BF7521AA6A5BD2A0E9B4408F5972C6F5144B41339D489C1200BA9A90DF2C01B54613360477651DFB2937D9112EB5D8D433D6C946518EB13464E2F17D00C71954AF9CC485BE459FD31543027A8C0D89D30F2451783E30EB9E86294C9510A2BF4BEA028701859373119B05416A1C5FDCE1F96AF7AD0627EF4C7148A1AA602556B160CFE7B6C49C26404F31507FA38E9E3B88202A30AF81709ECC8CA4D917FFF96F9F6C2E5D25ED3EBF7994E6F7ED2F69DF21D66CFBF6DA67C93ABB8FFDCF8FDE6C11B1F23BDE67C6799EF1EDAFF7F27433E36C17A77BD3339B2CEFA5EB2D63D4448CD2C0FE464C60109EFBF92CD37E4F319A7B3BF974CBEFBFA547E355B52DE3C3545DF98A15FBD24B048EC3167DB5C455ADA145753F2BE2D775F07DE06608E99FD5B6B5EBF9E7C531EBB2DEFBF2FED5F379335B15B3B97B92EC088AF22EFB766405723A0795FD6591F4D16E2FBAD0750F3DC5D13DC4D19F2EF35D7DF637FDE60C913E5F10F5D246F2DBB37FA9DA4EAABEFBFCC57707F8995B92B92AC3A88E26D1BC148F0126D9F2BF494377E4BA2A8E9229DC4AFD98EC5CC859C639A3C8188B2CF1124A4FC63013F8374539EFB1F617C856E3674BDA16CC9307B4C05DD2F9C9E6DFEB21E41A4797E53DEB9932996C0C84C8AABBD1BF4E74D92C62DDD979ABB020344E14DEB9BC7622F697103B9DAB6485F9444181350CDBE3608B887D93A6560E4062DC10B1C42DB57023FC31588B6CD33BE19A47F2344B6CF2F12B0C220233546379EFDCA6438CE5E7FF81F17D00E9890580000, N'6.4.4')
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202111221534047_UpdatedCar', N'GadgetsOnline.Migrations.Configuration', 0x1F8B0800000000000400DD5C5B6FE4B6157E2FD0FF20E8A9291C8FEDDD34A93193C019AF03A3EBB5EBF1067D5BD0123D16A2CB94E4181E14FD657DE84FEA5F28A92BAF12296934DE2040E0E1E5F0F0F03B3C87D4C7FDDF7FFE3BFFE93589BD17887094A50BFFF4F8C4F7601A646194AE17FE963C7DFB83FFD38F7FFCC3FC4398BC7ABF56EDDEB176B4678A17FE33219BF3D90C07CF3001F838890294E1EC891C0759320361363B3B39F9EBECF47406A9089FCAF2BCF9FD36255102F31FF4E7324B03B8215B10DF64218C71594E6B56B954EF134820DE80002EFC5F40B88604DFA67194C2E3A2BDEF5DC411A0BAAC60FCE47B204D330208D5F4FC33862B82B274BDDAD002103FEC3690B67B023186E50CCE9BE6B6933939639399351D2B51C116932C711478FAAEB4CE4CEEDECBC67E6D3D6ABF0FD4CE64C7669DDB70E12F0122BE270F74BE8C116BA437EF31EB74E409554735182866D87F47DE721B932D828B146E0902F19177B77D8CA3E06F70F790FD06D345BA8D635E39AA1EAD130A68D11DCA361091DD3D7C2A55BE874186C2EBD0F76662EF99DCBDEEACF42C26779D927767BEF7892A021E6358E38033C48A6408FE0253880081E11D200422BA8CD721CC2DA9E8208DC82CD58C47A147FDC8F76EC0EB4798AEC9F3C2A77FFADE55F40AC3AAA4D4E1731A51B7A39D08DAC2AE61E8CF701B90EE9975689B513F1C26E2929A69892033562588153D50EFEE96F509BC44EBDCEEFAF9F9DE3D8CF37AFC1C6D0AF7CEC1F8A56E7085B2E43E8B4BD357E55F56D9160574C0874C53F9001005B2A8CD7CD6B84AAB03D5233BFA50D9EF706EC461C6D58FACE136A62311B8CED06E28C4D9FF5BDCF1ECBBEFACDCD171D43B1405F5B09730881210FBDE1DA27F9581F607DF5B058009749F53B91C17887C4671CBE44E4FCEDEF7D96C8C6E592D8AC12F8BCACACDB0E89C5265ED848D87CA2D2A1FB6D5EE1685105D42022296116834E41AE836104DB5A2A5AE8D4E4FEBEDA431A9734C2E3A1E6E43E15DD47547B177EFF1B6948EAD609CC87C097180A24D91BD8D3D5657BCD4C3DED131D5D06972DD5E80E73CC819F35CDFC3C19E53A20FF2A5EE53813F1F7668301D29EDFCFB16943A0F91425D858C1C67DB438B39A67C11438F1452845A7D44119BB806BEB66CB947CC933780B6B8D87F0BE8E7FC0776FBDE0E3FB9ABB34398FB814C76314C079E226A5E4508938EF87CFA97937DA4EA1FC1A146BE084304316E19F8FBBD8CBBE4B65ECDA0EFF732E88A70809C6CD4BB0C13102FA980D663D25EACCCEE56D0F486BE7BCED2D613AFDD91D071D40F499ECF0DDE261C877DA05B663C55FCEF3C5ABAA401DA20ABCF146C62EC05C65910E55A4927AC26EB17E7FA210DBDCE2340B19CFC2182AE2A0DB0D1868654AA0635B02F87CEDBF412C69040EF2228AEC09700072054AD4DA712DAEB54E74D8D4E753E23AAF46765241AC52162C193ED0529A67941941235E44769106D40DC6516A9A3E3D9984DBC1E4AAEB9841B98B230DF6586E13AD443498BD265ABF98CC35A3B04354E615AEF360F6916BC4C1C2741605BEA2E69549D66F70243B3656C3060C85A9D4068B6C4400DA682A074FC695D71D359A8E792B74BB7DFD34605797F1CEAF5B78181F1EB833B14F54B34588909D0287CBA32873EDD772C3E12238B906790F735214EA7F87450D32DC3DBC358910DD23ED42552884A1D843B92BC4904B1E6C2859EEFCB3B175C26E0328898F415241C7EA99C26051520A92050ECDCDC3E2BFD6B08768828339A7C321A25AA0CB5438A98A52B7284FDDD46945188D29D5B446552FCF53CD7CE78872F63CB269FAFD5174DA9E0D4260FE764358ACB1B8138610B63E8CE51AA35BA124BDBD4929B43B5922DB668C9086541B5EEE31844BEBF3558A42DCFB1CE742CA7629DDBEC0727220944E72FA648DB1D6B052F41AABADDD175D89CAB337EBDABD775F359C1872B0BE63303716E7E03369B285D7344BAB2C45B152CBAE5B72B77725952C8980558C331ABB5AD472219026B28D5B28BB110E6F7BD97808047C0AE619661A234D3C730C3765C8DC9872975CDAA3DBA6ACDFED6044C9EF5A609F965EF2B3AB984A50BF96DBD8419B59BC7B88C2006C848515B66F13649DB296F6D922AEA192FA72AB397C2A52FBCA096ACA645A3825E26285414D9CB10F865BC24A14295379F49EBA4E4620A1E942456049715F45AC2B323FA0C9B9705008D3D275973EED24944A2F932CA2CADF830C3CB294A5CF09C7F2116E715A95F572DEC53F1AD3436AAAADE0C0EB9F46E847DB04CACFBEC85A6AE5F0B7E043E8FB0FFF0156F66DD3B7262C795E78F42EE8BDFDADB646F891EC35BBC9578D329532BED70B1B1E1C0F0A29A527B491C0F8617C515BF2D748E85CBBE8874C4E208B8E108192A9EF36287D5AE2919C262D7A5F69238CE052F8A2BB697D5902878514DA9BDA49A14C10BAA0B1DF210C5B7968E7E55321678116591C38EC1F10F842D832B77CCA7913CADAAD041AB822220285414D9CB283FF8F332CA227B19E5D77B5E465934F18EA59CB8E526F5E8F5C95B3A61CFCBD36EF7FB35E5F85B3461AC85EC250AD9D177B5C30426C7ACC1F1EA9FF1328E203B34550D6E401A3D414C0A3E9B7F76727A263D807B3B8FD1661887B1E6B6407E9126AED5C4CFC22266DD4ED29D2BFF47780996BE00143C03F4A704BC7EC3CBEAF5DA2B5758B9CDBF4E43F8BAF0FF95F73AF7AEFFF1A5EE78E4E5C1E6DC3BF1FE3DEC95583EF4F0376221FD41BA2989CEAFB27AE0C898BEF57817B52724C96F256CD7BFE9390800450C1781ACBEA21AF2442A9CE4899456F7E291549B43BABFE5E981C2711FD3EC05873A18F4DACF346F641CE4F57A69D26345F6F1CE632FEB2211CC6D3787B2DBA09DE1C091497E48D2273829CF4806EE458EAF20FA0273849708FB0323FFF8C032D26B16467A7C3068CB511E18E8630123FA0F7C3F309A60E9798056EEF7EE6279F6BF56E67B779902B97F2CA12A77DF10BF8752F347539867DEEBF3A4F7C388F546177027CBEF69971B83877E48DE794D29989C663E25ADDCFC6DD175C837C8223F2C63BC228E4DCF119F960F6EFC2AE434E61B63803B78FFEF0E432E7BC2380C5B571C4DCBACEDC9DE3E3C840A32AE3361FC2B018D81947568B4E879D82AD54D5E34955F6DA45717DF0968E6F698D1E52D32332D3FD1C4BC6E235EEB841BA98B065AF6AE9594AD57DF44426E236D7771B67523B5B272B5639949DD46F9AAE46909DF3A82B7E6C3A06EB7D2D0C7DE2E995B2529DBB2934DF4E6B74AD476589F034C79241276DF49F2BB65C3BCDD0BCF5AFDBA4B6305F76F98D23085A3752382FD8BA6290C842851B7B94E9FB22A5E491A554DA493FB0D5DB19086900B44A22710105A1D408CF347F6BF82789BDF133CC2F03ABDDD92CD96D029C3E431167C9F05BDB6F17332B9A8F3FC36BFA3C7634C81AA19B1ABC0DBF4E76D1487B5DE579ABB058308164DCB9B4AB69684DD58AE77B5A44F0A83C124A8345F9D043CC064135361F8365D8117D847B7CF187E846B10ECAA8FF46621DD0B219A7D7E19813502092E6534FDE94F8AE13079FDF1FF1CD0D2E9CA570000, N'6.4.4')
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 
GO
INSERT [dbo].[Carts] ([RecordId], [CartId], [Count], [DateCreated], [ProductId]) VALUES (1, N'7c885359-6ec6-4bea-aa83-a3c7888e93bd', 1, CAST(N'2022-10-14T15:11:00.790' AS DateTime), 4)
GO
INSERT [dbo].[Carts] ([RecordId], [CartId], [Count], [DateCreated], [ProductId]) VALUES (2, N'4b7fc53f-5146-4908-b12d-af9fa49ab799', 1, CAST(N'2022-10-17T14:48:13.357' AS DateTime), 4)
GO
INSERT [dbo].[Carts] ([RecordId], [CartId], [Count], [DateCreated], [ProductId]) VALUES (5, N'5f07006a-6771-4302-9daa-b2214e9cfad7', 1, CAST(N'2022-10-18T16:47:36.097' AS DateTime), 1)
GO
INSERT [dbo].[Carts] ([RecordId], [CartId], [Count], [DateCreated], [ProductId]) VALUES (1002, N'64c798ca-a032-4ad5-bfde-8a9a2eae7133', 1, CAST(N'2023-08-30T16:58:35.423' AS DateTime), 13)
GO
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (1, N'Mobile Phones', N'Latest collection of Mobile Phones')
GO
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (2, N'Laptops', N'Latest Laptops in 2022')
GO
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (3, N'Desktops', N'Latest Desktops in 2022')
GO
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (4, N'Audio', N'Latest audio devices')
GO
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description]) VALUES (5, N'Accessories', N'USB Cables, Mobile chargers and Keyboards etc')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (1, 7, 4, 1, CAST(899.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (2, 1003, 1, 2, CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (3, 1009, 2, 1, CAST(999.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (4, 1010, 2, 1, CAST(999.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (5, 1011, 2, 1, CAST(999.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (1, CAST(N'2013-02-01T00:00:00.000' AS DateTime), N't', N't', N't', N't', N't', N'test', N'test', N'test', N'test', N'test', CAST(1234.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (2, CAST(N'2013-02-01T00:00:00.000' AS DateTime), N'''', N'''', N'''', N'''', N'''', N'''test''', N'''test''', N'''test''', N'''test''', N'''test''', CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (3, CAST(N'2022-10-14T00:00:00.000' AS DateTime), N'''', N'''', N'''', N'''', N'''', N'''test''', N'''test''', N'''test''', N'''test''', N'''test''', CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (4, CAST(N'2022-10-14T00:00:00.000' AS DateTime), N'''', N'''', N'''', N'''', N'''', N'''test''', N'''test''', N'''test''', N'''test''', N'''test''', CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (5, CAST(N'2022-10-14T15:11:17.473' AS DateTime), N'Anonymous', N'As', N'Bh', N'1080', N'Alpharetta', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (6, CAST(N'2022-10-14T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (7, CAST(N'2022-10-17T14:50:52.120' AS DateTime), N'Anonymous', N'As', N'Bh', N'1080', N'Alpharetta', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (8, CAST(N'2022-10-17T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (9, CAST(N'2022-10-17T14:56:55.347' AS DateTime), N'Anonymous', N'As', N'Bh', N'1080', N'Alpharetta', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (10, CAST(N'2022-10-17T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (11, CAST(N'2022-10-19T00:00:00.000' AS DateTime), N'''', N'''', N'''', N'''', N'''', N'''test''', N'''test''', N'''test''', N'''test''', N'''test''', CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (12, CAST(N'2022-10-19T00:00:00.000' AS DateTime), N'''', N'''', N'''', N'''', N'''', N'''test''', N'''test''', N'''test''', N'''test''', N'''test''', CAST(20.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (13, CAST(N'2022-10-19T00:00:00.000' AS DateTime), N'''', N'''', N'''', N'''', N'''', N'''t''', N'''t''', N'''t''', N'''t''', N'''t''', CAST(2.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (14, CAST(N'2022-10-19T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (1003, CAST(N'2022-10-25T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (1004, CAST(N'2022-10-25T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (1005, CAST(N'2022-10-25T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (1006, CAST(N'2022-10-25T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (1007, CAST(N'2022-10-25T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (1008, CAST(N'2022-10-25T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (1009, CAST(N'2022-10-25T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (1010, CAST(N'2022-10-26T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [Username], [FirstName], [LastName], [Address], [City], [State], [PostalCode], [Country], [Phone], [Email], [Total]) VALUES (1011, CAST(N'2022-10-26T00:00:00.000' AS DateTime), N'A', N'A', N'B', N'1', N'A', N'GA', N'200003', N'US', N'4044444444', N'ab@test.com', CAST(0.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (1, 1, N'Phone 12', CAST(699.00 AS Decimal(18, 2)), N'/Content/Images/Mobile/1.jpg')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (2, 1, N'Phone 13 Pro', CAST(999.00 AS Decimal(18, 2)), N'/Content/Images/Mobile/2.jpg')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (3, 1, N'Phone 13 Pro Max', CAST(1199.00 AS Decimal(18, 2)), N'/Content/Images/Mobile/3.jpg')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (4, 2, N'XTS 13''', CAST(899.00 AS Decimal(18, 2)), N'/Content/Images/Laptop/1.jpg')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (5, 2, N'PC 15.5''', CAST(479.00 AS Decimal(18, 2)), N'/Content/Images/Laptop/2.jpg')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (6, 2, N'Notebook 14', CAST(169.00 AS Decimal(18, 2)), N'/Content/Images/Laptop/3.jpg')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (7, 3, N'The IdeaCenter', CAST(539.00 AS Decimal(18, 2)), N'/Content/Images/placeholder.gif')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (8, 3, N'COMP 22-df003w', CAST(389.00 AS Decimal(18, 2)), N'/Content/Images/placeholder.gif')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (9, 4, N'Bluetooth Headphones Over Ear', CAST(28.00 AS Decimal(18, 2)), N'/Content/Images/Headphones/1.png')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (10, 4, N'ZX Series ', CAST(10.00 AS Decimal(18, 2)), N'/Content/Images/Headphones/2.png')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (11, 5, N'Wireless charger', CAST(9.99 AS Decimal(18, 2)), N'/Content/Images/placeholder.gif')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (12, 5, N'Mousepad', CAST(2.99 AS Decimal(18, 2)), N'/Content/Images/placeholder.gif')
GO
INSERT [dbo].[Products] ([ProductId], [CategoryId], [Name], [Price], [ProductArtUrl]) VALUES (13, 5, N'Keyboard', CAST(9.99 AS Decimal(18, 2)), N'/Content/Images/placeholder.gif')
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
/****** Object:  Index [IX_ProductId]    Script Date: 9/15/2023 4:49:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[Carts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderId]    Script Date: 9/15/2023 4:49:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderId] ON [dbo].[OrderDetails]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 9/15/2023 4:49:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[OrderDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 9/15/2023 4:49:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Carts_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_dbo.Carts_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId]
GO
/****** Object:  StoredProcedure [dbo].[InsertOrders]    Script Date: 9/15/2023 4:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertOrders]
	-- Add the parameters for the stored procedure here
	--@OrderDate DateTime,
	@OrderId int  OUTPUT ,
	@Username nvarchar,
    @FirstName nvarchar,
    @LastName nvarchar,
    @Address nvarchar,
    @City nvarchar,
    @State nvarchar(40),
    @PostalCode nvarchar(10),
    @Country nvarchar(40),
    @Phone nvarchar(24),
    @Email nvarchar(max),
    @Total decimal(18,2)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @OrderDate1 Date
	SET NOCOUNT ON;
	SET @OrderDate1 = GETDATE()
	--SET @OrderId = 0
	
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Orders]
           (
		     [OrderDate]
           ,[Username]
           ,[FirstName]
           ,[LastName]
           ,[Address]
           ,[City]
           ,[State]
           ,[PostalCode]
           ,[Country]
           ,[Phone]
           ,[Email]
           ,[Total])
     VALUES
           (@OrderDate1
           ,@Username
           ,@FirstName
           ,@LastName
           ,@Address
           ,@City
           ,@State
           ,@PostalCode
           ,@Country
           ,@Phone
           ,@Email
           ,@Total)

SELECT @OrderId  = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[InsertOrders_Detail]    Script Date: 9/15/2023 4:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertOrders_Detail]
	-- Add the parameters for the stored procedure here
	--@OrderDate DateTime,
	@OrderId int ,
	@ProductId int,
    @Quantity int,

    @UnitPrice decimal(18,2)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @OrderDate1 Date
	SET NOCOUNT ON;
	
	
    -- Insert statements for procedure here


INSERT INTO [dbo].[OrderDetails]
           ([OrderId]
           ,[ProductId]
           ,[Quantity]
           ,[UnitPrice])
     VALUES
           (@OrderId
           ,@ProductId
           ,@Quantity
           ,@UnitPrice)




END
GO
/****** Object:  StoredProcedure [dbo].[ViewProducts]    Script Date: 9/15/2023 4:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[ViewProducts] AS
BEGIN
   SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
   BEGIN TRAN
       SELECT * FROM dbo.Products
   COMMIT TRAN 
END
GO
USE [master]
GO
ALTER DATABASE [GadgetsOnlineDB] SET  READ_WRITE 
GO