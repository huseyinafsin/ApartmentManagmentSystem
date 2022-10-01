```json
{
  "openapi": "3.0.1",
  "info": {
    "title": "PaymmentService",
    "version": "v1"
  },
  "paths": {
    "/api/Account/GetCustomerCards/{customerId}": {
      "get": {
        "tags": [
          "Account"
        ],
        "parameters": [
          {
            "name": "customerId",
            "in": "path",
            "required": true,
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
    "/api/Account/GetCustomerCard": {
      "post": {
        "tags": [
          "Account"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/GetCardDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/GetCardDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/GetCardDto"
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
    "/api/Account/GetCardWithDetails/{cardId}": {
      "get": {
        "tags": [
          "Account"
        ],
        "parameters": [
          {
            "name": "cardId",
            "in": "path",
            "required": true,
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
    "/api/Account/CreateCreditCard": {
      "post": {
        "tags": [
          "Account"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CreditCardDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CreditCardDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CreditCardDto"
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
    "/api/Customer": {
      "get": {
        "tags": [
          "Customer"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Customer"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomerCreateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CustomerCreateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CustomerCreateDto"
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
    "/api/Transaction/Pay": {
      "post": {
        "tags": [
          "Transaction"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/TransactionCreateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/TransactionCreateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/TransactionCreateDto"
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
    "/api/Transaction": {
      "get": {
        "tags": [
          "Transaction"
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
      "GetCardDto": {
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
          "number": {
            "type": "string",
            "nullable": true
          },
          "cvv": {
            "type": "integer",
            "format": "int32"
          },
          "month": {
            "type": "integer",
            "format": "int32"
          },
          "year": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "CreditCardDto": {
        "type": "object",
        "properties": {
          "customerId": {
            "type": "string",
            "nullable": true
          },
          "number": {
            "type": "string",
            "nullable": true
          },
          "debt": {
            "type": "number",
            "format": "double"
          },
          "limit": {
            "type": "number",
            "format": "double"
          },
          "mont": {
            "type": "integer",
            "format": "int32"
          },
          "year": {
            "type": "integer",
            "format": "int32"
          },
          "cvv": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "CustomerCreateDto": {
        "type": "object",
        "properties": {
          "firstname": {
            "type": "string",
            "nullable": true
          },
          "lastname": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "TransactionCreateDto": {
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
          "number": {
            "type": "string",
            "nullable": true
          },
          "month": {
            "type": "integer",
            "format": "int32"
          },
          "year": {
            "type": "integer",
            "format": "int32"
          },
          "cvv": {
            "type": "integer",
            "format": "int32"
          },
          "amount": {
            "type": "number",
            "format": "double"
          },
          "paymentDetails": {
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
