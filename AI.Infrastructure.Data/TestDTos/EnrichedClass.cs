using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Infrastructure.Data.TestDTos
{
    // Sample class for enrichment
    public class EnrichedClass
    {
        public double Age { get; set; } = 82;
        public double TransactionAmount { get; set; } = 100000;
        public double Frequency { get; set; } = 11;
    }

    // Sample class for settings
    public class SettingsClass
    {
        public double TransactionThereshold { get; set; } = 50000;
        public double AgeThereshold { get; set; } = 20;
        public double FrequencyThereshold { get; set; } = 30;
    }
}
