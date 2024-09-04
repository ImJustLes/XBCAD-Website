package co.za.WeRTutors_Website.model;


import org.springframework.data.annotation.Id;

import java.util.List;

public class Client {

    @Id
    private String parentName;
    private String parentSurname;
    private String parentEmail;
    private String phoneNumber;
    private String encryptedPassword; // Store encrypted password

    private List<Child> children;

    public String[] subjects;


    //Default Constructor
    public Client(){}


    public void Parent(){

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
