package co.za.WeRTutors_Website.model;

import org.springframework.format.annotation.DateTimeFormat;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class Session {

    private LocalDateTime startTime;
    private LocalDateTime endTime;
    private double duration;
    private boolean isOnline;


    //Default Constructor
    public Session(){}

    public void CalculateCost(){

    }

}
