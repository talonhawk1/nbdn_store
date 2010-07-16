 using System;
 using System.Collections.Generic;
 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
 {   
     public class DefaultViewRegistrySpecs
     {
         public abstract class concern : Observes<ViewRegistry,
             DefaultViewRegistry>
         {
        
         }

         [Subject(typeof(DefaultViewRegistry))]
         public class when_getting_path_to_view_for_view_model : concern
         {
             Establish c = () =>
             {
                 view_types = new[]
                 {
                     typeof (OtherView),
                     typeof (OtherView),
                     typeof (TestView)
                 };
                 provide_a_basic_sut_constructor_argument(view_types);
             };

             Because b = () =>
                 result = sut.get_path_to_view_for<TestModel>();

             It should_return_path_of_view_for_model = () =>
                 result.ShouldEqual("~/views/TestView.aspx");

             static string result;
             static IEnumerable<Type> view_types;
         }

         class TestModel{}
         
         abstract class TestView : ViewFor<TestModel> 
         {
             public abstract void ProcessRequest(HttpContext context);
             public abstract bool IsReusable { get; }
             public abstract TestModel model { get; set; }
         }

         abstract class OtherView : ViewFor<object>
         {
             public abstract void ProcessRequest(HttpContext context);
             public abstract bool IsReusable { get; }
             public abstract object model { get; set; }
         }
     }
 }
