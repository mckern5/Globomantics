﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.WebApi.Controllers
{
    public class ProposalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}