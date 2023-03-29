SocialBrothersWebAPICase
Social Brothers Case Readme File
Jandre Van Peer
--------------------------------
Project title:Asp.net web Api for a Address Application
--------------------------------

-----------------------------------
How to compile:
----------------------------------
Pull the code from the Github repository
and Run the project in Visual Studio 2022.

Build status:
-----------------------------------
-no errors
-The Distance calculation controller
does not work properly I have doen a lot of 
research on the Distance calculation Api 
and tried different approaches to make
it work and i think I am very close but
if I had more time I would have made It work. 
_____________WARNING______________________
If Message Pops up while you run the program
that want to correct the address.db file click
on "NO" because it will corrupt the Sqlite 
Database file.

---------------------------------
Code Style:
---------------------------------
Used-C#,Asp.net,sql,Json file
----------------------------------
Features:
-----------------------------------
The program useses Sqlite and also has a swagger interface.
1.The user will be able to record Addresses and the Owners of theses addresses[post]
2.The user will be able to get all of the addresses in the database[Get]
3.The user will be able to get a adrress by entering the ID [get id]
4.The user will be able to Edit a record[put]
5.The User will be able to Delete a record [Delete]
6.The user will be able to sort the data Alphabetically Ascending or descending order[Get]
7.The user will be able to Search for a Owner of the address but(Not only the full name but a letter will do.)[Get]
8.The program also has some Error handeling
-------------------------------
How to use:
-------------------------------
When you run the project a Swagger interface will appear in a web browser With
4 Titles AddressCRUD, FilterAscending, FilterDescending, SearchByName(These are the parts that I am proud of
and with a little more time I would have been able to Figure the Distance calculator out but I did add the code
that was thinking of how to do it I think there is something wrong with the Api key.... )

The AddressCRUD Controller is where the user will eb able to:
1. get all of the addresses in the database[Get]
2.  record Addresses and the Owners of theses addresses[post]
3. Edit a record[put](Remember to add the ID number when editing)
4. get a adrress by entering the ID [get id]
5. Delete a record [Delete]

Then the FilterAscending Controller:
  Is where the user will be able to sort the data Alphabetically in Ascending order

Then the FilterDescending Controller:
  Is where the user will be able to sort the data Alphabetically in Descending order

And the SearchByName Controller is where:
  The user will be able to search for the owner of an address or just a Letter in the Owners name.

------------------------------
credit:
-----------------------------
Programmer-Jandré A. Van Peer
-----------------------------
