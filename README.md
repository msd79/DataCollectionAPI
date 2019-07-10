## Synopsis

Data Collection API is a Dot Net Core REST API which acts as a central repository for various information, it allows custom dataset to be gathered and stored from multiple sources.
* It can be hosted on a Windows, Linux or Mac OS. 
* Uses Kestel web server which enables the API to run as self-host without needing a web server.
* Can be install as a Windows service and let windows take care of the running state of the API.
* Uses Entity Framework code first approach to interface with a SQL server and takes care of creating the database at the fist launch (if one doesn’t exist) 

## Use cases
* The API can be used to collect any type of information from client that can make REST API calls. E.g. login activity of users, when registry key is deleted, when file or folder is modified, gather troubleshooting information, various statics from an environment and so on. Information collected can be analysed using sorting and filtering capabilities of which can be built in to the API easily or at the client side using various methods.
* It can be used in conjunction with Ansible to gather information from the target environment or log results of the playbook for later viewing and analysis.
* It can be called from any scripting or programing language such as PowerShell, Python, Perl, JavaScript, Ruby, C# using GET, POST, UPDATE, DELETE, REST API methods.
* Information that is collected can later be analyse for informed decision making, optimisation of the environment, discover enhancement opportunities,  troubleshooting, planning or any other purpose that can be derived from data analysis.

## Code Example
* PowerShell GET information  <br />
`Invoke-RestMethod 'http://<URLfortheAPI>/api/logins' -Method Get `

* PowerShell POST information 
```
$date = get-date -Format s
$event = @{
    dateandTime = $date
    source = 'Application'
    keyword = 'TestKeyword'
    details = 'SetDetails'
    Level1 = 'Information or  Warning or Error'
}
$json = $event | ConvertTo-Json
$response = Invoke-RestMethod 'http://APIURL/api/event' -Method Post -Body $json -ContentType 'application/json'
```


* Python GET 
```
import requests  
url = 'http://APIURL/api/event' 
ret = requests.get(url,headers=head) 
ret.status_code 
```

* Python POST 
```
import requests <br />
url = 'http://APIURL/api/event' <br />
parameters = {'dateandTime':'2017-06-26T13:50:50', 
               'source ':'Application', 
               'keyword ':'TestKeyword',
               'details':'SetDetails',
               'Level1 ':'Information or  Warning or Error'} 
head = {'Content-Type':'application/json'} 
ret = requests.post(url,params=parameters,header=head) 
ret.status_code 
```

## Installation

* Prerequisites <br />
Installation of dot net core SDK. Can be downloaded from https://www.microsoft.com/net/download/core<br />
SQL server to host the database. This can be  lightweight version of the SQL Server, LocalDB or a standard SQL server

* Setup <br />
Update the SQL connection string in the "appsessing.json" file <br />
Set the URL (this can be the IP address or hostname of the hosting machine) and port number for the API in "hosting.json" <br />


* Build <br />
The API's default build target Windows7 and Windows 2008R2 however more platforms can be tagetted prior to build by adding appropirate platform values for "runtimes" key in "appsettings.json" <br />
Using VS Code, the build can be initiated using the command below. This will build the API for the target platform and return it's location <br />


    dotnet publish -c release -r win7-x64


The API is self hosting therefore it does not require any installation to run, it can simply be run by starting the .exe. However optionally it can also be installed as a service using the below command from a Windows system. <br />

* Install as service


    sc.exe create Service-Name binPath= "Path to the dotnet core executable"


## API Reference


The API provides interactive documentation and discoverability interface using Swagger . Visit http://swagger.io/ for further information <br />

* UI URL 


    http://APIURL/swagger

* Machine discoverable interface URL


    http://APIURL/swagger/v1/swagger.json

<a href="https://ibb.co/kvApxk"><img src="https://preview.ibb.co/cTdyq5/Swagger.png" alt="Swagger" border="0"></a><br />

## Contributors

If you wish to contribute to this project, feel free to do so. Contact Serhat Damlica at `sdamlica@csc.com `
