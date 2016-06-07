using System;
using System.Linq;
using System.Collections.Generic;

namespace EmployeePass
{
	public enum PassStatus{
		Used = 0,
		Unused,
		Other
	}

	public enum Region{
		NorthAmerica = 0,
		Europe,
		Asia,
		China,
		Taiwan
	}


	public class EmployeeElectronicPass
	{
		public List<Ticket> Tickets { get; set; }
		public string FlightsToString { get; set; }
		public string ElectronicPassId { get; set; }
		public string ProcessId { get; set; }
		public DateTime AppliedDate { get; set; }
		public string EMDId { get; set; }
		public PassStatus Status { get; set; }
	}

	public class Ticket{

		public string Id { get; set; }
		public Flight TicketFlight { get; set; }

		public DateTime StartDate { get; set; }
		public string ClassName { get; set; }
	}


	public class Flight
	{
		// Route
		public Route FlightRoute {get;set;}

		public string Id { get; set; }

		// 個別航班資訊

		public DateTime TakeoffTime { get; set; }
		public DateTime LandingTime { get; set; }
		public List<string> Classes{ get; set; }
	}


	public class Route
	{
		public int Id { get; set; }
		public Airport StartAirport { get; set; }
		public Airport StopAirport { get; set; }
		public List<Flight> Flights { get; set;}

		public Terminal StartTerminal { get; set;}
		public Terminal Stoperminal { get; set;}
	}

	public class Terminal {
		public string Name { get; set; }
		public string EnglishName { get; set; }
		public string Address { get; set; }
		public string Note { get; set; }
		public string Phone { get; set; }
		public string Web { get; set; }
	}


	public class Airport
	{
		public string IATA_Code { get; set; }
		public string Name { get; set; }
		public Region GeoRegion { get; set; }
	}


	public class FlightInfoManager
	{
		public List<string> ReadRegions(){
		
			return new List<string>{ "North America", "Europe", "Asia", "China", "Taiwan" };
		}

		public List<Airport> ReadAirportsFromRemote(){
			var results = new List<Airport> ();
		
			results.Add (new Airport{ IATA_Code = @"TPE", Name = @"Taipei", GeoRegion = Region.Taiwan });
			results.Add (new Airport{ IATA_Code = @"HKG", Name = @"Hong Kong", GeoRegion = Region.Asia });
			results.Add (new Airport{ IATA_Code = @"BKK", Name = @"Bangkok", GeoRegion = Region.Asia });
			results.Add (new Airport{ IATA_Code = @"RMQ", Name = @"Taichung", GeoRegion = Region.Taiwan });
			results.Add (new Airport{ IATA_Code = @"KHH", Name = @"Kaohsiung", GeoRegion = Region.Taiwan });
			results.Add (new Airport{ IATA_Code = @"NRT", Name = @"Tokyo", GeoRegion = Region.Asia });
			results.Add (new Airport{ IATA_Code = @"LHR", Name = @"London", GeoRegion = Region.Europe });
			results.Add (new Airport{ IATA_Code = @"LUX", Name = @"Luxemburg", GeoRegion = Region.Europe });
			results.Add (new Airport{ IATA_Code = @"CAN", Name = @"Guangzhou", GeoRegion = Region.China });
			results.Add (new Airport{ IATA_Code = @"PVG", Name = @"Shanghai", GeoRegion = Region.China });
			results.Add (new Airport{ IATA_Code = @"PEK", Name = @"Beijing", GeoRegion = Region.China });
			results.Add (new Airport{ IATA_Code = @"LAX", Name = @"Los Angels", GeoRegion = Region.NorthAmerica });
			results.Add (new Airport{ IATA_Code = @"EWR", Name = @"New York", GeoRegion = Region.NorthAmerica });
		
			return results;
		}

		public Airport ReadAirportByIATACode (string IATA_Code){
			var airports = ReadAirportsFromRemote ();

			var list = airports.Where (field => field.IATA_Code == IATA_Code).ToList ();

			return (1 == list.Count) ? list [0] : null;
		}
			
