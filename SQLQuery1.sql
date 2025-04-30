------INSERT INTO [dbo].[Clients] 
------    ([Id], [Name], [AddressId], [Age], [PhoneNumber], [LeftEyeNumber], [RightEyeNumber], [Cylinder], [Email], [BackgroundDiseases], [HealthInsurance])
------VALUES
------    ('1234567890', 'Yael Cohen', 1, 25, '0501234567', -2.5, -3.0, -1.0, 'yael.cohen@example.com', 0, 'Maccabi'),
------    ('2345678901', 'David Levi', 2, 30, '0542345678', -1.0, -1.5, -0.5, 'david.levi@example.com', 1, 'Clalit'),
------    ('3456789012', 'Rivka Mizrachi', 3, 35, '0523456789', -2.0, -2.5, -1.0, 'rivka.mizrachi@example.com', 0, 'Meuhedet'),
------    ('4567890123', 'Moshe Azoulay', 4, 40, '0504567890', -1.5, -2.0, -0.5, 'moshe.azoulay@example.com', 1, 'Leumit'),
------    ('5678901234', 'Shira Peretz', 5, 28, '0535678901', -3.0, -3.5, -1.5, 'shira.peretz@example.com', 0, 'Maccabi'),
------    ('6789012345', 'Eli Katz', 6, 32, '0546789012', -2.2, -2.8, -1.2, 'eli.katz@example.com', 1, 'Clalit'),
------    ('7890123456', 'Noa Baruch', 7, 27, '0507890123', -1.8, -2.3, -0.7, 'noa.baruch@example.com', 0, 'Meuhedet'),
------    ('8901234567', 'Ronen Shalom', 8, 45, '0528901234', -2.6, -3.1, -1.1, 'ronen.shalom@example.com', 1, 'Leumit'),
------    ('9012345678', 'Tamar Dror', 9, 29, '0539012345', -3.4, -3.9, -1.6, 'tamar.dror@example.com', 0, 'Maccabi'),
------    ('1123456789', 'Avi Harel', 10, 33, '0501123456', -2.1, -2.7, -1.3, 'avi.harel@example.com', 1, 'Clalit');
------מילוי רופאים
----INSERT INTO [dbo].[Doctors] 
----    ([Id], [Name], [AddressId], [Specialization])
----VALUES
----    ('123456782', 'Dr. Yael Cohen', 1, 'רופא'),
----    ('234567893', 'Dr. David Levi', 2, 'אופטמטריסט'),
----    ('345678904', 'Dr. Rivka Mizrachi', 3, 'לייזר'),
----    ('456789015', 'Dr. Moshe Azoulay', 4, 'קטרט'),
----    ('567890126', 'Dr. Shira Peretz', 5, 'רופא'),
----    ('678901237', 'Dr. Eli Katz', 6, 'אופטמטריסט'),
----    ('789012348', 'Dr. Noa Baruch', 7, 'לייזר'),
----    ('890123459', 'Dr. Ronen Shalom', 8, 'קטרט'),
----    ('901234560', 'Dr. Tamar Dror', 9, 'רופא'),
----    ('112345671', 'Dr. Avi Harel', 10, 'אופטמטריסט'),
----    ('223456782', 'Dr. Sarah Levy', 11, 'לייזר'),
----    ('334567893', 'Dr. Daniel Green', 12, 'קטרט');
----select* from [dbo].[Doctors]
----מילוי תורים
--TRUNCATE TABLE [dbo].[Appointments];
--DECLARE @StartDate DATE = GETDATE(); -- תאריך התחלה (היום)
--DECLARE @EndDate DATE = DATEADD(DAY, 7, @StartDate); -- תאריך סיום (שבוע מהיום)
--DECLARE @DoctorId NCHAR(10);
--DECLARE @CurrentDate DATE;
--DECLARE @StartTime TIME;
--DECLARE @EndTime TIME;
--DECLARE @NextAppointment TIME;

---- לולאה על כל הרופאים
--DECLARE DoctorsCursor CURSOR FOR
--SELECT [Id]
--FROM [dbo].[Doctors];

--OPEN DoctorsCursor;

--FETCH NEXT FROM DoctorsCursor INTO @DoctorId;

--WHILE @@FETCH_STATUS = 0
--BEGIN
--    -- הגדרת שעות עבודה ייחודיות לכל רופא
--    IF @DoctorId = '123456782' BEGIN SET @StartTime = '09:00'; SET @EndTime = '12:00'; END
--    ELSE IF @DoctorId = '234567893' BEGIN SET @StartTime = '10:00'; SET @EndTime = '13:00'; END
--    ELSE IF @DoctorId = '345678904' BEGIN SET @StartTime = '14:00'; SET @EndTime = '17:00'; END
--    ELSE IF @DoctorId = '456789015' BEGIN SET @StartTime = '08:00'; SET @EndTime = '11:00'; END
--    ELSE IF @DoctorId = '567890126' BEGIN SET @StartTime = '12:00'; SET @EndTime = '15:00'; END
--    ELSE IF @DoctorId = '678901237' BEGIN SET @StartTime = '15:00'; SET @EndTime = '18:00'; END
--    ELSE IF @DoctorId = '789012348' BEGIN SET @StartTime = '09:30'; SET @EndTime = '12:30'; END
--    ELSE IF @DoctorId = '890123459' BEGIN SET @StartTime = '11:00'; SET @EndTime = '14:00'; END
--    ELSE IF @DoctorId = '901234560' BEGIN SET @StartTime = '10:30'; SET @EndTime = '13:30'; END
--    ELSE IF @DoctorId = '112345671' BEGIN SET @StartTime = '13:00'; SET @EndTime = '16:00'; END
--    ELSE IF @DoctorId = '223456782' BEGIN SET @StartTime = '08:30'; SET @EndTime = '11:30'; END
--    ELSE IF @DoctorId = '334567893' BEGIN SET @StartTime = '14:30'; SET @EndTime = '17:30'; END

--    -- לולאה על כל יום בשבוע הקרוב
--    SET @CurrentDate = @StartDate;
--    WHILE @CurrentDate < @EndDate
--    BEGIN
--        -- יצירת תורים בהפרש של רבע שעה
--        SET @NextAppointment = @StartTime;

--        WHILE @NextAppointment < @EndTime
--        BEGIN
--            INSERT INTO [dbo].[Appointments] ([Date], [Hour], [DoctorId], [ClientId])
--            VALUES (@CurrentDate, @NextAppointment, @DoctorId, NULL);

--            SET @NextAppointment = DATEADD(MINUTE, 15, @NextAppointment); -- הוספת רבע שעה
--        END;

--        SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate); -- יום הבא
--    END;

--    -- מעבר לרופא הבא
--    FETCH NEXT FROM DoctorsCursor INTO @DoctorId;
--END;

--CLOSE DoctorsCursor;
--DEALLOCATE DoctorsCursor;
select* from [dbo].[Appointments]
