namespace AI.Engine.Interfaces

{



    public interface IDecider

    {

        void Invoke(Action action);

        void Decide(IAggregator aggregate, Action action);

    }

}