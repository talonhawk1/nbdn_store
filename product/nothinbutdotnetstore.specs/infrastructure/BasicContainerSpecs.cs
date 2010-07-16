using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class BasicContainerSpecs
    {
        public abstract class concern : Observes<Container,
                                            BasicContainer>
        {
            Establish c = () =>
            {
                factories = new Dictionary<Type, DependencyFactory>();
                provide_a_basic_sut_constructor_argument(factories);
            };

            protected static IDictionary<Type, DependencyFactory> factories;
        }

        [Subject(typeof(BasicContainer))]
        public class when_getting_a_dependency_and_it_has_the_factory_for_that_dependency : concern
        {
            Establish c = () =>
            {
                connection = new SqlConnection();
                DependencyFactory factory = () => connection;
                factories.Add(typeof(IDbConnection), factory);
            };

            Because b = () =>
                result = sut.an_instance_of<IDbConnection>();

            It should_return_the_dependency_created_by_the_factory = () =>
                result.ShouldEqual(connection);

            static object result;
            static IDbConnection connection;
        }

        [Subject(typeof(BasicContainer))]
        public class when_getting_a_dependency_and_it_does_not_have_the_factory_for_that_dependency : concern
        {
            Because b = () =>
                catch_exception(() => sut.an_instance_of<IDbConnection>());

            It should_get_a_factory_not_registered_exception_that_provides_access_to_the_type_that_has_no_factory =
                () =>
                {
                    exception_thrown_by_the_sut.ShouldBeAn<DependencyFactoryNotRegisteredException>()
                        .type_that_has_no_factory.ShouldEqual(typeof(IDbConnection));
                };
        }

        [Subject(typeof(BasicContainer))]
        public class when_getting_a_dependency_and_the_factory_for_the_dependency_throws_an_exception : concern
        {
            Establish c = () =>
            {
                inner_exception = new Exception();
                DependencyFactory factory = delegate { throw inner_exception; };
                factories.Add(typeof(IDbConnection), factory);
            };

            Because b = () =>
                catch_exception(() => sut.an_instance_of<IDbConnection>());

            It should_throw_a_dependency_creation_exception_that_provides_access_to_the_correct_information =
                () =>
                {
                    var exception = exception_thrown_by_the_sut.ShouldBeAn<DependencyCreationException>();
                    exception.type_that_could_not_be_created.ShouldEqual(typeof(IDbConnection));
                    exception.InnerException.ShouldEqual(inner_exception);
                };

            static Exception inner_exception;
        }
    }
}