﻿Feature: Deck of playing cards
	As a card player on a digital device
	I want to be able to play familiar card games
	So that I'm not bored

Scenario: The deck has 52 cards
Given a deck of cards
When I count each card
Then I have a total of 52 cards

Scenario: The deck has 4 suits
Given a deck of cards
When I check for suits
Then I see hearts, clubs, spades, and diamonds

Scenario: Each suit has 13 cards
Given a deck of cards
When I count all the cards in a single suit
Then I have 13 cards: Ace, Card2, Card3, Card4, Card5, Card6, Card7, Card8, Card9, Card10, Jack, Queen, King

Scenario Outline: Card values
Given a deck of cards
When I have a card with <face_value>
Then the card is worth <point_value>
| <face_value> | <point_value> |
| Ace          | 1             |
| Card2        | 2             |
| Card10       | 10            |
| Jack         | 10            |
| Queen        | 10            |
| King         | 10            |

Scenario: Face cards are ordered and all count as 10
Given a deck of cards
Then the face cards are ordered Jack, Queen, King