Feature: Open bidding online for a property
    In order to allow house buyers to bid without my immediate help
    As an estate agent
    I want to open the bidding online for a property

Scenario Outline: Adding a property for bidding
    Adding a property with valid data
    Given I chose to create a new property
    And I entered title <title>
    And I entered asking price <value>  
    When I send the data
    Then a property is added with these details
    And it is available for bidding

    Examples:
        |title|value|
        |25 Kimmage Close, Clonsilla|256000|

Scenario Outline: Attempting to add a property with invalid data
    Title and asking price are required; Asking price needs to be a positive number
    Given I chose to create a new property
    And I entered title <title>
    And I entered asking price <value>  
    When I send the data
    Then The message that appears is <message>
    And the property is not added

    Examples:
        |title|value|message|
        ||12200|Title is required.|
        |52 Alendale Close|-1|Asking price is not valid.|
        |52 Alendale Close|0|Asking price is not valid.|
        # |52 Alendale Close||Asking price is required.|

