package co.za.WeRTutors_Website.model;

import org.springframework.data.annotation.Id;

public class Child {

    @Id
    private Long id;
    private String childName;
    private String childSurname;
    private String subjectsToBeTutored; // List subjects needing help
    private String availability;
    private String tutorQualities;


}
