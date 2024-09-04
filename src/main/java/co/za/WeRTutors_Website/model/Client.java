package co.za.WeRTutors_Website.model;


import org.springframework.data.annotation.Id;

import java.util.List;

public class Client extends User {

    /****** Client Attributes Getters and Setters *****/
    public List<Child> getChildren() {
        return children;
    }

    public void setChildren(List<Child> children) {
        this.children = children;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }

    public double getPayment() {
        return payment;
    }

    public void setPayment(double payment) {
        this.payment = payment;
    }

    /****** Client Attributes *****/
    @Id
    private  String location;
    private List<Child> children;
    private double payment;


    /****** Constructors ******/
    //Default Constructor
    public Client(){}

    //Constructor to create Profile
    public Client(User user, List<Child> children) {
        super();
        this.children = children;
    }

    //Constructor to Login
    public Client (String email, String password)
    {
        this.userEmail = email;
        this.password = password;
    }


    /****** Methods ******/
    //Overrided Methods
    @Override
    public boolean Login(User user) {
        return false;
    }

    @Override
    public void Logout(User user) {

    }

    @Override
    public boolean CreateProfile(User user){
        boolean created = false;

        return created;

    }
    public void Student(){

    }

    public void AddProgress(){

    }

    public void ViewProgress() {

    }

    public void ViewChildProgress(){

    }

    public void RecommendTutors(){

    }

}
