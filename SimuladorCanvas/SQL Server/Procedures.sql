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

--procedimiento para registrar un estudiante a un curso 
GO
CREATE PROCEDURE RegistrarEstudianteACurso
    @student_id INT,
    @course_id INT
AS
BEGIN
    -- Declare variables to store student name and email
    DECLARE @student_name VARCHAR(100);
    DECLARE @student_email VARCHAR(100);

    -- Retrieve student name and email based on student ID
    SELECT @student_name = firstName + ' ' + lastName, @student_email = email
    FROM STUDENT
    WHERE student_id = @student_id;

    -- Check if the student exists
    IF @student_name IS NOT NULL AND @student_email IS NOT NULL
    BEGIN
        -- Verificar si el curso tiene cupo disponible
        DECLARE @maxStudents INT;
        SELECT @maxStudents = maxStudents
        FROM COURSE
        WHERE course_id = @course_id;

        DECLARE @currentStudents INT;
        SELECT @currentStudents = COUNT(*)
        FROM REGISTRO
        WHERE course_id = @course_id;

        IF @currentStudents >= @maxStudents
        BEGIN
            PRINT 'El curso ya está lleno. No se puede registrar más estudiantes.';
            RETURN;
        END;

        -- Insertar el registro si hay campo disponible
        INSERT INTO REGISTRO (student_id, course_id, student_name, student_email)
        VALUES (@student_id, @course_id, @student_name, @student_email);

        PRINT 'El estudiante ha sido registrado exitosamente en el curso.';
    END
    ELSE
    BEGIN
        PRINT 'El estudiante no existe o no tiene nombre y correo asociados.';
    END;
END;

--procedure to eliminate a student from the table registro
GO
CREATE PROCEDURE EliminarEstudianteDeCurso
    @student_id INT,
    @course_id INT
AS
BEGIN
    -- Verificar si el estudiante está registrado en el curso
    IF EXISTS (
        SELECT 1
        FROM REGISTRO
        WHERE student_id = @student_id AND course_id = @course_id
    )
    BEGIN
        -- Eliminar al estudiante del registro del curso
        DELETE FROM REGISTRO
        WHERE student_id = @student_id AND course_id = @course_id;

        PRINT 'El estudiante ha sido eliminado exitosamente del curso.';
    END
    ELSE
    BEGIN
        PRINT 'El estudiante no está registrado en este curso.';
    END;
END;
