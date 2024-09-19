package co.za.WeRTutors_Website.model;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

@Document
public abstract class User {
    /****** Client_Parent Attributes Getters and Setters *****/
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

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
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

    /****** Client_Parent Attributes *****/
    @Id
    protected String userID;
    protected String userName;
    protected String userSurname;
    protected String email;
    protected String password;
    protected String userPhoneNumber;
    protected String role;




    /****** Constructors ******/
    public User(){}

    //User Create Profile Constructor
    public User(String userID, String userName, String userSurname, String email, String password,
                String userPhoneNumber, String role){
        this.userID=userID;
        this.userName=userName;
        this.userSurname=userSurname;
        this.email=email;
        this.password=password;
        this.userPhoneNumber=userPhoneNumber;
        this.role=role;
    }

    //User Loin Constructor
    public User (String email, String password)
    {
        this.email=email;
        this.password=password;
    }


    /****** Methods ******/
    public abstract boolean Login(User user);

    public  abstract  void Logout(User user);

    public abstract boolean CreateProfile(User user);


}
