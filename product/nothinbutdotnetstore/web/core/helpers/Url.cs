using System;
using System.Collections.Generic;
using System.Linq;
namespace nothinbutdotnetstore.web.core.helpers
{
    public class Url
    {
        public static UrlBuilder<Command> for_command<Command>() where Command : ApplicationCommand
        {
            return new UrlBuilder<Command>();
        }
    }

    public interface UrlBuilder
    {
        string get_url();
    }

    public class UrlBuilder<Command> : UrlBuilder where Command : ApplicationCommand
    {
        public virtual string get_url()
        {
            return string.Format("{0}.store", typeof (Command).Name);
        }

        public UrlBuilder<Command, Model> with_input_model<Model>(Model model)
        {
            return new UrlBuilder<Command, Model>(model);
        }
    }

    public class UrlBuilder<Command, Model> : UrlBuilder where Command : ApplicationCommand
    {
        Model model;
        IDictionary<string, string> parameters;
        UrlBuilder inner_builder;

        public UrlBuilder(Model model)
        {
            inner_builder = new UrlBuilder<Command>();
            this.model = model;
            parameters = new Dictionary<string, string>();
        }

        private UrlBuilder(Model model, IEnumerable<KeyValuePair<string, string>> parameters, 
            string new_field, string new_value) : this(model)
        {
            parameters.each(parameter => this.parameters.Add(parameter));
            this.parameters.Add(new_field, new_value);
        }

        public string get_url()
        {
            var base_url = inner_builder.get_url();         
            if (parameters.Count == 0)
                return base_url;

            var query_string = new StringBuilder();
            parameters.each(parameter =>
            {
                query_string.Append(query_string.Length == 0 ? "?" : "&");
                query_string.AppendFormat("{0}={1}", parameter.Key, parameter.Value);
            });
            return string.Format("{0}{1}", base_url, query_string);
        }

        public UrlBuilder<Command, Model> with_parameter<ReturnType>(Expression<Func<Model, ReturnType>> func)
        {
            string name;
            if (func.Body is UnaryExpression)
            {
                var expression = (UnaryExpression) func.Body;
                name = expression.Method.Name;
            }
            else
            {
                var expression = (MemberExpression) func.Body;
                name = expression.Member.Name;
            }
            var value = func.Compile().Invoke(model).ToString();

            return new UrlBuilder<Command, Model>(model, parameters, name, value);
        }
    }
}