CREATE TABLE Department (
    DepNum INT PRIMARY KEY,
    Name_department NVARCHAR(255)
);

CREATE TABLE ProjectGroup (
    ProjNum INT PRIMARY KEY,
    Name_project NVARCHAR(255),
    DepNum INT,
    FOREIGN KEY (DepNum) REFERENCES Department(DepNum)

);

CREATE TABLE Users (
    ID INT PRIMARY KEY,
    First_name NVARCHAR(255),
    Last_name NVARCHAR(255),
    passworde NVARCHAR(255),
    confirm_password NVARCHAR(255),
    email NVARCHAR(255),
    DepNum INT,
    ProjNum INT,
    FOREIGN KEY (DepNum) REFERENCES Department(DepNum),
    FOREIGN KEY (ProjNum) REFERENCES ProjectGroup (ProjNum),


);


CREATE TABLE Task (
    TaskNum INT PRIMARY KEY,
    Name NVARCHAR(255),
    description TEXT,
    is_completed BIT,
    due_date DATE,
    ProjNum INT,
	ID INT,
    FOREIGN KEY (ProjNum) REFERENCES ProjectGroup(ProjNum),
	FOREIGN KEY (ID) REFERENCES Users (ID)
);

CREATE TABLE SubmissionDate (
    SubNum INT PRIMARY KEY,
    Submission_name NVARCHAR(255),
    description TEXT,
    due_date DATE,
    ProjNum INT,
	ID INT,
    FOREIGN KEY (ProjNum) REFERENCES ProjectGroup(ProjNum),
	FOREIGN KEY (ID) REFERENCES Users (ID)

);

CREATE TABLE Files (
    FileNum INT PRIMARY KEY,
    file_name NVARCHAR(255),
    file_path NVARCHAR(255),
    ProjNum INT,
	ID INT,
    FOREIGN KEY (ProjNum) REFERENCES ProjectGroup(ProjNum),
	FOREIGN KEY (ID) REFERENCES Users (ID)

);

CREATE TABLE CalendarEvent (
    EventNum INT PRIMARY KEY,
    title NVARCHAR(255),
    description TEXT,
    start_date DATE,
    end_date DATE,
    eventType NVARCHAR(255),
    start_hour TIME,
    end_hour TIME,
    ProjNum INT,
	ID INT,
    FOREIGN KEY (ProjNum) REFERENCES ProjectGroup(ProjNum),
	FOREIGN KEY (ID) REFERENCES Users (ID)
);

CREATE TABLE AddedBy (
    EventNum INT,
    ID INT,
    PRIMARY KEY (EventNum, ID),
    FOREIGN KEY (EventNum) REFERENCES CalendarEvent(EventNum),
    FOREIGN KEY (ID) REFERENCES Users(ID)
);

CREATE TABLE UploadedBy (
    ID INT,
    FileNum INT,
    PRIMARY KEY (ID, FileNum),
    FOREIGN KEY (ID) REFERENCES Users(ID),
    FOREIGN KEY (FileNum) REFERENCES Files(FileNum)
);


CREATE TABLE WrittenBy (
    TaskNum INT,
    ID INT,
    PRIMARY KEY (TaskNum, ID),
    FOREIGN KEY (TaskNum) REFERENCES Task(TaskNum),
    FOREIGN KEY (ID) REFERENCES Users(ID),
);

CREATE TABLE AddTo (
    TaskNum INT,
    EventNum INT,
    PRIMARY KEY (TaskNum, EventNum),
    FOREIGN KEY (TaskNum) REFERENCES Task(TaskNum),
    FOREIGN KEY (EventNum) REFERENCES CalendarEvent(EventNum)
);

