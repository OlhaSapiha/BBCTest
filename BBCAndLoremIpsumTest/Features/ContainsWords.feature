Feature: ContainsWordsDefaultValues

@mytag
Scenario: CheckTheFirstParagraphContainsTheWord
	Given the expected word in first paragraph 'рыба'
	When user goes to Russian Lorem Ipsum Page
	Then the first paragraph contains the expected word

