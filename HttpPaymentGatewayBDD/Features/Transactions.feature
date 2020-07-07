Feature: Transactions
	

Scenario: Successfull Sale Transaction
	Given I am authorized
	When I submit my payment details:
	| CardNumber       | Cvv | ExpirationDate | Amount | Usage       | TransactionType | CardHolder  | Email             | Address             |
	| 4200000000000000 | 123 | 06/2019        | 500    | Coffeemaker | sale            | Panda Panda | panda@example.com | Panda Street, China |
	Then I had the status code 200


Scenario: Unauthorized Sale Transaction
	Given I am not authorized
	When I post my correct payment details:
	| CardNumber       | Cvv | ExpirationDate | Amount | Usage       | TransactionType | CardHolder  | Email             | Address             |
	| 4200000000000000 | 123 | 06/2019        | 500    | Coffeemaker | sale            | Panda Panda | panda@example.com | Panda Street, China |
	Then I had the status code 401


Scenario: Successfull Void Transaction
	Given I am authorized
	When I try to void my previously successfull transaction
	Then I had the status code 200

Scenario: Void to Void Transaction
	Given I am authorized
	When I try to void my previous void transaction
	Then I had the status code 422

Scenario: Void to non-existent payment Transaction
	Given I am authorized
	When I try to void my non-existent payment transaction:
	| CardNumber       | TransactionType |
	| 2300000000000000 | void            |
	Then I had the status code 422







