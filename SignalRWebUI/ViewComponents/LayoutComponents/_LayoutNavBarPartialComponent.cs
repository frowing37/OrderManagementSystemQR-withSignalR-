using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR_Entities.Concrete;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavBarPartialComponent : ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;

		public _LayoutNavBarPartialComponent(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var userId = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
			var user = await _userManager.FindByIdAsync(userId);
			
			return View(user);
		}
	}
}

