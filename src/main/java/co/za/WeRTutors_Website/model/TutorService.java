package co.za.WeRTutors_Website.model;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class TutorService {

    @Autowired
    private ITutorRepository tutorRepository;
    @Autowired
    private Security tutorEncryptionService;


    public void SaveTutor(Tutor tutor) {
        // Encrypt the password before saving
        tutor.setPassword(tutorEncryptionService.encryptPassword(tutor.getPassword()));
        tutorRepository.save(tutor);
    }

    public void LoginTutor(Tutor loginTutor)
    {
        loginTutor.setEmail(loginTutor.getEmail());
        tutorRepository.findByEmail(loginTutor.email);
    }


}
