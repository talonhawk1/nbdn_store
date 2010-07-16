using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubFakeCommandSet : IEnumerable<WebCommand>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<WebCommand> GetEnumerator()
        {
            var now = DateTime.Now;
            var random = new Random().Next(0, 2);
            if (now.Hour > 14 || (now.Hour == 14 && now.Minute > 30))
            {
                throw new NotImplementedException();
            }

            yield return new DefaultWebCommand(x => !x.raw_command.Contains("?"),
                                               new ViewMainDepartments(
                                                   IOC.get.an_instance_of<ResponseEngine>(),
                                                   IOC.get.an_instance_of<CatalogTasks>()));
            yield return new DefaultWebCommand(x => x.raw_command.Contains("?") && random == 0,
                                               new ViewSubDepartments(
                                                   IOC.get.an_instance_of<ResponseEngine>(),
                                                   IOC.get.an_instance_of<CatalogTasks>()));
            yield return new DefaultWebCommand(x => x.raw_command.Contains("?"),
                                               new ViewProducts(
                                                   IOC.get.an_instance_of<ResponseEngine>(),
                                                   IOC.get.an_instance_of<CatalogTasks>()));
        }
    }
}