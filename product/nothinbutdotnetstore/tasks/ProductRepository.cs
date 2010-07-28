using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface ProductRepository
    {
        IEnumerable<Product> get_products_for_department(Department department);
    }
}