package co.za.WeRTutors_Website.controller;

import co.za.WeRTutors_Website.model.ClientService;
import co.za.WeRTutors_Website.model.Client_Parent;
import co.za.WeRTutors_Website.model.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;


@Controller //Accept requests and return responses
@RequestMapping("/client")
public class ClientController {

    @Autowired
    private ClientService clientService;


    @GetMapping("/signup")
    public String signupForm(Model model) {
        model.addAttribute("client", new Client_Parent());
        return "client_signup"; // Redirect to client signup page
    }

    @PostMapping("/signup")
    public String signupClient(@ModelAttribute Client_Parent clientParent) {
        clientService.SaveClient(clientParent); // Save clientParent data
        return "redirect:/login"; // Redirect to login after successful signup
    }


}
