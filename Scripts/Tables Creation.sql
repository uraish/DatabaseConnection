CREATE TABLE [dbo].[tb_users](  
   [id] [int] IDENTITY(1,1) PRIMARY KEY,  
   [username] varchar(100) NOT NULL,  
   [password] varchar(100) NOT NULL
)

CREATE TABLE [dbo].[tb_scores](  
   [id] [int] IDENTITY(1,1) PRIMARY KEY,  
   [aces] int NOT NULL,  
   [twos] int NOT NULL,
   [threes] int NOT NULL,
   [userId] int FOREIGN KEY REFERENCES tb_users(id)
)