		public List<Route> ReadRouteFromRemote(){
			var results = new List<Route> ();

			var taipeiT1 = new Terminal {
				Name = @"桃園國際機場第一航廈",
				EnglishName = @"Taoyuan International Airport Terminal 1",
				Address = @"337 桃園市大園區航站南路15號",
				Phone = @"033982143",
				Web = @"http://taoyuan-airport.com",
				Note = @""
			};

			var taipeiT2 = new Terminal {
				Name = @"桃園國際機場第二航廈",
				EnglishName = @"Taoyuan International Airport Terminal 2",
				Address = @"33758桃園市大園區航站南路9號",
				Phone = @"033983728",
				Web = @"http://taoyuan-airport.com",
				Note = @""
			};

			var taichung = new Terminal{ 
				Name = @"台中國際機場第一航廈", 
				EnglishName = @"Taichung Airport Terminal 1", 
				Address = @"433台中市沙鹿區中航路一段168號",
				Phone = @"0426155000",
				Web = @"http://tca.gov.tw",
				Note = @""
			};

			var kaohsiung = new Terminal{ 
				Name = @"高雄機場國際航廈", 
				EnglishName = @"Kaohsiung International Airport International Terminal", 
				Address = @"812高雄市小港區中山四路",
				Phone = @"078057630",
				Web = @"http://kia.gov.tw",
				Note = @""
			};

			var defaultT = new Terminal{ 
				Name = @"", 
				EnglishName = @"", 
				Address = @"",
				Phone = @"",
				Web = @"",
				Note = @""
			};


			results.Add (
				new Route{
					Id = 1001,
					StartAirport = ReadAirportByIATACode ( @"TPE" ),
					StopAirport = ReadAirportByIATACode ( @"HKG" ),
					StartTerminal = taipeiT1,
				}
			);

			results.Add (
				new Route{
					Id = 1002,
					StartAirport = ReadAirportByIATACode( @"HKG" ),
					StopAirport = ReadAirportByIATACode ( @"TPE" ),
					StartTerminal = defaultT ,
				}
			);

			results.Add (
				new Route{
					Id = 1101,
					StartAirport = ReadAirportByIATACode ( @"TPE" ),
					StopAirport = ReadAirportByIATACode ( @"BKK" ),
					StartTerminal = taipeiT2,
				}
			);

			results.Add (
				new Route{
					Id = 1102,
					StartAirport = ReadAirportByIATACode( @"BKK" ),
					StopAirport = ReadAirportByIATACode ( @"TPE" ),
					StartTerminal = defaultT ,
				}
			);

			results.Add (
				new Route{
					Id = 1201,
					StartAirport = ReadAirportByIATACode ( @"RMQ" ),
					StopAirport = ReadAirportByIATACode ( @"BKK" ),
					StartTerminal = taichung,
				}
			);

			results.Add (
				new Route{
					Id = 1202,
					StartAirport = ReadAirportByIATACode( @"BKK" ),
					StopAirport = ReadAirportByIATACode ( @"RMQ" ),
					StartTerminal = defaultT ,
				}
			);


			results.Add (
				new Route{
					Id = 1301,
					StartAirport = ReadAirportByIATACode ( @"KHH" ),
					StopAirport = ReadAirportByIATACode ( @"NRT" ),
					StartTerminal = kaohsiung,
				}
			);

			results.Add (
				new Route{
					Id = 1302,
					StartAirport = ReadAirportByIATACode( @"NRT" ),
					StopAirport = ReadAirportByIATACode ( @"KHH" ),
					StartTerminal = defaultT ,
				}
			);

			results.Add (
				new Route{
					Id = 1401,
					StartAirport = ReadAirportByIATACode ( @"TPE" ),
					StopAirport = ReadAirportByIATACode ( @"LHR" ),
					StartTerminal = taipeiT2,
				}
			);

			results.Add (
				new Route{
					Id = 1402,
					StartAirport = ReadAirportByIATACode ( @"LHR" ),
					StopAirport = ReadAirportByIATACode ( @"TPE" ),
					StartTerminal = defaultT ,
				}
			);


			results.Add (
				new Route{
					Id = 1501,
					StartAirport = ReadAirportByIATACode ( @"TPE" ),
					StopAirport = ReadAirportByIATACode ( @"LUX" ),
					StartTerminal = taipeiT2,
				}
			);

			results.Add (
				new Route{
					Id = 1502,
					StartAirport = ReadAirportByIATACode ( @"LUX" ),
					StopAirport = ReadAirportByIATACode ( @"TPE" ),
					StartTerminal = defaultT ,
				}
			);


			results.Add (
				new Route{
					Id = 1601,
					StartAirport = ReadAirportByIATACode ( @"TPE" ),
					StopAirport = ReadAirportByIATACode ( @"CAN" ),
					StartTerminal = taipeiT1,
				}
			);

			results.Add (
				new Route{
					Id = 1602,	
					StartAirport = ReadAirportByIATACode ( @"CAN" ),
					StopAirport = ReadAirportByIATACode ( @"TPE" ),
					StartTerminal = defaultT ,
				}
			);

			results.Add (
				new Route{
					Id = 1701,
					StartAirport = ReadAirportByIATACode ( @"TPE" ),
					StopAirport = ReadAirportByIATACode ( @"PVG" ),
					StartTerminal = taipeiT1,
				}
			);

			results.Add (
				new Route{
					Id = 1702,
					StartAirport = ReadAirportByIATACode ( @"PVG" ),
					StopAirport = ReadAirportByIATACode ( @"TPE" ),
					StartTerminal = defaultT ,
				}
			);

			results.Add (
				new Route{
					Id = 1801,
					StartAirport = ReadAirportByIATACode ( @"TPE" ),
					StopAirport = ReadAirportByIATACode ( @"PEK" ),
					StartTerminal = taipeiT2,
				}
			);

			results.Add (
				new Route{
					Id = 1802,
					StartAirport = ReadAirportByIATACode ( @"PEK" ),
					StopAirport = ReadAirportByIATACode ( @"TPE" ),
					StartTerminal = defaultT ,
				}
			);

			results.Add (
				new Route{
					Id = 1901,
					StartAirport = ReadAirportByIATACode ( @"TPE" ),
					StopAirport = ReadAirportByIATACode ( @"LAX" ),
					StartTerminal = taipeiT2,
				}
			);

			results.Add (
				new Route{
					Id = 1902,
					StartAirport = ReadAirportByIATACode ( @"LAX" ),
					StopAirport = ReadAirportByIATACode ( @"TPE" ),
					StartTerminal = defaultT ,
				}
			);

			results.Add (
				new Route{
					Id = 2001,
					StartAirport = ReadAirportByIATACode ( @"TPE" ),
					StopAirport = ReadAirportByIATACode ( @"EWR" ),
					StartTerminal = taipeiT2,
				}
			);

			results.Add (
				new Route{
					Id = 2002,
					StartAirport = ReadAirportByIATACode ( @"EWR" ),
					StopAirport = ReadAirportByIATACode ( @"TPE" ),
					StartTerminal = defaultT ,
				}
			);

		
			return results;
		}

