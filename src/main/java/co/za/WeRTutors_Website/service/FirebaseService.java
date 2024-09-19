package co.za.WeRTutors_Website.service;

import co.za.WeRTutors_Website.model.Tutor;
import com.google.cloud.firestore.Firestore;
import com.google.firebase.cloud.FirestoreClient;
import org.springframework.stereotype.Service;

import java.util.concurrent.ExecutionException;

@Service
public class FirebaseService {

    public String saveTutorData(Tutor tutor) throws ExecutionException, InterruptedException {
        Firestore firestore = FirestoreClient.getFirestore();
        firestore.collection("tutor").document(tutor.getUserID()).set(tutor).get();
        return "Tutor Applicant data saved successfully";
    }


}
