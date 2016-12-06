@laborScheduler
Feature: Labor Scheduler Store Selection
	In order to be able to create schedules for a store
	As an admin user
	Initial data should be loaded when selecting a store

Scenario Outline: Store Selection
	Given I am logged into the labor scheduler as an admin
	When I select the store '<store>'
	Then I should see the store '<store>' is selected

	Examples:
	| store   |
	| Store 1 |
	| Store 2 |
	| Store 3 |
	
Scenario: Labor Schedule Dropdown Populated
	Given I am logged into the labor scheduler as an admin
	When I click on the pay period dropdown
	Then I should see the expected labor schedules

Scenario: Labor Schedule Day Dropdown Populated
	Given I am logged into the labor scheduler as an admin
	When I select a pay period
	And I click on the day dropdown
	Then I should see the expected day dropdown options

Scenario: Store Selection Employee List
	Given I am logged into the labor scheduler as an admin
	When I select a store
	Then I should see the employee list is displayed