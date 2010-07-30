 using System.Collections.Specialized;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.specs.web
 {   
     public class PayloadKeySpecs
     {
         public abstract class concern : Observes<PayloadKey<long>>
         {
        
         }

         [Subject(typeof(PayloadKey<>))]
         public class when_implicitly_converting_to_a_string : concern
         {
             Establish c = () =>
             {
                 provide_a_basic_sut_constructor_argument(key_name);
             };

             Because b = () =>
                 result = sut;

             It should_return_the_name_of_the_key = () =>
                 result.ShouldEqual(key_name);

             static string result;
             static string key_name;
         }

         [Subject(typeof(PayloadKey<>))]
         public class when_rendering_as_string : concern
         {
             Establish c = () =>
             {
                 key_name = "sdfsdf";
                 provide_a_basic_sut_constructor_argument(key_name);
             };

             Because b = () =>
                 result = sut.ToString();

             It should_return_the_name_of_the_key = () =>
                 result.ShouldEqual(key_name);

             static string result;
             static string key_name;
         }

         public class when_mapping_a_value_from_a_payload : concern
         {
             Establish c = () =>
             {
                 key_name = "sdfsdf";
                 all_values = new NameValueCollection();
                 value_to_map = 23;
                 all_values.Add(key_name, value_to_map.ToString());
                 provide_a_basic_sut_constructor_argument(key_name);
             };

             Because b = () =>
                 result = sut.map_from(all_values);

             It should_return_the_value_as_the_correct_type = () =>
                 result.ShouldEqual(value_to_map);

             static long result;
             static string key_name;
             static long value_to_map;
             static NameValueCollection all_values;
         }
     }
 }
