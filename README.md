# CodeAvenueSolutionRepo

ReadMe by Aravind Gopinath

● How to compile and run the application in an Windows machine, including any

dependency requirements (ex: .NET Framework 4.x, Visual Studio 2013, etc...).

	● I built the project on .NET 4.5 on the VS Ultimate 2013 environment.

	● I used the ASP.NET MVC template as I have previous experience in it.As a result, I didn't have to add any additional references    to the project. Though, I'm sure I could get rid of a few of those DLL's

	● I have imported jquery 1.10.2 ("http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js") to create the FindTotal.js(used to calculate grand total in Cart)
	
	● I changed the theme using Bootsnatch and made a few changes on the CSS files according to my preference. 
	
	● I used SQLServer Express in the backend as persistent storage as I was most comfortable with it. I created a local db and manually added products with CartID as null to the dbo.Products table. The products table acts as the FK table with respect to the Cart Table. The 'Cart' table has only 1 entry as I am the only user. If this project were to be scaled for other users, there would be multiple cart entries in the Cart Table. I understand you folks don't want any db specific scripts but I have attached the .bak file for your perusal, just in case. If you do use it, ensure that you name the DB 'local'
	
	● I, then, created an ADO.NET Entity Data Model which contains the EF designer from the locally created database. The Mapping is set in place where dbo.Products is the Foreign Key Table.
		
	● I changed the theme using Bootsnatch and made a few changes on the CSS files according to my preference. 
	
	● I have an Images folder that contains the images for the products. 


● How to run the suite of automated tests (unit tests, BDD tests, etc...), including any external libraries it requires.\

	● I built the project on .NET 4.5 on the VS Ultimate 2013 environment.
	
	● I imported the CodeAvenueSolution dll and other dll's that were associated with the Code Avenue Project. Prevention is better than cure....
	
	● I created a Unit Test Project containing Unit Test Scripts for the Products Controller that contained tests for the all the ActionResult Methods. I ensure that none of the views came back as null. I also tested that the correct details were returned for their respective productID. It passed these tests for both controllers. 

	
	
