#DB Tables
GO
CREATE TABLE tbl_Users(UserID INT PRIMARY KEY IDENTITY(1,1),NAME VARCHAR(100),Email VARCHAR(200),Password varchar(100))
GO
CREATE TABLE tbl_Cities(CityID INT PRIMARY KEY IDENTITY(1,1),CityName varchar(100),Country varchar(100))

#Procedures
--For Validate UserID
GO
CREATE PROCEDURE SP_CheckAuthentication
(
@Email varchar(200),
@Password varchar(100)
)
AS
BEGIN
	SELECT * FROM tbl_Users where Email=@Email and Password=@Password
END
--Save City
CREATE PROCEDURE SP_SaveCity
(
@CityId INT,
@CityName VARCHAR(100)
@Country VARCHAR(100)
)
AS
BEGIN
	INSERT INTO tbl_Cities(CityName,Country) values(@CityName,@Country)
END
--Get Cities
CREATE PROCEDURE SP_GetAllCities
AS
BEGIN
	SELECT * FROM tbl_Cities
END

#API Calls in Postman
1. For getting Bearer Token
Post Method
https://localhost:44304/Token
Body:{
    "Email":"raj@gmail.com",
    "Password":"1234"
}

2. For getting Cities
Get method
Pass Bearer token in Authorization tab
https://localhost:44304/values

3.For Saving City
Post Method
Pass Bearer token in Authorization tab
Body: {
    "CityId":0,
    "CityName":"Delhi",
    "Country":"India"
}

