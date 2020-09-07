Feature: Get User details by City name
In order to get user details by City name 
As an api service 
I want to be able to retrieve user details.


Scenario Outline: Get users details when user search by city name
	Given I have a get user by city request <City>
	When I call the endpoint
	Then the response should have the status OK and success status True
	And the API response should have <Id>, <FirstName>, <LastName>, <Email>, <IpAddress>, <Latitude>, <Longitude>	

	Examples:
		| Id | FirstName | LastName | Email             | IpAddress       | Latitude    | Longitude   | City             |
		| 10 | Brennan   | Matej    | bmatej9@umich.edu | 252.214.166.100 | 41.1086264  | -7.6901721  | Armamar          |
		| 50 | Charlot   | Hockey   | chockey1d@gov.uk  | 38.124.22.205   | -34.7903355 | -56.3502545 | Santiago Vázquez |


# This test is to verify user details without passing city name 
Scenario Outline: Get users details when user search without a city name
	Given I have a get user by empty city request
	When I call the endpoint
	Then the response should have the status NotFound and success status False



# Note: the current api implementation returns a 200 OK with an empty list for cities names in lower/upper case / lower case with numbers or
# with lower case with special characters or with numbers
Scenario Outline: Get users by city given an invalid city name
	Given I have a get user by city request <City>
	When I call the endpoint
	Then the response should have the status OK and success status True
	And the response should be empty

	Examples:
		| Id | FirstName | LastName | Email             | IpAddress       | Latitude   | Longitude  | City           |
		| 10 | Brennan   | Matej    | bmatej9@umich.edu | 252.214.166.100 | 41.1086264 | -7.6901721 | invalidcity123 |
		| 10 | Brennan   | Matej    | bmatej9@umich.edu | 252.214.166.100 | 41.1086264 | -7.6901721 | armamar        |
		| 10 | Brennan   | Matej    | bmatej9@umich.edu | 252.214.166.100 | 41.1086264 | -7.6901721 | ARMAMAR        |
		| 10 | Brennan   | Matej    | bmatej9@umich.edu | 252.214.166.100 | 41.1086264 | -7.6901721 | Armamar$123    |
		| 10 | Brennan   | Matej    | bmatej9@umich.edu | 252.214.166.100 | 41.1086264 | -7.6901721 | 123562         |


