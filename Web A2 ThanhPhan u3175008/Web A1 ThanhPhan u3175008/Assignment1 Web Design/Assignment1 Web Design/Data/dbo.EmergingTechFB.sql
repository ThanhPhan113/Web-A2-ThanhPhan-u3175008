CREATE TABLE [dbo].[EmergingTechFB] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [Agree]                  INT            NOT NULL,
    [Date]                   DATETIME2 (7)  NOT NULL,
    [Disagree]               INT            NOT NULL,
    [EmergingTechnologyName] NVARCHAR (MAX) NULL,
    [FeedBack]               NVARCHAR (MAX) NOT NULL,
    [Heading]                NVARCHAR (MAX) NOT NULL,
    [StarRating]             INT            NOT NULL,
    [Username]               NVARCHAR (MAX) NULL,
    [isAgreeAdded]           BIT            NOT NULL,
    [isDisagreeAdded]        BIT            NOT NULL,
    CONSTRAINT [PK_EmergingTechFB] PRIMARY KEY CLUSTERED ([Id] ASC)
);

