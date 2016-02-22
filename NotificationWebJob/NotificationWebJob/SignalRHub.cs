using System.Data.Entity;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationWebJob.Models;


namespace NotificationWebJob
{


	[Authorize]
	public class SignalRHub : Hub
	{
		readonly NotificationDb _myDbContext = new NotificationDb();

		private static int _connectionCounter = 0;


		public async Task SendMessage(string message)
		{
			Clients.Caller.send("something");
		}



		public override Task OnConnected()
		{

			var name = _myDbContext.LogEventSubscriptionses.FirstOrDefault
				         (r => r.UserWhoSubscribed == Context.User.Identity.Name);


			var obj = new LogEvents()
			{
				Id = name.Id,
				UserWhoCreatesEvent = name.UserWhoSubscribed,
				EventType = name.EventType,
				ObjectTypeOfEvent = name.ObjectTypeOfEvent

			};
			
			var json = new JavaScriptSerializer().Serialize(obj);
			
			_connectionCounter++;
			
			Clients.All.send("Current active number of connection " + _connectionCounter);

			Clients.All.send(json);

			return base.OnConnected();
		}


		public override Task OnDisconnected(bool stopCalled)
		{

			_connectionCounter--;

			return base.OnDisconnected(stopCalled);
		}
	}

}