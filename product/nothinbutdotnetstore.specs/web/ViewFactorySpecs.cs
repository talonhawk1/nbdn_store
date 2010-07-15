 using System;
 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ViewFactorySpecs
     {
         public abstract class concern : Observes<ViewFactory,
                                             DefaultViewFactory>
         {
        
         }

         [Subject(typeof(DefaultViewFactory))]
         public class when_creating_a_view_from_a_view_model : concern
         {

             Establish c = () =>
             {
                 item = new object();
                 view_registry = the_dependency<ViewRegistry>();
                 view = an<ViewFor<object>>();

                 PageFactory factory = (path, type) =>
                 {
                     path_requested = path;
                     type_requested = type;
                     return view;
                 };

                 view_path = "blah.aspx";
                 view_registry.Stub(x => x.get_path_to_view_for<object>()).Return(view_path);

                 change(() => DefaultViewFactory.page_factory).to(factory);

             };

             Because b = () =>
                 view = sut.create_view(item);

             It should_provide_the_page_factory_with_the_correct_details_for_correct_construction = () =>
             {
                 path_requested.ShouldEqual(view_path);
                 type_requested.ShouldEqual(typeof(ViewFor<object>));


             };
  
             It should_create_a_view_that_has_been_populated_with_its_data = () =>
                 view.model.ShouldEqual(item);

             static ViewFor<object> view;
             static object item;
             static ViewRegistry view_registry;
             static string view_path;
             static string path_requested;
             static Type type_requested;
         }
     }
 }
