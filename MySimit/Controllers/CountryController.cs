﻿using Microsoft.AspNetCore.Mvc;
using MySimit.Application.CountryService;
using MySimit.Domain.Entities;
using System.Diagnostics.Metrics;

namespace MySimit.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            this._countryService = countryService;
        }
        public IActionResult Create(Country country)
        {
            country.Id = new int();
            _countryService.AddAsync(country);
            return CreatedAtAction(nameof(Create), new { country.Id }, country);
        }

        [HttpGet]
        [Route("Id")]
        [ActionName("GetCountry")]
        public async Task<IActionResult> GetCard(int id)
        {
            var cards = await _countryService.GetByID(id);
            if (cards != null)
            {
                return Ok(cards);
            }
            return NotFound("Card Not Found");
        }

        [HttpDelete]
        [Route("Id")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var numberOfRowsEffected = await _countryService.DeleteAsync(id);
            if (numberOfRowsEffected > 0)
            {
                return Ok();
            }

            return NotFound("Country Not Found");
        }
    }
}
