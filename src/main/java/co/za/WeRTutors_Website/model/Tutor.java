package co.za.WeRTutors_Website.model;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.stereotype.Service;

@Document
public class Tutor extends User
{
    /****** Tutor Attributes Getters and Setters *****/




    /****** Tutor Attributes *****/

    private  String location;
    private String[] subjects;
    private String[] levels; //Primary School, High School, University
    public String[] availability;
    private double payment;

    public byte[] getCvDocument() {
        return cvDocument;
    }

    public void setCvDocument(byte[] cvDocument) {
        this.cvDocument = cvDocument;
    }

    private byte[] cvDocument; // Store CV as byte array


    /****** Methods ******/
    public Tutor() {
        super();
    }



    public void UpdateAvailability(){

    }

    public void StartSession(){

    }

    public void EndSession(){

    }

    public void TrackProgress(){

    }

    public void CreateSession(){

    }

    @Override
    public boolean CreateProfile(User user) //User profile requires name, surname,
    {
        boolean created = false;





        return created;
    }

    @Override
    public boolean Login(User user) {
        boolean created = false;

        return created;
    }

    @Override
    public void Logout(User user) {



    }


}
