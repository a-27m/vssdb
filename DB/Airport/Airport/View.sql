use Airport
go
--drop view TimeTable
create view TimeTable
as
SELECT	AirRoute.ShortTitle AS RouteTitle,
		Flight.ShortTitle AS FlightTitle,
		RouteType.Title AS RTypeTitle,
		PlannedFlight.IDPlannedFlight,
		PlannedFlight.Departure, 
		Plane.Model, Plane.RegNo,
		PlannedFlight.Price
FROM 
	PlannedFlight INNER JOIN
	Flight ON PlannedFlight.IDFlight = Flight.IDFlight INNER JOIN
	Plane ON PlannedFlight.IDPlane = Plane.IDPlane INNER JOIN
	PlannedRoute ON PlannedFlight.IDPlannedRoute = PlannedRoute.IDPlannedRoute INNER JOIN
	AirRoute ON PlannedRoute.IDAirRoute = AirRoute.IDRoute INNER JOIN
	RouteType ON AirRoute.IDRouteType = RouteType.IDRouteType

--ORDER BY PlannedFlight.Departure DESC
