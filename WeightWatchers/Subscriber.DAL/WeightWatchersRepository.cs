using Azure;
using Microsoft.EntityFrameworkCore;
using Subscriber.CORE.DTO;
using Subscriber.CORE.Interface_DAL;
using Subscriber.CORE.Response;
using Subscriber.Data;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.DAL
{
    public class WeightWatchersRepository : IWeightWatchersRepository
    {
        readonly WeightWatchersContext _weightWatchersContext;
        public WeightWatchersRepository(WeightWatchersContext weightWatchersContext)
        {
            _weightWatchersContext = weightWatchersContext;
        }
        public async Task<BaseResponseGeneral<GetCardIdResponse>> GetCardDetails(int id)
        {
            try
            {
                BaseResponseGeneral<GetCardIdResponse> response = new BaseResponseGeneral<GetCardIdResponse>();
                Card card = _weightWatchersContext.Cards.Where(p => p.Id == id).FirstOrDefault();
                if (card != null)
                {
                    Subscribers subscriber = _weightWatchersContext.Subscribers.Where(p => p.Id == card.SubscriberId).FirstOrDefault();
                    if (subscriber != null)
                    {
                        response.Succed = true;
                        response.Status = "succed";
                        response.Response = new GetCardIdResponse();
                        response.Response.Id = id;
                        response.Response.Height = card.Height;
                        response.Response.Weight = card.Weight;
                        response.Response.BMI = card.BMI;
                        response.Response.FirstName = subscriber.FirstName;
                        response.Response.LastName = subscriber.LastName;
                    }
                    else
                    {
                        response.Succed = false;
                        response.Status = "failed";
                    }
                }
                else
                {
                    response.Succed = false;
                    response.Status = "Card not found";
                }


                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("Get card Failed");
            }
        }

        public async Task<BaseResponseGeneral<Card>> Login(string password, string email)
        {
            try
            {
                Subscribers subscribers = _weightWatchersContext.Subscribers.Where(p => p.Email == email && p.Password == password).FirstOrDefault();
                BaseResponseGeneral<Card> response = new BaseResponseGeneral<Card>();

                if (subscribers != null)
                {
                    response.Response = _weightWatchersContext.Cards.Where(c => c.SubscriberId == subscribers.Id).FirstOrDefault();
                   
                    response.Status = "succed";
                }
                else
                {
                    response.Succed = false;
                    response.Response = null;
                    response.Status = "this email and password didnot exist";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(" error 401 Login Failed");
            }

        }

        public async Task<BaseResponseGeneral<bool>> Register(Subscribers subscriber, double height)
        {
            try
            {
                   BaseResponseGeneral<bool> response = new BaseResponseGeneral<bool>();
                    
                      
                    var createdSubscriber = await _weightWatchersContext.Subscribers.AddAsync(subscriber);
                    await _weightWatchersContext.SaveChangesAsync();
                    var defaultCard = new Card
                    {
                        SubscriberId = createdSubscriber.Entity.Id,
                        OpenDate = DateTime.Now,
                        UpDate = DateTime.Now,
                        BMI = 0,
                        Height = height
                    };
                    _weightWatchersContext.Cards.AddAsync(defaultCard);
                    await _weightWatchersContext.SaveChangesAsync();
                    response.Succed = true;
                    response.Response = true;
                    response.Status = " added successfuly";
                  
                
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("Register Failed");
            }

        }
        public async Task<bool> SubscriberEmailExists(string email)
        {    
            return await _weightWatchersContext.Subscribers.AnyAsync(s => s.Email == email);
        }


    }
}
