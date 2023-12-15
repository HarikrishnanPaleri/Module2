Feature: Search&AddToCart

A short summary of the feature

@E2E-Search_AddtoCart
Scenario: Search & Add to Cart
	Given User will be on homepage
	When User will type the '<searchtext>'in the search box
	Then Search Results are loaded in the same page with '<searchtext>'
	When User select the '<productno>'
	Then Product page '<searchtext>' is loaded
	When User Clicks the Add to Cart Button
    Then Product '<searchtext>' added to cart
Examples: 
     | searchtext | productno |
     | Bag        | 2         |

