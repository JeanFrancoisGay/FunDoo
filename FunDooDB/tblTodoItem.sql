
IF EXISTS (SELECT 1 FROM sys.objects where name = 'tblTodoItem') DROP TABLE tblTodoItem;
GO

CREATE TABLE [dbo].[tblTodoItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(50) NOT NULL,
	Description NVARCHAR(2000) NOT NULL,
	DueDate DATETIME NULL,
	IsCompleted BIT NOT NULL DEFAULT 0,
	CreatedAt DATETIME NOT NULL DEFAULT (GETDATE()),
	UpdatedAt DATETIME NULL
);
GO

INSERT tblTodoItem (Title, Description, DueDate, IsCompleted) VALUES ('Item #1', 'My first test item (scripted)', NULL, 0)
INSERT tblTodoItem (Title, Description, DueDate, IsCompleted) VALUES ('Item #22', 'A second item, just for fun (scripted)', NULL, 0)
GO

CREATE OR ALTER PROC spTodoItem_Get
				@Id INT = NULL
AS
BEGIN
	
	SELECT	TD.Id,
			TD.Title,
			TD.Description,
			TD.DueDate,
			TD.IsCompleted
	FROM	tblTodoItem TD
	WHERE	TD.Id = ISNULL(@Id, TD.Id)

END
GO

GRANT EXEC ON spTodoItem_Get TO FunDooDbUser;
GO

CREATE OR ALTER PROC spTodoItem_Insert
				@Title NVARCHAR(50),
				@Description NVARCHAR(2000),
				@DueDate DATETIME,
				@IsCompleted BIT
AS
BEGIN
	
	INSERT	tblTodoItem
			(
			Title,
			Description,
			DueDate,
			IsCompleted
			)
	VALUES	(
			@Title,
			@Description,
			@DueDate,
			@IsCompleted
			)

END
GO

GRANT EXEC ON spTodoItem_Insert TO FunDooDbUser;
GO

CREATE OR ALTER PROC spTodoItem_Update
				@Id INT,
				@Title NVARCHAR(50),
				@Description NVARCHAR(2000),
				@DueDate DATETIME,
				@IsCompleted BIT
AS
BEGIN
	
	UPDATE	TI
		SET	Title = @Title,
			Description = @Description,
			DueDate = @DueDate,
			IsCompleted = @IsCompleted,
			UpdatedAt = GETDATE()
	FROM	tblTodoItem TI
	WHERE	Ti.Id = @Id

END
GO

GRANT EXEC ON spTodoItem_Update TO FunDooDbUser;
GO

CREATE OR ALTER PROC spTodoItem_Delete
				@Id INT
AS
BEGIN
	
	DELETE	tblTodoItem
	WHERE	Id = @Id

END
GO

GRANT EXEC ON spTodoItem_Delete TO FunDooDbUser;
GO

