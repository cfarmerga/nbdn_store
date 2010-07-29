 using System.Collections.Specialized;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.model;
 using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.specs.web
 {   
     public class DepartmentMapperSpecs
     {
         public abstract class concern : Observes<DiscreteMapper<NameValueCollection,Department>,
                                             DepartmentMapper>
         {
        
         }

         [Subject(typeof(DepartmentMapper))]
         public class when_mapping_a_department_from_a_payload : concern
         {

             Establish c = () =>
             {
                 reference = new Department {name = "the name",id =  23};
                 payload = new NameValueCollection();
                 payload.Add(InputModels.department.name,reference.name);
                 payload.Add(InputModels.department.id,reference.id.ToString());
             };

             Because b = () =>
                 result = sut.map_from(payload);


             It should_map_the_department_using_the_payload_values = () =>
             {
                 result.name.ShouldEqual(reference.name);
                 result.id.ShouldEqual(reference.id);
             };

             static Department result;
             static Department reference;
             static NameValueCollection payload;
         }
     }
 }
