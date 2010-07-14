using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator,DefaultCalculator>
        {
        }

        public class when_shutting_off_the_calculator_and_they_are_not_in_the_correct_role : concern
        {
            Establish c = () =>
            {
                principal = an<IPrincipal>();
                principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

                change(() => Thread.CurrentPrincipal).to(principal);
            };

            Because b = () =>
                catch_exception(() => sut.shut_off());



            It should_shut_off_successfully = () =>
                exception_thrown_by_the_sut.ShouldBeAn<SecurityException>();

            static IPrincipal principal;
        }
        public class when_shutting_off_the_calculator_and_they_are_in_the_correct_role : concern
        {
            Establish c = () =>
            {
                principal = an<IPrincipal>();
                principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);

                change(() => Thread.CurrentPrincipal).to(principal);
            };

            Because b = () =>
                sut.shut_off();


            It should_shut_off_successfully = () =>
            {

            };

            static IPrincipal principal;
        }
        public class when_adding_two_numbers : concern
        {
            Establish c = () =>
            {
                connection = the_dependency<IDbConnection>();
                command = an<IDbCommand>();
                connection.Stub(x => x.CreateCommand()).Return(command);
            };

            Because b = () =>
                result = sut.add(2, 2);

            It should_return_the_sum = () =>
                result.ShouldEqual(4);

            It should_open_a_connection_to_the_database = () =>
                connection.received(x => x.Open());

            It should_run_the_command = () =>
                command.received(db_command => db_command.ExecuteNonQuery());

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }
    }

    public interface Calculator
    {
        int add(int first, int second);
        void shut_off();
    }

    public class DefaultCalculator : Calculator
    {
        IDbConnection connection;

        public DefaultCalculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
                return first + second;
            }
        }

        public void shut_off()
        {
            if (Thread.CurrentPrincipal.IsInRole("blah")) return;

            throw new SecurityException();
        }
    }
}