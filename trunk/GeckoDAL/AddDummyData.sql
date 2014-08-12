USE [Gecko]
GO

INSERT INTO [dbo].[Users]([FirstName],[LastName],[Email],[Phone],[IsDeleted])
     VALUES('Pelle', 'Svanslös', 'pelle@svanslos.se', '0123-45678','0')
GO
INSERT INTO [dbo].[Users]([FirstName],[LastName],[Email],[Phone],[IsDeleted])
     VALUES('Maja', 'Gräddnos', 'maja@graddnos.se', '0123-45678','0')
GO
INSERT INTO [dbo].[Users]([FirstName],[LastName],[Email],[Phone],[IsDeleted])
     VALUES('Måns', 'Bully', 'mans@bully.se', '0123-45678','0')
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


INSERT INTO [dbo].[Bookings]([BookingDate],[TotalCost],[IsDeleted],[UserUserID])
     VALUES ('2014-08-03 15:23', 300, 0, 1)
GO
INSERT INTO [dbo].[Bookings]([BookingDate],[TotalCost],[IsDeleted],[UserUserID])
     VALUES ('2014-08-08 16:23', 300, 0, 2)
GO

INSERT INTO [dbo].[Sessions]([StartDateTime],[EndDateTime],[SessionCost],[IsDeleted],[BookingBookingID],[CourtCourtID])
     VALUES('2014-08-04 10:00', '2014-08-04 11:00', 100, '0', 1, 1)
GO
INSERT INTO [dbo].[Sessions]([StartDateTime],[EndDateTime],[SessionCost],[IsDeleted],[BookingBookingID],[CourtCourtID])
     VALUES('2014-08-05 9:00', '2014-08-05 11:00', 200, '0', 1, 1)
GO
INSERT INTO [dbo].[Sessions]([StartDateTime],[EndDateTime],[SessionCost],[IsDeleted],[BookingBookingID],[CourtCourtID])
     VALUES('2014-08-05 9:00', '2014-08-05 11:00', 200, '0', 2, 3)
GO



