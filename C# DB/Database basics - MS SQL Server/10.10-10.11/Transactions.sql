CREATE TRIGGER tr_TownsUpdate ON Towns FOR UPDATE -- Executes after the operation
AS
  IF (EXISTS(
        SELECT * FROM inserted
        WHERE Name IS NULL OR LEN(Name) = 0))
  BEGIN
    RAISERROR('Town name cannot be empty.', 16, 1)
    ROLLBACK
    RETURN
  END

UPDATE Towns SET Name='' WHERE TownId=1

CREATE TABLE Accounts(
  Username varchar(10) NOT NULL PRIMARY KEY,
  [Password] varchar(20) NOT NULL,
  Active char(1) NOT NULL DEFAULT 'Y'
)
CREATE TRIGGER tr_AccountsDelete ON Accounts -- Replaces The Operation
INSTEAD OF DELETE
AS
UPDATE a SET Active = 'N'
  FROM Accounts AS a JOIN DELETED d 
    ON d.Username = a.Username
 WHERE a.Active = 'Y'  
