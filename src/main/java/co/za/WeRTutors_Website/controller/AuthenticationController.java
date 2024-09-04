package co.za.WeRTutors_Website.controller;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import co.za.WeRTutors_Website.WeRTutorsWebsiteApplication;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;


@SpringBootApplication
@Controller //Accept requests and return responses
@RequestMapping("/wertutors")
public class AuthenticationController {

    //Home View


    //Login View
    @GetMapping("/home")
    String login(Model model) {
        model.addAttribute("message", "Welcome");
        return "authentication/home_page";
    }



    //Register Tutor


    //Register Client


    //Create Admin


}
