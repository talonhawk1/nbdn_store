 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ResponseEngineSpecs
     {
         public abstract class concern : Observes<ResponseEngine,
                                             DefaultResponseEngine>
         {
        

         }

         public class Logger
         {
            public static void info(string message)
            {

            } 
         }

         [Subject(typeof(DefaultResponseEngine))]
         public class when_displaying_a_view_model : concern
         {

             Establish c = () =>
             {
                 view_factory = the_dependency<ViewFactory>();
                 http_context = ObjectMother.create_http_context();

                 view_model = new object();
                 actual_view = an<ViewFor<object>>();

                 Context context = () => http_context;
                 view_factory.Stub(factory => factory.create_view(view_model)).Return(actual_view);

                 change(() => DefaultResponseEngine.context).to(context);

             };

             Because b = () =>
                 sut.display(view_model);



             It should_tell_the_view_to_process = () =>
                 actual_view.received(x => x.ProcessRequest(http_context));
  
  

             static object view_model;
             static ViewFactory view_factory;
             static ViewFor<object> actual_view;
             static HttpContext http_context;
         }
     }
 }
