using Subscriber.CORE.DTO;
using Subscriber.CORE.Response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.CORE.Interface_Service
{
    public interface IWeightWatchersService
    {
        public Task<BaseResponseGeneral<bool>> Register(SubscriberDTO subscriberDTO);
        public Task<BaseResponseGeneral<CardDTO>> Login(string password, string email);
        public Task<BaseResponseGeneral<GetCardIdResponse>> GetCardDetails(int id);
    }
}
