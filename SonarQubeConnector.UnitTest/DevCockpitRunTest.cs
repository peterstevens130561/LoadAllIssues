﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeterSoft.SonarQubeConnector.Commands;
using PeterSoft.SonarQubeConnector.CommandHandlers;
using Moq;
using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.UnitTest
{
    [TestClass]
    public class DevCockpitRunTest
    {
        [TestMethod]
        public void InstantiationTest()
        {
            var connector = new SonarQubeConnector();
            var session = connector.CreateSession();
            var command = session.CreateCommand<IDevCockpitRunCommand>();
            Assert.IsNotNull(command);
            Assert.IsInstanceOfType(command,typeof(DevCockpitRunCommand));
        }
        [TestMethod]
        public void TestCommandHandler()
        {
            var developerTasks = new List<DeveloperTask>();
            developerTasks.Add(new DeveloperTask());
            var restClientMock = new Mock<IRestClient>();
            restClientMock.Setup(r => r.SetPath("devcockpit/run")).Returns(restClientMock.Object);
            restClientMock.Setup(r => r.GetPostResult<IList<DeveloperTask>>()).Returns(developerTasks);
            var handler = new DevCockpitRunCommandHandler(restClientMock.Object);
            var command = new DevCockpitRunCommand(new RestParameters());
            handler.Execute(command);
            var actualTasks = command.DeveloperTasks;
            Assert.AreSame(developerTasks, actualTasks);
        }

        /// <summary>
        /// Simple deserialization test
        /// </summary>
        [TestMethod]
        public void DeSerializeTest()
        {
            var client = new RestClient();
            client.Result = @"[
                      {
                       ""taskId"": ""TASK_UUID_1"",
                        ""developerId"": ""DEV_UUID_1""
                      },
                      {
                        ""taskId"": ""TASK_UUID_2"",
                        ""developerId"": ""DEV_UUID_2""
                      }
                    ]";
            IList<DeveloperTask> developerTasks = client.GetPostResult<IList<DeveloperTask>>();
            Assert.AreEqual(2, developerTasks.Count);
            Assert.AreEqual("TASK_UUID_1", developerTasks[0].TaskId);
            Assert.AreEqual("TASK_UUID_2", developerTasks[1].TaskId);
            Assert.AreEqual("DEV_UUID_1", developerTasks[0].DeveloperId);
            Assert.AreEqual("DEV_UUID_2", developerTasks[1].DeveloperId);
        }

    }
}
