using System;
using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Application
{
    public class ConditionEvaluator
    {
        private QualityGate qualityGate;

        public ConditionEvaluator(QualityGate qualityGate)
        {
            this.qualityGate = qualityGate;
        }

        public string Evaluate(IList<Measure> measures)
        {
            foreach(var condition in qualityGate.Conditions )
            {
                foreach(var measure in measures)
                {
                    if(measure.Metric == condition.Metric)
                    {
                        if(condition.Period==0)
                        {

                        } else
                        {

                        }
                    }
                }
            }
            return @"Warning";
        }
    }
}