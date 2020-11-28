CREATE TABLE [dbo].[Users] (
    [IdUser]       INT           IDENTITY (1, 1) NOT NULL,
    [Username]     VARCHAR (32)  NOT NULL,
    [Password]     VARCHAR (MAX) NOT NULL,
    [PasswordSalt] VARCHAR (MAX) NOT NULL,
    [Role]         VARCHAR (32)  NOT NULL,
    [FirstName]    VARCHAR (64)  NULL,
    [LastName]     VARCHAR (64)  NULL,
    [Address]      VARCHAR (64)  NULL,
    [City]         VARCHAR (64)  NULL,
    [State]        VARCHAR (32)  NULL,
    [ZipCode]      VARCHAR (32)  NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([IdUser] ASC, [Username] ASC),
    CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([Role]) REFERENCES [dbo].[Roles] ([Value])
);





