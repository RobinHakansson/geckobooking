USE [Gecko]
GO

INSERT INTO [dbo].[Users]([UserName],[Password],[FirstName],[LastName],[Email],[Phone],[CreatedDate],[FailedPasswordAttemptCount],[IsLockedOut],[LockedOutDate],[Comment],[IsDeleted])
     VALUES('Pelle01', '123', 'Pelle', 'Svanslös', 'pelle@svanslos.se', '0123-45678', '2014-08-05', 0, '0', null, '', '0')
GO
INSERT INTO [dbo].[Users]([UserName],[Password],[FirstName],[LastName],[Email],[Phone],[CreatedDate],[FailedPasswordAttemptCount],[IsLockedOut],[LockedOutDate],[Comment],[IsDeleted])
     VALUES('Kalle01', '123', 'Kalle', 'Anka', 'kalle@anka.se', '0123-45678', '2014-08-06', 0, '0', null, '', '0')
GO
INSERT INTO [dbo].[Users]([UserName],[Password],[FirstName],[LastName],[Email],[Phone],[CreatedDate],[FailedPasswordAttemptCount],[IsLockedOut],[LockedOutDate],[Comment],[IsDeleted])
     VALUES('Superman01', '123', 'Stål', 'Mannen', 'suuper@man.se', '0123-45678', '2014-08-07', 0, '0', null, '', '0')
GO


INSERT INTO [dbo].[Courts]([Name],[HourlyFee],[Status],[IsDeleted])
     VALUES ('Alpha', 100.00, 'Badminton', '0')
GO
INSERT INTO [dbo].[Courts]([Name],[HourlyFee],[Status],[IsDeleted])
     VALUES ('Beta', 100.00, 'Badminton', '0')
GO
INSERT INTO [dbo].[Courts]([Name],[HourlyFee],[Status],[IsDeleted])
     VALUES ('Gamma', 100.00, 'Tennis', '0')
GO
INSERT INTO [dbo].[Courts]([Name],[HourlyFee],[Status],[IsDeleted])
     VALUES ('Delta', 100.00, 'Tennis', '0')
GO


INSERT INTO [dbo].[Bookings]([BookingDate],[TotalCost],[IsDeleted],[UserId])
     VALUES ('2014-08-03 15:23', 300, 0, 1)
GO
INSERT INTO [dbo].[Bookings]([BookingDate],[TotalCost],[IsDeleted],[UserId])
     VALUES ('2014-08-08 16:23', 300, 0, 2)
GO

INSERT INTO [dbo].[Sessions]([StartDateTime],[EndDateTime],[SessionCost],[IsDeleted],[BookingId],[CourtId])
     VALUES('2014-08-04 10:00', '2014-08-04 11:00', 100, '0', 1, 1)
GO
INSERT INTO [dbo].[Sessions]([StartDateTime],[EndDateTime],[SessionCost],[IsDeleted],[BookingId],[CourtId])
     VALUES('2014-08-05 9:00', '2014-08-05 11:00', 200, '0', 1, 1)
GO
INSERT INTO [dbo].[Sessions]([StartDateTime],[EndDateTime],[SessionCost],[IsDeleted],[BookingId],[CourtId])
     VALUES('2014-08-05 9:00', '2014-08-05 11:00', 200, '0', 2, 3)
GO



