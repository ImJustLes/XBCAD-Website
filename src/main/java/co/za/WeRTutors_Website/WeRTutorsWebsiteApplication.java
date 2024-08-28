package co.za.WeRTutors_Website;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController //Accept requests and return responses
@SpringBootApplication
public class WeRTutorsWebsiteApplication {

	@GetMapping
	String home() {
		return "Hello World!";
	}

	public static void main(String[] args) {
		SpringApplication.run(WeRTutorsWebsiteApplication.class, args);
	}

}
