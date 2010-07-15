using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.extensions;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class EnumerableExtensionsSpecs
    {
        public abstract class  concern : Observes
        {
            
        }
        public class when_performing_an_action_over_a_set_of_items : concern
        {
            Establish c = () =>
            {
                items = new List<int>(Enumerable.Range(1,1000));
            };

            Because b = () =>
                EnumerableExtensions.each(items, x => number_of_items_visisted++);


            It should_visit_each_item_in_the_set_with_the_visitor = () =>
                number_of_items_visisted.ShouldEqual(items.Count);

            static int number_of_items_visisted;
            static IList<int > items;
        } 
    }
}