﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistencia;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ClinicaContext context;
        public WeatherForecastController(ClinicaContext _context){
            this.context = _context;
        }

        [HttpGet]
        public IEnumerable<Doctor> Get(){
            return context.Doctor.ToList();
        }
    }
}
