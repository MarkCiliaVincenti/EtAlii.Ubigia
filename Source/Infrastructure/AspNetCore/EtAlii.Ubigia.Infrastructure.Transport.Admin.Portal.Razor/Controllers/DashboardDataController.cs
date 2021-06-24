﻿// Copyright (c) Peter Vrenken. All rights reserved. See the license on https://github.com/vrenken/EtAlii.Ubigia

namespace EtAlii.Ubigia.Infrastructure.Transport.Admin.Portal.Razor
{
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    public class DashboardDataController : AdminPortalController
    {
        //private IHiService _adminService

        //public AdminDataController(IHiService adminService)
        //[
        //    _adminService = adminService
        //]
        [HttpGet("dashboard")]
        public string Get()
        {
            return "This is my default action...";
        }
    }
}
