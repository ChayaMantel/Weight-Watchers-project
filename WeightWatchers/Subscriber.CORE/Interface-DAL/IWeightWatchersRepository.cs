using Subscriber.CORE.DTO;
using Subscriber.CORE.Response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.CORE.Interface_DAL
{
    public interface IWeightWatchersRepository
    {
        public Task<BaseResponseGeneral<bool>> Register(Subscribers subscriber, double height);
        public Task<BaseResponseGeneral<Card>> Login(string password,string email);
        public Task<BaseResponseGeneral<GetCardIdResponse>> GetCardDetails(int id );
        public  Task<bool> SubscriberEmailExists(string email);


    }
}
