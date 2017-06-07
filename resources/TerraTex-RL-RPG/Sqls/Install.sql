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
	Admin INT DEFAULT 0,
	Dev INT DEFAULT 0,
    Created_at TIMESTAMP DEFAULT current_timestamp(),
    Last_Login TIMESTAMP,
	Last_Fingerprint TEXT
);
CREATE UNIQUE INDEX user_Nickname_uindex ON user (Nickname);

CREATE TABLE user_data
(
    UserID INT PRIMARY KEY,
    PlayTime INT DEFAULT 0,
    CONSTRAINT user_data_user_ID_fk FOREIGN KEY (UserID) REFERENCES user (ID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE user_inventory
(
    UserID INT PRIMARY KEY,
    Money INT DEFAULT 0,
    BankAccount INT DEFAULT 0,
    Phone INT DEFAULT 0,
    CONSTRAINT user_inventory_user_ID_fk FOREIGN KEY (UserID) REFERENCES user (ID) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE UNIQUE INDEX user_inventory_Phone_uindex ON user_inventory (Phone);

ALTER TABLE user_inventory ALTER COLUMN Phone SET DEFAULT NULL ;

