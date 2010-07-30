using System.Data;
using System.Linq;
using System.Reflection;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.custom;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class AutoWiringDependencyFactorySpecs
    {
        public abstract class concern : Observes<DependencyFactory,
                                            AutoWiringDependencyFactory>
        {
        }

        [Subject(typeof(AutoWiringDependencyFactorySpecs))]
        public class when_creating_a_dependency_and_it_has_other_dependencies : concern
        {
            Establish c = () =>
            {
                the_constructor =
                    typeof(OurItemWithDependencies).GetConstructors().OrderByDescending(x => x.GetParameters().Count())
                        .First();

                provide_a_basic_sut_constructor_argument(typeof(OurItemWithDependencies));
                constructor_resolver = the_dependency<ConstructorResolver>();
                constructor_resolver.Stub(x => x.get_applicable_constructor_on(typeof(OurItemWithDependencies))).Return
                    (the_constructor);
                container = the_dependency<DependencyContainer>();

                the_connection = an<IDbConnection>();
                the_command = an<IDbCommand>();
                the_adapter = an<IDbDataAdapter>();

                container.Stub(x => x.an(typeof(IDbConnection))).Return(the_connection);
                container.Stub(x => x.an(typeof(IDbCommand))).Return(the_command);
                container.Stub(x => x.an(typeof(IDbDataAdapter))).Return(the_adapter);
            };

            Because b = () =>
                result = sut.create();

            It should_create_the_dependency_while_also_satisfying_its_dependencies = () =>
            {
                var item_with_dependencies = result.ShouldBeAn<OurItemWithDependencies>();
                item_with_dependencies.connection.ShouldEqual(the_connection);
                item_with_dependencies.command.ShouldEqual(the_command);
                item_with_dependencies.adapter.ShouldEqual(the_adapter);
            };

            static object result;
            static IDbConnection the_connection;
            static IDbCommand the_command;
            static IDbDataAdapter the_adapter;
            static ConstructorResolver constructor_resolver;
            static ConstructorInfo the_constructor;
            static DependencyContainer container;
        }

        class OurItemWithDependencies
        {
            public IDbConnection connection { get; set; }

            public IDbCommand command { get; set; }

            public IDbDataAdapter adapter { get; set; }

            public OurItemWithDependencies(IDbConnection connection, IDbCommand command)
            {
                this.connection = connection;
                this.command = command;
            }

            public OurItemWithDependencies(IDbConnection connection, IDbCommand command, IDbDataAdapter adapter)
            {
                this.connection = connection;
                this.command = command;
                this.adapter = adapter;
            }
        }
    }
}