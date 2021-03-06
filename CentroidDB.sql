USE [Centroid]
GO
/****** Object:  Table [dbo].[Abouts]    Script Date: 12/12/2019 4:05:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abouts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AboutUs] [nvarchar](max) NOT NULL,
	[Vision] [nvarchar](max) NOT NULL,
	[Mission] [nvarchar](max) NOT NULL,
	[Values] [nvarchar](max) NULL,
	[CoreBusiness] [nvarchar](max) NOT NULL,
	[Experience] [nvarchar](max) NOT NULL,
	[Expertise] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Abouts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[RoleId] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Careers]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Careers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CareerMsg] [nvarchar](max) NOT NULL,
	[Active] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address1] [nvarchar](max) NOT NULL,
	[Address2] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Fax] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Facebook] [nvarchar](max) NOT NULL,
	[Twitter] [nvarchar](max) NOT NULL,
	[LinkedIn] [nvarchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Educations]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Educations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EducationalInstitution] [nvarchar](max) NOT NULL,
	[Discipline] [nvarchar](max) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Highest] [bit] NOT NULL,
	[PersonalInfoId] [int] NOT NULL,
	[EducationLevel] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Educations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Homes]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Homes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Homes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobApplications]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobApplications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplyDate] [datetime] NOT NULL,
	[ProfileId] [int] NOT NULL,
	[JobId] [int] NOT NULL,
 CONSTRAINT [PK_JobApplications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobTitle] [nvarchar](max) NOT NULL,
	[JobDetails] [nvarchar](max) NOT NULL,
	[JobType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeyRecords]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeyRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecordText] [nvarchar](max) NOT NULL,
	[RecordImage] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_KeyRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalInfoes]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalInfoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[Nationality] [nvarchar](max) NULL,
	[Phone1] [nvarchar](max) NULL,
	[Phone2] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
 CONSTRAINT [PK_PersonalInfoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileDocuments]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileDocuments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Document] [nvarchar](max) NOT NULL,
	[DocType] [nvarchar](50) NOT NULL,
	[ProfileId] [int] NOT NULL,
 CONSTRAINT [PK_ProfileDocuments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectTitle] [nvarchar](max) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Client] [nvarchar](max) NOT NULL,
	[ClientLogo] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QHSEs]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QHSEs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Vision] [nvarchar](max) NOT NULL,
	[Mission] [nvarchar](max) NOT NULL,
	[QhsePolicy] [nvarchar](max) NOT NULL,
	[QhsePolicyAr] [nvarchar](max) NOT NULL,
	[QhseIMS] [nvarchar](max) NOT NULL,
	[Hse] [nvarchar](max) NOT NULL,
	[IsoCertificates] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_QHSEs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceDetails]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[ServiceId] [int] NOT NULL,
 CONSTRAINT [PK_ServiceDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceHead] [nvarchar](max) NOT NULL,
	[ServiceFoot] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkExperiences]    Script Date: 12/12/2019 4:05:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkExperiences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Employer] [nvarchar](max) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[JobTitle] [nvarchar](max) NOT NULL,
	[PersonalInfoId] [int] NOT NULL,
 CONSTRAINT [PK_WorkExperiences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Abouts] ON 

INSERT [dbo].[Abouts] ([Id], [AboutUs], [Vision], [Mission], [Values], [CoreBusiness], [Experience], [Expertise]) VALUES (1, N'<p style="text-align: justify;">Centroid Technical Services (CTS) is a specialized company in the provision of Project Management Consultancy (PMC) services with core expertise in Oil &amp; Gas surface Facilities. Set up in 2005 as a joint venture between Sudan National Petroleum Company (SUDAPET) and OGP Technical Services a subsidiary of PETRONAS of Malaysia, it became a fully owned subsidiary of SUDAPET in 2014, with head office located in Khartoum.</p>', N'<h2><strong>OUR VISION</strong></h2>
<p>The Preferred Technical Service Provider in the Oil and Gas Industry</p>', N'<h2><strong>OUR MISSION</strong></h2>
<p>We are strategic business entity contributing to the development of the oil and gas industry in Sudan. Our core business is PMC, O&amp;M and Specialized Technical Services. We build Sudanese capability. We are cost competitive without compromising quality</p>', N'<ul>
<li title=" to delight our stakeholders through, shared responsibility with team members.">Our Services doing whatever it takes...</li>
<li title="that reflects shareholders values and employee well being as well.">Doing the right thing...</li>
<li title="by providing healthy environment that fosters personal development and professional growth.">Developing our people...</li>
<li title="by measuring ourselves against the highest standards of integrity and fiscal responsibility.">Being accountable...</li>
<li title="We&rsquo;re honest, transparent and committed to do what&rsquo;s best for our stakeholders and the company.">Acting with integrity...</li>
<li title="We are committed to build an encouraging, caring, and supportive environment and respect for each other.">Cohesiveness...</li>
<li title="We hire awesome people. You can move sideways, you can move up, and there are always new opportunities to learn.">Graw...</li>
<li title="Achieving long-term growth &amp; profitability.">Sustainability...</li>
</ul>', N'<h2><strong>OUR CORE BUSINESS</strong></h2>
<p>Centroid is a technical services provider, however, our core business is in the provision of Project Management &amp; Consultancy Services (PMC) and Projects Consultancy Services (PCS) with a very rich experience and proven expertise in the oil and gas facilities.</p>', N'<h2>OUR EXPERIENCE</h2>
<ul>
<li>Managing all aspects of even the most complex projects, from engineering to procurement to construction, commissioning and hand-over.</li>
<li>Serving major O&amp;G companies in Sudan.</li>
<li>Strong HSE track records with more than 50 millions man-hours without LTI, Zero LTIF.</li>
<li>On time quality project delivery.</li>
</ul>', N'<h2>OUR EXPERTISE</h2>
<ul class="list-unstyled">
<li>Managing the bid process, procurement and negotiating awarding contracts.</li>
<li>Conceptual, basic and detailed engineering design.</li>
<li>Project constructions management and field administration.</li>
<li>Contracts and Warranties Management.</li>
<li>Field Improvement Projects (&lsquo;FIP&rsquo;).</li>
<li>Environment/HSE.</li>
<li>Quality Managem</li>
</ul>')
SET IDENTITY_INSERT [dbo].[Abouts] OFF
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4a43cb88-ad38-463f-82d4-8fb604103a47', N'websiteadmin@centroidtech.com', 0, N'AEG4s1cslcFA3pu0T9S8aCdstn9BBekkVfzN8JIueL6lsaADuqANvWUiom4Nz0Hd0Q==', N'0e15aed4-8c5f-4c0e-8c11-ba8524569e1a', NULL, 0, 0, NULL, 0, 0, N'websiteadmin@centroidtech.com')
SET IDENTITY_INSERT [dbo].[Careers] ON 

INSERT [dbo].[Careers] ([Id], [CareerMsg], [Active]) VALUES (1, N'<p>One of the main objectives behind the establishment of CTS was to develop the Sudanese national capabilities in the field of the PMC services for the petroleum industry in Sudan. Most of our current staff joined the company as on-job trainees; and through-out their exposure within the company&rsquo;s projects, they shaped and developed a strong experience with which the company has successfully increased the ratio of the Sudanese national workforce from the company&rsquo;s total manpower.</p>', 1)
SET IDENTITY_INSERT [dbo].[Careers] OFF
SET IDENTITY_INSERT [dbo].[ContactUs] ON 

INSERT [dbo].[ContactUs] ([Id], [Address1], [Address2], [Phone], [Fax], [Email], [Facebook], [Twitter], [LinkedIn], [Active]) VALUES (1, N'Head Office: Block No. 1. Lot 144. Garden City Burry East, Khartom - Sudan ', N' Head Office: Block No. 1. Lot 144. Garden City Burry East, Khartom - Sudan ', N'+249-155-117-729', N'+249-155-295-038', N'info@centroidtech.com', N'https://www.facebook.com/Centroid-Technical-Services-Co-Ltd-165049610217997/?__tn__=%2Cd%2CP-R&eid=ARAEP8IlfmXFhorLOEGRFNP9kEX7KD9e_tK8vy7YsxQP_Hgi9QMOmPDdk3poND9AZhRqQ5HVV9Ncqt7p', N'https://www.linkedin.com/company/centroid-technical-services-co-ltd-/about/', N'https://www.linkedin.com/company/centroid-technical-services-co-ltd-/about/', 1)
SET IDENTITY_INSERT [dbo].[ContactUs] OFF
SET IDENTITY_INSERT [dbo].[Educations] ON 

INSERT [dbo].[Educations] ([Id], [EducationalInstitution], [Discipline], [StartDate], [EndDate], [Highest], [PersonalInfoId], [EducationLevel], [Country]) VALUES (1012, N'Alneelain University', N'Information System', CAST(N'2013-01-01T00:00:00.000' AS DateTime), CAST(N'2016-12-31T00:00:00.000' AS DateTime), 1, 3012, N' Master', N'Sudan')
SET IDENTITY_INSERT [dbo].[Educations] OFF
SET IDENTITY_INSERT [dbo].[Homes] ON 

INSERT [dbo].[Homes] ([Id], [Name], [Image], [Description], [Active]) VALUES (3, N'Image One', N'~/Content/images/slides\5a58e7a7-7f37-4896-b4c6-e10d9a0cc0af.jpg', N'<p>Image One</p>', 1)
INSERT [dbo].[Homes] ([Id], [Name], [Image], [Description], [Active]) VALUES (4, N'Image Two', N'~/Content/images/slides\d318dde7-5040-4fab-99a7-78181ec9a04b.jpg', N'<p>Iamge Two</p>', 1)
INSERT [dbo].[Homes] ([Id], [Name], [Image], [Description], [Active]) VALUES (5, N'Image Three', N'~/Content/images/slides\cbb1e33e-5357-450f-aec9-3fd90b5d57d6.jpg', N'<p>Image Three</p>', 1)
INSERT [dbo].[Homes] ([Id], [Name], [Image], [Description], [Active]) VALUES (6, N'Image Four', N'~/Content/images/slides\3527d3af-e0ed-4117-b3b9-ce07aa31f280.jpg', N'<p>Image Four</p>', 1)
INSERT [dbo].[Homes] ([Id], [Name], [Image], [Description], [Active]) VALUES (7, N'Image Five', N'~/Content/images/slides\7439b0df-f31a-4949-b8e3-4b4b9381be61.jpg', N'<p>Image Five</p>', 1)
INSERT [dbo].[Homes] ([Id], [Name], [Image], [Description], [Active]) VALUES (8, N'Image Six', N'~/Content/images/slides\ae6ca686-5f71-4c6c-81c6-ebae41d1db41.jpg', N'<p>Image Six</p>', 1)
INSERT [dbo].[Homes] ([Id], [Name], [Image], [Description], [Active]) VALUES (9, N'Image Seven', N'~/Content/images/slides\4bd5fe8e-b625-416a-9535-e429e816af33.jpg', N'<p>Image Seven</p>', 1)
INSERT [dbo].[Homes] ([Id], [Name], [Image], [Description], [Active]) VALUES (10, N'Image Nine', N'~/Content/images/slides\ded9a5b9-29e6-4bc3-a074-2528cfe2654e.jpg', N'<p>Image Nine</p>', 1)
SET IDENTITY_INSERT [dbo].[Homes] OFF
SET IDENTITY_INSERT [dbo].[KeyRecords] ON 

INSERT [dbo].[KeyRecords] ([Id], [RecordText], [RecordImage]) VALUES (1, N'Centroid PMC Market Leader for Oil & Gas Industry in Sudan', N'~/Content/images/KeyRecords/Leader.jpg')
INSERT [dbo].[KeyRecords] ([Id], [RecordText], [RecordImage]) VALUES (4, N'Over 4 billion USD managed projects', N'~/Content/images/KeyRecords/Projects.png')
INSERT [dbo].[KeyRecords] ([Id], [RecordText], [RecordImage]) VALUES (5, N'ISO Certified Company', N'~/Content/images/KeyRecords/ISO.jpg')
INSERT [dbo].[KeyRecords] ([Id], [RecordText], [RecordImage]) VALUES (6, N'Over 37 million safe man-hours without lost time injuries.

Accumulated hours since July 2007', N'~/Content/images/KeyRecords/Safety.jpg')
SET IDENTITY_INSERT [dbo].[KeyRecords] OFF
SET IDENTITY_INSERT [dbo].[PersonalInfoes] ON 

INSERT [dbo].[PersonalInfoes] ([Id], [FullName], [Email], [Password], [DateOfBirth], [Nationality], [Phone1], [Phone2], [Gender]) VALUES (3012, N'Hassona Hassan Atallah Ali', N'hassona@sudapet.com', N'Pa$$w0rd', N'2019-11-05', N'Sudan', N'+249912336542', N'249915112012', N'Male')
SET IDENTITY_INSERT [dbo].[PersonalInfoes] OFF
SET IDENTITY_INSERT [dbo].[ProfileDocuments] ON 

INSERT [dbo].[ProfileDocuments] ([Id], [Name], [Document], [DocType], [ProfileId]) VALUES (1013, N'Resume', N'~/Content/JobApplicationDoc/3012_Resume.pdf', N'Resume', 3012)
INSERT [dbo].[ProfileDocuments] ([Id], [Name], [Document], [DocType], [ProfileId]) VALUES (1014, N'Photo', N'~/Content/JobApplicationDoc/3012_ Photo.jpg', N'Photo', 3012)
SET IDENTITY_INSERT [dbo].[ProfileDocuments] OFF
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (1, N'Provision of Projects Consultancy Services for Upstream Facilities', CAST(N'2009-04-05T00:00:00.000' AS DateTime), CAST(N'2020-04-04T00:00:00.000' AS DateTime), N'GNPOC', N'~/Content/images/Projects\1b393229-29f3-4972-8a83-762a67dd7809.jpg', N'~/Content/images/Projects\86adf66b-033d-4d55-bc84-921e4d2433d6.jpg', N'<p>During the last seven years, the PCS team of CTS has substantially contributed in the development of oil fields within Block 1, 2 and 4 of the Muglad Basin (fields include Heglig, Unity, Al-Nar, Al-Toor, Toma South, Bamboo, Muga, Diffra, Neem and other satellite fields).</p>
<p>The PCS scope of work included the development and upgrading of:</p>
<ul>
<li>Central Processing Facility</li>
<li>Field Processing Facilities</li>
<li>Storage tanks</li>
<li>Power Generation &amp; Distribution Systems</li>
<li>Pump Station &amp; Export Pipeline</li>
<li>Main crude oil export pipeline</li>
<li>SCADA &amp; Communication</li>
<li>Infrastructure (maintenance workshops, warehouse, roads, airport, operation base camp, etc).</li>
<li>Marine terminal.</li>
</ul>')
INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (2, N'Provision of Projects Consultancy Services for Upstream Facilities', CAST(N'2017-04-17T00:00:00.000' AS DateTime), CAST(N'2020-04-04T00:00:00.000' AS DateTime), N'OPCO', N'~/Content/images/Projects\9b7c94d0-3afb-4f4a-b7f6-16845a1bfaa7.png', N'~/Content/images/Projects\020246c6-959f-452d-80c3-1235fc5ede7f.png', N'<p>.</p>')
INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (3, N'Provision of Project Management Consultancy Services ', CAST(N'2018-04-04T00:00:00.000' AS DateTime), CAST(N'2020-04-04T00:00:00.000' AS DateTime), N'SHPOC', N'~/Content/images/Projects\8e1d110e-dbab-4fc9-9706-8dcf5f9ab35f.jpg', N'~/Content/images/Projects\eae5e4ae-e786-4fe6-ab80-8ce5ec6589ed.jpg', N'<p>.</p>')
INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (4, N'Provision of Project Management consultancy Services for forthcoming Projects', CAST(N'2015-02-01T00:00:00.000' AS DateTime), CAST(N'2021-11-07T00:00:00.000' AS DateTime), N'PETROENERGY', N'~/Content/images/Projects\d292782a-e725-44fa-bc08-27492323c1a4.png', N'~/Content/images/Projects\76e62ab0-adf1-4161-87e3-9bf6e18fee7c.png', N'<p>.</p>')
INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (5, N'Provision of Project Management Consultancy Services', CAST(N'2016-05-09T00:00:00.000' AS DateTime), CAST(N'2021-05-08T00:00:00.000' AS DateTime), N'RPOC', N'~/Content/images/Projects\48e7cbc5-e66e-4be2-b14e-df2881bfd564.jpg', N'~/Content/images/Projects\807f94e4-7c62-484a-bae5-bc3bad8adeaa.jpg', N'<p>.</p>')
INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (6, N'Provision of Consultancy for Pipeline Repair Project Phase II', CAST(N'2016-09-02T00:00:00.000' AS DateTime), CAST(N'2019-08-02T00:00:00.000' AS DateTime), N'BAPCO', N'~/Content/images/Projects\0985e177-4922-4167-b020-58535a9db283.jpg', N'~/Content/images/Projects\73c82a34-b960-4a82-884b-4d2143342263.jpg', N'<p>.</p>')
INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (7, N'Provision of Engineering & Consultancy Services', CAST(N'2018-08-30T00:00:00.000' AS DateTime), CAST(N'2020-08-29T00:00:00.000' AS DateTime), N'SPC/DGD  ', N'~/Content/images/Projects\23f93de5-0e0f-449f-961d-9b5132de6690.jpg', N'~/Content/images/Projects\2eacf70b-86a9-4b09-a9a8-fec6a46480aa.jpg', N'<p>.</p>')
INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (8, N'Provision of Project Management Consultancy Services ', CAST(N'2007-06-01T00:00:00.000' AS DateTime), CAST(N'2012-05-01T00:00:00.000' AS DateTime), N'PDOC', N'~/Content/images/Projects\f7de5bb5-7fe4-4dfc-ab98-f1991bfde5bd.png', N'~/Content/images/Projects\98efe8ce-bfd8-4e97-9353-863c4cf2dd52.png', N'<p>.</p>')
INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (9, N'Provision of Project Management Consultancy Services', CAST(N'2011-06-01T00:00:00.000' AS DateTime), CAST(N'2012-04-01T00:00:00.000' AS DateTime), N'WNPOC', N'~/Content/images/Projects\6917129f-e8bf-41e8-bb11-59282de39957.png', N'~/Content/images/Projects\8f74273a-b77d-4f25-8bde-cad868651fd9.png', N'<p style="language: en-MY; line-height: 107%; text-align: left; direction: ltr; unicode-bidi: embed; mso-line-break-override: none; word-break: normal; punctuation-wrap: hanging; margin: 0pt 0in 0pt 0in;"><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; font-weight: bold; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Client:</span><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;"> White Nile Petroleum Operating Company (WNPOC)</span></p>
<p style="language: en-MY; line-height: 107%; text-align: left; direction: ltr; unicode-bidi: embed; mso-line-break-override: none; word-break: normal; punctuation-wrap: hanging; margin: 0pt 0in 0pt 0in;"><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; font-weight: bold; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Location: </span><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Block 5B, Sudan</span></p>
<p style="language: en-MY; line-height: 107%; text-align: left; direction: ltr; unicode-bidi: embed; mso-line-break-override: none; word-break: normal; punctuation-wrap: hanging; margin: 0pt 0in 0pt 0in;"><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; font-weight: bold; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Duration: </span><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">June 2011 - April 2012</span></p>')
INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (10, N'Provision of Operation & Maintenance (O&M)', CAST(N'2009-11-01T00:00:00.000' AS DateTime), CAST(N'2012-04-01T00:00:00.000' AS DateTime), N'WNPOC', N'~/Content/images/Projects\7dd78267-f36b-4e1e-ad62-a1c6181e93e0.png', N'~/Content/images/Projects\b5c47534-e33a-499b-9104-e1158ba0df33.png', N'<p style="language: en-MY; line-height: 107%; text-align: left; direction: ltr; unicode-bidi: embed; mso-line-break-override: none; word-break: normal; punctuation-wrap: hanging; margin: 0pt 0in 0pt 0in;"><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; font-weight: bold; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Client:</span><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;"> White Nile Petroleum Operating Company (WNPOC)</span></p>
<p style="language: en-MY; line-height: 107%; text-align: left; direction: ltr; unicode-bidi: embed; mso-line-break-override: none; word-break: normal; punctuation-wrap: hanging; margin: 0pt 0in 0pt 0in;"><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; font-weight: bold; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Location: </span><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Tharjath</span><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;"> CPF, Sudan</span></p>
<p style="language: en-MY; line-height: 107%; text-align: left; direction: ltr; unicode-bidi: embed; mso-line-break-override: none; word-break: normal; punctuation-wrap: hanging; margin: 0pt 0in 0pt 0in;"><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; font-weight: bold; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Duration: </span><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">November 2009 - April 2012</span></p>')
INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (11, N'Provision of Project Management Consultancy Services Phase I', CAST(N'2011-12-01T00:00:00.000' AS DateTime), CAST(N'2014-03-01T00:00:00.000' AS DateTime), N'Star-Oil', N'~/Content/images/Projects\59943661-211c-4fec-b8e1-5aab262e0db3.jpg', N'~/Content/images/Projects\10ba4610-156f-4144-a1c7-5422e6c7bb68.jpg', N'<p style="language: en-MY; line-height: 107%; text-align: left; direction: ltr; unicode-bidi: embed; mso-line-break-override: none; word-break: normal; punctuation-wrap: hanging; margin: 0pt 0in 0pt 0in;"><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; font-weight: bold; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Client:</span><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;"> Star-Oil Petroleum Operating Company (STAROIL)</span></p>
<p style="language: en-MY; line-height: 107%; text-align: left; direction: ltr; unicode-bidi: embed; mso-line-break-override: none; word-break: normal; punctuation-wrap: hanging; margin: 0pt 0in 0pt 0in;"><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; font-weight: bold; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Location: </span><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Block 17, Sudan</span></p>
<p style="language: en-MY; line-height: 107%; text-align: left; direction: ltr; unicode-bidi: embed; mso-line-break-override: none; word-break: normal; punctuation-wrap: hanging; margin: 0pt 0in 0pt 0in;"><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; font-weight: bold; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;">Duration:</span><span style="font-size: 14.0pt; font-family: ''Yu Gothic''; mso-ascii-font-family: ''Yu Gothic''; mso-fareast-font-family: ''Yu Gothic''; mso-bidi-font-family: Arial; color: black; mso-color-index: 13; mso-font-kerning: 12.0pt; language: en-US; mso-style-textfill-type: solid; mso-style-textfill-fill-themecolor: dark1; mso-style-textfill-fill-color: black; mso-style-textfill-fill-alpha: 100.0%;"> December 2011 &ndash; March 2014</span></p>')
INSERT [dbo].[Projects] ([Id], [ProjectTitle], [StartDate], [EndDate], [Client], [ClientLogo], [Image], [Description]) VALUES (12, N'Provision of Project Management Consultancy Services Phase II ', CAST(N'2015-01-01T00:00:00.000' AS DateTime), CAST(N'2018-02-01T00:00:00.000' AS DateTime), N'Star-Oil', N'~/Content/images/Projects\10eed9b8-1278-4a55-a64c-a238ea47f84a.jpg', N'~/Content/images/Projects\30174cb3-e9dc-4e31-90c8-f448ef4b9655.jpg', N'<p style="line-height: 107%; margin: 0pt 0in; direction: ltr; unicode-bidi: embed; word-break: normal;"><span style="font-size: 14pt; font-family: ''Yu Gothic''; font-weight: bold;">Client:</span><span style="font-size: 14pt; font-family: ''Yu Gothic'';"> Star-Oil Petroleum Operating Company (STAROIL)</span></p>
<p style="line-height: 107%; margin-top: 0pt; margin-bottom: 0pt; margin-left: 0in; direction: ltr; unicode-bidi: embed; word-break: normal;"><span style="font-size: 14pt; font-family: ''Yu Gothic''; font-weight: bold;">Location: </span><span style="font-size: 14pt; font-family: ''Yu Gothic'';">Block 17, </span><span style="font-size: 14pt; font-family: ''Yu Gothic'';">Sudan8</span></p>
<p style="line-height: 107%; margin-top: 0pt; margin-bottom: 0pt; margin-left: 0in; direction: ltr; unicode-bidi: embed; word-break: normal;"><span style="font-size: 14pt; font-family: ''Yu Gothic''; font-weight: bold;">Duration:</span><span style="font-size: 14pt; font-family: ''Yu Gothic'';"> December </span><span style="font-size: 14pt; font-family: ''Yu Gothic'';">January 2015 &ndash; February 2018</span></p>')
SET IDENTITY_INSERT [dbo].[Projects] OFF
SET IDENTITY_INSERT [dbo].[QHSEs] ON 

INSERT [dbo].[QHSEs] ([Id], [Vision], [Mission], [QhsePolicy], [QhsePolicyAr], [QhseIMS], [Hse], [IsoCertificates]) VALUES (1, N'<p>To be a Center of Excellence in attaining World Class QHSE Performance</p>', N'<ul class="list-unstyled">
<li>To develop a corporate culture in which QHSE is equally important to all business activities.</li>
<li>To ensure that all our activities are carried out in a quality, healthy, safe and environmentally responsible manner.</li>
<li>To educate and influence employees so that they embrace quality, health, safety and environmental policies, practices and procedures.</li>
<li>To continually improve our QHSE performance.</li>
</ul>', N'<h2>QHSE POLICY STATEMENT</h2>
<p style="margin: 0px; padding: 0px; font-size: 16.8px; font-family: futura;"><strong>Centroid Technical Services Co. Ltd. (CTS) management considers quality of services, the health and safety of workers and protection of the environment as fundamental to achieving business excellence. CTS is committed to:</strong></p>
<ul>
<li>Provide the necessary processes for continually improving the Quality, Health, Safety and Environment within all CTS activities.</li>
</ul>
<ul>
<li>Apply effective management system to prevent and minimize injury, occupational health hazards, property damage and environmental impacts.</li>
</ul>
<ul>
<li>Ensure that the facilities it designs, builds and the services it provides are in accordance with appropriate legal requirements, industry standards and best practices.</li>
</ul>
<ul>
<li>Provide the necessary resources, organization, system and training and shall communicate with employees, clients, contractors, customers, suppliers and the public the appropriate matters on Quality, Health, Safety and Environment.</li>
</ul>
<ul>
<li>Record non-conformances and incidents at all levels, share lessons learnt to prevent recurrence and ensure that efficient work practices are established.</li>
</ul>
<ul>
<li>Ensure that contingency plans are in place and maintained to deal with emergencies and shall periodically review the quality, health, safety and environment management system and practices to ensure their continual improvement.</li>
</ul>
<ul>
<li>Empower all employees to stop any work that does not follow safe work practices.</li>
</ul>
<ul>
<li>Make QHSE excellence, both an individual and management responsibility.</li>
</ul>
<p style="margin: 0px; padding: 0px;"><strong>CTS expect all its employees and contractors to strictly adhere to this policy at all times.</strong></p>', N'<h2 style="margin: 15px 0px 20px; padding: 0px; font-variant-numeric: normal; font-variant-east-asian: normal; font-stretch: normal; font-size: 25.2px; line-height: 20px; font-family: futura; text-align: right;"><strong style="margin: 0px; padding: 0px;">سياسة الجودة والصحة والسلامة والبيئة</strong></h2>
<p style="margin: 15px 0px 20px; padding: 0px; font-variant-numeric: normal; font-variant-east-asian: normal; font-stretch: normal; font-size: 20.16px; line-height: 20px; font-family: futura; text-align: right;">تعتبر إدارة شركة سنترويد للخدمات الفنية المحدودة أن جودة الخدمات التى تقدمها الشركة لعملاءها وصحة وسلامة عامليها بالإضافة إلى حماية البيئة هى من صميم أساسيات العمل لتحقيق التميز و الإتقان، لذلك فإن إدراة الشركة تتعهد بالاّتى</p>
<ul dir="rtl" style="text-align: right;">
<li>توفير كل الخطوات المطلوبة والضرورية لضمان الجودة والصحة والسلامة والبيئة فى كل نشاطات الشركة</li>
<li>تطبيق نظام إدارى فعَال لحماية وتقليل الأصابات والأخطار التى تهدد الصحة المهنية والممتلكات والبيئة .</li>
<li>ضمان أن تصميم وبناء المنشاّت والخدمات الهندسية التى تقدمها الشركة للعملاء يتم وفق المتطلبات القانونية و أفضل معاييرالصناعة والمواصفات المقبولة عالمياً .</li>
<li>توفير الموارد الضرورية والتنظيم والتدريب والتأهيل والإتصال بالعاملين بالشركة والعملاء والمقاولين والزبائن لمناقشة المسائل المتعلقة بالجودة والصحة والسلامة والبيئة .</li>
<li>تسجيل كل حالات عدم التوافق مع متطلبات الجودة والحوادث فى كل المستويات ومشاركة الخبرات والدروس المستفادة مع الاّخرين لمنع حدوث هذه الحوادث مره أخرى مع ضمان أن جميع خطوات العمل قد تم إنشاءها بصورة سليمة .</li>
<li>ضمان أن خطة الطوارئ موجودة ومحفوظه بصورة جيدة للتعامل مع الحالات الطارئة ، كما تضمن الشركة إجراء فحص دورى لنظام الجودة والصحة والسلامة والبيئة وكل النشاطات ذات الصلة لضمان إستمرارية تحسينها .</li>
<li>تشجيع جميع العاملين على إيقاف أى عمل لا يتبع إجراءات السلامة المهنية .</li>
<li>تحقيق التميز فى الجودة والصحة والسلامة والبيئة يعتبر مسؤلية&nbsp; تضامنية للجميع .</li>
</ul>
<p dir="rtl">تتوقع إدارة الشركة من جميع العاملين بالشركة والمقاولين الإلتزام بهذه السياسات فى جميع الأوقات</p>', N'~/Content/images/QHSE\903f668b-03f7-44cc-b086-05a2563930d6.pdf', N'<h2>HEALTH, SAFETY AND ENVIRONMENT</h2>
<p>CTS&rsquo;s commitment to Quality, Health, Safety and Environment starts with the senior leaders of the organization and it is the responsibility of everyone in the organization including newest recruit. This commitment enhanced its reputation and image, enabling to maintain and expand its reputable customer base.<br />CTS is committed to protect environment, determined to prevent accidents, and to be a leader in workplace safety, and will continue to move forward through a strategy which is based on high standards of integrity and performance. All of our people, facilities and partnerships, are accountable for pursuing these goals by driving the QHSE Management Program. All business units are aligned with CTS&rsquo; corporate QHSE Management System. All the relevant policies and objectives are defined and clearly stated. The organizational structure and associated responsibilities for all parts of the business are highlighted, and the arrangements put in place to ensure that all policies are implemented, controlled, monitored and improved as required.<br />CTS recognizes that a major factor in its business success is the emphasis it has placed on Quality, Health, Safety, and Environment (QHSE) as key elements of all of its activities. CTS provides its clients with services which are of the highest professional and technical standards and which comply with client specific QHSE requirements and local statutory requirements. Doing the job right and doing it safely is our primary business objective. Everyone within the organization, as well as contractors, has an essential part to play in ensuring that CTS continues to improve all aspects of its operational activities.<br />Facilities are routinely audited to verify compliance with CTS Corporate QHSE Performance Standards, policies, procedures, and the laws and regulations of applicable governing entities. Global programs for safety observation and resource efficiency have been set up and are already delivering results. CTS believe that the solid foundations of management systems and programs have helped to drive the progress the organization has made.<br />CTS maintains an integrated Quality, Health, Safety and Environmental Management system based on three international standards, which are ISO9001:2008 for Quality, ISO14001:2004 for environmental and OHSAS18001:2007 for occupational health and safety.</p>', N'~/Content/images/QHSE/IsoCertificates')
SET IDENTITY_INSERT [dbo].[QHSEs] OFF
SET IDENTITY_INSERT [dbo].[ServiceDetails] ON 

INSERT [dbo].[ServiceDetails] ([Id], [Description], [Image], [ServiceId]) VALUES (1, N'<h2>Central Processing Facilities</h2>
<p>Central Processing Facilities</p>', N'~/Content/images/Services\89f7aeb5-ecf3-4d79-a457-b02eb306a382.png', 1)
INSERT [dbo].[ServiceDetails] ([Id], [Description], [Image], [ServiceId]) VALUES (2, N'<h2>Field Processing Facilities</h2>
<p>Field Processing Facilities</p>', N'~/Content/images/Services\d74c6975-2254-4551-bfc9-f90ee7b0c17f.png', 1)
INSERT [dbo].[ServiceDetails] ([Id], [Description], [Image], [ServiceId]) VALUES (3, N'<h2>Field Surface Facilities</h2>
<p>Field Surface Facilities</p>', N'~/Content/images/Services\81c82153-086d-49c9-a43f-6a26bfb62f2d.png', 1)
INSERT [dbo].[ServiceDetails] ([Id], [Description], [Image], [ServiceId]) VALUES (4, N'<h2>Power</h2>
<p>Power Generation &amp; Distribution Systems</p>', N'~/Content/images/Services\6f26e8cf-4fad-48d9-bb91-d6643f44ac6f.png', 1)
INSERT [dbo].[ServiceDetails] ([Id], [Description], [Image], [ServiceId]) VALUES (5, N'<h2>Pipelines</h2>
<p>Crude Oil Pipelines</p>', N'~/Content/images/Services\3a4c1728-c3ce-458c-b955-5878eaac2766.png', 1)
INSERT [dbo].[ServiceDetails] ([Id], [Description], [Image], [ServiceId]) VALUES (6, N'<h2>Infrastructure</h2>
<p>Infrastructure</p>', N'~/Content/images/Services\1fe5f157-447a-4460-9787-0a284692575d.png', 1)
SET IDENTITY_INSERT [dbo].[ServiceDetails] OFF
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [ServiceHead], [ServiceFoot]) VALUES (1, N'<p>Our service is customer-oriented with an ultimate goal of maximizing our clients&rsquo; value &amp; benefits out of our provided PMC service. With a fully dedicated teams of interdisciplinary engineers, we help our clients controlling and managing all the aspects of their projects.</p>', N'<p>In Centroid, we have specialized teams of experienced professionals who are fully dedicated to help our clients managing all the technical and contractual aspects of their oilfield surface facilities projects. For a specific project, Centroid provides PMC services for the all Engineering, Procurements, Construction and Commissioning (EPCC) phases of the project till the project&rsquo;s close-out and making the facility ready to support the clients&rsquo; production.</p>')
SET IDENTITY_INSERT [dbo].[Services] OFF
SET IDENTITY_INSERT [dbo].[WorkExperiences] ON 

INSERT [dbo].[WorkExperiences] ([Id], [Employer], [StartDate], [EndDate], [JobTitle], [PersonalInfoId]) VALUES (1017, N'Sudapet', CAST(N'2006-05-01T00:00:00.000' AS DateTime), CAST(N'2008-09-01T00:00:00.000' AS DateTime), N'Senior DM Supprt', 3012)
SET IDENTITY_INSERT [dbo].[WorkExperiences] OFF
ALTER TABLE [dbo].[Careers] ADD  CONSTRAINT [DF_Careers_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRole]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUser]
GO
ALTER TABLE [dbo].[Educations]  WITH CHECK ADD  CONSTRAINT [FK_PersonalInfoEducation] FOREIGN KEY([PersonalInfoId])
REFERENCES [dbo].[PersonalInfoes] ([Id])
GO
ALTER TABLE [dbo].[Educations] CHECK CONSTRAINT [FK_PersonalInfoEducation]
GO
ALTER TABLE [dbo].[JobApplications]  WITH CHECK ADD  CONSTRAINT [FK_JobApplicationJob] FOREIGN KEY([JobId])
REFERENCES [dbo].[Jobs] ([Id])
GO
ALTER TABLE [dbo].[JobApplications] CHECK CONSTRAINT [FK_JobApplicationJob]
GO
ALTER TABLE [dbo].[JobApplications]  WITH CHECK ADD  CONSTRAINT [FK_JobApplicationProfile] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[PersonalInfoes] ([Id])
GO
ALTER TABLE [dbo].[JobApplications] CHECK CONSTRAINT [FK_JobApplicationProfile]
GO
ALTER TABLE [dbo].[ProfileDocuments]  WITH CHECK ADD  CONSTRAINT [FK_DocumentProfile] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[PersonalInfoes] ([Id])
GO
ALTER TABLE [dbo].[ProfileDocuments] CHECK CONSTRAINT [FK_DocumentProfile]
GO
ALTER TABLE [dbo].[ServiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_ServiceServiceDetails] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
GO
ALTER TABLE [dbo].[ServiceDetails] CHECK CONSTRAINT [FK_ServiceServiceDetails]
GO
ALTER TABLE [dbo].[WorkExperiences]  WITH CHECK ADD  CONSTRAINT [FK_WorkExperiencePersonalInfo] FOREIGN KEY([PersonalInfoId])
REFERENCES [dbo].[PersonalInfoes] ([Id])
GO
ALTER TABLE [dbo].[WorkExperiences] CHECK CONSTRAINT [FK_WorkExperiencePersonalInfo]
GO
