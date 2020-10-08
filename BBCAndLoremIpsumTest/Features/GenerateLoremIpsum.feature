Feature: GenerateLoremIpsum

@mytag
Scenario: CheckDefaultSettingResultInTextStartsWithLoremIpsum
	Given the expected start of the paragraph 'Lorem ipsum dolor sit amet, consectetur adipiscing elit'
	When user goes to Generate Page
	Then the paragraph starts with the expected sentence

Scenario: CheckLoremIpsumIsGeneratedWithCorrectSizeOfWords
	Given the expected <amount> of words after generation
		| amount |
		| 10     |
		| -1     |
		| 0      |
		| 5      |
		| 20     |
	When user generate with radio button 'words' and given amount
	And user goes to Generate Page
	Then the expected amount of words is displayed