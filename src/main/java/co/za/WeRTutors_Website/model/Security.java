package co.za.WeRTutors_Website.model;

import org.springframework.stereotype.Service;

import java.util.Base64;

public class Security {
    @Service
    public class EncryptionService {

        private static final String SECRET_KEY = "secret-key";

        public String encryptPassword(String password) {
            try {
                // AES encryption logic here
                return Base64.getEncoder().encodeToString(password.getBytes());
            } catch (Exception e) {
                throw new RuntimeException("Error encrypting password", e);
            }
        }
    }

}
