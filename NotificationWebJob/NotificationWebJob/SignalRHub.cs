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

		NotificationDb _myDbContext = new NotificationDb();

		public async Task sendMessage(string message)
		{

			//message = "sssssssssssssssssssss";

			Clients.All.send(message);
		}


		public override Task OnConnected()
		{

			// on production should have a query if seen== false then trigger 'send'

			var name = _myDbContext.LogEventSubscriptionses.Where(r => r.UserWhoSubscribed == Context.User.Identity.Name).Select(r => r.UserWhoSubscribed);

			Clients.All.send(name);

			//implement method html in index

			return base.OnConnected();
		}
	}

}