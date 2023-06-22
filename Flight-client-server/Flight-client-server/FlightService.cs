using AutoMapper;

using Flight_client_server.Models;
using Flight_client_server.Models.Filters;
using Flights.DataAccess;

namespace Flight_client_server;

public class FlightService : IFlightService
{
    private readonly IMapper _mapper;
    private readonly FlightContext _context;
    public FlightService(IMapper mapper, FlightContext context) 
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<string> CreateFlight(CreateFlightVM model)
    {
        var mapperModel = _mapper.Map<Flight>(model);

        mapperModel.Id = Guid.NewGuid().ToString();

        _context.Flights.Add(mapperModel);

        await _context.SaveChangesAsync();

        return mapperModel.Id;
    }

    public async Task DeleteFlight(string id)
    {
        var entity = _context.Flights.FirstOrDefault(x => x.Id == id);

        if(entity is null)
        {
            return;
        }
        
        _context.Flights.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task EditFlight(UpdateFlightVM model)
    {
        var mapperModel = _mapper.Map<Flight>(model);

        _context.Flights.Update(mapperModel);
        await _context.SaveChangesAsync();
    }

    public async Task<BatchDataResult<FlightVM>> GetAllFlights()
    {
        var flights = _context.Flights.ToList();

        var mappedFlights = _mapper.Map<IEnumerable<FlightVM>>(flights);

        return new BatchDataResult<FlightVM>()
        {
            Data = mappedFlights,
            Total = mappedFlights.Count()
        };
    }

    public async Task<BatchDataResult<FlightVM>> GetFlights(Func<Flight, bool> filter)
    {
        var flights = _context.Flights.Where(filter);

        if(!flights.Any())
        {
            return new BatchDataResult<FlightVM>();
        }
        var mappedFlights = _mapper.Map<IEnumerable<FlightVM>>(flights);

        return new BatchDataResult<FlightVM>()
        {
            Data = mappedFlights,
            Total = mappedFlights.Count()
        };
    }

    public async Task<BatchDataResult<FlightVM>> GetFlights(Func<Flight, bool> filter, int take, int skip)
    {
        var flights = await GetFlights(filter);

        flights.Data = flights.Data.Skip(skip).Take(take);

        return flights;
    }
}
