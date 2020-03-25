DECLARE @UserName NVARCHAR = ''
DECLARE @RoleName NVARCHAR = ''

DECLARE @userId NVARCHAR = (SELECT Id FROM AspNetUsers WHERE UserName = @UserName)
DECLARE @roleId NVARCHAR = (SELECT Id FROM AspNetRoles WHERE Name = @RoleName)

INSERT INTO AspNetUserRoles VALUES (@userId, @roleId)