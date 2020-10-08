Feature: SearchResult

@mytag
Scenario: Check text of the first article using category link in search
	Given the expected text of the first article after search 'Bitesize Scotland: Secondary: Daily: Secondary Programme 5'
	When user goes to the News page
	And user searches by category link from the first article
	Then the name of the first article after search should match the expected name