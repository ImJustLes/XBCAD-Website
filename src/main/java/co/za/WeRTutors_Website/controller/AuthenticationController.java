package co.za.WeRTutors_Website.controller;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import co.za.WeRTutors_Website.WeRTutorsWebsiteApplication;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller //Accept requests and return responses
public class AuthenticationController {

    //Home View
    @GetMapping("/home_page")
    String login(Model model) {
        model.addAttribute("message", "Welcome");
        return "/authentication/home_page";
    }

    //About Us
    @GetMapping("/about_us")
    public String about() {
        return "/authentication/about_us";
    }

    //Login View
    @GetMapping("/login")
    public String login() {
        return "/authentication/login_and_register";
    }



    //Register Client_Parent


    //Create Admin





}
