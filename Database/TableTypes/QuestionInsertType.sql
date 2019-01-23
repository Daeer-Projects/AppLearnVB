CREATE TYPE [questions].[QuestionInsertType] AS TABLE(
SelectedSubjectID INT NOT NULL,
SelectedCurriculumID INT NOT NULL,
SelectedKeyStageID INT NOT NULL,
SelectedExplanationID INT NOT NULL,
NewQuestion VARCHAR(200) NOT NULL,
NewAnswer VARCHAR(1500) NOT NULL,
AmountOfStepsSet INT NOT NULL,
TotalMarksSet INT NOT NULL,
NewFalseAnswerA VARCHAR(1500) NOT NULL,
NewFalseAnswerB VARCHAR(1500) NOT NULL,
NewFalseAnswerC VARCHAR(1500) NOT NULL,
NewSearchString VARCHAR(300) NULL,
NewWebLink VARCHAR(300) NULL
);
