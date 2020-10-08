Feature: TextOfArticles

@mytag
Scenario: Check the name of the headline article
	Given the expected name of the headline article is 'Biden calls for police to be charged in shootings'
	When user goes to the News page
	Then the name of the headline article should match the expected name


Scenario: Check the names of the secondary articles
	Given the expected text of second articles
		| titles                                              |
		| NY black man killed in police 'spit hood' restraint |
		| Dwayne 'The Rock' Johnson and family had Covid-19   |
		| Russian opposition leader 'poisoned with Novichok'  |
		| 'I'm gonna go finish feeding my daughter'           |
		| Australia 'anti-lockdown' arrest stirs controversy  |
	When user goes to the News page
	Then the names of the secondary articles should match the expected names