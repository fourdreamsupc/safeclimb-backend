﻿using AutoMapper;
using Go2Climb.API.Reviews.Domain.Models;
using Go2Climb.API.Reviews.Domain.Services;
using Go2Climb.API.Reviews.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Go2Climb.API.Agencies.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/agencies/{agencyId}/agencyreviews")]
    public class AgencyAgencyReviewsControllers : ControllerBase
    {
        private readonly IAgencyReviewService _agencyReviewService;
        private readonly IMapper _mapper;

        public AgencyAgencyReviewsControllers(IAgencyReviewService agencyReviewService, IMapper mapper)
        {
            _agencyReviewService = agencyReviewService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get All AgencyReviews By Agency",
            Description = "Get All Reviews for a given AgencyId",
            Tags = new[] {"Agencies"})]
        [HttpGet]
        public async Task<IEnumerable<AgencyReviewResource>> GetAllByAgencyId(int agencyId)
        {
            var agencyReviews = await _agencyReviewService.ListByAgencyIdAsync(agencyId);
            var resources = _mapper
                .Map<IEnumerable<AgencyReview>, IEnumerable<AgencyReviewResource>>(agencyReviews);
            return resources;
        }
    }
}