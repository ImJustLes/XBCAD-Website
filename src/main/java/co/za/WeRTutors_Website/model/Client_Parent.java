package co.za.WeRTutors_Website.model;
import org.springframework.data.mongodb.core.mapping.Document;

import java.util.List;

@Document
public class Client_Parent extends User {

    /****** Client_Parent Attributes Getters and Setters *****/
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

    /****** Client_Parent Attributes *****/

    private String location;
    private List<Child> children;
    private double payment;


    /****** Constructors ******/
    //Default Constructor
    public Client_Parent(){}

    //Constructor to create Profile
    public Client_Parent(User user, List<Child> children) {
        super();
        this.children = children;
    }

    //Constructor to Login
    public Client_Parent(String email, String password)
    {
        this.email = email;
        this.password = password;
    }


    /****** Methods ******/
    //Overrided Methods
    @Override
    public boolean Login(User user) {
        boolean loggedin = false;
        Client_Parent loginClientParent = new Client_Parent(user, children);

        return loggedin;
    }

    @Override
    public void Logout(User user) {

    }

    @Override
    public boolean CreateProfile(User user){
        boolean created = false;

        Client_Parent newClientParent = new Client_Parent(user, children);

        return created;
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
