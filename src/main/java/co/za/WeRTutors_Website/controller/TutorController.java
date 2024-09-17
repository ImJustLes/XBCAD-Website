package co.za.WeRTutors_Website.controller;

import co.za.WeRTutors_Website.model.Tutor;
import co.za.WeRTutors_Website.model.TutorService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;


@Controller //Accept requests and return responses
@RequestMapping("/tutor")
public class TutorController {

    @Autowired
    private TutorService tutorService;

    @GetMapping("tutor/become_a_tutor")
    public String BecomeTutor() {
        return "tutor/become_a_tutor";  // Refers to templates/tutor/become_a_tutor.html
    }

    @PostMapping("/signup")
    public String signupTutor(@ModelAttribute Tutor tutor, @RequestParam("cvFile") MultipartFile file) {
        try {
            tutor.setCvDocument(file.getBytes()); //set CV
        } catch (IOException e) {
            e.printStackTrace();
        }
        tutorService.SaveTutor(tutor);
        return "redirect:/login";
    }




}
