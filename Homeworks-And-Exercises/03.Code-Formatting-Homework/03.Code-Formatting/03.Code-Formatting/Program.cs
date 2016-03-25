using System;
using System.Text;

public class Event : IComparable
{
    private readonly string title;
    private readonly string location;
    private DateTime date;

    public Event(DateTime date, string title, string location)
    {
        this.date = date;
        this.title = title;
        this.location = location;
    }

    public int CompareTo(object obj)
    {
        Event other = obj as Event;
        int comparisonByDate = this.date.CompareTo(other.date);
        int comparisonByTitle = this.title.CompareTo(other.title);
        var comparisonByLocation = this.location.CompareTo(other.location);

        if (comparisonByDate == 0)
        {
            if (comparisonByTitle == 0)
            {
                return comparisonByLocation;
            }
            else
            {
                return comparisonByTitle;
            }
        }
        else
        {
            return comparisonByDate;
        }
    }

    public override string ToString()
    {
        StringBuilder toString = new StringBuilder();

        toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
        toString.Append(" | " + this.title);
        if (!string.IsNullOrEmpty(this.location))
        {
            toString.Append(" | " + this.location);
        }

        return toString.ToString();
    }
}

public class Program
{
    public static readonly StringBuilder Output = new StringBuilder();
    public static readonly EventHolder Events = new EventHolder();

    internal static void Main(string[] args)
    {
        while (ExecuteNextCommand())
        {
        }

        Console.WriteLine(Output);
    }

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();

        if (command[0] == 'A')
        {
            AddEvent(command); 
            return true;
        }

        if (command[0] == 'D')
        {
            DeleteEvents(command); 
            return true;
        }

        if (command[0] == 'L')
        {
            ListEvents(command); 
            return true;
        }

        if (command[0] == 'E')
        {
            return false;
        }

        return false;
    }

    private static void ListEvents(string command)
    {
        int pipeIndex = command.IndexOf('|');
        DateTime date = GetDate(command, "ListEvents");
        string countString = command.Substring(pipeIndex + 1);
        int count = int.Parse(countString);

        Events.ListEvents(date, count);
    }

    private static void DeleteEvents(string command)
    {
        string title = command.Substring("DeleteEvents".Length + 1);

        Events.DeleteEvents(title);
    }

    private static void AddEvent(string command)
    {
        DateTime date; 
        string title; 
        string location;

        GetParameters(command, "AddEvent", out date, out title, out location);

        Events.AddEvent(date, title, location);
    }

    private static void GetParameters(
        string commandForExecution, 
        string commandType, 
        out DateTime dateAndTime, 
        out string eventTitle, 
        out string eventLocation)
    {
        dateAndTime = GetDate(commandForExecution, commandType);
        int firstPipeIndex = commandForExecution.IndexOf('|');
        int lastPipeIndex = commandForExecution.LastIndexOf('|');

        if (firstPipeIndex == lastPipeIndex)
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
            eventLocation = string.Empty;
        }
        else
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
            eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
        }
    }

    private static DateTime GetDate(string command, string commandType)
    {
        DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));

        return date;
    }

    public class EventHolder
    {
        private readonly MultiDictionary<string, Event> eventCollectionByTitle = new MultiDictionary<string, Event>(true);
        private readonly OrderedBag<Event> eventCollectionByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);

            this.eventCollectionByTitle.Add(title.ToLower(), newEvent);
            this.eventCollectionByDate.Add(newEvent);

            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in this.eventCollectionByTitle[title])
            {
                removed++;
                this.eventCollectionByDate.Remove(eventToRemove);
            }

            this.eventCollectionByTitle.Remove(title);

            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View
            eventsToShow = this.eventCollectionByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);

                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }

    internal static class Messages
    {
        public static void EventAdded()
        {
            Output.Append("Event added\n");
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                Output.AppendFormat("{0} Events deleted\n", x);
            }
        }

        public static void NoEventsFound()
        {
            Output.Append("No Events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output.Append(eventToPrint + "\n");
            }
        }
    }
}