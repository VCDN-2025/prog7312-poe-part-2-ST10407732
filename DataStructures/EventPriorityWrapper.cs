//using MunicipalServicesApp.Models;
//using System;

//namespace MunicipalServicesApp.DataStructures
//{
//    public class EventPriorityWrapper : IComparable<EventPriorityWrapper>
//    {
//        public Event Event { get; set; }

//        public EventPriorityWrapper(Event evt)
//        {
//            Event = evt;
//        }

//        public int CompareTo(EventPriorityWrapper other)
//        {
//            if (other == null) return 1;
//            int priorityCompare = this.Event.Priority.CompareTo(other.Event.Priority);
//            if (priorityCompare != 0) return priorityCompare;
//            return this.Event.Date.CompareTo(other.Event.Date);
//        }
//    }
//}
