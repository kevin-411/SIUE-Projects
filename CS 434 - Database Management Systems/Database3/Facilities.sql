SELECT Distinct *
FROM dbo.FacilityTable As F, dbo.AirportTable As A
Where F.FacilityId = A.FacilityId