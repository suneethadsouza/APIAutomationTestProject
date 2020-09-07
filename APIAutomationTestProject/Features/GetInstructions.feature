Feature: Get User Instructions
In order to manage instruction endpoints  
As an api service 
I want to get user instructions.

Scenario: Get User instructions
	Given I have a get instructions request
	When I call the endpoint
	Then the response should have the status OK and success status True
	And instructions details should be retrieved