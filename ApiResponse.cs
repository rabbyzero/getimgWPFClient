using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getimgWPFClient
{
    internal class ApiResponse:GetimgResponse
    {
        public class Success
        {
            public float cost {  get; set; }
            public int seed { get; set; }
            public String url { get; set; }
        }
        ApiResponse() { }
    }
}
