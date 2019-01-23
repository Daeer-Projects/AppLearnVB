CREATE TYPE [questions].[DemonstrationInsertType] AS TABLE(
DemonstrationStageInsert VARCHAR(6000) NOT NULL,
RegExInsert VARCHAR(2000) NOT NULL,
StageMarkInsert INT NOT NULL
);