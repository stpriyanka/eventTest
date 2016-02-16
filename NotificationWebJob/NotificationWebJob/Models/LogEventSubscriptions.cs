using System;

namespace NotificationWebJob.Models
{
	public class LogEventSubscriptions
	{

		public Guid Id { get; set; }

		public string UserWhoSubscribed { get; set; }

		public Enum.EventType EventType { get; set; }

		public Enum.ObjectTypeOfEvent ObjectTypeOfEvent { get; set; }
	}
	//public class Notification
	//{

	//	public Guid Id { get; set; }

	//	//public string UserWhoSubscribed { get; set; }

	//	public Enum.EventType EventType { get; set; }

	//	public Enum.ObjectTypeOfEvent ObjectTypeOfEvent { get; set; }


	//	public DateTime  DateTime.Now { get; set; }
	//	public DateTime seennAt { get; set; }


	//}
}