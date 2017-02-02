using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Models
{
    /// <summary>
    /// The response of a component measures service, see api/measures/component
    /// see api
    /// </summary>
    public class ComponentMeasures 
    {
        public MeasuresDetail Component{ get; set; }

    }

    public class MeasuresDetail
    {
        /// <summary>
        /// id of the component
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// key of the component
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// name of the component
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// what the component is (FIL, TRK, PRJ...)
        /// </summary>
        public string Qualifier { get; set; }
        /// <summary>
        /// programming language
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// relative path of the component
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// the measures
        /// </summary>
        public IList<Measure> Measures { get; set; }
        /// <summary>
        /// the metrics
        /// </summary>
        public IList<Metric> Metrics { get; set; }
        /// <summary>
        /// the periods
        /// </summary>
        public IList<ComponentPeriod> Periods { get; set; }

    }
    }
