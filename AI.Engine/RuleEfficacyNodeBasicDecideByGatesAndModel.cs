using AI.Engine.Interfaces;
using AI.Infrastructure.Data;


namespace AI.Engine

{
    public class RuleEfficacyNodeBasicDecideByGatesAndModel
    {

        public bool _isFinalNode { get; private set; } = false;
        private static bool _lambdaResult;
        private static CentroidData _centroidData { get; set; }

        public RuleEfficacyNodeBasicDecideByGatesAndModel(bool lambdaResult)
        {
            _lambdaResult = lambdaResult;
        }
        /// <summary>
        /// Simpple choice of action on decide.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public RuleEfficacyNodeBasicDecideByGatesAndModel 
            IfLambdaTrueDecideAndEffect(Action action)
        {
            if(_lambdaResult)
            {
                action();
            }
            return this;
        }

        public RuleEfficacyNodeBasicDecideByGatesAndModel 
            RuleEfficacyNodeBasicOnLambdaDecideByModel(Func<CentroidData> action)// PythonExecutor.ExecPythonScript()
        {
            _centroidData = action();
            return this;
        }
    }
}