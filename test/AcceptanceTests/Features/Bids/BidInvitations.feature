Feature: Invite home buyers to bid for a property
    In order to accept bids for a property
    As an estate agent
    I want to send invitations to select home buyers

Scenario: Send invitation
    Send an invitation by email to a home buyer
    Given I have added this property
    |Title|AskingPrice|
    |28 Melbourne Road, Milton Keys, London|245000|
    And the property is accepting bids
    When I select to send an invitation to this home buyer
    |Name|Email|
    |John Smith|john@smith.com|
    Then an email is sent to this email address
    And the email content is as follows
    """
    Hi John,
    You have been invited to bid for 28 Melbourne Road, Milton Keys, London.
    Please click the link below to accept the invitation:
    http://localhost/invitations/12345
    Regards,
    The team.
    """

Scenario: Attempt to send an invitation to an invalid email address
    Given I have added this property
    |Title|AskingPrice|
    |28 Melbourne Road, Milton Keys, London|245000|
    And the property is accepting bids
    When I select to send an invitation to these home buyers
        |Name|Email|
        |John Smith|blah|
        ||john@email.com|
        |||
    Then no email is sent
    And this message appears instead:
        |Message|
        |Invalid email address.|
        |Name is required.|
        |Invalid email address. Name is required|

Scenario: Accept bid invitations
    Given I received an invitation to bid for this property
    |Title|AskingPrice|
    |28 Melbourne Road, Milton Keys, London|245000|
    And the property is accepting bids
    When I accept the invitation
    Then I get the option to place bids for this property