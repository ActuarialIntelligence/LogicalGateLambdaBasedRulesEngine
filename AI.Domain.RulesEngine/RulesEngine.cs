using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AI.Domain.RulesEngine
{
    public static class RulesEngine
    {

        // Function to process the CSV string and apply lambdas
        public static async Task<IList<bool>> ProcessLambdas(List<string> lambdas)
        {
            var boolList = new List<bool>();

            foreach (var lambda in lambdas)
            {
                var lambdaResult = ExecuteLambda<EnrichedClass, SettingsClass>(new EnrichedClass(), new SettingsClass(), lambda);
                boolList.Add(lambdaResult);
            }
            return boolList;
        }

        // Function to execute lambda expression dynamically
        public static bool ExecuteLambda<T, U>(T enriched, U settings, string lambdaExpression)
        {
            // Parse the lambda expression string and create the expression tree
            LambdaExpression expression = DynamicExpressionParser
                .ParseLambda(new[] { Expression.Parameter(typeof(T), "t"),
                Expression.Parameter(typeof(U), "u") }, typeof(bool), lambdaExpression);

            // Compile the expression tree into a lambda function
            Func<T, U, bool> lambda = (Func<T, U, bool>)expression.Compile();

            // Execute the lambda function
            return lambda(enriched, settings);
        }

        private static void TestExpression()
        {
            var result = Function((t, u) => (t.TransactionAmount >= u.TransactionThereshold));
        }

        private static bool Function(Func<EnrichedClass, SettingsClass, bool> expression)
        {
            return expression.Invoke(new EnrichedClass(), new SettingsClass());
        }

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
}