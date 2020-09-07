Feature: Get User details by Id
In order to get user details by Id
As an api service 
I want to be able to retrieve user details.
 

# Ideally, the data should be created on the fly by either creating  the data into the database or using post method of the API and then delete the data after the test is run.
# This generated data should be persisted across the steps in a context should be verified. Hence the example section can be eliminated.
# ID can differ from environment to environment, hence a bad practice.
Scenario Outline: Get User details by Valid Id
	Given I have a get user by Id request <Id>
	When I call the endpoint
	Then the response should have the status OK and success status True
	And validate API response <Id>, <FirstName>, <LastName>, <Email>, <IpAddress>, <Latitude>, <Longitude>, <City>

	Examples:
		| Id | FirstName | LastName | Email             | IpAddress       | Latitude    | Longitude   | City             |
		| 10 | Brennan   | Matej    | bmatej9@umich.edu | 252.214.166.100 | 41.1086264  | -7.6901721  | Armamar          |
		| 50 | Charlot   | Hockey   | chockey1d@gov.uk  | 38.124.22.205   | -34.7903355 | -56.3502545 | Santiago Vázquez |


Scenario Outline: The endpoint response should return error when User search by invalid Id
	Given I have a get user by Id request <Id>
	When I call the endpoint
	Then the response should have the status NotFound and success status False
	And Validate <ErrorMessage> in API response body

	Examples:
		| Id                    | ErrorMessage                           |
		| 0000                  | Id 0000 doesn't exist                  |
		| 000999999999999999999 | Id 000999999999999999999 doesn't exist |
		| abc                   | Id abc doesn't exist                   |
		| abc123                | Id abc123 doesn't exist                |
		| $$$$                  | Id $$$$ doesn't exist                  |
		| $$$$20                | Id $$$$20 doesn't exist                |
		| 55.5                  | Id 55.5 doesn't exist                  |

# This test is to verify user details without passing Id 
Scenario Outline: Get User details by empty Id
	Given I have a get user by empty Id request
	When I call the endpoint
	Then the response should have the status NotFound and success status False