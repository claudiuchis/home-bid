Feature: Sign up for estate agents

  In order to manage my bids online as an estate agent I want to sign up for an account

  @ORPHAN
  Scenario: Sign up as an estate agent
    Given I chose to sign up
    And I enter my new account details
     |First Name|Last Name|Email          |Password |AcceptTermsAndConditions|
    | John     | Smith   | john@smith.com|pass1234 |yes                     |
    When I submit my account details
    Then My account is created
    
