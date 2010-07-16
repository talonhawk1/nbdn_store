using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewFactory : ViewFactory
    {
        ViewRegistry view_registry;

        public static PageFactory page_factory = delegate
        {
            throw new Exception(
                "You need to register a page factory at application startup");
        };

        public DefaultViewFactory(ViewRegistry view_registry)
        {
            this.view_registry = view_registry;
        }

        public ViewFor<ViewModel> create_view<ViewModel>(ViewModel view_model)
        {
            var view = (ViewFor<ViewModel>) page_factory(view_registry.get_path_to_view_for<ViewModel>(),
                                                         typeof(ViewFor<ViewModel>));

            view.model = view_model;

            return view;
        }
    }
}