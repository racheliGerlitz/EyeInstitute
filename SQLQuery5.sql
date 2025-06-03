-- מחיקת תורים קיימים ואיפוס מפתח זהות
DELETE FROM [dbo].[Appointments];
DBCC CHECKIDENT ('Appointments', RESEED, 0);

-- הגדרת משתנים
DECLARE @StartDate DATE = '2025-06-01';
DECLARE @Weeks INT = 7; -- מספר שבועות ליצירת תורים
DECLARE @DaysToGenerate INT = @Weeks * 7;

-- טבלת הרופאים וימי העבודה שלהם
DECLARE @Doctors TABLE (
    DoctorId INT,
    WorkDays VARCHAR(20) -- ימי עבודה מופרדים בפסיק, לפי מספרי ימים: 1=ראשון ... 7=שבת
);

-- הכנסת 9 רופאים עם ימי העבודה שלהם
INSERT INTO @Doctors VALUES
(11111111, '1,3,5'),
(22222222, '1,2,4'),
(33333333, '2,4,6'),
(44444444, '1,3,4'),
(55555555, '2,3,5'),
(66666666, '1,5,7'),
(77777777, '2,4,6'),
(88888888, '1,3,5'),
(99999999, '1,2,4');

-- יצירת תורים לכל רופא
DECLARE @i INT = 0;
WHILE @i < @DaysToGenerate
BEGIN
    DECLARE @CurrentDate DATE = DATEADD(DAY, @i, @StartDate);
    DECLARE @DayOfWeek INT = DATEPART(WEEKDAY, @CurrentDate); -- 1=ראשון, 7=שבת

    -- התאמת פורמט ל-Sunday=1, Monday=2 וכו' (SQL Server לעיתים מגדיר אחרת)
    SET DATEFIRST 7; -- Sunday = 1

    DECLARE @DoctorId INT;
    DECLARE @WorkDays VARCHAR(20);
    DECLARE DoctorCursor CURSOR FOR
        SELECT DoctorId, WorkDays FROM @Doctors;
    OPEN DoctorCursor;
    FETCH NEXT FROM DoctorCursor INTO @DoctorId, @WorkDays;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- לבדוק אם הרופא עובד ביום השבוע הזה
        IF EXISTS (
            SELECT 1
            FROM STRING_SPLIT(@WorkDays, ',')
            WHERE TRY_CAST(value AS INT) = @DayOfWeek
        )
        BEGIN
            -- הוספת 4 תורים ביום הזה לרופא הזה (09:00 עד 10:00)
            INSERT INTO [dbo].[Appointments] (Date, Hour, DoctorId, ClientId) VALUES
                (CAST(@CurrentDate AS DATETIME) + '09:00', 9, @DoctorId, NULL),
                (CAST(@CurrentDate AS DATETIME) + '09:15', 9, @DoctorId, NULL),
                (CAST(@CurrentDate AS DATETIME) + '09:30', 9, @DoctorId, NULL),
                (CAST(@CurrentDate AS DATETIME) + '09:45', 9, @DoctorId, NULL);
        END

        FETCH NEXT FROM DoctorCursor INTO @DoctorId, @WorkDays;
    END
    CLOSE DoctorCursor;
    DEALLOCATE DoctorCursor;

    SET @i = @i + 1;
END
select* from Appointments