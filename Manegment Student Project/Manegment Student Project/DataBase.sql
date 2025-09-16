USE Student;
GO

CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Gender CHAR(1) CHECK (Gender IN ('M','F')),
    DateOfBirth DATE, -- 2002-05-14
    Phone NVARCHAR(15),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Teachers (
    TeacherID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) ,
    Phone NVARCHAR(15),
    HireDate DATE,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Courses (
    CourseID INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(100) NOT NULL,
    Credits INT CHECK (Credits > 0),
    TeacherID INT NULL,
    CONSTRAINT FK_Course_Teacher FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Enrollments (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    EnrollDate DATE DEFAULT GETDATE(),
    Grade DECIMAL(4,2) NULL,
    CONSTRAINT FK_Enroll_Student FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
    CONSTRAINT FK_Enroll_Course FOREIGN KEY (CourseID) REFERENCES Courses(CourseID) ON DELETE CASCADE,
    CONSTRAINT UQ_Student_Course UNIQUE (StudentID, CourseID)
);

INSERT INTO Students (FirstName, LastName, Gender, DateOfBirth, Phone)
VALUES 
('Ahmed', 'Hassan', 'M', '2002-05-14', '0791111111'),
('Sara', 'Ali', 'F', '2003-09-21', '0792222222'),
('Omar', 'Khaled', 'M', '2001-12-02', '0793333333'),
('Laila', 'Mohammed', 'F', '2004-03-15', '0794444444');


INSERT INTO Teachers (FirstName, LastName, Email, Phone, HireDate)
VALUES
('Khaled', 'Saleh', 'khaled.saleh@university.com', '0781111111', '2015-09-01'),
('Nadia', 'Hussein', 'nadia.hussein@university.com', '0782222222', '2018-02-15'),
('Yousef', 'Odeh', 'yousef.odeh@university.com', '0783333333', '2020-01-10');

INSERT INTO Courses (CourseName, Credits, TeacherID)
VALUES
('Programming 1', 3, 1),       -- Khaled Saleh
('Mathematics', 4, 2),         -- Nadia Hussein
('Database Systems', 3, 1),    -- Khaled Saleh
('Physics', 4, 3);             -- Yousef Odeh

INSERT INTO Enrollments (StudentID, CourseID, Grade)
VALUES (1, (SELECT CourseID FROM Courses WHERE CourseName = 'Programming 1'), 85.50);

INSERT INTO Enrollments (StudentID, CourseID, Grade)
VALUES (1, (SELECT CourseID FROM Courses WHERE CourseName = 'Mathematics'), 90.00);

INSERT INTO Enrollments (StudentID, CourseID, Grade)
VALUES (2, (SELECT CourseID FROM Courses WHERE CourseName = 'Programming 1'), 78.25);

INSERT INTO Enrollments (StudentID, CourseID, Grade)
VALUES (2, (SELECT CourseID FROM Courses WHERE CourseName = 'Database Systems'), 88.00);

INSERT INTO Enrollments (StudentID, CourseID, Grade)
VALUES (3, (SELECT CourseID FROM Courses WHERE CourseName = 'Mathematics'), 92.75);

INSERT INTO Enrollments (StudentID, CourseID, Grade)
VALUES (3, (SELECT CourseID FROM Courses WHERE CourseName = 'Physics'), 81.50);

INSERT INTO Enrollments (StudentID, CourseID, Grade)
VALUES (4, (SELECT CourseID FROM Courses WHERE CourseName = 'Physics'), 89.00);