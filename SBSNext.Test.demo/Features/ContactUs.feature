Feature: ContactUs

Scenario: User can submit contact us form
	Given user landed in SBSNext.com
	And contact us modal is open and empty
	When user enters the following field values
	| FieldName | Value                         |
	| Name      | Miguel                        |
	| Email     | miguel@sbsnext.com            |
	| Subject   | UI Automation                 |
	| Contact   | 201 790 0720                  |
	| Message   | Inquiry about test automation |
	When user clicks on "submit"
	Then contact us request should be sent

Scenario: User validations
	Given user landed in SBSNext.com
	And contact us modal is open and empty
	When user enters the following field values
	| FieldName   | Value   |
	| <FieldName> | <Value> |
	When user clicks on "submit"
	Then user should be presented with '<Validation>'

	Examples: 
	| FieldName | Value         | Validation                          |
	| Name      |               | Name is required                    |
	| Email     |               | Email is required                   |
	| Email     | invalid-email | Email must be a valid email address |