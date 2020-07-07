# eMerchantPayAssignment

# Sanity API Tests 

**This is anapplication which performs sanity checks to the a RoR (ruby on rails) Payment Gateway application.**

## The following packages are installed:
Microsoft.Extensions.Configuration.Json
nunit
NUnit3TestAdapter
Microsoft.NET.Test.Sdk
RestSharp
SpecFlow
SpecFlow.Assist.Dynamic
SpecFlow.NUnit
SpecFlow.Tools.MsBuild.Generation

The conf.json is added to store information about Endpoint, Uri, Content-Type, AuthToken and AuthTokenFalse.

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

**Scenario 5 : Void to non-existent payment Transaction ** - sends a void transaction pointing to a non-existent payment transaction
and expect 422 etc

*The scenarios Void to Void Transaction and Successfull Void Transaction are dependable from the execution of the prevoius scenarios respectively:
Void to Void Transaction => Successfull Void Transaction
Successfull Void Transaction => Successfull Sale Transaction, because once executed Transactions change their state on the fly and it is impossible to assure fixed
request reference_id for the transaction with proper state.
The other option is to combine these Scenarios.*

Two main models added: Request and TransactionResult.








