Feature: Edit my properties 
    In order to manage my properties
    As an estate agent
    I want to be able to edit my properties

Scenario: Edit property
    The property details can be changed only when providing valid data, e.g. Tile and Asking Price are required.
    Given I have added these properties
        |Title            |AskingPrice|
        |52 Alendale Close|123456      |
    When I change the properties details
        |Title            |AskingPrice|
        |54 Alendale Close|1234567     |
    Then the details are updated

Scenario: Attempting to edit properties using invalid data
    Given I have added this property
        |Title            |AskingPrice|
        |52 Alendale Close|123456      |
    When I change the the property with details
        |Title            |AskingPrice|
        |54 Alendale Close|-1     |
        |54 Alendale Close|0      |
        ||123     |
    Then the properties are not updated
    And the following messages are shown
        |Message|
        |Asking price is not valid|
        |Title is missing|
