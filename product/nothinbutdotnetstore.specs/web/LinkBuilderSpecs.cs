using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.specs.utility;

namespace nothinbutdotnetstore.specs.web
{
    public class LinkBuilderSpecs
    {
        public abstract class concern : Observes
        {
        }

        public class when_retrieving_a_department_link : concern
        {
            private Establish c = () =>
                                      {
                                          department = new Department() {has_sub_departments = true, name = "Dept"};
                                          url = "xxxx";
                                          url2 = "yyyy";
                                      };

            private Because b = () =>
                                result = Link<Department>.for_a(department).when(d => d.has_sub_departments).then(url).otherwise(url2);

            private It should_render_a_link_to_a_subdepartment_list = () =>
                                                                      result.ShouldEqual(url);


            private static string result;
            private static Department department;
            private static string url;
            private static string url2;
        }
    }
}