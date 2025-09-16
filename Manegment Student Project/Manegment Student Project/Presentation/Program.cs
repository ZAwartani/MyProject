using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.Presentation
{
    public class Program : Presentation.Presentaion_Layer
    {
        static void Main(string[] args)
        {
            Presentaion_Layer p = new Presentaion_Layer();
            p.ShowMenu();
        }
    }
}