		public Route ReadRouteById(int routeId){
			var routes = ReadRouteFromRemote ();

			var list = routes.Where (route => route.Id == routeId ).ToList ();

			return (1 == list.Count) ? list [0] : null;
			
		}

		public List<Flight> ReadFlightFromRemote(){
			var results = new List<Flight> ();

			results.Add( new Flight{ Id = @"CI100101", FlightRoute = ReadRouteById(1001)} );
			results.Add( new Flight{ Id = @"CI100201", FlightRoute = ReadRouteById(1002)} );
			results.Add( new Flight{ Id = @"CI100102", FlightRoute = ReadRouteById(1001)} );
			results.Add( new Flight{ Id = @"CI100202", FlightRoute = ReadRouteById(1002)} );
			results.Add( new Flight{ Id = @"CI100103", FlightRoute = ReadRouteById(1001)} );
			results.Add( new Flight{ Id = @"CI100203", FlightRoute = ReadRouteById(1002)} );

			results.Add( new Flight{ Id = @"CI110101", FlightRoute = ReadRouteById(1101)} );
			results.Add( new Flight{ Id = @"CI110201", FlightRoute = ReadRouteById(1102)} );

			results.Add( new Flight{ Id = @"CI120101", FlightRoute = ReadRouteById(1201)} );
			results.Add( new Flight{ Id = @"CI120201", FlightRoute = ReadRouteById(1202)} );

			results.Add( new Flight{ Id = @"CI130101", FlightRoute = ReadRouteById(1301)} );
			results.Add( new Flight{ Id = @"CI130201", FlightRoute = ReadRouteById(1302)} );

			results.Add( new Flight{ Id = @"CI140101", FlightRoute = ReadRouteById(1401)} );
			results.Add( new Flight{ Id = @"CI140201", FlightRoute = ReadRouteById(1402)} );


			results.Add( new Flight{ Id = @"CI150101", FlightRoute = ReadRouteById(1501)} );
			results.Add( new Flight{ Id = @"CI150201", FlightRoute = ReadRouteById(1502)} );

			results.Add( new Flight{ Id = @"CI160101", FlightRoute = ReadRouteById(1601)} );
			results.Add( new Flight{ Id = @"CI160201", FlightRoute = ReadRouteById(1602)} );

			results.Add( new Flight{ Id = @"CI170101", FlightRoute = ReadRouteById(1701)} );
			results.Add( new Flight{ Id = @"CI170201", FlightRoute = ReadRouteById(1702)} );

			results.Add( new Flight{ Id = @"CI180101", FlightRoute = ReadRouteById(1801)} );
			results.Add( new Flight{ Id = @"CI180201", FlightRoute = ReadRouteById(1802)} );

			results.Add( new Flight{ Id = @"CI190101", FlightRoute = ReadRouteById(1901)} );
			results.Add( new Flight{ Id = @"CI190201", FlightRoute = ReadRouteById(1902)} );

			results.Add( new Flight{ Id = @"CI200101", FlightRoute = ReadRouteById(2001)} );
			results.Add( new Flight{ Id = @"CI200201", FlightRoute = ReadRouteById(2002)} );

			return results;
		}

