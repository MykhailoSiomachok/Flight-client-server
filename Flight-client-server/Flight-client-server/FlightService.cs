using AutoMapper;

using Flight_client_server.Models;

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

    public async Task<Guid> CreateFlight(CreateFlightVM model)
    {
        var mapperModel = _mapper.Map<Flight>(model);

        _context.Flights.Add(mapperModel);
        await _context.SaveChangesAsync();

        return mapperModel.Id;
    }

    public async Task DeleteFlight(Guid id)
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
