# AFI_Registration for Registering Policy Holders

Requirement is to build a REST API for registering policy holders based on few validations.

I have created a REST service for registering policy holders using .net Core, Entity Framework Core, Microsoft SQL as database and used Entity framework migration nuget package for migration. Added Swagger for consumers to easily integrate with their application.

Used Sequences in EF core to generate unique customerID.

## How to run
### DB Migration
Make sure you have valid SQL connection string under ConnectionStrings setting of *appsettings.json*
- In Package manager console select "AFI_Registration.Data" as default project.
- Run *Add-Migration* command
- Provede valid migration name
- Run *Update-Database* command

### Endpoint and test details
- There is swagger implementation for the API to know the Request and Response with status code in details. Available in Json and can also access after running the application.
- The local url for swagger - https://localhost:44342/swagger/index.html
There is 1 endpoints as mentioned below,
- `POST` /api/Registration
#### Request
`{
  "firstName": "John",
  "lastName": "Abraham",
  "policyReferenceNumber": "AA-123456",
  "dob": "2000-05-19T09:35:33.824Z"
}`

**Using CURL**

`curl -X POST "https://localhost:44342/api/Registration" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"firstName\":\"John\",\"lastName\":\"Abraham\",\"policyReferenceNumber\":\"AA-123456\",\"dob\":\"2000-05-19T09:35:33.824Z\"}"`
#### Response
`1002`

## Unit Test
Used `MS Unite test`, `NUnit` and `Moq` for writing unit test.

## Improvements/Extra miles
Below improvements can be implemented if I get more time,
 - I can build token based authentication.
 - If provided with more time I could write more Unit tests for more code coverage

## Cloud Technologies to Consider
We can implement Registration portal using below cloud technologies,
 - API Gateway / App for hosting service in cloud
 - Use cloud data store
