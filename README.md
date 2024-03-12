
# The Strongest

API for web application that allows users to add, save and modify their training results. Users can create workout plans by combining various exercises and exchange them with other users. Each user has own account to which created workout plans and results (weight, number of sets) in individual workouts are assigned. For each exercise stored in the database, there is a short description containing
information about the correct technique of performing the exercise and the muscle groups
that this exercise primarily stimulates.


## API Reference
### Auth Controller

#### Login

```http
  POST /api/auth/login
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `request` | `LoginRequestDto ` | Login data |

#### Register

```http
  POST /api/auth/register
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `request` | `RegisterRequestDto  ` | Register data |


### Exercise Info Controller


#### GetFromLocalDb
Get all data from local database:
```http
  GET /api/ExerciseInfo/GetFromLocalDb
```




Get exercise based on its id from local database:
```http
  GET /api/ExerciseInfo/GetFromLocalDb/{id}
```


| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `string ` | id of exercise |




#### GetFromApi
Get all informations about exercises from [rapidapi](https://rapidapi.com/justin-WFnsXH_t6/api/exercisedb/) database and save it to the local database:
```http
  POST /api/ExerciseInfo/GetFromApi
```


### Training Controller
Get all trainings of the logged user:
```http
  GET /api/Training/GetOwnTrainings
```


Get all public trainings:
```http
  GET /api/Training/GetAllPublic
```

Get training based on its id from database:
```http
  GET /api/Training/GetById/{id}
```


| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `Guid ` | id of training |

Create new training:
```http
  POST /api/Training/CreateTraining
```


| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `request` | `CreateTrainingRequestDto ` | data of training |

Delete training:
```http
  DELETE /api/Training/DeleteTraining/{id}
```


| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `Guid ` | id of training |

Update training:
```http
  PUT /api/Training/UpdateTraining/{id}
```


| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `Guid ` | id of training |
| `request` | `UpdateTrainingRequestDto ` | updated data of training |

## Used Technologies 

[![MS SQL](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)](https://www.microsoft.com/en-us/sql-server/)
[![C#](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)](https://visualstudio.microsoft.com)
[![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)





