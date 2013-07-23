using System;
using System.Collections.Generic;
using System.Linq;

namespace FixieDemo.Example5_IoC
{
    public class ComplaintForm
    {
        public string Handle { get; set; }
        public string Complaint { get; set; }
    }

    public interface ITwitter
    {
        void SendPrivateMessage(string handle, string message);
    }

    public interface ISupportTicketService
    {
        void CreateTicket(string handle, string complaint);
    }

    public class Controller
    {
    }

    public interface ISupportTicketRepository
    {
        Ticket[] GetAll();
    }

    public class Ticket
    {
        public string Handle { get; set; }
        public string Complaint { get; set; }
        public TicketStatus Status { get; set; }
    }

    public enum TicketStatus
    {
        Open
    }


    public class RealSupportTicketRepository : ISupportTicketRepository
    {
        static internal List<Ticket> all = new List<Ticket>();

        public Ticket[] GetAll()
        {
            return all.ToArray();
        }
    }

    public class RealSupportTicketService : ISupportTicketService
    {
        public void CreateTicket(string handle, string complaint)
        {
            Console.WriteLine("Support ticket created against a real (integration) database: {0} {1}", handle, complaint);

            RealSupportTicketRepository.all.Add(new Ticket
            {
                Handle = handle,
                Complaint = complaint,
                Status = TicketStatus.Open
            });
        }
    }

    public class FakeTwitter : ITwitter
    {
        public void SendPrivateMessage(string handle, string message)
        {
            Console.WriteLine("Fake tweet to {0}: {1}", handle, message);
        }
    }

    public class IoCContainer
    {
        readonly Dictionary<Type, object> instances = new Dictionary<Type, object>();

        public void Add(Type type, object instance)
        {
            instances[type] = instance;
        }

        public object Get(Type type)
        {
            if (instances.ContainsKey(type))
                return instances[type];

            var constructor = type.GetConstructors().Single();

            var parameters = constructor.GetParameters();

            var arguments = parameters.Select(p => Get(p.ParameterType)).ToArray();

            return Activator.CreateInstance(type, arguments);
        }
    }
}
