using AI.Domain.RulesEngine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class Program
{
    public static void Main(string[] args)
    {
        var lambdaList = new List<string>();
        var lambda = "t.TransactionAmount >= u.TransactionThereshold";
        lambdaList.Add(lambda);
        _ = RulesEngine.ProcessLambdas(lambdaList);
    }
}