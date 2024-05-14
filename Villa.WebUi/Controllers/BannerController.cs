﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.BannerDtos;
using Villa.Entity.Entites;

namespace Villa.WebUi.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;

        public BannerController(IBannerService bannerService, IMapper mapper)
        {
            _bannerService=bannerService;
            _mapper=mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values=await _bannerService.TGetListAsync();
            var bannerList=_mapper.Map<List<ResultBannerDto>>(values);
            return View(bannerList);;
        }
        public async Task<IActionResult> DeleteBanner(ObjectId id)
        {
            await _bannerService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }
        
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var newBanner= _mapper.Map<Banner>(createBannerDto);

            await _bannerService.TCreateAsync(newBanner);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UptadeBanner(ObjectId id) {
            var value = await _bannerService.TGetByIdAsync(id);
            var uptdeBanner = _mapper.Map<UptadeBannerDto>(value);
            return View(uptdeBanner);
        }

        [HttpPost]
        public async Task<IActionResult> UptadeBanner(UptadeBannerDto uptadeBannerDto)
        {
            var banner=_mapper.Map<Banner>(uptadeBannerDto);
            await _bannerService.TUptadeAsync(banner);
            return RedirectToAction("Index");
        }
    }
}
