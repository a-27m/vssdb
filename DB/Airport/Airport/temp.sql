use Airport;

SELECT     Flight.IDFlight, Flight.ShortTitle, PlannedFlight.Departure, PlannedFlight.Price, PlannedRoute.Price AS Expr1, AirRoute.ShortTitle AS Expr2, 
                      Ticket.IDTicket
FROM         PlannedFlight INNER JOIN
                      Flight ON PlannedFlight.IDFlight = Flight.IDFlight INNER JOIN
                      PlannedRoute ON PlannedFlight.IDPlannedRoute = PlannedRoute.IDPlannedRoute INNER JOIN
                      AirRoute ON PlannedRoute.IDAirRoute = AirRoute.IDRoute INNER JOIN
                      Ticket ON PlannedRoute.IDPlannedRoute = Ticket.IDPlannedRoute


use airport;
select * from AirRoute
delete from AirRoute where IDRoute = 10;