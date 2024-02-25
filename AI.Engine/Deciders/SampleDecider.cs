using AI.Engine.Interfaces;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace AI.Engine.Deciders

{

    public class SampleDecider : IDecider

    {



        public SampleDecider()

        {



        }

        public void Invoke(Action action)

        {

            action.Invoke();

        }



        public void Decide(IAggregator aggregate, Action action)

        {

            if (aggregate.IsAllTrue() && aggregate._riskAggregation > 60)

            {

                action.Invoke();

            }

        }

    }

}