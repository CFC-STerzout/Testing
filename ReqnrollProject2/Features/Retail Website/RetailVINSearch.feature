
Feature: Retail VIN search
  As a retail user
  I want to search by VIN
  So that I can see vehicle details

  Background:
    Given I am on the Retail page

  @happy
  Scenario: Search returns results for valid VIN
    When I search for VIN "1FTFW1E50NKD12345"
    Then I should see at least one result

  @negative
  Scenario: Invalid VIN shows no results
    When I search for VIN "INVALIDVIN"
    Then I should not see any results
