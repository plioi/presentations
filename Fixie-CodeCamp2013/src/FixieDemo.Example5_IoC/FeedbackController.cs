namespace FixieDemo.Example5_IoC
{
    public class FeedbackController : Controller
    {
        private readonly ISupportTicketService _support;
        private readonly ITwitter _twitter;

        public FeedbackController(ISupportTicketService support, ITwitter twitter)
        {
            _support = support;
            _twitter = twitter;
        }

        public void SubmitComplaint(ComplaintForm form)
        {
            _support.CreateTicket(form.Handle, form.Complaint);

            _twitter.SendPrivateMessage(
                form.Handle,
                "Thanks for your feedback! Our support " +
                "staff will contact you shortly.");
        }
    }
}
