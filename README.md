
# Apartment Managment System

<div align="center">

 [![Documentation](https://img.shields.io/badge/Documentation-complete-green.svg?style=flat)](https://github.com/huseyinafsin/ApartmentManagmentSystem)

 
 [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
</div>

## About
<p>
The apartment management system is a multi-layered system with a microservice architecture that allows the user in the role of a site manager to perform operations such as adding, deleting, editing, adding tenants, assigning tenants to the apartment, adding invoices, assigning invoices; and the user in the role of tenant to log in to the system and view invoices, edit profile and change password.
</p>

## Table of Contents  
[About](#about)  
[Table of Contents](#-table-of-contents)  
[Structure](#structure)  
[Ports](#ports)  
[Installation](#electric_plug-installation)  
[Endpoints](#endpoints)  
[Libraries](#-libraries)  
[Features](#-features)  

<a name="about"/>
<a name="-table-of-contents"/>
<a name="structure"/>
<a name="ports"/>
<a name="electric_plug-installation"/>
<a name="endpoints"/>
<a name="-libraries"/>
<a name="-features"/>


## Structure
<img width="1680" alt="Adsız tasarım" src="https://user-images.githubusercontent.com/42337444/183386752-f68c7734-efd1-485c-a601-77d0469cb076.png">

## Ports
  Project  | Port Number (Http,Https)
  ---------  | -----------
   Main API | 43394, 44365
   Payment micro service |60524, 44324
   UI| 52759, 44349
   
## :electric_plug: Installation


Follow the steps below to run the project in your local

  1. Clone the repo
     ```sh
     git clone https://github.com/huseyinafsin/ApartmentManagmentSystem.git
     ```
  2. Go to project folder
     ```sh
     cd ApartmentManagmentSystem
     ```
  ### Configurations
   
   To make this project work, go to `ApartmentManagmentSystem/ApartmentManagmentSystem/appsettings.json` file and replace it with your configuration information as below.
   
```json
    {
    "MongoDbSettings": {
      "ConnectionString": "<Put your mongodb instance here>",
      "Database": "TodebPay"
    },
    "RedisEndpointInfo": {
      "Endpoint": "<Put your redis endpoint informations here>",
      "Port": 16764, // 16764 is default port
      "Username": "< User name>",
      "Password": "<Password >",
      "DatabaseName": "<Database name>"
    }
```
Get free mongodb account from [Mongo Atlas ](https://www.mongodb.com/cloud/atlas/lp/try4?utm_source=google&utm_campaign=search_gs_pl_evergreen_atlas_core_prosp-brand_gic-null_emea-tr_ps-all_desktop_eng_lead&utm_term=mongodb%20atlas&utm_medium=cpc_paid_search&utm_ad=e&utm_ad_campaign_id=12212624572&adgroup=115749712023&gclid=Cj0KCQjwyt-ZBhCNARIsAKH11755BhHUAguv-dd6o3hmosGD0igKkJyXBY8HXXj-S1PJgLvMpwGHzX4aAvRJEALw_wcB)

Get free redis account from [Redis Labs ](https://redis.com/try-free/))
 
 ### Database
  Create a database named ***ApartmentHangfire*** in your local Mssql database server
  
  Migrate the database:
   Open Package manager console ```dotnet ef database update ``` or ```Update-Database```
  
  
## :earth_americas: Endpoints
 ### Api 

 | Method | URL | Description |
 | --- | --- | --- |
 | `POST` | `/api/Auth/ManagerRegister` | `Registers user` |
 | `POST` | `/api/Auth/ChangePassword` | `Changes password` |
 | `POST` | `/api/Auth/Login` | `For login` |
 | `GET` | `/api/Bill/GetAllWithDetails` | `Lists all bills with details` |
 | `GET` | `/api/Bill/GetTenantBills/{id}` | `Lists tenant bills` |
 | `GET` | `/api/Bill/{id}` | `Lists tenant bill by id` |
 | `DELETE` | `/api/Bill/{id}` | `Deletes tenant bill by id` |
 | `PUT` | `/api/Bill/{id}` | `Updates tenant bill by id` |
 | `POST` | `/api/Bill/` | `Creates new bill` |
 | `GET` | `/api/BillType` | `Lists bill types` |
 | `POST` | `/api/BillType` | `Creates new bill type` |
 | `PUT` | `/api/BillType` | `Update bill type` |
 | `GET` | `/api/Flat/GetAll` | `List all flats` |
 | `GET` | `/api/Flat/GetAllWithDetails` | `List all flats with details` |
 | `GET` | `/api/Flat/GetWithDetails/{id}` | `List flat details` |
 | `GET` | `/api/Flat/{id}` | `Fetches a flat` |
 | `DELETE` | `/api/Flat/{id}` | `Deletes a flat` |
 | `PUT` | `/api/Flat/{id}` | `Updates a flat` |
 | `POST` | `/api/Flat/` | `Creates a new flat` |
 | `GET` | `/api/FlatType` | `Lists flat types` |
 | `POST` | `/api/FlatType` | `Creates new flat type` |
 | `PUT` | `/api/FlatType` | `Update flat type` |
 | `GET` | `/api/Messages/{id}` | `Fetches a message` |
 | `POST` | `/api/Messages/GetUserMessagesBetween` | `Lists all messages between two users` |
 | `POST` | `/api/Messages` | `Creates a new message` |
 | `POST` | `/api/Payment` | `Makes a payment request` |
 | `GET` | `/api/Tenant` | `List all the tenats` |
 | `POST` | `/api/Tenant` | `Creates a new tenart` |
 | `GET` | `/api/Tenant` | `Fetches a tenant` |
 | `DELETE` | `/api/Tenant` | `Deletes a tenant` |
 | `PUT` | `/api/Tenant` | `Updates a tenant` |
 | `GET` | `/api/Users` | `List all the users` |
 
 ### Payment service

 | Method | URL | Description |
 | --- | --- | --- |
 | `GET` | `/api/Account/GetCustomerCards/{customerId}` | `Lists cards for a specific customer` |
 | `POST` | `/api/Account/GetCustomerCard` | `Returns detailed information about posted card informations` |
 | `GET` | `/api/Account/GetCardWithDetails/{cardId}` | `Returns detailed informations of card id` |
 | `POST` | `/api/Account/CreateCreditCard` | `Adds new Credit card` |
 | `GET` | `/api/Customer` | `Lists all customers` |
 | `POST` | `/api/Customer` | `Creates new customer` |
 | `POST` | `/api/Transaction/Pay` | `Pays the given bill` |
 | `GET` | `/api/Transaction` | `List all the transactions` |


  To see the in go to [Swagger Editor](https://editor.swagger.io/) and import the swagger files.
 -  [API Swagger File](/api-routes.md)
 -  [Payment Service Swagger File](/payment-routes.md)

## 📚 Libraries

  Library  | Versiyon
  ---------  | -----------
   Automapper | 11.0.1  
   Hangfire | 11.0.0
   JwtBearer | 5.0.17
   EntityFrameworkCore | 5.0.17
   StackExcangeRedis | 6.0.7
   Redis | 2.6.48
   Swashbuckle | 5.6.3
   Automapper | 11.0.1
   Mirosoft.IdentityModel.Tokens | 6.21.0
   MongoDb.Bson | 2.17.1
   MongoDb.Driver | 2.17.0
   Bogus | 34.0.2
   Autofac | 2.17.0
   MongoDb.Driver | 2.17.0
   Serilog | 2.11.0
   FluentValidation | 11.2.2
   Coverlet.Collector | 3.0.2
   Moq | 4.18.2
   xunit | 2.4.1



   
## 🚀 Features

-  N-Layered Architecture
-  Generic Repository Pattern
-  Dependency Injection
-  IOC
-  Caching
-  Logging
-  Microservice
-  Rest
-  Backgound Jobs
-  Unit Testing
-  UI
