# eMerchantPayAssignment

## The tested Application  
The tested application is a simple payment gateway implementing a JSON API via the Rails 5 API mode. Usually merchants with online businesses integrate with payment gateways in order to offer electronic payments to their customers. The API allows you to trigger Sale and Void transactions and receive the transaction's status and unique identifier.

### Supported transaction types:
**Sale**
A Sale transaction allows the merchant to bill directly the customer's credit card.

**Void**
A Sale transaction can be reversed with a Void transaction and this way it will not show up on the customer's credit card statement. Real world Void transactions can be triggered only on the same day the corresponding Sale transaction took place.

## Setup of the testing environment
The API was tested on the Windows 10 Home. To host the Rest API I used Windows Subsystem for Linux Installation, which enables developers to run native Ubuntu user-mode console binaries through the Bash shell in Windows 10.

## Sanity API Tests with SpecFlow 

**This is anapplication which performs sanity checks to the a RoR (ruby on rails) Payment Gateway application.**

**SpecFlow for Visual Studio 2019 exstention installed**

**The following packages are installed:**
- Microsoft.Extensions.Configuration.Json
- nunit
- NUnit3TestAdapter
- Microsoft.NET.Test.Sdk
- RestSharp
- SpecFlow
- SpecFlow.Assist.Dynamic
- SpecFlow.NUnit
- SpecFlow.Tools.MsBuild.Generation

The conf.json is added to store information about Endpoint, Uri, Content-Type, AuthToken and AuthTokenFalse.

The Project Structure

![ProjectStructure](https://user-images.githubusercontent.com/35447819/86813373-c4ea5c00-c088-11ea-8ee7-ada684130dc0.png)

The functionality is covered of the sanity checks app with tests/specs using SpecFlow

# Feature: Transactions

## Adding test scenarios

**The following scenarios added:**

**Scenario 1: Successfull Sale Transaction** - sends a valid payment transaction request and expect an approved
response

**Scenario 2: Unauthorized Sale Transaction** - sends a valid payment transaction with an invalid authentication and expect
an appropriate response (401 etc)

**Scenario 3: Successfull Void Transaction** - sends a valid void transaction request and expect an approved response

**Scenario 4 : Void to Void Transaction** - sends a void transaction pointing to an existent void transaction and
expect 422 etc

**Scenario 5 : Void to non-existent payment Transaction** - sends a void transaction pointing to a non-existent payment transaction
and expect 422 etc

*The scenarios Void to Void Transaction and Successfull Void Transaction are dependable from the execution of the prevoius scenarios respectively:
Void to Void Transaction => Successfull Void Transaction
Successfull Void Transaction => Successfull Sale Transaction, because once executed Transactions change their state on the fly and it is impossible to assure fixed
request reference_id for the transaction with proper state.
The other option is to combine these Scenarios.*
