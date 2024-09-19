package co.za.WeRTutors_Website.model;

import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ITutorRepository  extends MongoRepository<Tutor, String> {
    Tutor findByEmail(String userEmail);

}
