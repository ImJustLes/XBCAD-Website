package co.za.WeRTutors_Website.model;

import org.springframework.format.annotation.DateTimeFormat;

public class Tutor extends User
{

    private String tutorID;
    private String tutorName;
    private String tutorSurname;
    private String tutorUsername;
    private String tutorPassword;

    private String location;
    private String[] subjects;
    private String[] levels;
    public DateTimeFormat[] availability;


    /*Getters and Setters*/


    /*Constructors*/
    Tutor() {
        super();
    }
    Tutor(String Username, String Password)
    {
        super.userName = Username;
        super.password = Password;

        //Instantiate Parent Class with super (Include Parameter)

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
    public boolean Login() {
        return false;
    }

    @Override
    public void Logout() {

    }
}
