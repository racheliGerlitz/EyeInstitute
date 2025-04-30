DECLARE @StartDate DATE = GETDATE(); -- תאריך התחלה (היום)
DECLARE @EndDate DATE = DATEADD(DAY, 7, @StartDate); -- תאריך סיום (שבוע מהיום)

-- הגדר שעות עבודה כלליות (לדוגמה, 08:00 עד 16:00)
DECLARE @StartHour TIME = '08:00:00';
DECLARE @EndHour TIME = '12:00:00';

-- לולאה על כל הימים בשבוע הקרוב
DECLARE @CurrentDate DATE = @StartDate;

WHILE @CurrentDate < @EndDate
BEGIN
    -- הוספת תורים לכל רופא
    INSERT INTO [dbo].[Appointments] ([Date], [Hour], [DoctorId], [ClientId])
    SELECT 
        @CurrentDate AS [Date],
        DATEADD(MINUTE, Number * 15, CAST(@StartHour AS DATETIME)) AS [Hour],
        D.[Id] AS [DoctorId],
        NULL AS [ClientId]
    FROM [dbo].[Doctors] D
    CROSS APPLY (
        SELECT TOP (DATEDIFF(MINUTE, @StartHour, @EndHour) / 15) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS Number
    ) AS TimeSlots;

    -- עבור ליום הבא
    SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate);
END;