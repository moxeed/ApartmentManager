 CREATE VIEW dbo.vwGetCalculatedCharges
AS
Select   TotalCharge ,t1.FromDate , t1.ToDate ,p.[Name] , p.LastName , a.[Number] as ApartmentNumber 
From (select sum(ci.Amount) as TotalCharge , c.ChargeId , ci.PayerId ,c.[From] as FromDate, c.[To] as ToDate , c.ApartmentId 
		From dbo.Charge as c
		Join dbo.ChargeItem as ci 
			On ci.ChargeId = c.ChargeId
		Join dbo.OwnerTenant as ot 
			On ot.PersonId = ci.PayerId
		Group by c.ChargeId, ci.PayerId , c.[From] , c.[To] , c.ApartmentId 
) as t1
Join dbo.Person as p
	on p.PersonId = t1.PayerId
Join Apartment as a
	on a.ApartmentId = t1.ApartmentId