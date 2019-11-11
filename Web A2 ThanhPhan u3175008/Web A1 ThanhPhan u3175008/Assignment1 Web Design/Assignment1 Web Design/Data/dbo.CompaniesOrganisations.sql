CREATE TABLE [dbo].[CompaniesOrganisations] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [Agree]                     INT            NOT NULL,
    [CompaniesOrganisationName] NVARCHAR (MAX) NULL,
    [Date]                      DATETIME2 (7)  NOT NULL,
    [Disagree]                  INT            NOT NULL,
    [FeedBack]                  NVARCHAR (MAX) NOT NULL,
    [Heading]                   NVARCHAR (MAX) NOT NULL,
    [StarRating]                INT            NOT NULL,
    [Username]                  NVARCHAR (MAX) NULL,
    [isAgreeAdded]              BIT            NOT NULL,
    [isDisagreeAdded]           BIT            NOT NULL,
    CONSTRAINT [PK_CompaniesOrganisations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

