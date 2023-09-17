using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaperFineryApp_Application.Services.Interfaces;
using PaperFineryApp_Domain.Dtos.ResponseDto;
using PaperFineryApp_Domain.Model;
using PaperFineryApp_Infrastructure.Repository.Abstraction;
using PaperFineryApp_Infrastructure.UnitOfWork.Abstraction;
using PaperFineryApp_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Application.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReviewRepository _review;
        private readonly UserManager<User> _userManager;
        private readonly ILogger _logger;

        public ReviewService(IMapper mapper, IUnitOfWork unitOfWork, ILogger logger, UserManager<User> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userManager = userManager;
            _review = _unitOfWork.ReviewRepository;
        }
        /// <summary>
        /// Creates a review
        /// </summary>
        /// <param name="userEmail"> Email of the app user giving review</param>
        /// <param name="comment"> The review given by the app user</param>
        /// <returns> a string message of acknowledgement for review.</returns>
        public async Task<string> CreateReview(string userEmail,string comment)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user!=null) 
            {
                var mapReview = _mapper.Map<Review>(comment);
                await _unitOfWork.ReviewRepository.CreateAsync(mapReview);
                user.Supplier.Reviews.Add(mapReview);
                await _unitOfWork.SaveChangesAsync();

                return "Thanks for your review";
            }
            return "Please sign in to review";
        }

        //public StandardResponse<ReviewResponseDto> GetReviewByUserName(string userName)
        //{
        //    var review = _review.GetReviewByUserName(userName);
        //    var mapReview = _mapper.Map<ReviewResponseDto>(review);
        //    if (review!=null)
        //    {
        //        return StandardResponse<ReviewResponseDto>.Success("success", mapReview, 200);
        //    }

        //    return StandardResponse<ReviewResponseDto>.Failed($"There's no review with username {userName} ", 400);
        //}

    }
}
