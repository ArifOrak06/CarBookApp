using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.AboutViewComponents
{
	public class _AboutComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();	
		}
	}
}
