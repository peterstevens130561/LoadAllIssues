using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQube.Connector.Models;
using PeterSoft.SonarQube.Connector.Services;
using Moq;
using System.Collections.Generic;
using PeterSoft.SonarQube.Connector.Application;

namespace PeterSoft.SonarQube.Connector.Application
{
    [TestClass]
    public class UnitTest1
    {

        public void CheckProject()
        {
            var qualityGate = new QualityGate();
            var condition = new Condition();
            condition.Metric = "blockers";
            condition.Op = "GT";
            condition.Warning = "4";
            condition.Error = "6";
            condition.Period = 1;
            qualityGate.Conditions = new List<Condition>();
            qualityGate.Conditions.Add(condition);

            var measure = new Measure();
            measure.Metric = "blockers";
            measure.Value = "1";
            measure.Periods = new List<MeasurePeriod>();
            measure.Periods.Add(new MeasurePeriod(1, "7"));

            var measures = new ComponentMeasures();
            measures.Component = new MeasuresDetail();
            measures.Component.Measures = new List<Measure>();
            measures.Component.Measures.Add(measure);
            var conditionEvaluator = new ConditionEvaluator(qualityGate);
            string result = conditionEvaluator.Evaluate(measures.Component.Measures);
            Assert.AreEqual("Error", result);
        }
    }
}
