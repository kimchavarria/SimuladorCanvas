﻿CREATE DATABASE DB_SC;
GO

--TABLA ESTUDIANTE
CREATE TABLE STUDENT (
    student_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    address VARCHAR(100) NOT NULL,
    dob DATE NOT NULL,
    number VARCHAR(60) NOT NULL,
    email VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL
);

--TABLA FACULTAD
CREATE TABLE FACULTY (
    faculty_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    address VARCHAR(100) NOT NULL,
    dob DATE NOT NULL,
    number VARCHAR(60) NOT NULL,
    email VARCHAR(100) NOT NULL,
    department VARCHAR(50) NOT NULL,
    password VARCHAR(100) NOT NULL
);

--TABLA LOGIN
CREATE TABLE LOGIN (
    login_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    username VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    user_type VARCHAR(20) NOT NULL 
);

--TABLA CURSOS
CREATE TABLE COURSE (
    course_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    faculty_id INT NOT NULL,
    title VARCHAR(100) NOT NULL,
    description VARCHAR(200) NOT NULL,
    credits INT NOT NULL,
    initialDate DATE NOT NULL,
    finalDate DATE NOT NULL,
    FOREIGN KEY (faculty_id) REFERENCES FACULTY(faculty_id)
);
--adding a column that will set a limit to students that can be register 
ALTER TABLE COURSE ADD maxStudents INT NOT NULL; 

--TABLE REGISTRO 
CREATE TABLE REGISTRO (
    registro_id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    student_id INT NOT NULL,
    course_id INT NOT NULL,
    student_name VARCHAR(100), 
    student_email VARCHAR(100), 
    FOREIGN KEY (student_id) REFERENCES STUDENT(student_id),
    FOREIGN KEY (course_id) REFERENCES COURSE(course_id)
);
--AGREGAR ESTE CONSTRAINT PARA QUE NO SE PUEDA REPETIR ESTUDIANTE EN UN CURSO
ALTER TABLE REGISTRO ADD CONSTRAINT UC_REGISTRO UNIQUE (student_id, course_id);
--agrega course name a la tabla 
ALTER TABLE REGISTRO
ADD course_name VARCHAR(100),
CONSTRAINT FK_REGISTRO_COURSE FOREIGN KEY (course_id) REFERENCES COURSE(course_id);

GO
UPDATE REGISTRO
SET course_name = c.title
FROM REGISTRO r
INNER JOIN COURSE c ON r.course_id = c.course_id;

-- Actualizar valores nulos en course_name
UPDATE REGISTRO
SET course_name = c.title
FROM REGISTRO r
INNER JOIN COURSE c ON r.course_id = c.course_id
WHERE r.course_name IS NULL;

-- Agregar restricción de no nulo (NOT NULL) a course_name
ALTER TABLE REGISTRO
ALTER COLUMN course_name VARCHAR(100) NOT NULL;
