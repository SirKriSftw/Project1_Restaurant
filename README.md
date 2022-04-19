# Project1_Restaurant

## Project Description
This Restaurant REST API handles reservations, orders and dishes for customers.
  A custom makes a reservation for a certain time with an amount of guests.
  Then a reservation can have multiple orders, which is like a split bills.
  These orders can have orderedDish, which can be something like 3 slices of pizza.
  Then these dishes reference a dish table to know its name and price.
  The price for each order and reservation is automatically calculated using triggers in the backend.

## Technology Used
* .Net Framework
* ADO.net
* SQL Server
* SSMS
* Visual Studios
* C#
* GitHub

## Features
* Keeps track of customer reservations
* Automatically calculates cost of a reservation bill
* Automatically updates quantity when ordering the same dish

TODO:
* Recalculate bill when updating a dish's price
* Add a front end for the REST API
* Add a way to pay a bill
* Either move DB to the cloud or get the connection string to be accessed from one place so it is easier to udpate

## Getting Started
* git clone https://github.com/SirKriSftw/Project1_Restaurant
* I used a local DB, connection string will have to be updated using your connection string for a DB with the same tables setup (use database .bak file)
* Run on Visual Studio using IIS and swagger should appear with all the API calls 

## Usage
Once running you should see several REST API calls
![image](https://user-images.githubusercontent.com/60492952/164026523-1620bed8-cce3-48dc-a5ec-f12489ffa12f.png)
First you will want to use the adduser API call to make a user for you to use
![image](https://user-images.githubusercontent.com/60492952/164026778-1b8c7a29-5e1a-4871-b25d-d98509f62746.png)
Then you will want to populate the Dish table with several dishes using adddish API call
![image](https://user-images.githubusercontent.com/60492952/164026951-e77f315a-37cb-42bc-a1b4-c118a1a9aa6d.png)
Then make a reservation with the addres call (using get users to find your userID)
![image](https://user-images.githubusercontent.com/60492952/164027216-515128ee-d7c9-4c5f-a7e0-6445a7702ac5.png)
Then make an order for the reservation (using get reservations to find resID)
![image](https://user-images.githubusercontent.com/60492952/164027336-04e15f12-f608-4395-aea8-5795e7ef65c0.png)
Finally you will add an ordered dish (using get orders to find orderID and get dishes to get dishID)
Additionally you can add multiple ordered dishes at the same time using the addordereddishes API call
![image](https://user-images.githubusercontent.com/60492952/164027613-0fae1447-b02d-4f3b-ab3e-ea64497d3027.png)






