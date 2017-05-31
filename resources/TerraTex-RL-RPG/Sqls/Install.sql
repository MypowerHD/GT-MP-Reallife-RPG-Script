CREATE TABLE user
(
    ID INT PRIMARY KEY AUTO_INCREMENT,
	UUID VARCHAR(128),
    Nickname VARCHAR(150),
    EMail VARCHAR(150),
    Forename VARCHAR(150),
    Lastname VARCHAR(150),
    Password VARCHAR(1025),
    Salt VARCHAR(512),
    Gender ENUM('male', 'female'),
    Birthday DATE,
	History TEXT,
    Created_at TIMESTAMP DEFAULT current_timestamp(),
    Last_Login TIMESTAMP,
	Last_Fingerprint TEXT
);
CREATE UNIQUE INDEX user_Nickname_uindex ON user (Nickname);
