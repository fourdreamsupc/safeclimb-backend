using AutoMapper;
using Go2Climb.API.Activities.Domain.Models;
using Go2Climb.API.Activities.Resources;
using Go2Climb.API.Agencies.Domain.Models;
using Go2Climb.API.Agencies.Resources;
using Go2Climb.API.Customers.Domain.Models;
using Go2Climb.API.Customers.Resources;
using Go2Climb.API.HiredServices.Domain.Models;
using Go2Climb.API.HiredServices.Resources;
using Go2Climb.API.Reviews.Domain.Models;
using Go2Climb.API.Reviews.Resources;
using Go2Climb.API.Security.Domain.Services.Communication;
using Go2Climb.API.Services.Domain.Models;
using Go2Climb.API.Services.Services.Resources;
using Go2Climb.API.Subscriptions.Domain.Models;
using Go2Climb.API.Subscriptions.Resources;

namespace Go2Climb.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {

            CreateMap<Activity, ActivityResource>();
            CreateMap<Agency, AgencyResource>();
            CreateMap<Agency, AuthenticateResponse>();
            CreateMap<Service, ServiceResource>();
            CreateMap<Customer, CustomerResource>();
            CreateMap<Customer, AuthenticateResponse>();
            CreateMap<HiredService, HiredServiceResource>();
            CreateMap<AgencyReview, AgencyReviewResource>();
            CreateMap<ServiceReview, ServiceReviewResource>();
            CreateMap<Subscription, SubscriptionResource>();
            CreateMap<AuthenticateResponse, AuthenticateAgencyResponse>();
            CreateMap<AuthenticateResponse, AuthenticateCustomerResponse>();
            
        }
    }
}