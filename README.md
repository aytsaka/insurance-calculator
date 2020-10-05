## Introduction
It is an implementation of a .NET Core Web Api application to calculate insurance values for given products via consuming data from an other REST Api.
This application provide two REST Api endpoints to gather insurance values via endpoint `api/insurance/product` and upload surcharge informations via endpoint `api/insurance/surchargerate`.

## Prerequisites
- docker
- docker-compose
- .NET Core SDK 3.1

## How to run
Navigate to Mysql folder location in command prompt and run command `docker-compose up`
Navigate to Product.Api folder location in command prompt and run command `dotnet ProductData.Api.dll`
Navigate to Insurance.Api folder location in command prompt and run command `dotnet run`

## Technologies
- AspNet Core 3.1
- EF Core
- MySql
- Docker
- XUnit
- FluentAssertions
- Newtonsoft.Json

## Approach

# Refactoring
- Project structure has been modified according to separation of concerns design principles.
- To make implementations more understandable, flexible and maintaninable SOLID principles and TDD applied.
- KISS and YAGNI principles are adopted for redundancy and when an open point discovered.

# Feature1
- To be able to calculate an insurance value only required field is `ProductId`, so order request contains only a collection of `Productid`.
 Existing insurance calculation functionality is still supported which accepts `InsuranceDto`.
 
# Feature2
- It is assumed that the product type name will not be changed.

# Feature3
- It is assumed that only `ProductTypeId` will be provided while uploading a surcharge rate as a product type information.

## High level design
- Insurance.Api - Provides two endpoints to calculate insurance values per product or per order and upload surcharge informations.
- Insurance.Domain - Keeps calculation/upload business logic.
- Insurance.Client - It is a data consumer which makes connection with third party REST Api endpoints and gather data.
- Insurance.Data - Provides data access to MySql database with EF Core.
