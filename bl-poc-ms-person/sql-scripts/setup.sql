-- `bl-poc-ms-person`.persons definition

CREATE TABLE bl-poc-ms-person.persons (
  Id int NOT NULL AUTO_INCREMENT,
  Name VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  Email VARCHAR(50) NOT NULL,
  Phone VARCHAR(10) NOT NULL,
  BirthDay date NOT NULL,
  MaritalStatus VARCHAR(50) NOT NULL,
  IsActive tinyint(1) NOT NULL,
  PRIMARY KEY (Id)
);