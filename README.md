# APIAutomationTestProject
API Automation test suit to get User details based on Id and City name
1. Links to Clone the repo: 
https://github.com/suneethadsouza/APIAutomationTestProject
2. Pre-requisites  
Microsoft Visual Studio Community 2019 
.NET Core 3.1
3. Packages:
Specflow
NUnit 3.12.0
Nunit3TestAdapter (3.15.1)
RestSharp
Specflow.Nunit (3.3.57)
FluentAssertions(5.10.3)
4. Once the project is cloned, open the solution and once the solution is loaded you can build the solution and run the test by following below steps:
a. Navigate to  Build option on  Visual studio  and click on Build Solution.
b. Once the build successful, click on Test option on  Visual studio  and Click on Test Explorer.
c. Once you are on Test Explorer, Right click on project and click on run . 

5. API Test  Automation Framework  details:
5.1: Model Folder: 
Instruction.cs  : Contains properties for instructions.
User.cs : Contains the properties for users

5.2: Helper Folder :
DataHelper.cs  : Contains a method to Deserialize the Json response.
RestEndpoints.cs : Contains all API endpoints.
TestContext.cs : Contains the base uri and call method to uri.
5.3: Features folder:
All Feature files are maintained Features folder.
5.4: Steps folder:
All step definition class file are maintained under steps folder.
