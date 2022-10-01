
# Apartment Managment System
## Description
The apartment management system is a multi-layered system with a microservice architecture that allows the user in the role of a site manager to perform operations such as adding, deleting, editing, adding tenants, assigning tenants to the apartment, adding invoices, assigning invoices; and the user in the role of tenant to log in to the system and view invoices, edit profile and change password.

## Table of Contents  
[Description](#description)  
[Table of Contents](#table_of_contents)  
[Structure](#structure)  
[Ports](#structure)  
[Installation](#technologies)  
[Routes](#technologies)  
[Libraries](#libraries)  
[Technologies](#technologies)  

<a name="table_of_contents"/>
<a name="description"/>
<a name="structure"/>
<a name="ports"/>
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
  To make this project work, go to `ApartmentManagmentSystem/ApartmentManagmentSystem/appsettings.json` file and replace it with your configuration information as below
  
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
 ###

## Libraries

  Kütüphane  | Versiyon
  ---------  | -----------
   IIS | 39758,44359
   Project |5000, 5001
   Docker| 49153
   
## Technologies

  Ortam  | Port Numarası (Http,Https)
  ---------  | -----------
   IIS | 39758,44359
   Project |5000, 5001
   Docker| 49153
