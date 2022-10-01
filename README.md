
# Apartment Managment System
## Description
The apartment management system is a multi-layered system with a microservice architecture that allows the user in the role of a site manager to perform operations such as adding, deleting, editing, adding tenants, assigning tenants to the apartment, adding invoices, assigning invoices; and the user in the role of tenant to log in to the system and view invoices, edit profile and change password.

## Table of Contents  
[Description](#description)  
[Table of Contents](#table_of_contents)  
[Structure](#structure)  
[Ports](#ports)  
[Installation](#installation)  
[Routes](#routes)  
[Libraries](#libraries)  
[Technologies](#technologies)  

<a name="description"/>
<a name="table_of_contents"/>
<a name="structure"/>
<a name="ports"/>
<a name="installation"/>
<a name="routes"/>
<a name="libraries"/>
<a name="technologies"/>


## Structure
<img width="1680" alt="Adsız tasarım" src="https://user-images.githubusercontent.com/42337444/183386752-f68c7734-efd1-485c-a601-77d0469cb076.png">

## Ports
  Project  | Port Number (Http,Https)
  ---------  | -----------
   Main API | 43394, 44365
   Payment micro service |60524, 44324
   UI| 52759, 44349
   
## Installation
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
  
  
## Routes
  To see the in go to [Swagger Editor](https://editor.swagger.io/) and import the [Swagger file](/routes.md)
## Libraries

  Library  | Versiyon
  ---------  | -----------
   IIS | 39758,44359
   Project |5000, 5001
   Docker| 49153
   
## Technologies

- George Washington
- John Adams
- Thomas Jefferson
