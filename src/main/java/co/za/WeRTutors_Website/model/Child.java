package co.za.WeRTutors_Website.model;

import org.springframework.data.annotation.Id;

import java.util.List;

public class Child {

    /****** Client Attributes Getters and Setters *****/
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getChildName() {
        return childName;
    }

    public void setChildName(String childName) {
        this.childName = childName;
    }

    public String getChildSurname() {
        return childSurname;
    }

    public void setChildSurname(String childSurname) {
        this.childSurname = childSurname;
    }

    public List<String>[] getSubjectsToBeTutored() {
        return subjectsToBeTutored;
    }

    public void setSubjectsToBeTutored(List<String>[] subjectsToBeTutored) {
        this.subjectsToBeTutored = subjectsToBeTutored;
    }

    public String getAvailability() {
        return availability;
    }

    public void setAvailability(String availability) {
        this.availability = availability;
    }

    public String getTutorQualities() {
        return tutorQualities;
    }

    public void setTutorQualities(String tutorQualities) {
        this.tutorQualities = tutorQualities;
    }

    public double getNumberOfSessions() {
        return numberOfSessions;
    }

    public void setNumberOfSessions(double numberOfSessions) {
        this.numberOfSessions = numberOfSessions;
    }

    /****** Child Attributes *****/
    @Id
    private String id;
    private String childName;
    private String childSurname;
    private List<String>[] subjectsToBeTutored; // List subjects needing help
    private String availability;
    private String tutorQualities;
    private  double numberOfSessions;



    /****** Constructors ******/
    public Child(String id, String childName, String childSurname, List<String>[] subjectsToBeTutored,
                 String availability, String tutorQualities, double numberOfSessions) {
        this.id = id;
        this.childName = childName;
        this.childSurname = childSurname;
        this.subjectsToBeTutored = subjectsToBeTutored;
        this.availability = availability;
        this.tutorQualities = tutorQualities;
        this.numberOfSessions = numberOfSessions;
    }

    /****** Methods ******/
    public void CreateChild()
    {

    }





}
