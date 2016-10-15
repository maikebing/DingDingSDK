using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.department
{
    public class Department
    {
        public String id;
        public String name;
        public String parentid;
        public override string ToString()
        {
            return "Department[id:" + id + ", name:" + name + ", parentId:" + parentid + "]";
        }
    }
}
