SELECT 
	CSM.Id
	,CSM,Name
	,ANU.UserName
FROM CharacterSheetModel AS CSM
JOIN AspNetUser AS ANU ON ANU.Id = CSM.UserId