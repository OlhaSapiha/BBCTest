Feature: GenerateLoremIpsum

@mytag
Scenario: CheckDefaultSettingResultInTextStartsWithLoremIpsum
	Given the expected start of the paragraph 'Lorem ipsum dolor sit amet, consectetur adipiscing elit'
	When user goes to Generate Page
	Then the paragraph starts with the expected sentence

Scenario Outline: CheckLoremIpsumIsGeneratedWithCorrectSizeOfWords
	Given the expected <amount> of radio button after generation
	When user generate with radio button 'words' and given amount
	And user goes to Generate Page
	Then the expected amount of words is displayed

	Examples:
		| amount |
		| 10     |
		| -1     |
		| 0      |
		| 5      |
		| 20     |

Scenario Outline: CheckLoremIpsumIsGeneratedWithCorrectSizeOfBytes
	Given the expected <amount> of radio button after generation
	When user generate with radio button 'bytes' and given amount
	And user goes to Generate Page
	Then the expected amount of bytes is displayed

	Examples:
		| amount |
		| 10     |
		| -1     |
		| 0      |
		| 20     |

Scenario: CheckUnchekedBoxResultInTextDoesntStartWithLoremIpsum
	Given the expected start of the paragraph 'Lorem ipsum dolor sit amet, consectetur adipiscing elit'
	When user generate with unchecked box
	Then the paragraph doesn't start with the expected sentence

Scenario: CheckRandomlyGeneratedTextParagraphsContainTheWord
	Given the expected word paragraph contains 'lorem'
	And how many times checked '10'
	When user goes to Generate Page
	And user counts how many paragraphs contains the given word
	And user returns to Home Page
	Then the average value of paragraphs generated given times containing the given word should be between '2' and '3'