CREATE PROCEDURE GetHighestScoredAssessment
AS
BEGIN
    SELECT TOP 1
        ta.assessment_id,
        a.type,
        a.total_marks,
        a.passing_marks,
        a.weightage,
        a.criteria,
        a.description,
        a.title
    FROM
        dbo.taken_assessment ta
    JOIN
        dbo.assessment a ON ta.assessment_id = a.assessment_id
    ORDER BY
        ta.scored_points DESC
END

drop procedure GetHighestScoredAssessment


