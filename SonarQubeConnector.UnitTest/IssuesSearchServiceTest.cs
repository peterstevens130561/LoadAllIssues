using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQubeConnector.Services;
using Moq;
using PeterSoft.SonarQubeConnector.API.Logic;
using System.Collections.Generic;
using PeterSoft.SonarQubeConnector.Models;

namespace SonarQubeConnector.UnitTest
{
	[TestClass]
	public class IssuesSearchServiceTest : IPagedServiceTest
	{


        /// <summary>
        /// Check that the proper parameters are set
        /// </summary>
        [TestMethod]
		public void ParametersTest()
		{
            Mock<IRestClient> client = new Mock<IRestClient>();
            Mock<IRestParameters> restParameters = new Mock<IRestParameters>();
            IIssuesSearchService service = new IssuesSearchService(client.Object, restParameters.Object);
            service.SetProjectKeys("key");
            service.SetRules("rule1");
            service.SetStatuses("bogus");
            service.SetSeverities("MAJOR,INFO");
            DateTime after = new DateTime(2017, 04, 05, 12, 06, 03);
            service.SetCreatedAfter(after);
            DateTime before = new DateTime(2017, 05, 06, 07, 08, 09);
            service.SetCreatedBefore(before);

            restParameters.Verify(p => p.SetParameter("projectKeys", "key"));
            restParameters.Verify(p => p.SetParameter("rules", "rule1"));
            restParameters.Verify(p => p.SetParameter("statuses", "bogus"));
            restParameters.Verify(p => p.SetParameter("createdAfter", "2017-04-05"));
            restParameters.Verify(p => p.SetParameter("severities", "MAJOR,INFO"));
            restParameters.Verify(p => p.SetParameter("createdBefore", "2017-05-06"));
        }


        /// <summary>
        /// Verify that the IssuesSearchPage is invoked, and does its work
        /// </summary>

        public void PageTest()
        {
            var serviceBaseMock = new Mock<ServiceBase< IssuesSearchPage>>();

            IssuesSearchPage page1 = new IssuesSearchPage();
            page1.Issues = new List<Issue>();
            var issue = new Issue();
            page1.Issues.Add(issue);
            IssuesSearchPage page2 = new IssuesSearchPage();
            serviceBaseMock.SetupSequence(p => p.Execute()).Returns(page1).Returns(page2);
            var service = new PagedServiceBase<Issue, IssuesSearchPage>(serviceBaseMock.Object);

            // let the client return an empty page, no issues
            var issues = service.Execute();
            Assert.IsNotNull(issues, "there should be a valid list");
            Assert.AreEqual(1, issues.Count, "with one item");
            Assert.AreSame(issue, issues[0]);
        }

        [TestMethod]
        public void DeserializationTest()
        {
            var client = new Mock<IRestClient>();
            var restParameters = new Mock<IRestParameters>();
            client.Setup(p => p.SetPath(It.IsAny<string>())).Returns(client.Object);
            IIssuesSearchService service = new IssuesSearchService(client.Object, restParameters.Object);

            string response = @"{""authors"":[""alex.siepman@bakerhughes.com"",""alexander.igubnov@bakerhughes.com""]}";
            client.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(response);

        }

    }
}
