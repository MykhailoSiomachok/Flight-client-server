using System.Text.Json;
using System.Text.Json.Serialization;

using AutoMapper;
using Flight_client_server.Models.Filters;
using Flights.DataAccess;

namespace Flight_client_server.Profiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightVM>()
                .ForMember(x => x.Route, y => y.MapFrom(o => JsonSerializer.Deserialize<List<string>>(o.Route, (JsonSerializerOptions)null)));

            CreateMap<CreateFlightVM, Flight>()
                .ForMember(x => x.Route, y => y.MapFrom(o => JsonSerializer.Serialize(o.Route, (JsonSerializerOptions)null)));
            CreateMap<UpdateFlightVM, Flight>()
                .ForMember(x => x.Route, y => y.MapFrom(o => JsonSerializer.Serialize(o.Route, (JsonSerializerOptions)null)));
        }
    }
}
