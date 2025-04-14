Feature: CreateAccount

Create account for advantage shoppping online portal

@LOG001
Scenario: Verify manadatory fields for create account
	Given I navigate to advantage online shopping website
	When I click on user icon to open the register popup
	And I click create new account
	And I click into and out of mandatory fields
	Then I verify error messages display correctly
	When I enter valid data into all mandatory fields
	Then I verify that all error messages are cleared