Feature: Login to SauceDemo
  As a user
  I want to log in to the application
  So that I can access the inventory

  @smoke
  Scenario: Successful login with valid credentials
    Given I am on the login page
    When I login with username "standard_user" and password "secret_sauce"
    Then I should be on the inventory page

  @negative
  Scenario: Failed login with invalid credentials
    Given I am on the login page
    When I login with username "invalid_user" and password "wrong_password"
    Then I should see an error message

  @negative
  Scenario: Login with locked out user
    Given I am on the login page
    When I login with username "locked_out_user" and password "secret_sauce"
    Then I should see an error message

  @negative
  Scenario: Login with error user
    Given I am on the login page
    When I login with username "error_user" and password "secret_sauce"
    Then I should see an error message
