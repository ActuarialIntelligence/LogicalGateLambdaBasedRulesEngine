namespace AI.Engine.Interfaces

{

    public interface IAggregator

    {

        double _riskAggregation { get; set; }

        IDictionary<int, bool> conditionlist { get; set; }
        bool IsAllTrue();

    }

}