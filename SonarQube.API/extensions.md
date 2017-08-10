# Add a service

1. Get the service from the web_api page, say api/qualityprofiles/search, and its sample response
2. Add a unit test class which takes the response like
```cs
      public void DeserializeTest()
        {
            var client = new RestClient(null);
            client.Result = @"{
            ""profiles"": [
    {
                ""key"": ""sonar-way-cs-12345"",
      ""name"": ""Sonar way"",
      ""language"": ""cs"",
      ""languageName"": ""C#"",
      ""isInherited"": false,
      ""activeRuleCount"": 37,
      ""isDefault"": true
    },
    {
      ""key"": ""sonar-way-python-01234"",
      ""name"": ""Sonar way"",
      ""language"": ""py"",
      ""languageName"": ""Python"",
      ""isInherited"": false,
      ""activeRuleCount"": 125,
      ""isDefault"": true
    }
  ]
}";
            Response response = client.GetPostResult<Response>();
            Assert.AreEqual(2, response.profiles.Count);
        }
    }
```
Via json2sharp you can create the model if needed
2. Check if the response type is in Models, if not add it. Often lists are returned, sometimes an object that contains a list. In the above we look for
a Profiles class, which has a list of profile. 
we look for a Profile object. 
2. Create a folder QualityProfiles under Services
3. Create an interface in the Services folder IQualityProfilesSearchService, which implements ExecuteService<response>. In this 
 interface you specify the parameters that can be set for the service

5. Create a class in the same folder QualityProfilesSearchService
```cs
    class QualityProfilesSearchService : ServiceBase<**IList<Profile>**>, IQualityProfilesSearchService
```

    Note the IList<Profile>, which is the response type
    and its constructor
 ```cs
    public QualityProfilesSearchService (RestClient restGetter, IRestParameters parameters): base(restGetter, "qualityprofiles/search") { }
```
    Followed by the implementations

6. Add the service to SonarQubeConnector::RegisterServices
````cs
    .Register<IQualityProfilesSearchService,QualityProfilesSearchService>();
````
## Try it
Create a sam

#Create a paged Service
SonarQube has several paged services. A paged service extends PagedServiceBase. For an example below
The PagedServiceBase has two parameters: the type of which the service will return an IList, and the type to which the response will be deserialized.

````
   internal class IssuesSearchService : PagedServiceBase<Issue, IssuesSearchPage>, IIssuesSearchService
    {
        public IssuesSearchService(IRestClient restGetter,IRestParameters parameters) : base(restGetter, parameters, "issues/search") { }  
````
SonarQube has various implementations of the page in the response. However, in the POST request all we need to do is specify the page. via the p parameter,
so the information is ignored. You do not have to worry about it. 

In order to extract the items that will be returned into the list, you need to implement the 'Page' class

The naming convention is to use the name of the service, extended with 'Page', and it extends the Page base class
The extension contains two critical elements

1. The list of the class that we're interested in. The received json is serialized into this one
2. The Items method, which takes the list in one. 

This approach allows a generic approach to map the page to service
````
    public class MeasuresComponentTreePage : Page<Component>
    {

        public IList<Component> Components { get; set; }
        public override IList<Component> Items
        {
            get
            {
                return Components;
            }
        }
    }
````