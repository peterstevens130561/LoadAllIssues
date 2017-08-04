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
	public class MeasuresComponentTreeTest : IPagedServiceTest
	{
        string pageResponse = @"
{   ""paging"":{""pageIndex"":2,""pageSize"":2,""total"":2147},
    ""baseComponent"":
        {""id"":""AVxuL60suzOSx7GKrB0j"",
        ""key"":""Transformer-Bhi.Esie.TooLink"",
        ""name"":""Bhi.Esie.TooLink"",
        ""qualifier"":""TRK"",
        ""measures"":[{""metric"":""duplicated_files"",""value"":""223"",""periods"":[{""index"":1,""value"":""-45""},{""index"":2,""value"":""0""},{""index"":3,""value"":""-5""}]}]},
        ""components"":[
            {""id"":""AV1QLHKbAjkANsPOeE0Q"",""key"":""Transformer-Bhi.Esie.TooLink:Transformer-Bhi.Esie.TooLink:0546CD87-DBED-43A0-B3F0-E8DB1D15CB82:Units/AccelerationUnitValue.cs"",""name"":""AccelerationUnitValue.cs"",""qualifier"":""FIL"",""path"":""Units/AccelerationUnitValue.cs"",""language"":""cs"",""measures"":[{""metric"":""duplicated_files"",""value"":""0""}]},
            {""id"":""AVxuL_IV1hfq_EPhvfR2"",""key"":""Transformer-Bhi.Esie.TooLink:Transformer-Bhi.Esie.TooLink:CE98D78F-6D56-4279-A456-8D5BCD83BBB1:DataContracts/AcDownlinkDefinition.cs"",""name"":""AcDownlinkDefinition.cs"",""qualifier"":""FIL"",""path"":""DataContracts/AcDownlinkDefinition.cs"",""language"":""cs"",""measures"":[{""metric"":""duplicated_files"",""value"":""0""}]}]}
";
        string endPage = @"
    {""paging"":{""pageIndex"":23,""pageSize"":100,""total"":2148},
    ""baseComponent"":{""id"":""AVxuL60suzOSx7GKrB0j"",""key"":""Transformer-Bhi.Esie.TooLink"",""name"":""Bhi.Esie.TooLink"",""qualifier"":""TRK"",""measures"":[{""metric"":""duplicated_files"",""value"":""223"",""periods"":[{""index"":1,""value"":""-45""},{""index"":2,""value"":""0""},{""index"":3,""value"":""-5""}]}]},""components"":[]}
";

        /// <summary>
        /// Check that the proper parameters are set
        /// </summary>
        [TestMethod]
		public void ParametersTest()
		{
            Mock<IRestClient> client = new Mock<IRestClient>();
            Mock<IRestParameters> restParameters = new Mock<IRestParameters>();
            IMeasuresComponentTreeService service = new MeasuresComponentTreeService(client.Object, restParameters.Object);
            service.SetBaseComponentKey("key");
            restParameters.Verify(p => p.SetParameter(@"baseComponentKey", @"key"));
        }


        /// <summary>
        /// Simple test for a one pager
        /// </summary>
        [TestMethod]
        public void DeserializationTest()
        {
            // given we have a response with one page, that has 2 components
            var client = new Mock<IRestClient>();
            var restParameters = new Mock<IRestParameters>();
            client.Setup(p => p.SetPath(It.IsAny<string>())).Returns(client.Object);
            IMeasuresComponentTreeService service = new MeasuresComponentTreeService(client.Object, restParameters.Object);

            string response = pageResponse;
            client.SetupSequence(p => p.Get(It.IsAny<IRestParameters>())).Returns(response).Returns(endPage);
            //when we execute the service
            var components=service.Execute();
            //then we expect two components in the result
            Assert.AreEqual(2, components.Count);
        }

        [TestMethod]
        public void PageTest()
        {
            // given we have a response with two pages, that has 2 components each
            var client = new Mock<IRestClient>();
            var restParameters = new Mock<IRestParameters>();
            client.Setup(p => p.SetPath(It.IsAny<string>())).Returns(client.Object);
            IMeasuresComponentTreeService service = new MeasuresComponentTreeService(client.Object, restParameters.Object);

            string response = pageResponse;
            client.SetupSequence(p => p.Get(It.IsAny<IRestParameters>())).Returns(response).Returns(response).Returns(endPage);
            //when we execute the service
            var components = service.Execute();
            //then we expect four components in the result
            Assert.AreEqual(4, components.Count);
        }
        [TestMethod]
        public void TestPageDeserialization()
        {
            var components = JsonConvert.DeserializeObject<MeasuresComponentTreePage>(pageResponse);
            Assert.AreEqual(2, components.Items.Count);
        }

    }
}
