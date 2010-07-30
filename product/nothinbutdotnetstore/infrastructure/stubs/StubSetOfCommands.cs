using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure.stubs
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        public IEnumerator<RequestCommand> GetEnumerator()
        {
            yield return
                new DefaultRequestCommand(x => x.command.Contains("ViewSubDepartments"),
                                          new ViewSubDepartmentsInADepartment(
                                              Container.retrieve.an<CatalogBrowsingTasks>(),
                                              Container.retrieve.an<ResponseEngine>()));
            yield return
                new DefaultRequestCommand(x => x.command.Contains("ViewProducts"),
                                          new ViewProductsInADepartment(
                                              Container.retrieve.an<CatalogBrowsingTasks>(),
                                              Container.retrieve.an<ResponseEngine>()));
            yield return
                new DefaultRequestCommand(x => true,
                                          new ViewMainDepartments(
                                              Container.retrieve.an<CatalogBrowsingTasks>(),
                                              Container.retrieve.an<ResponseEngine>()));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}