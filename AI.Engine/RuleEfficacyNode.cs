using AI.Engine.Interfaces;

using AI.Infrastructure.Data;


namespace AI.Engine

{

    //Fork to decide the tree paths in original Rules Engine





    public class RuleEfficacyNode

    {



        private readonly IDecider _decider;



        public bool _isFinalNode { get; private set; } = false;

        private IAggregator _aggregate;

        private Action _action;

        public RuleEfficacyNode(IList<double> rowValues, IAggregator aggregate, IDecider decider, Action action,

             bool IsFinalNode)

        {

            _aggregate = aggregate;

            _decider = decider;

            _isFinalNode = IsFinalNode;

            Dro.RowValues = rowValues;

            _action = action;

        }





        //Lets Inline the Delegate



        #region risk Aggregators

        public RuleEfficacyNode? RiskAggregationCondition(Func<double, double, double, double, double, double, double> riskDelegate

            , int arg1, int arg2, int arg3, int arg4, int arg5, int arg6)

        {

            _aggregate._riskAggregation = riskDelegate.Invoke(Dro.RowValues[arg1], Dro.RowValues[arg2], Dro.RowValues[arg3], Dro.RowValues[arg4], Dro.RowValues[arg5], Dro.RowValues[arg6]);

            return this; // In Current State with all vararaible state data

        }



        public RuleEfficacyNode? RiskAggregationCondition(Func<double, double, double, double, double, double> riskDelegate

    , int arg1, int arg2, int arg3, int arg4, int arg5)

        {

            _aggregate._riskAggregation = riskDelegate.Invoke(Dro.RowValues[arg1], Dro.RowValues[arg2], Dro.RowValues[arg3], Dro.RowValues[arg4], Dro.RowValues[arg5]);

            return this; // In Current State with all vararaible state data

        }



        public RuleEfficacyNode? RiskAggregationCondition(Func<double, double, double, double, double> riskDelegate

     , int arg1, int arg2, int arg3, int arg4)

        {

            _aggregate._riskAggregation = riskDelegate.Invoke(Dro.RowValues[arg1], Dro.RowValues[arg2], Dro.RowValues[arg3], Dro.RowValues[arg4]);

            return this; // In Current State with all vararaible state data

        }



        public RuleEfficacyNode? RiskAggregationCondition(Func<double, double, double, double> riskDelegate

    , int arg1, int arg2, int arg3)

        {

            _aggregate._riskAggregation = riskDelegate.Invoke(Dro.RowValues[arg1], Dro.RowValues[arg2], Dro.RowValues[arg3]);

            return this; // In Current State with all vararaible state data

        }

        public RuleEfficacyNode? RiskAggregationCondition(Func<double, double, double> riskDelegate

            , int arg1, int arg2)

        {

            _aggregate._riskAggregation = riskDelegate.Invoke(Dro.RowValues[arg1], Dro.RowValues[arg2]);// sample

            return this; // In Current State with all vararaible state data

        }

        #endregion



        #region RowBasedConditioningForAlertInvocation

        public RuleEfficacyNode? AddCondition<T>(Func<T, bool> lambdaCondition, T row1)

        {

            var result = lambdaCondition.Invoke(row1);

            if (result)

            {

                _aggregate.conditionlist.Add(_aggregate.conditionlist.Count(), result);

            }

            return this; // In Current State with all vararaible state data

        }



        public RuleEfficacyNode? AddListCondition<T>(Func<IList<T>, bool> lambdaCondition, IList<T> rows1)

        {

            var result = lambdaCondition.Invoke(rows1);

            if (result)

            {

                _aggregate.conditionlist.Add(_aggregate.conditionlist.Count(), result);

            }

            return this; // In Current State with all vararaible state data

        }

        public RuleEfficacyNode? AddListCondition<T>(Func<IList<T>, IList<T>, bool> lambdaCondition, IList<T> row1, IList<T> row2)

        {

            var result = lambdaCondition.Invoke(row1, row2);

            if (result)

            {

                _aggregate.conditionlist.Add(_aggregate.conditionlist.Count(), result);

            }

            return this; // In Current State with all vararaible state data

        }





        public RuleEfficacyNode? AddListCondition<T, U>(Func<IList<T>, IList<U>, bool>

            lambdaCondition, IList<T> rows1, IList<U> rows2)

        {

            var result = lambdaCondition.Invoke(rows1, rows2);

            if (result)

            {

                _aggregate.conditionlist.Add(_aggregate.conditionlist.Count(), result);

            }

            return this; // In Current State with all vararaible state data

        }



        public RuleEfficacyNode? AddListCondition<T, U, V>(Func<IList<T>, IList<U>, IList<V>, bool>

            lambdaCondition, IList<T> rows1, IList<U> rows2, IList<V> rows3)

        {

            var result = lambdaCondition.Invoke(rows1, rows2, rows3);

            if (result)

            {

                _aggregate.conditionlist.Add(_aggregate.conditionlist.Count(), result);

            }

            return this; // In Current State with all vararaible state data

        }



        public RuleEfficacyNode? AddListCondition<T, U, V, W>(Func<IList<T>, IList<U>, IList<V>, IList<W>, bool>

            lambdaCondition, IList<T> rows1, IList<U> rows2, IList<V> rows3, IList<W> rows4)

        {

            var result = lambdaCondition.Invoke(rows1, rows2, rows3, rows4);

            if (result)

            {

                _aggregate.conditionlist.Add(_aggregate.conditionlist.Count(), result);

            }

            return this; // In Current State with all vararaible state data

        }
        #endregion
    }
}