using System.Collections.Generic;

namespace ConnectToCRM.Models
{
    public class DynamicsEntityCollection<T>
    {
        public IList<T> Value { get; set; }
        //public string NextLink { get; set; }
    }
}
