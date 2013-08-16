using System.Linq;
using Should;

namespace FixieDemo.Example5_IoC
{
    public class FeedbackControllerTests
    {
        readonly FeedbackController _controller;
        readonly ISupportTicketRepository _tickets;

        public FeedbackControllerTests(FeedbackController controller, ISupportTicketRepository tickets)
        {
            _controller = controller;
            _tickets = tickets;
        }

        public void ShouldCreateSupportTicketWhenCustomerSubmitsComplaint()
        {
            _controller.SubmitComplaint(new ComplaintForm { Handle = "@plioi", Complaint = "Needs more cowbell." });

            var ticket = _tickets.GetAll().Single();

            ticket.Handle.ShouldEqual("@plioi");
            ticket.Complaint.ShouldEqual("Needs more cowbell.");
            ticket.Status.ShouldEqual(TicketStatus.Open);
        }
    }
}
