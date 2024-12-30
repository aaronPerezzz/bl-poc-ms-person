# bl-poc-md-persons

# Descripción

API encargada de administrar información de una persona.

# Endpoints

## Crear persona

- POST - /api/persons

## Request

```json
{
  "name": "Aaron",
  "lastName": "Pérez",
  "email": "aaron@gmail.com",
  "phone": "224597300",
  "birthDay": "1993-03-11",
  "maritalStatus": "Soltero"
}
```

## Response

```json
{
  "name": "Aaron",
  "lastName": "Pérez",
  "email": "aaron@gmail.com",
  "phone": "224597300",
  "birthDay": "1993-03-11",
  "maritalStatus": "Soltero"
}
```

## Buscar persona por id

- Get - /api/persons/{id}

## Response

```json
{
  "name": "Aaron",
  "lastName": "Pérez",
  "email": "aaron@gmail.com",
  "phone": "224597300",
  "birthDay": "1993-03-11",
  "maritalStatus": "Soltero"
}
```

## Obtener todas las personas

- GET - /api/persons

## Response

```json
[
  {
    "name": "Aaron",
    "lastName": "Pérez",
    "email": "aaron@gmail.com",
    "phone": "224597300",
    "birthDay": "1993-03-11",
    "maritalStatus": "Soltero"
  }
]
```

## Actualizar información de una persona

- PUT - /api/persons/{id}
## Response

```json
{
  "name": "Aaron",
  "lastName": "Pérez",
  "email": "aaron@gmail.com",
  "phone": "224597300",
  "birthDay": "1993-03-11",
  "maritalStatus": "Soltero"
}
```

## Eliminar registro
- DELETE - /api/persons/{id}

## Prerequsitos

- Visual Studio 2022
- .NET 8 SDK
- Docker

## Instalación

Descargar codigo fuente en Git
```bash
  git clone https://github.com/aaronPerezzz/bl-poc-ms-person
```

## Despligue

Ejecutar el siguiente comando
```bash
 docker-compose -f docker-compose.yaml up
```
  
  
