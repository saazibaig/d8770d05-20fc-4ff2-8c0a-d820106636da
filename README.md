# Seek Coding Excercise

This project demonstrates the Asp.Net Core api structure, for job ads checkout system. The solution has been written in C#.Net. 

.Net Core 6.0 is required to run this project.  

The solution consists of 4 projects, that are:

1) **SeekAd.API**

		Is the web api project which talks to SeekAd.BusienssServices layer to get the data from SeekAd.Data layer. It implements the IoC pattern. The api endpoints resides in DealController.cs.

2) **SeekAd.BusinessModel**

		Holds the model of different entities. Right now, it only got a Request model.

3) **SeekAd.BusinessServices**

		Is the actual business layer where the business logic is written down. This project consists of interface ‘IAdService.cs' and class ' AdService.cs' which implements interface and has the definition of functions in it.

4) **SeekAd.Data**

		Is a layer which talks to database but in this example, as there is no actual db involved, that’s why It got simple classes which hold the data.

The **SeekAd.Api** should be the startup project. There isn’t any front end built for this project, that’s why I have used **swagger** to provide input and receive output to demonstrate the working algorithms for seek jobs ads. 
Input payload example:
```
{
 	 "customerName": "secondbite",
  	"ads": [
    		"classic", "classic", "standout"
  		]
}
```
The response/cost will appear in the response body.

Conclusion:

		This project is lightly presenting the professional architecture of web api. There are lot of things ignored during development e.g., data formatting, frond end scripting and unit testing.
