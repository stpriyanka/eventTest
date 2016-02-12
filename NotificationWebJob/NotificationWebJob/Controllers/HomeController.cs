using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NotificationWebJob.Models;
using Enum = NotificationWebJob.Models.Enum;

namespace NotificationWebJob.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}


		public async Task<ActionResult> LogEventSubscriptions()
		{
			var dbContext = new NotificationDb();
			var logEventSub = new LogEventSubscriptions
			{
				Id = Guid.NewGuid(),
				ObjectTypeOfEvent = Enum.ObjectTypeOfEvent.MonthlyMeeting,
				EventType = Enum.EventType.Add
			};

			dbContext.LogEventSubscriptionses.Add(logEventSub);
			await dbContext.SaveChangesAsync();
			return Content("Created new row");
		}


		public async Task<ActionResult> LogEvents()
		{
			var dbContext = new NotificationDb();
			var logEvent = new LogEvents()
			{
				EventType = Enum.EventType.Add,
				Id = Guid.NewGuid(),
				UserWhoCreatesEvent = "somenameOREmail",
				ObjectTypeOfEvent = Enum.ObjectTypeOfEvent.MonthlyMeeting
			};
			dbContext.LogEventses.Add(logEvent);
			await dbContext.SaveChangesAsync();
			return Content("new row created");
		}

	}
}