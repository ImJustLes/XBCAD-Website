package co.za.WeRTutors_Website.model;

import org.springframework.data.annotation.Id;

public abstract class User {
    /****** Client Attributes Getters and Setters *****/
    public String getUserID() {
        return userID;
    }

    public void setUserID(String userID) {
        this.userID = userID;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getUserSurname() {
        return userSurname;
    }

    public void setUserSurname(String userSurname) {
        this.userSurname = userSurname;
    }

    public String getUserEmail() {
        return userEmail;
    }

    public void setUserEmail(String userEmail) {
        this.userEmail = userEmail;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getUserPhoneNumber() {
        return userPhoneNumber;
    }

    public void setUserPhoneNumber(String userPhoneNumber) {
        this.userPhoneNumber = userPhoneNumber;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    /****** Client Attributes *****/
    @Id
    protected String userID;
    protected String userName;
    protected String userSurname;
    protected String userEmail;
    protected String password;
    protected String userPhoneNumber;
    protected String role;




    /****** Constructors ******/
    public User(){}

    //User Create Profile Constructor
    public User(String userID, String userName, String userSurname, String userEmail, String password,
                String userPhoneNumber, String role){
        this.userID=userID;
        this.userName=userName;
        this.userSurname=userSurname;
        this.userEmail=userEmail;
        this.password=password;
        this.userPhoneNumber=userPhoneNumber;
        this.role=role;
    }

    //User Loin Constructor
    public User (String userEmail, String password)
    {
        this.userEmail=userEmail;
        this.password=password;
    }


    /****** Methods ******/
    public abstract boolean Login(User user);

    public  abstract  void Logout(User user);

    public abstract boolean CreateProfile(User user);


}
