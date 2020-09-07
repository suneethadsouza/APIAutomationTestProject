Feature: Get All User details
In order to manage all users lists 
As an api service 
I want to be able to retrieve all user details 


Scenario: Get User details
	Given I have a get all users request
	When I call the endpoint
	Then the response should have the status OK and success status True
	And user details should be retrieved