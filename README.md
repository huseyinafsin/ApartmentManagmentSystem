
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
  ```
  {
  "openapi": "3.0.1",
  "info": {
    "title": "ApartmentManagmentSystem",
    "version": "v1"
  },
  "paths": {
    "/api/Auth/ManagerRegister": {
      "post": {
        "tags": [
          "Auth"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ManagerForRegister"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ManagerForRegister"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ManagerForRegister"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Auth/ChangePassword": {
      "post": {
        "tags": [
          "Auth"
        ],
        "parameters": [
          {
            "name": "password",
            "in": "query",
            "schema": {
              "type": "string",
              "nullable": true
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Auth/Login": {
      "post": {
        "tags": [
          "Auth"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/UserForLogin"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/UserForLogin"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/UserForLogin"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Bill/GetAllWithDetails": {
      "get": {
        "tags": [
          "Bill"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Bill/GetTenantBills/{id}": {
      "get": {
        "tags": [
          "Bill"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Bill/{id}": {
      "get": {
        "tags": [
          "Bill"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Bill"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Bill"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Bill"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Bill"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Bill"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Bill": {
      "post": {
        "tags": [
          "Bill"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/BillCreateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/BillCreateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/BillCreateDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/BillType": {
      "get": {
        "tags": [
          "BillType"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "BillType"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/BillType"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/BillType"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/BillType"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "BillType"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/BillType"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/BillType"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/BillType"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Flat/GetAll": {
      "get": {
        "tags": [
          "Flat"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Flat/GetAllWithDetails": {
      "get": {
        "tags": [
          "Flat"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Flat/GetWithDetails/{id}": {
      "get": {
        "tags": [
          "Flat"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Flat/{id}": {
      "get": {
        "tags": [
          "Flat"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Flat"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Flat"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/FlatModelDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/FlatModelDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/FlatModelDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Flat": {
      "post": {
        "tags": [
          "Flat"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/FlatCreateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/FlatCreateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/FlatCreateDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/FlatType": {
      "get": {
        "tags": [
          "FlatType"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "FlatType"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/FlatType"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/FlatType"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/FlatType"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "FlatType"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/FlatType"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/FlatType"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/FlatType"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Messages/{id}": {
      "get": {
        "tags": [
          "Messages"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Messages/GetUserMessagesBetween": {
      "post": {
        "tags": [
          "Messages"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/GetUserMessagesBetween"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/GetUserMessagesBetween"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/GetUserMessagesBetween"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Messages/Create": {
      "post": {
        "tags": [
          "Messages"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/MessageCreateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/MessageCreateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/MessageCreateDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Messages": {
      "post": {
        "tags": [
          "Messages"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/MessageCreateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/MessageCreateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/MessageCreateDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Payment": {
      "post": {
        "tags": [
          "Payment"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/PaymentCreateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/PaymentCreateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/PaymentCreateDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Tenant": {
      "get": {
        "tags": [
          "Tenant"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Tenant"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/TenantForRegister"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/TenantForRegister"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/TenantForRegister"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Tenant/{id}": {
      "get": {
        "tags": [
          "Tenant"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Tenant"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Tenant"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/TenantModelDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/TenantModelDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/TenantModelDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Users": {
      "get": {
        "tags": [
          "Users"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "ManagerForRegister": {
        "type": "object",
        "properties": {
          "firstname": {
            "type": "string",
            "nullable": true
          },
          "lastname": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "username": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "UserForLogin": {
        "type": "object",
        "properties": {
          "email": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Password": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "createdAt": {
            "type": "string",
            "format": "date-time"
          },
          "status": {
            "type": "boolean"
          },
          "passwordSalt": {
            "type": "string",
            "format": "byte",
            "nullable": true
          },
          "passwordHash": {
            "type": "string",
            "format": "byte",
            "nullable": true
          },
          "initialPassword": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "User": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "createdAt": {
            "type": "string",
            "format": "date-time"
          },
          "status": {
            "type": "boolean"
          },
          "passwordId": {
            "type": "integer",
            "format": "int32"
          },
          "firstname": {
            "type": "string",
            "nullable": true
          },
          "lastname": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "cardIdList": {
            "type": "string",
            "nullable": true
          },
          "active": {
            "type": "boolean"
          },
          "pasword": {
            "$ref": "#/components/schemas/Password"
          }
        },
        "additionalProperties": false
      },
      "FlatType": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "createdAt": {
            "type": "string",
            "format": "date-time"
          },
          "status": {
            "type": "boolean"
          },
          "type": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Flat": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "createdAt": {
            "type": "string",
            "format": "date-time"
          },
          "status": {
            "type": "boolean"
          },
          "flatTypeId": {
            "type": "integer",
            "format": "int32"
          },
          "monthlyPrice": {
            "type": "number",
            "format": "double"
          },
          "block": {
            "type": "string",
            "nullable": true
          },
          "floor": {
            "type": "integer",
            "format": "int32"
          },
          "number": {
            "type": "integer",
            "format": "int32"
          },
          "isInUse": {
            "type": "boolean"
          },
          "flatType": {
            "$ref": "#/components/schemas/FlatType"
          }
        },
        "additionalProperties": false
      },
      "Tenant": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "createdAt": {
            "type": "string",
            "format": "date-time"
          },
          "status": {
            "type": "boolean"
          },
          "userId": {
            "type": "integer",
            "format": "int32"
          },
          "flatId": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "identityNumber": {
            "type": "string",
            "nullable": true
          },
          "phone": {
            "type": "string",
            "nullable": true
          },
          "hasACar": {
            "type": "boolean"
          },
          "plate": {
            "type": "string",
            "nullable": true
          },
          "user": {
            "$ref": "#/components/schemas/User"
          },
          "flat": {
            "$ref": "#/components/schemas/Flat"
          },
          "bills": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Bill"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "BillType": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "createdAt": {
            "type": "string",
            "format": "date-time"
          },
          "status": {
            "type": "boolean"
          },
          "name": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Bill": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "createdAt": {
            "type": "string",
            "format": "date-time"
          },
          "status": {
            "type": "boolean"
          },
          "tenantId": {
            "type": "integer",
            "format": "int32"
          },
          "billTypeId": {
            "type": "integer",
            "format": "int32"
          },
          "amount": {
            "type": "number",
            "format": "double"
          },
          "paid": {
            "type": "boolean"
          },
          "tenant": {
            "$ref": "#/components/schemas/Tenant"
          },
          "billType": {
            "$ref": "#/components/schemas/BillType"
          }
        },
        "additionalProperties": false
      },
      "BillCreateDto": {
        "type": "object",
        "properties": {
          "tenantId": {
            "type": "integer",
            "format": "int32"
          },
          "billTypeId": {
            "type": "integer",
            "format": "int32"
          },
          "amount": {
            "type": "number",
            "format": "double"
          }
        },
        "additionalProperties": false
      },
      "FlatModelDto": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "monthlyPrice": {
            "type": "number",
            "format": "double"
          },
          "block": {
            "type": "string",
            "nullable": true
          },
          "floor": {
            "type": "integer",
            "format": "int32"
          },
          "number": {
            "type": "integer",
            "format": "int32"
          },
          "isInUse": {
            "type": "boolean"
          },
          "tenantFirstname": {
            "type": "string",
            "nullable": true
          },
          "tenantLastname": {
            "type": "string",
            "nullable": true
          },
          "flatType": {
            "$ref": "#/components/schemas/FlatType"
          }
        },
        "additionalProperties": false
      },
      "FlatCreateDto": {
        "type": "object",
        "properties": {
          "flatTypeId": {
            "type": "integer",
            "format": "int32"
          },
          "monthlyPrice": {
            "type": "number",
            "format": "double"
          },
          "block": {
            "type": "string",
            "nullable": true
          },
          "floor": {
            "type": "integer",
            "format": "int32"
          },
          "number": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "GetUserMessagesBetween": {
        "type": "object",
        "properties": {
          "fromUserId": {
            "type": "integer",
            "format": "int32"
          },
          "toUserId": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "MessageCreateDto": {
        "type": "object",
        "properties": {
          "fromUserId": {
            "type": "integer",
            "format": "int32"
          },
          "toUserId": {
            "type": "integer",
            "format": "int32"
          },
          "messageText": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "PaymentCreateDto": {
        "type": "object",
        "properties": {
          "billId": {
            "type": "integer",
            "format": "int32"
          },
          "creditCardId": {
            "type": "integer",
            "format": "int32"
          },
          "amount": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "TenantForRegister": {
        "type": "object",
        "properties": {
          "flatId": {
            "type": "integer",
            "format": "int32"
          },
          "firstname": {
            "type": "string",
            "nullable": true
          },
          "lastname": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "username": {
            "type": "string",
            "nullable": true
          },
          "identityNumber": {
            "type": "string",
            "nullable": true
          },
          "phone": {
            "type": "string",
            "nullable": true
          },
          "hasACar": {
            "type": "boolean"
          },
          "plate": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "TenantModelDto": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "userId": {
            "type": "integer",
            "format": "int32"
          },
          "flatId": {
            "type": "integer",
            "format": "int32"
          },
          "firstname": {
            "type": "string",
            "nullable": true
          },
          "lastname": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "initialPassword": {
            "type": "string",
            "nullable": true
          },
          "identityNumber": {
            "type": "string",
            "nullable": true
          },
          "phone": {
            "type": "string",
            "nullable": true
          },
          "hasACar": {
            "type": "boolean"
          },
          "plate": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    }
  }
}
```
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
