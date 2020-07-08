Feature: Transactions
	
Scenario:1 Successfull Sale Transaction
	Given I am authorized
	When I submit my payment details:
	| CardNumber       | Cvv | ExpirationDate | Amount | Usage       | TransactionType | CardHolder  | Email             | Address             |
	| 4200000000000000 | 123 | 06/2019        | 500    | Coffeemaker | sale            | Panda Panda | panda@example.com | Panda Street, China |
	Then I have the status code 200


Scenario:2 Unauthorized Sale Transaction
	Given I am not authorized
	When I post my correct payment details:
	| CardNumber       | Cvv | ExpirationDate | Amount | Usage       | TransactionType | CardHolder  | Email             | Address             |
	| 4200000000000000 | 123 | 06/2019        | 500    | Coffeemaker | sale            | Panda Panda | panda@example.com | Panda Street, China |
	Then I have the status code 401


Scenario:3 Successfull Void Transaction
	Given I am authorized
	When I try to void my previously successfull transaction
	Then I have the status code 200

Scenario:4 Void to Void Transaction
	Given I am authorized
	When I try to void my previous void transaction
	Then I have the status code 422

Scenario:5 Void to non-existent payment Transaction
	Given I am authorized
	When I try to void my non-existent payment transaction:
	| CardNumber       | TransactionType |
	| 2300000000000000 | void            |
	Then I have the status code 422







