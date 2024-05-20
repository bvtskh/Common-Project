using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject.Template
{
    public interface IFormTemplete
    {
        DataTable GetData();
        DataTable ImportData();
        void RequestCompleted(DataTable dt);
    }
}
