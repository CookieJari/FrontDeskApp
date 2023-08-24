# FrontDeskApp

This app is made for the Coding Exercise for STEALTH MONITORING.<br>
This is a C# app for the front desk at a storage facility. It takes in the mobile number and the first and last name of a customer. The app also asks for the amount of boxes to be stored or retrieved. This app uses the Memory to store the customers and boxes. <br><br>
##Storage.cs<br>
This class is where we put the boxes. This represents the storage facility that stores the boxes. We have here the Maximum number of boxes in each size category, and the number of boxes currently stored.<br><br>
##Customer.cs<br>
Very similar to Storage.cs the big difference is that this class also takes in the first name, last name, and number of the customer. This also has the number of boxes they are currently storing in each size category.<br><br>
Transaction.cs<br>
This class is the structure of each transaction we store. We have here the Customer object who is the Owner of this transaction, the number of boxes in each size category in the transaction, the Date and Time of the transaction and the transaction type whether it was Storing or Retrieving.
##Form1.cs<br>
This is where most of the work happens. This is where the GUI and the button functionality is written. We get the input from the user of the app and the details about each transaction, The customer and the number of boxes. Whenever we Store or Retrieve boxes, we just subtract or add the amount of boxes from both the Storage and Customer. We validate each transaction before they happen and alert the user if they have inputted too many boxes for storing or if there are not enough boxes to retrieve.<br>
There is a button for checking the transaction history. As of the moment this is just a message box and a formatted string. In the future this could be changed to a new form to present the data here in a table format.<br>
There is also a button to check how much space is left in each size category. This is also just a message box with formatted string to show the user how much space is left.<br><br>

##Space to improve:<br>
There are many ways to improve the app such as making the app use a database for easier and better data storage, making a separate box object to individually store and retrieve the boxes, checking the validity of phone numbers, etc.
