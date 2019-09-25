Feature: Make a bid
    In order to buy a house
    As a house buyer
    I need to make a bid

Scenario Outline: Make the first bid
    The first bid can be lower, equal or higher than the asking price
    Given I am eligible to bid for this property
    |Title|AskingPrice|
    |23 Kimmage Road|250000|
    And there are no bids made yet
    When I make a bid of <Bid> for this property
    Then the <Bid> bid <IsBidAccepted> accepted
    And <Message> message is returned when not accepted
    
    Examples:
    |Bid   |IsBidAccepted|Message|
    |100000|is           |       |
    |1     |is           |       |
    |200000|is           |       |
    |-1    |is not       |Invalid bid|
    |0     |is not       |Invalid bid|

Scenario Outline: Make a subsequent bid
    A subsequent bid needs to be higher than the last bid.
    Given I am eligible to bid for this property
    |Title|AskingPrice|
    |23 Kimmage Road|250000|
    And the last bid was <LastBid>
    When I make a bid of <NewBid> for this property
    Then the bid <IsBidAccepted> accepted
    And <Message> message is returned when not accepted
    
    Examples:
    |LastBid|NewBid|IsBidAccepted|Message|
    |200000|210000 |is           ||
    |200000|190000 |is not       |The bid needs to be higher than the last bid|
    |250000|251000 |is           ||
    |250000|250000 |is not       |The bid needs to be higher than the last bid|
    |250000|-1     |is not       |Invalid bid|
    |250000|0      |is not       |Invalid bid|

Scenario: View bids
    Given this property
    |Title|AskingPrice|
    |23 Kimmage Road|250000|
    And these bids
    |Bid|
    |200000|
    |200000|
    When I select to see the bids for this property
    Then they match these bids

Scenario: Revoke last bid
    When revoking the last bid, the next highest bid becomes the last bid
    Given this property
    |Title|AskingPrice|
    |23 Kimmage Road|250000|
    And these exiting bids
    |Bid|
    |200000|
    |210000|
    And that I made a bid
    |Bid|
    |220000|
    When I select to revoke my bid
    Then the bid is removed
    And the next highest bid becomes the highest bid

Scenario: See the highest bid
    Given a property has received these bids:
    |Bid|
    |200000|
    |205000|
    |210000|
    When I select to view the highest bid for this property
    Then the value that displays is 210000