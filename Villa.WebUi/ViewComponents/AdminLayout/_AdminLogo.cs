﻿using Microsoft.AspNetCore.Mvc;

namespace Villa.WebUi.ViewComponents.AdminLayout
{
    public class _AdminLogo:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
