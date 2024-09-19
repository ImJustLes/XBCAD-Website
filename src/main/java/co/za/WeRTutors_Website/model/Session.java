package co.za.WeRTutors_Website.model;

import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

@Document
public class Session {

    /****** Client_Parent Attributes Getters and Setters *****/
    public LocalDateTime getStartTime() {
        return startTime;
    }

    public void setStartTime(LocalDateTime startTime) {
        this.startTime = startTime;
    }

    public LocalDateTime getEndTime() {
        return endTime;
    }

    public void setEndTime(LocalDateTime endTime) {
        this.endTime = endTime;
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

    /****** Client_Parent Attributes *****/
    private LocalDateTime startTime;
    private LocalDateTime endTime;
    private double duration;
    private boolean isOnline;



    //Default Constructor
    public Session(){}


    /****** Methods ******/
    public void CalculateCost(){

    }

}
