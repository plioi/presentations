using System;
using Fixie;
using Fixie.Conventions;

namespace FixieDemo.Example5_IoC
{
    public class IntegrationTestConvention : Convention
    {
        readonly IoCContainer container;

        public IntegrationTestConvention()
        {
            container = InitContainerForIntegrationTests();

            Classes
                .Where(type => type.IsInNamespace(GetType().Namespace))
                .NameEndsWith("Tests");

            Cases
                .Where(method => method.Void());

            ClassExecution
                .CreateInstancePerTestClass(UsingContainer);
        }

        static IoCContainer InitContainerForIntegrationTests()
        {
            //Prepare the IoC Container for integration testing:
            //real implementations where possible, and fakes
            //where necessary.

            var container = new IoCContainer();

            container.Add(typeof(ISupportTicketService), new RealSupportTicketService());
            container.Add(typeof(ITwitter), new FakeTwitter());
            container.Add(typeof(ISupportTicketRepository), new RealSupportTicketRepository());

            return container;
        }

        object UsingContainer(Type fixtureclass)
        {
            //Teach Fixie to use the IoC container
            //in order to obtain an instance of a
            //test fixture class.

            return container.Get(fixtureclass);
        }
    }
}