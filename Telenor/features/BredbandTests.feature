Feature: Bredband Page
  Background:
    Given I am on the Telenor home page
    And   I navigate to the Bredband page from the main menu

  Scenario: The 5G product should be displayed for non-apartments
    When  I search for products at a non-apartment address
    Then  the 5G internet product should be displayed

  Scenario: The 5G product should be displayed for apartments
    When  I search for products at an apartment address
    And   I select my apartment from the list
    Then  the 5G internet product should be displayed