		public List<Flight> ReadFlightByRouteId(int routeId){
			var routes = ReadFlightFromRemote ();

			var list = routes.Where (flight => flight.FlightRoute.Id == routeId ).ToList ();

			return list;

		}

		public Flight ReadFlightById(string flightId){
			var routes = ReadFlightFromRemote ();

			var list = routes.Where (flight => flight.Id == flightId ).ToList ();

			return (1 == list.Count) ? list [0] : null;
		
		}
	}


	public class PassManager
	{
		private Airport ReadAirportByIATACode (string IATA_Code){
			return new FlightInfoManager().ReadAirportByIATACode (IATA_Code);
		}

		private Route ReadRouteById(int routeId){
			return new FlightInfoManager().ReadRouteById (routeId);
		}

		public Flight ReadFlightById(string flightId){
			return new FlightInfoManager().ReadFlightById (flightId);
		}
			
		public List<EmployeeElectronicPass> ReadPassRecordFromRemote(){
		
			var results = new List<EmployeeElectronicPass> ();
		
			results.Add (new EmployeeElectronicPass{
				Tickets = new List<Ticket>{ 
					new Ticket{ TicketFlight = ReadFlightById(@"CI100101"), ClassName = @"Y", StartDate = new DateTime(2016,2,1) }, 
					new Ticket{ TicketFlight = ReadFlightById(@"CI100201"), ClassName = @"Y", StartDate = new DateTime(2016,2,7) } },
				ElectronicPassId = @"Pass12348978",
				ProcessId = @"Apply12345678",
				AppliedDate = new DateTime( 2016, 1,2),
				FlightsToString = @"TPE-HKG-TPE",
				EMDId = @"THR001",
				Status = PassStatus.Used
			});

			results.Add (new EmployeeElectronicPass{
				Tickets = new List<Ticket>{
					new Ticket{ TicketFlight = ReadFlightById(@"CI100102"), ClassName = @"Y", StartDate = new DateTime(2016,3,1) }, 
					new Ticket{ TicketFlight = ReadFlightById(@"CI100202"), ClassName = @"Y", StartDate = new DateTime(2016,3,12)}  },
				ElectronicPassId = @"Pass12345438",
				ProcessId = @"Apply12345679",
				AppliedDate = new DateTime( 2016, 2,3),
				FlightsToString = @"TPE-HKG-TPE",
				EMDId = @"THR002",
				Status = PassStatus.Used
			});

			results.Add (new EmployeeElectronicPass{
				Tickets = new List<Ticket>{
					new Ticket{ TicketFlight = ReadFlightById(@"CI100101"), ClassName = @"Y", StartDate = new DateTime(2016,3,21) }, 
					new Ticket{ TicketFlight = ReadFlightById(@"CI100202"), ClassName = @"Y", StartDate = new DateTime(2016,3,25) }  },
				ElectronicPassId = @"Pass12345680",
				ProcessId = @"Apply12348678",
				AppliedDate = new DateTime( 2016, 6,1),
				FlightsToString = @"TPE-HKG-TPE",
				EMDId = @"THR003",
				Status = PassStatus.Used
			});

			results.Add (new EmployeeElectronicPass{
				Tickets = new List<Ticket>{
					new Ticket{ TicketFlight = ReadFlightById(@"CI140101"), ClassName = @"Y", StartDate = new DateTime(2016,6,11) }, 
					new Ticket{ TicketFlight = ReadFlightById(@"CI140201"), ClassName = @"Y", StartDate = new DateTime(2016,6,21) }  },
				ElectronicPassId = @"Pass72345438",
				ProcessId = @"Apply72345679",
				AppliedDate = new DateTime( 2016, 5,3),
				FlightsToString = @"TPE-LHR-TPE",
				EMDId = @"THR004",
				Status = PassStatus.Unused
			});

			results.Add (new EmployeeElectronicPass{
				Tickets = new List<Ticket>{
					new Ticket{ TicketFlight = ReadFlightById(@"CI150101"), ClassName = @"Y", StartDate = new DateTime(2016,7,11) }, 
					new Ticket{ TicketFlight = ReadFlightById(@"CI150201"), ClassName = @"Y", StartDate = new DateTime(2016,7,21) }  },
				ElectronicPassId = @"Pass72345680",
				ProcessId = @"Apply72348678",
				AppliedDate = new DateTime( 2016, 6,1),
				FlightsToString = @"TPE-LUX-TPE",
				EMDId = @"THR005",
				Status = PassStatus.Unused
			});

			results.Add (new EmployeeElectronicPass{
				Tickets = new List<Ticket>{
					new Ticket{ TicketFlight = ReadFlightById(@"CI160101"), ClassName = @"Y", StartDate = new DateTime(2016,12,11) }, 
					new Ticket{ TicketFlight = ReadFlightById(@"CI160201"), ClassName = @"Y", StartDate = new DateTime(2016,12,15) }  },
				ElectronicPassId = @"Pass32345438",
				ProcessId = @"Apply32345679",
				AppliedDate = new DateTime( 2015, 12,3),
				FlightsToString = @"TPE-CAN-TPE",
				EMDId = @"THR006",
				Status = PassStatus.Other
			});

			results.Add (new EmployeeElectronicPass{
				Tickets = new List<Ticket>{
					new Ticket{ TicketFlight = ReadFlightById(@"CI170101"), ClassName = @"Y", StartDate = new DateTime(2015,12,19) }, 
					new Ticket{ TicketFlight = ReadFlightById(@"CI170201"), ClassName = @"Y", StartDate = new DateTime(2015,12,21) }  },
				ElectronicPassId = @"Pass32345680",
				ProcessId = @"Apply32348678",
				AppliedDate = new DateTime( 2015, 12,8),
				FlightsToString = @"TPE-PVG-TPE",
				EMDId = @"THR007",
				Status = PassStatus.Other
			});

		
		
			return results;
		}


	}
}

