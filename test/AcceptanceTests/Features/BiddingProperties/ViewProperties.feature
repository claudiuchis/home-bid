Feature: View my properties 
    In order to manage my properties
    As an estate agent
    I want to see all the properties I added

Scenario: Viewing all my properties
    List all properties added in the system by an estate agent
    Given I have added these properties
        |Title            |AskingPrice|
        |52 Alendale Close|123456      |
        |53 Kimmage       |234567      |
    When I request all the properties I added
    Then these properties display

Scenario: View single property
    Given I have added this property
        |Title            |AskingPrice|
        |52 Alendale Close|123456      |
    When I choose to see the details for this property
    Then I can see this property's details
