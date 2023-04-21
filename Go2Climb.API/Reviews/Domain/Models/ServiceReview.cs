﻿using Go2Climb.API.Customers.Domain.Models;
using Go2Climb.API.Services.Domain.Models;

namespace Go2Climb.API.Reviews.Domain.Models
{
    public class ServiceReview
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; } 
        public double Score { get; set; }
        
        //Relationships
        public int ServiceId { get; set; } 
        public Service Service { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}