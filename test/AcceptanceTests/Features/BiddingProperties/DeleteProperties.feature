Feature: Delete my properties 
    In order to manage my properties
    As an estate agent
    I want to be able to delete old properties

Scenario: Remove property
    Given I have added this property
        |Title            |AskingPrice|
        |52 Alendale Close|123456      |
    When I select to delete it
    Then the property is deleted