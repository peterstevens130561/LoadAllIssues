# Markdown file
```
    [TestClass]
    public class *name*Test : ServiceTestBase<I*name*>
    {
        [TestMethod]
        public override void DeserializationTest()
        {
            var service = createService();

            string response = *response*;
            clientMock.Setup(p => p.Get(It.IsAny<IRestParameters>())).Returns(response);
            clientMock.Setup(p => p.SetPath(It.IsAny<string>())).Returns(clientMock.Object);

            IList<String> transitions = service.Execute();
            Assert.IsNotNull(transitions, "should be valid list");
            //check the values here
            //Assert.AreEqual(1, transitions.Count);
            //Assert.AreEqual(@*value*", transitions[0]);
        }

        [TestMethod]
        public override void ParametersTest()
        {
            var service = createService();
            // service.Set*parameter*(value);
            // parameters to set here


            //restParametersMock.Verify(p => p.SetParameter(*key*, *value*));
        }

        [TestMethod]
        public override void RegistrationTest()
        {
            BaseRegistrationTest();
        }
    }
    ```