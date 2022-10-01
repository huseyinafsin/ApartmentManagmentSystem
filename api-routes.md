```json
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
