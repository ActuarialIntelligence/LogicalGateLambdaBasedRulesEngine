using AI.Engine.Interfaces;

using AI.Infrastructure.Data;


namespace AI.Engine

{

    //Fork to decide the tree paths in original Rules Engine





    public class RuleEfficacyNodeBasic

    {



        private readonly IDecider _decider;



        public bool _isFinalNode { get; private set; } = false;

        private IAggregator _aggregate;

        private Action _action;

        public RuleEfficacyNodeBasic(IList<double> rowValues, IAggregator aggregate, IDecider decider, Action action,

             bool IsFinalNode)

        {

            _aggregate = aggregate;

            _decider = decider;

            _isFinalNode = IsFinalNode;

            Dro.RowValues = rowValues;

            _action = action;

        }




    }
}