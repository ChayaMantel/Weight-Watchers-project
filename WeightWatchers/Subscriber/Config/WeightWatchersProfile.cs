using AutoMapper;
using Subscriber.CORE.DTO;
using Subscriber.CORE.Response;
using Subscriber.Data.Entities;

namespace Subscriber.WebWpi.Config
{
    public class WeightWatchersProfile : Profile
    {
        public WeightWatchersProfile()
        {
            CreateMap<CardDTO, Card>().ReverseMap();
            CreateMap<Subscribers, SubscriberDTO>().ForMember(dest => dest.Height, opt => opt.Ignore()).ReverseMap();//ברצוני שיהיה מבלי הגובה
            CreateMap<BaseResponseGeneral<Card>, BaseResponseGeneral<CardDTO>>();
        }
    }
}
