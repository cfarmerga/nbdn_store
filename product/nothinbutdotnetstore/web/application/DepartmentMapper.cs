using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.application
{
    public class DepartmentMapper : DiscreteMapper<NameValueCollection, Department>
    {
        public Department map_from(NameValueCollection input)
        {
            return new Department
            {
                name = InputModels.department.name.map_from(input),
                id = InputModels.department.id.map_from(input)
            };
        }
    }
}