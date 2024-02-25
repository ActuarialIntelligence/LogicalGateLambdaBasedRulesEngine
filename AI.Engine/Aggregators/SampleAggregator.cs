using AI.Engine.Interfaces;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace AI.Engine.Aggregators

{

    public class SampleAggregator : IAggregator

    {

        //less than Greater than

        //if less than return some risk value.

        public double _riskAggregation { get; set; } = 0;



        public IDictionary<int, bool> conditionlist { get; set; } = new Dictionary<int, bool>();



        public bool IsAllTrue()

        {

            var result = conditionlist.Where(s => s.Value == false);

            if (result == null)

            {

                return true;

            }

            else

            {

                return false;

            }

        }

    }

}