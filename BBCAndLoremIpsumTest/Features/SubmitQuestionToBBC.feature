Feature: SubmitQuestionToBBC

@mytag
Scenario: SubmitQuestionWithEmptyTellUsYourStory
	Given the credentials and over16Box 'true' and termsBox 'true' to submit the form
		| Key      | Value                 |
		| Tell     |                       |
		| Name     | Olha                  |
		| Email    | osapiha5553@gmail.com |
		| Contact  | +380931256769         |
		| Location | Kyiv                  |
	When user goes to the News page
	And user goes to the Coronavirus tab
	And user goes to the Your coronavirus stories tab
	And user goes to the How to share with BBC News page
	And user submits form with given credentials
	Then the error message 'can't be blank' is shown under the field Tell

Scenario: SubmitQuestionWithInvalidEmail
	Given the credentials and over16Box 'true' and termsBox 'true' to submit the form
		| Key      | Value         |
		| Tell     | Hello!        |
		| Name     | Olha          |
		| Email    | osapiha5553   |
		| Contact  | +380931256769 |
		| Location | Kyiv          |
	When user goes to the News page
	And user goes to the Coronavirus tab
	And user goes to the Your coronavirus stories tab
	And user goes to the How to share with BBC News page
	And user submits form with given credentials
	Then the error message 'Email address is invalid' is shown under the email field

Scenario: SubmitQuestionWithUncheckedAcceptTermsService
	Given the credentials and over16Box 'true' and termsBox 'false' to submit the form
		| Key      | Value                 |
		| Tell     | Hello!                |
		| Name     | Olha                  |
		| Email    | osapiha5553@gmail.com |
		| Contact  | +380931256769         |
		| Location | Kyiv                  |
	When user goes to the News page
	And user goes to the Coronavirus tab
	And user goes to the Your coronavirus stories tab
	And user goes to the How to share with BBC News page
	And user submits form with given credentials
	Then the error message 'must be accepted' is shown under the unchecked box

Scenario: SubmitQuestionWithEmptyName
	Given the credentials and over16Box 'true' and termsBox 'true' to submit the form
		| Key      | Value                 |
		| Tell     | Hello!                |
		| Name     |                       |
		| Email    | osapiha5553@gmail.com |
		| Contact  | +380931256769         |
		| Location | Kyiv                  |
	When user goes to the News page
	And user goes to the Coronavirus tab
	And user goes to the Your coronavirus stories tab
	And user goes to the How to share with BBC News page
	And user submits form with given credentials
	Then the error message 'Name can't be blank' is shown under the name field