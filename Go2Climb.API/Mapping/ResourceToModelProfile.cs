 using AutoMapper;
using Go2Climb.API.Agencies.Domain.Models;
using Go2Climb.API.Resources;
using Go2Climb.API.Security.Domain.Services.Communication;
using Go2Climb.API.Activities.Resources;
using Go2Climb.API.Services.Resources;
using Go2Climb.API.Customers.Domain.Models;
using Go2Climb.API.Customers.Resources;
using Go2Climb.API.Subscriptions.Domain.Models;
using Go2Climb.API.HiredServices.Resources;
using Go2Climb.API.Subscriptions.Resources;
using Go2Climb.API.HiredServices.Domain.Models;
using Go2Climb.API.Reviews.Resources;
using Go2Climb.API.Reviews.Domain.Models;
using Go2Climb.API.Activities.Domain.Models;
using Go2Climb.API.Services.Domain.Models;

namespace Go2Climb.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {

            CreateMap<SaveActivityResource, Activity>();
            CreateMap<SaveAgencyResource, Agency>();
            CreateMap<UpdateAgencyRequest, Agency>()
                .ForAllMembers(options => options.Condition(
                    (source, Target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }));
            CreateMap<SaveServiceResource, Service>();

            CreateMap<RegisterCustomerRequest, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>()
                .ForAllMembers(options => options.Condition(
                    (source, Target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }));
            CreateMap<SaveCustomerResourse, Customer>();
            CreateMap<SaveHiredServiceResource, HiredService>();
            CreateMap<SaveSubscriptionResource, Subscription>();
            
            CreateMap<SaveAgencyReviewResource, AgencyReview>();
            CreateMap<SaveServiceReviewResource, ServiceReview>();
            
        }
    }
}