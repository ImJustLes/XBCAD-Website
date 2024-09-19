<style>
/* General Styles */
:root{
	--primary-colour: #26ABE3;
    --black: #000000;
    --white: #FFFFFF;
}
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
    line-height: 1.6;
	color: #333333;
	background-color: #F5F5F5;
}
a {
    text-decoration: none;
    color: white;
}

/* Header*/
header {
    background-color: #26ABE3;
	color: white;
    padding: 2rem;
    display: flex;
    justify-content: space-between;
    align-items: center;
	box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
	height: 80px;
}
.logo {
    font-size: 1.5rem;
    font-weight: bold;
    color: white;
	align-items: center;
}
header .logo {
	font-size: 28px;
	font-weight: bold;
	text-decoration: none;
	color: #FFFFFF;
	text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.3);
}
main {
  padding: 40px;
}
.container{
	max-width: 1200px;
	margin: 0 auto;
	padding: 20px;
}
/* Sections */
.section {
  background-color: #FFFFFF;
  padding: 20px;
  margin-bottom: 20px;
  border-radius: 4px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}
h1, h3 {
    margin-bottom: 1rem;
	color: #000000;
	margin-bottom: 30px;
}
h2{
	color: #26ABE3;
	margin-bottom: 1rem;
	margin-bottom: 30px;
}
ul {
  list-style-type: none;
  padding-left: 10px;
  display: inline-block;
  margin-left: value;  /* for e.g: value = 40px*/
}
.tab1 {
            tab-size: 2;
            font-size = 20px;
        }

p {
    color: #000000;
    font-size: 16px
}
ol{
    color: #000000;
    font-size: 16px
}


</style>
<header>
WeRTutors
</header>
<h1>WeRTutors Web Application</h1>


<h2>Table of Contents</h2>
<ol style="font-size: 20px">
    <li>Attributes</li>
    <li>Description</li>
    <li>Requirements</li>
    <li>Installation Instructions</li>
    <li>Instructions</li>
</ol>

<h2>Team Members</h2>
<l>
    <li>Lesedi Maela</li>
    <li>Christian Lombo</li>
    <li>Ratjatji Malatji</li>
    <li>Nqobile Sibiya</li>
    <li>Olifile Seilane</li>
    <li>Lwando Ntshinka</li>
</l>

<h2>Description</h2>
The WeRTutors platform is made as solution to manage tutoring services will be  found on web and mobile application.</br> 
It aims to streamline the data and tasks of  tutors, clients and administrators by implementing users features to aid in</br> 
efficiency and usability. The platform will be supported by an API to provide additional services to  the web and</br> 
mobile application. The app’s main functionalities will include a login system which for different user roles like students,</br> 
tutors and admins to make sure that each user can use and see the features and information based on their role.</br>


<h2>Requirements</h2>
JDK Version 21</br>
Gradle 8.8</br>
</br>
</br>

<h2>Installation Instructions</h2>
</br>
</br>
</br>

<h2>Instructions</h2>



<h2>Notes for Developers</h2>
<p>
Ensure that when you run this application, it does not have apps like OneDrive running in the background as it will not execute.<br>
The localhost is run on this port: 9000. The url for the application is on the port is: 
"localhost:9000/home". <br>
This can be changed in the file "application.properties" within the resources folder.<br>
MongoDB database called WeRTutorsDB  port is running on port 27017 by default, which is where data can be retrieved by default<br>
Run the application by connecting to MongoDB using the command "./gradlew bootRun"<br>
To test on POSTMAN, use this: <br>
</p>

<ul>
<l>Create Client:<br>
"curl -X POST http://localhost:8080/client/add \ <br>
-H "Content-Type: application/json" \<br>
-d '{"userName": "John", "userSurname": "Doe", "userEmail": "john.doe@gmail.com", "password": "12345", "userPhoneNumber": "5551234", "role": "Parent"}'"</l>
<l>
Retrieve Clients:<br>
curl -X GET http://localhost:8080/client/all
</l>


</ul>

<br>


<h2>References</h2>
