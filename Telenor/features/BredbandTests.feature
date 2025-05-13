Feature: Bredband Page
  Background:
    Given I am on the Telenor home page
    And   I navigate to the Bredband page from the main menu

  Scenario: The 5G product should be displayed for non-apartments
    When I search for products at the "Storgatan 10, Uppsala" address
    And  select the "Storgatan 10, Uppsala" address
    Then  the 5G internet product should be displayed

  Scenario: The 5G product should be displayed for apartments
    When I search for products at the "Storgatan 1, Uppsala" address
    And  select the "Storgatan 1, Uppsala" address
    And  I select "0004" from the apartment list
    Then  the 5G internet product should be displayed

  Scenario: All products should be displayed for the Telenor test address
    When I search for products at the "Garvis Carlssons Gata" address
    And  select the "Garvis Carlssons Gata 3, Solna" address
    And  I select "test" from the apartment list
    Then all 6 products should be displayed