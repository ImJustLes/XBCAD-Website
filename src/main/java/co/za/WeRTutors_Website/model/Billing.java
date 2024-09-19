package co.za.WeRTutors_Website.model;

import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.stereotype.Service;

@Document
public class Billing {

    /****** Client_Parent Attributes Getters and Setters *****/




    /****** Client_Parent Attributes *****/
    String billingType;
    double amount;

    final double ONLINE_SESSION = 100;
    final double IN_PERSON_SESSION = 150;



    /****** Methods ******/
    public void GenerateInvoice(){

    }

    public void GeneratePayment(){

    }


}
