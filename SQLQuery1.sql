﻿/*
BACKUP DATABASE "User"
TO DISK = 'C:\User.BAK'
GO 

BACKUP DATABASE [User] TO  DISK = N'C:\User.BAK' WITH NOFORMAT, INIT,  NAME = N'User-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
GO
*/

BACKUP DATABASE [User] 
TO  DISK = N'C:\xampp\User.bak' 
GO
