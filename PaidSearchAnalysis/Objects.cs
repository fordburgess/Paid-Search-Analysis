using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaidSearchAnalysis
{

    public class BrandData
    {
        public string Brand { get; set; }
        public double SearchesSum { get; set; }
        public double ImpressionsSum { get; set; }
        public double NetCostSum { get; set; }
    }

    public class Output
    {
        public string YearHalf { get; set; }
        public List<BrandData> Outputs { get; set; }
        public double SearchesTotal { get; set; }
        public double ImpressionsTotal { get; set; }
        public double NetCostTotal { get; set; }

    }
}
