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
        }

        [Subject(typeof(BasicContainer))]
        public class when_getting_a_dependency_and_it_has_the_factory_for_that_dependency : concern
        {
            Establish c = () =>
            {
                factories = new Dictionary<Type, DependencyFactory>();
                provide_a_basic_sut_constructor_argument(factories);

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
            static IDictionary<Type, DependencyFactory> factories;
        }
    }
}