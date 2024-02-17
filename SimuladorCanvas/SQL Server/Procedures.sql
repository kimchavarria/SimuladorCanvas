USE DB_SC;
GO
-- Procedimiento para iniciar sesión
CREATE PROCEDURE UserLogin
    @username VARCHAR(100),
    @password VARCHAR(100),
    @user_type VARCHAR(20),
    @success BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @user_type = 'student'
    BEGIN
        IF EXISTS (SELECT 1 FROM STUDENT WHERE email = @username AND [password] = @password)
        BEGIN
            INSERT INTO LOGIN (username, [password], user_type)
            VALUES (@username, @password, @user_type);
            SET @success = 1;
        END
        ELSE
        BEGIN
            SET @success = 0;
        END
    END
    ELSE IF @user_type = 'faculty'
    BEGIN
        IF EXISTS (SELECT 1 FROM FACULTY WHERE email = @username AND [password] = @password)
        BEGIN
            INSERT INTO LOGIN (username, [password], user_type)
            VALUES (@username, @password, @user_type);
            SET @success = 1;
        END
        ELSE
        BEGIN
            SET @success = 0;
        END
    END
END;