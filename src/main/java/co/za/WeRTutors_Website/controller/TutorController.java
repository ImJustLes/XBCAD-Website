package co.za.WeRTutors_Website.controller;

import co.za.WeRTutors_Website.service.FirebaseService;
import co.za.WeRTutors_Website.service.TutorService;
import co.za.WeRTutors_Website.service.model.FirebaseService;
import co.za.WeRTutors_Website.model.Tutor;
import co.za.WeRTutors_Website.service.model.TutorService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.util.concurrent.ExecutionException;


@Controller //Accept requests and return responses
@RequestMapping("/tutor")
public class TutorController {

    @Autowired
    private TutorService tutorService;

    @Autowired
    FirebaseService firebaseService;

    @GetMapping("/become_a_tutor")
    public String becomeTutor() {
        return "tutor/become_a_tutor";  // Refers to templates/tutor/become_a_tutor.html
    }




    @PostMapping("/save_tutor")
    public String signupTutor(@ModelAttribute Tutor tutor, @RequestParam("cvFile") MultipartFile file) {
        try {

            tutor.setCvDocument(file.getBytes()); //set CV
            tutorService.SaveTutor(tutor);
            firebaseService.saveTutorData(tutor);

        } catch (IOException e) {
            e.printStackTrace();
            return "redirect::/home";
        }

        //Redirect to Error Page
        catch (ExecutionException | InterruptedException e) {
            throw new RuntimeException(e);
        }


        return "redirect:/login";
    }




}
