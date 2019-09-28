Feature: Sign up for estate agents

  In order to manage my bids online as an estate agent I want to sign up for an account

  @IDENTITY
  Scenario: Sign up as an estate agent
    First name, last name, email and password are required. 
    Given I chose to sign up as an estage agent
    And I entered my new account details
     |First Name|Last Name|Email          |Password |AcceptTermsAndConditions|
    | John     | Smith   | john@smith.com|pass1234 |yes                     |
    When I submit my account details
    Then My estate agent account
    
  @IDENTITY
  Scenario: Attempting to sign up as an estate agent with invalid details
    First name, last name, email and password are required. 
    Given I chose to sign up
    And I entered invalid account details:
     |First Name|Last Name|Email          |Password |AcceptTermsAndConditions|
    |      | Smith   | john@smith.com|pass1234 |yes                     |
    | John     |   | john@smith.com|pass1234 |yes                     |
    | John     | Smith   | |pass1234 |yes                     |
    | John     | Smith   | john@smith.com| |yes                     |
    | John     | Smith   | john@smith.com|p |yes                     |
    When I submit my account details
    Then validation message appears as follows:
    |Message|
    | First Name is required. |
    | Second Name is required. |
    | Email is required. |
    | Password is required. |
    | Passoword is invalid. Minimum 8 characters.|


