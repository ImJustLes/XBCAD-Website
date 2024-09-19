package co.za.WeRTutors_Website.model;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

@Document
public class Session {


    //*Copy onto Website Session Class
    /****** Session Planning Variables and Attributes ******/
    public String getSessionID() {
        return sessionID;
    }

    public void setSessionID(String sessionID) {
        this.sessionID = sessionID;
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

    public String getChildID() {
        return childID;
    }

    public void setChildID(String childID) {
        this.childID = childID;
    }

    public DateTimeFormatter getSessionDateTime() {
        return sessionDateTime;
    }

    public void setSessionDateTime(DateTimeFormatter sessionDateTime) {
        this.sessionDateTime = sessionDateTime;
    }

    public String getSessionReportType() {
        return sessionReportType;
    }

    public void setSessionReportType(String sessionReportType) {
        this.sessionReportType = sessionReportType;
    }

    public double getDuration() {
        return duration;
    }

    public void setDuration(double duration) {
        this.duration = duration;
    }

    public boolean isOnline() {
        return isOnline;
    }

    public void setOnline(boolean online) {
        isOnline = online;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getNotes() {
        return notes;
    }

    public void setNotes(String notes) {
        this.notes = notes;
    }

    public double getONLINE_RATE() {
        return ONLINE_RATE;
    }

    public double getIN_PERSON_RATE() {
        return IN_PERSON_RATE;
    }

    @Id
    private String sessionID; //Session ID
    private String tutorID; //Tutor ID
    private String clientID; //Parent ID
    private String childID; //Child ID
    private DateTimeFormatter sessionDateTime = DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm");
    //Session Date and Start Time  amend in user interface with date first and time
    private String sessionReportType; //Assessment Prep/ Normal
    private double duration; //Projected duration-> Convert Hours and Seconds to Decimal Values in getter and Setter,
    private boolean isOnline; //Online or In-person
    private String status; //Upcoming, Completed, Cancelled, Rescheduled (show for 1 day)
    private String notes; //Plan session

    //Constants
    private final double ONLINE_RATE = 100;
    private final double IN_PERSON_RATE = 150;


    /****** Session Planning Constructor ******/
    //Use when creating new session
    public Session(String sessionID, String tutorID, String clientID, String childID, DateTimeFormatter sessionDateTime,
                   String sessionReportType, double duration, boolean isOnline ,String status, String notes) {
        this.sessionID = sessionID;
        this.tutorID = tutorID;
        this.clientID = clientID;
        this.childID = childID;
        this.sessionDateTime = sessionDateTime;
        this.sessionReportType = sessionReportType;
        this.duration = duration;
        this.isOnline = isOnline;
        this.status = status;
        this.notes = notes;
    }



    /****** Session Planning Methods ******/
    //New Session
    public void ScheduleSession(Session newSession)
    {

    }

    //Start at the start of session once parent has apporved if session
    public void StartSession()
    {

        double totalDuration = 0;

    }

    public double EndSessionSummary(Session session)
    {
        //Stop and reset
        double time = 0;


        return time;
    }

    public void UpdateSession()
    {

    }

}
