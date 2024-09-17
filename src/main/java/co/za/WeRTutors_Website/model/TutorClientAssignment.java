package co.za.WeRTutors_Website.model;

import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.stereotype.Service;

import java.util.List;

@Document
public class TutorClientAssignment {
    /****** Tutor Attributes Getters and Setters *****/
    public String getAssignmentID() {
        return assignmentID;
    }

    public void setAssignmentID(String assignmentID) {
        this.assignmentID = assignmentID;
    }

    public String getTutorID() {
        return tutorID;
    }

    public void setTutorID(String tutorID) {
        this.tutorID = tutorID;
    }

    public String getClientID() {
        return clientID;
    }

    public void setClientID(String clientID) {
        this.clientID = clientID;
    }

    /****** Child Attributes *****/
    private String assignmentID;
    private String tutorID;
    private String clientID;


    //Pair Tutor and Client_Parent (Student)
    public List<TutorClientAssignment> Pair(String clientID, String childID, String tutorID)
    {
        List<TutorClientAssignment> assignment = null; //List of assignment for client, child and tutor





        return assignment;
    }

    //ReAssign
    public TutorClientAssignment Reassign(String clientID, String childID, String newTutorID)
    {
        TutorClientAssignment newAssignment = new TutorClientAssignment();


        return newAssignment;
    }



}
