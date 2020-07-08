Feature: Transactions

Scenario:1 Successfull Sale Transaction
	Given I am authorized
	When I submit my payment details:
		| Card Number       | Cvv | Expiration Date | Amount | Usage       | Card Holder  | Email             | Address             |
		| 4200000000000000 | 123 | 06/2019        | 500    | Coffeemaker | Panda Panda | panda@example.com | Panda Street, China |
	Then I have the status code 200

Scenario:2 Unauthorized Sale Transaction
	Given I am not authorized
	When I submit my payment details:
		| Card Number       | Cvv | Expiration Date | Amount | Usage       | Card Holder  | Email             | Address             |
		| 4200000000000000 | 123 | 06/2019        | 500    | Coffeemaker | Panda Panda | panda@example.com | Panda Street, China |
	Then I have the status code 401

Scenario:3 Successfull Void Transaction
	Given I am authorized
	When I try to void my previously successfull transaction
	Then I have the status code 200

Scenario:4 Void a Void Transaction
	Given I am authorized
	When I try to void my previous void transaction
	Then I have the status code 422

Scenario:5 Void a non-existent payment Transaction
	Given I am authorized
	When I try to void my non-existent payment transaction with ref id 2f256d59ce3472459704dc43040f0786
	Then I have the status code 422