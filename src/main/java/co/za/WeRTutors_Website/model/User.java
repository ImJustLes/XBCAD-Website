package co.za.WeRTutors_Website.model;

public abstract class User {
    protected int userID;
    protected String userName;
    protected String password;
    protected String role;



    //Constructor
    protected User(){}
    User(String userName, String password){
        this.userName=userName;
        this.password=password;
    }

    //Abstract Login Method
    public abstract boolean Login();

    public  abstract  void Logout();
}
