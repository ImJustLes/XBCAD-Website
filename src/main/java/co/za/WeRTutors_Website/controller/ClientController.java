package co.za.WeRTutors_Website.controller;

import co.za.WeRTutors_Website.service.ClientService;
import co.za.WeRTutors_Website.service.ClientService;
import co.za.WeRTutors_Website.model.Client_Parent;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;


@Controller //Accept requests and return responses
@RequestMapping("/client")
public class ClientController {

    @Autowired
    private ClientService clientService;


    @GetMapping("/client_sign_up")
    public String signupForm(Model model) {
        model.addAttribute("client", new Client_Parent());
        return "client/client_sign_up"; // Redirect to client signup page
    }

    @PostMapping("/signup")
    public String signupClient(@ModelAttribute Client_Parent clientParent) {
        clientService.SaveClient(clientParent); // Save clientParent data
        return "redirect:/login"; // Redirect to login after successful signup
    }


}
