@local
Feature: Labor Scheduler Select Store
	In order to be able to create a labor schedule
	As an admin user
	I should be able to select a specific store

Scenario: Select Store verify schedule
	Given I am logged into the labor scheduler as an admin
	When I select a store
	Then I should see the expected schedule

Scenario: Select Store verify date
	Given I am logged into the labor scheduler as an admin
	When I select a store
	Then I should see the current date

Scenario: Select Store verify employees
	Given I am logged into the labor scheduler as an admin
	When I select a store
	Then I should see the expected schedule

Scenario: Select Store verify date range
	Given I am logged into the labor scheduler as an admin
	When I select a store
	Then I should see the current date