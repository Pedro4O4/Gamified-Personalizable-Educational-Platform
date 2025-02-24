ALTER TABLE [dbo].[learner]
ADD CONSTRAINT DF_Learner_BirthDate DEFAULT '1900-01-01' FOR [birth_date];

GO

ALTER TABLE [dbo].[learner]
ALTER COLUMN [birth_date] DATE NOT NULL;

GO
 select * from [dbo].[learner]

 -- Drop the dependent index
IF EXISTS (SELECT name FROM sys.indexes WHERE name = 'ix_learner3')
BEGIN
    DROP INDEX ix_learner3 ON [dbo].[learner];
END

GO

-- Alter the column
ALTER TABLE [dbo].[learner]
ALTER COLUMN [birth_date] DATE NOT NULL;

GO

-- Recreate the index
CREATE INDEX ix_learner3 ON [dbo].[learner]([birth_date]);

GO

-- Verify the changes
SELECT * FROM [dbo].[learner];


-- Drop the dependent index
IF EXISTS (SELECT name FROM sys.indexes WHERE name = 'ix_learner3')
BEGIN
    DROP INDEX ix_learner3 ON [dbo].[learner];
END

GO

-- Update existing rows to have a default value if they are null
UPDATE [dbo].[learner]
SET [birth_date] = '1900-01-01'
WHERE [birth_date] IS NULL;

GO

-- Alter the column
ALTER TABLE [dbo].[learner]
ALTER COLUMN [birth_date] DATE NOT NULL;

GO

-- Recreate the index
CREATE INDEX ix_learner3 ON [dbo].[learner]([birth_date]);

GO

-- Verify the changes
SELECT * FROM [dbo].[learner];
