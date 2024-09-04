package co.za.WeRTutors_Website;

public abstract class User {
    int userID;
    String userName;
    String password;
    String role;

    //Abstract Login Method
    public abstract boolean Login();

    public  abstract  void Logout();
}
