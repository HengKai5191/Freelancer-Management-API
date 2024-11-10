# FreeLancer-Management-API

FreeLancer-Management-API is a C# WebAPI application that consume GET, POST and DELETE.

## Installation

While setup using ngrok.exe is possible, it requires keeping the PC running continuously. Due to this limitation, this setup method was not implemented.

Alternative way.
Setup SQL Database
1. Run database_script.sql to create table and insert data.
2. Clone this current repository.
3. Change data string connnection based on your local pc. 



## Usage
[Consume by FreeLancer Web App]
```
# Insert New FreeLancer
var response = await _httpClient.PostAsJsonAsync($"InsertFreeLancer", model);

# Get FreeLancer By ID
var freelancer = await _httpClient.GetFromJsonAsync<MC_FreeLancer>($"GetFreeLancer/{id}");

# Update FreeLanver with Model
var response = await _httpClient.PutAsJsonAsync($"UpdateFreeLancer/{model.FL_Id}", model);

```
### Authentication
[No authentication needed for now]

## License
N/A
