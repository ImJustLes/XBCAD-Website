package co.za.WeRTutors_Website;

import co.za.WeRTutors_Website.controller.AuthenticationController;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@SpringBootApplication
public class WeRTutorsWebsiteApplication {

	//Main Method
	public static void main(String[] args) {
		SpringApplication.run(WeRTutorsWebsiteApplication.class, args);
	}

}
