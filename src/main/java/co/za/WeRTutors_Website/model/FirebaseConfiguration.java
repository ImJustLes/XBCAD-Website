package co.za.WeRTutors_Website.model;

import com.google.auth.oauth2.GoogleCredentials;
import com.google.firebase.FirebaseApp;
import com.google.firebase.FirebaseOptions;
import org.springframework.context.annotation.Configuration;

import javax.annotation.PostConstruct;
import java.io.FileInputStream;

@Configuration
public class FirebaseConfiguration {
    @PostConstruct
    public void init() {

        try{
            FileInputStream serviceAccount = new FileInputStream("path/to/serviceAccountKey.json");
            FirebaseOptions options = new FirebaseOptions.Builder()
                    .setCredentials(GoogleCredentials.fromStream(serviceAccount))
                    .setDatabaseUrl("https://wertutors-v1-default-rtdb.firebaseio.com")
                    .build();
            FirebaseApp.initializeApp(options);

        }
        catch (Exception e)
        {

        }



    }





}