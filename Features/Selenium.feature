Feature: Selenium Example

@example
Scenario: Check Search Results
	Given I navigate to the teamliquid website
	When I search for 'blah'
	Then I should see 'blah' in the search results