package co.za.WeRTutors_Website.model;

import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.stereotype.Service;

@Document
public class Admin extends User
{
    /****** Client_Parent Attributes Getters and Setters *****/
    public String getDepartment() {
        return department;
    }

    public void setDepartment(String department) {
        this.department = department;
    }

    public String getPosition() {
        return position;
    }

    public void setPosition(String position) {
        this.position = position;
    }

    /****** Client_Parent Attributes *****/
    private String department;
    private String position;


    /****** Constructors ******/
    //Default Constructor
    public Admin(){}

    //Login Constructor
    public Admin(String email, String password)
    {

    }

    /****** Methods ******/
    public void ManageUsers(){

    }

    public void GenerateReports(){

    }


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
}
