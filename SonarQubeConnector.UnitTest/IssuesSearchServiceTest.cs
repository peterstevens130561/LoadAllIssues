using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQube.Connector.Services;
using Moq;
using PeterSoft.SonarQube.Connector.Client;
using System.Collections.Generic;
using PeterSoft.SonarQube.Connector.Models;
using Newtonsoft.Json;

namespace Connector.UnitTest
{
	[TestClass]
	public class IssuesSearchServiceTest : IPagedServiceTest
	{

        private string pageResponse = @"
{""total"":1345768,""p"":1,""ps"":2,""paging"":{""pageIndex"":1,""pageSize"":2,""total"":1345768},""issues"":[{""key"":""AV0ZWX77AjkANsPOcYHO"",""rule"":""fxcop:ValidateArgumentsOfPublicMethods"",""severity"":""MAJOR"",""component"":""SaturationModeling:SaturationModeling:F459C127-1ADD-42D0-9816-38069A8656FD:Controllers/SaturationModelDragDropController.cs"",""componentId"":283051,""project"":""SaturationModeling"",""subProject"":""SaturationModeling:SaturationModeling:F459C127-1ADD-42D0-9816-38069A8656FD"",""line"":25,""textRange"":{""startLine"":25,""endLine"":25,""startOffset"":0,""endOffset"":78},""flows"":[],""resolution"":""FIXED"",""status"":""RESOLVED"",""message"":""In externally visible method 'SaturationModelDragDropController.OnDrop(IViewModel, IViewModel)', validate parameter 'draggedViewModel' before using it."",""effort"":""5min"",""debt"":""5min"",""assignee"":""jannnie"",""author"":""niek.jannink @bakerhughes.com"",""tags"":[],""creationDate"":""2017-07-06T21:05:07+0200"",""updateDate"":""2017-08-01T13:55:43+0200"",""type"":""BUG""},{""key"":""AV0ZWX77AjkANsPOcYHN"",""rule"":""fxcop:ValidateArgumentsOfPublicMethods"",""severity"":""MAJOR"",""component"":""SaturationModeling:SaturationModeling:F459C127-1ADD-42D0-9816-38069A8656FD:Controllers/SaturationModelDragDropController.cs"",""componentId"":283051,""project"":""SaturationModeling"",""subProject"":""SaturationModeling:SaturationModeling:F459C127-1ADD-42D0-9816-38069A8656FD"",""line"":18,""textRange"":{""startLine"":18,""endLine"":18,""startOffset"":0,""endOffset"":69},""flows"":[],""resolution"":""FIXED"",""status"":""RESOLVED"",""message"":""In externally visible method 'SaturationModelDragDropController.OnCanBeDropped(IViewModel, IViewModel)', validate parameter 'targetViewModel' before using it."",""effort"":""5min"",""debt"":""5min"",""assignee"":""jannnie"",""author"":""niek.jannink @bakerhughes.com"",""tags"":[],""creationDate"":""2017-07-06T21:05:07+0200"",""updateDate"":""2017-08-01T13:55:32+0200"",""type"":""BUG""}],""components"":[{""id"":283037,""key"":""SaturationModeling"",""uuid"":""AVuNUXRXqi4hEIdyH0VJ"",""enabled"":true,""qualifier"":""TRK"",""name"":""SaturationModeling"",""longName"":""SaturationModeling""},{""id"":283051,""key"":""SaturationModeling:SaturationModeling:F459C127-1ADD-42D0-9816-38069A8656FD:Controllers/SaturationModelDragDropController.cs"",""uuid"":""AVuNVBWboY-pUUdjkKzK"",""enabled"":true,""qualifier"":""FIL"",""name"":""SaturationModelDragDropController.cs"",""longName"":""Controllers/SaturationModelDragDropController.cs"",""path"":""Controllers/SaturationModelDragDropController.cs"",""projectId"":283037,""subProjectId"":283048},{""id"":283048,""key"":""SaturationModeling:SaturationModeling:F459C127-1ADD-42D0-9816-38069A8656FD"",""uuid"":""AVuNVBWeoY-pUUdjkKzQ"",""enabled"":true,""qualifier"":""BRC"",""name"":""SaturationModeling.Application.Core"",""longName"":""SaturationModeling.Application.Core"",""path"":""JewelEarth/JewelAddins/SaturationModeling/SaturationModeling.Application.Core"",""projectId"":283037,""subProjectId"":283037}]}
";
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
            DateTime at = new DateTime(2017, 01, 02, 03, 04, 05);
            service.SetCreatedAt(at);

            restParameters.Verify(p => p.SetParameter(@"projectKeys", @"key"));
            restParameters.Verify(p => p.SetParameter(@"rules", @"rule1"));
            restParameters.Verify(p => p.SetParameter(@"statuses", @"bogus"));
            restParameters.Verify(p => p.SetParameter(@"createdAfter", @"2017-04-05"));
            restParameters.Verify(p => p.SetParameter(@"severities", @"MAJOR,INFO"));
            restParameters.Verify(p => p.SetParameter(@"createdBefore", @"2017-05-06"));
            restParameters.Verify(p => p.SetParameter(@"createdAt", @"2017-01-02"));
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

            string response = pageResponse;
            client.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(response);

        }

        [TestMethod]
        public void TestPageDeserialization()
        {
            var issues=JsonConvert.DeserializeObject<IssuesSearchPage>(pageResponse);
            Assert.AreEqual(2, issues.Issues.Count);
        }

    }
}
