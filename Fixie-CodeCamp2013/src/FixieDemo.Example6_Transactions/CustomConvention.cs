using Fixie;
using Fixie.Conventions;

namespace FixieDemo.Example6_Transactions
{
    public class IntegrationTestConvention : Convention
    {
        public IntegrationTestConvention()
        {
            Classes
                .NameEndsWith("Tests");

            Cases
                .Where(method => method.Void());

            InstanceExecution
                .Wrap((fixture, innerBehavior) =>
                {
                    using (new TransactionScope())
                        innerBehavior();
                });
        }
    }
}